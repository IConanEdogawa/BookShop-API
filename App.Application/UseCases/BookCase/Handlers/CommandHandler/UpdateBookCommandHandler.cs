using App.Application.Abstractions;
using App.Application.UseCases.BookCase.Commands;
using App.Domain.Entities.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Handlers.CommandHandler
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ResponseModel>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateBookCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _appDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (book == null)
            {
                return new ResponseModel { IsSuccess = false, Message = "Book not found", StatusCode = 404 };
            }

            book.Title = string.IsNullOrEmpty(request.Title) ? book.Title : request.Title!;
            book.Price = string.IsNullOrEmpty(request.Price) ? book.Price : request.Price!;
            book.OriginalTitle = string.IsNullOrEmpty(request.OriginalTitle) ? request.Title! : request.OriginalTitle!;
            book.AlternativeTitle = string.IsNullOrEmpty(request.AlternativeTitle) ? book.AlternativeTitle : request.AlternativeTitle!;
            book.Author = string.IsNullOrEmpty(request.Author) ? book.Author : request.Author!;
            book.Description = string.IsNullOrEmpty(request.Description) ? book.Description : request.Description!;
            book.Publisher = string.IsNullOrEmpty(request.Publisher) ? book.Publisher : request.Publisher!;
            book.Translator = string.IsNullOrEmpty(request.Translator) ? book.Translator : request.Translator!;
            book.Country = string.IsNullOrEmpty(request.Country) ? book.Country : request.Country!;
            book.Status = string.IsNullOrEmpty(request.Status) ? book.Status : request.Status!;
            book.Tags = request.Tags.Count == 0 ? book.Tags : request.Tags;
            book.Categories = request.Categories.Count == 0 ? book.Categories : request.Categories;

            _appDbContext.Books.Update(book);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return new ResponseModel { IsSuccess = true, Message = $" The book {book.Title} was updated successfully", StatusCode = 200 };
        }

    }
}
