using App.Application.Abstractions;
using App.Application.UseCases.RoleCase.Commands;
using App.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.RoleCase.Handlers.CommandHandler
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ResponseModel>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateRoleCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseModel> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _appDbContext.Roles.AddAsync(new Roles() { Id = Guid.NewGuid(), Name = request.Name }, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel() { IsSuccess = true, Message = "Role created successfully", StatusCode = 201 };
        }
    }
}
