using Evice.Authentication.Application.Commands.Requests.User;
using Evice.Authentication.Application.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Evice.Authentication.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserHandler _userHandler;

        public UserController(IUserHandler userHandler)
            => this._userHandler = userHandler ?? throw new ArgumentNullException(nameof(userHandler));

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var response = await this._userHandler.Add(request);

            return StatusCode((int)response.HttpStatusCode, response);
        }
    }
}