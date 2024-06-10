using App.Application.Abstractions;
using App.Application.UseCases.BookCase.Commands;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
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
        public CreateBookCommandHandler(IWebHostEnvironment webHostEnvironment, IAppDbContext appDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appDbContext;
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
                var photoPath = $"/posters/{uniqueFileName}";
                var book = new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    OriginalTitle = request.Title,
                    Author = request.Author,
                    Description = request.Description,
                    CreatedDate = DateTime.UtcNow,
                    PosterUrl = $"localhost:4200{photoPath}"
            };

                await _appDbContext.Books.AddAsync(book);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new ResponseModel { StatusCode = 201, Message = "Book created successfully", IsSuccess = true };
            }

           return new ResponseModel { StatusCode = 400, Message = "Failed to create book", IsSuccess = false };


            
        }
    }
}
