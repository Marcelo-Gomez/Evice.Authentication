namespace Evice.Authentication.Application.Commands.Requests.Authentication
{
    public class ForgotPasswordRequest
    {
        public string Email { get; set; }

        // TODO: Considerar usar uma validação de captcha no esqueceu a senha.
        //public string RecaptchaToken { get; set; }
    }
}