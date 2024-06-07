using App.Application.Abstractions;
using App.Application.UseCases.RoleCase.Queries;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.RoleCase.Handlers.QieryHandler
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<Roles>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllRolesQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Roles>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Roles.ToListAsync();

            return result;
        }
    }
}
