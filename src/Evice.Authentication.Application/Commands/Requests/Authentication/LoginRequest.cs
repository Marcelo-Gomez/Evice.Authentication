using Evice.Authentication.Application.Commands.Responses;
using Evice.Authentication.Domain.SeedWork.Bases;

namespace Evice.Authentication.Application.Commands.Requests.Authentication
{
    public class LoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        // TODO: Considerar usar uma validação de captcha no login.
        //public string RecaptchaToken { get; set; }
    }
}