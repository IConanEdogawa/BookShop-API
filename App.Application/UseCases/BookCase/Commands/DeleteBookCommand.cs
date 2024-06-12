using App.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Commands
{
    public class DeleteBookCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
