using Evice.Authentication.Application.Commands.Responses;
using Evice.Authentication.Domain.SeedWork.Bases;
using MediatR;

namespace Evice.Authentication.Application.Commands.Requests
{
    public class LoginRequest : IRequest<ResponseBase<LoginResponse>>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        // TODO: Considerar usar uma validação de captcha no login.
        //public string RecaptchaToken { get; set; }
    }
}