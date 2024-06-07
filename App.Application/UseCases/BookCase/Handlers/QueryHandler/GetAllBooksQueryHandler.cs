using App.Application.Abstractions;
using App.Application.UseCases.BookCase.Queries;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Handlers.QueryHandler
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllBooksQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var result =  await _appDbContext.Books.ToListAsync();

            return result;
        }
    }
}
