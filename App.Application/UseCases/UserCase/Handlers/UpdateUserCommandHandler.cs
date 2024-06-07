using App.Application.Abstractions;
using App.Application.UseCases.UserCase.Commands;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.UseCases.UserCase.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseModel>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAppDbContext _appDbContext;

        public UpdateUserCommandHandler(IWebHostEnvironment webHostEnvironment, IAppDbContext appDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(user == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "User not found !"
                };
            }

            if (request.Photo != null)
            {
                // Генерация уникального имени файла
                var uniqueFileName = $"{Guid.NewGuid()}_{request.Photo.FileName}";
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                // Создание папки, если ее не существует
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Сохранение файла
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Photo.CopyToAsync(fileStream);
                }

                // Установка пути к файлу
                var photoPath = $"/uploads/{uniqueFileName}";

                if (user != null)
                {
                    user.FullName = request.FullName;
                    user.PhotoPath = photoPath;
                    user.Bio = request.Bio;
                    user.Email = request.Email;

                    _appDbContext.Users.Update(user);
                    await _appDbContext.SaveChangesAsync(cancellationToken);

                    return new ResponseModel { IsSuccess = true, Message = "User updated successfully", StatusCode = 201 };
                }
                else
                {
                    return new ResponseModel { IsSuccess = false, Message = "User not found", StatusCode = 201 };
                }
            }
            else
            {
                return new ResponseModel { IsSuccess = false, Message = "Photo is required", StatusCode = 201 };
            }
        }
    }
}
