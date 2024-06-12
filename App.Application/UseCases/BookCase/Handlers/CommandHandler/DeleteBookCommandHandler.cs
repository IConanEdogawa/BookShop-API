using App.Application.Abstractions;
using App.Application.UseCases.BookCase.Commands;
using App.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Handlers.CommandHandler
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ResponseModel>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteBookCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.Id == request.Id);

            if (book == null)
            {
                return new ResponseModel { StatusCode = 404, Message = "Book not found", IsSuccess = true };
            }

            _appDbContext.Books.Remove(book);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel { StatusCode = 200, Message = "Book deleted successfully", IsSuccess = true }; 
 
        }
    }
}
