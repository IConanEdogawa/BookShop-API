using App.Application.Abstractions;
using App.Application.UseCases.UserCase.Queries;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.UserCase.Handlers
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<Comments>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllCommentsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Comments>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users
                .Include(u => u.Comments)
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (user == null)
            {
                return Enumerable.Empty<Comments>();
            }

            return user.Comments;
        }
    }
}
