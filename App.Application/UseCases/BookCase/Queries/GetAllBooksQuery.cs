using App.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
    {

    }
}
