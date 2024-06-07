using App.Application.UseCases.BookCase.Commands;
using App.Application.UseCases.BookCase.Queries;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
