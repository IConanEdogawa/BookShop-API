using App.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.UserCase.Commands
{
    public class UpdateUserCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public IFormFile? Photo { get; set; }
        public string? Bio { get; set; }

    }
}
