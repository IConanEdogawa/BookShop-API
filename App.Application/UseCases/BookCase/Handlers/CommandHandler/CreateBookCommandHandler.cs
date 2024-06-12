using App.Application.Abstractions;
using App.Application.UseCases.BookCase.Commands;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Handlers.CommandHandler
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ResponseModel>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateBookCommandHandler(IWebHostEnvironment webHostEnvironment, IAppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            if (request.Poster != null)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{request.Poster.FileName}";
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "posters");

                // Создание папки, если ее не существует
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Сохранение файла
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Poster.CopyToAsync(fileStream);
                }

                // Установка пути к файлу
                var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                var photoUrl = $"{baseUrl}/posters/{uniqueFileName}";
                var book = new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    OriginalTitle = request.Title,
                    Author = request.Author,
                    Description = request.Description,
                    CreatedDate = DateTime.UtcNow,
                    PosterUrl = photoUrl,
                    Price = request.Price,
            };

                await _appDbContext.Books.AddAsync(book);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new ResponseModel { StatusCode = 201, Message = "Book created successfully", IsSuccess = true };
            }

           return new ResponseModel { StatusCode = 400, Message = "Failed to create book", IsSuccess = false };


            
        }
    }
}
