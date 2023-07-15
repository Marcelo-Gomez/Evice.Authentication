using Evice.Authentication.Application.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evice.Authentication.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest command)
        {
            var response = await _mediator.Send(command);

            return StatusCode((int)response.HttpStatusCode, response);
        }
    }
}