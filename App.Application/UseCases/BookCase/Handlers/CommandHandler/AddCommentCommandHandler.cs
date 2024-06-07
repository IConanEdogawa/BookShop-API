using App.Application.Abstractions;
using App.Application.UseCases.BookCase.Commands;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Handlers.CommandHandler
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, ResponseModel>
    {
        private readonly IAppDbContext _appDbContext;

        public AddCommentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseModel> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var bookComment = new BookComment
            {
                Id = Guid.NewGuid(),
                BookId = request.BookId,
                UserId = request.UserId,
                CommentText = request.Message,
                CreatedDate = DateTime.UtcNow
            };

            var userComment = new UserCommentModel
            {
                Id = Guid.NewGuid(),
                BookId = request.BookId,
                UserId = request.UserId,
                Message = request.Message,
                CreatedDate = DateTime.UtcNow,
            };

            // Загрузка связанных сущностей Users и Books
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            var book = await _appDbContext.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

            if (user != null)
            {
                user.Comments.Add(userComment);
                _appDbContext.Users.Update(user);
            }

            if (book != null)
            {
                book.Comments.Add(bookComment);
                _appDbContext.Books.Update(book);
            }

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                StatusCode = 200,
                Message = $"Comment added successfully to {book?.Title} by {user?.FullName}!",
                IsSuccess = true
            };
        }

    }
}
