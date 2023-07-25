using Evice.Authentication.Application.Commands.Requests.Authentication;
using Evice.Authentication.Application.Commands.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace Evice.Authentication.Application.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthenticationController : Controller
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("password/change")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("password/forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("password/new")]
        public async Task<IActionResult> NewPassword([FromBody] AddUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}