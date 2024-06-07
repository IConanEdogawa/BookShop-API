using App.Application.Abstractions;
using App.Application.UseCases.UserCase.Queries;
using App.Domain.Entities.DTOs;
using App.Domain.Entities.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.UserCase.Handlers
{
    public class GetAllTgUsersQueryHandler : IRequestHandler<GetAllTgUsersQuery, List<ViewDto>>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetAllTgUsersQueryHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<ViewDto>> Handle(GetAllTgUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _appDbContext.Users.ToListAsync(cancellationToken);
            var result = _mapper.Map<List<ViewDto>>(users);
            return result;
        }
    }
}
