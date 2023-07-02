using Microsoft.AspNetCore.Mvc;

namespace Evice.Authentication.Application.Controllers
{
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        /// <summary>
        /// Responsible for create a user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("~/api/v1/payment-schemes/{paymentSchemeKey}/messages/build")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> CreateUser(
            //[FromBody] UserRequest request
            )
        {
            throw new NotImplementedException();
        }
    }
}