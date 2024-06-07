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
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<UserCommentModel>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllCommentsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<UserCommentModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

            if(user == null)
            {
                return Enumerable.Empty<UserCommentModel>();
            }

            var comments = user.Comments;

            return comments!;
        }
    }
}
