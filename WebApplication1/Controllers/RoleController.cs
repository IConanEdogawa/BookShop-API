using App.Application.UseCases.RoleCase.Commands;
using App.Application.UseCases.RoleCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());

            return Ok(result);
        }
    }
}
