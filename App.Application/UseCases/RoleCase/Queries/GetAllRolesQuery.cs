﻿using App.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.RoleCase.Queries
{
    public class GetAllRolesQuery : IRequest<List<Roles>>
    {

    }
}
