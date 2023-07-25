namespace Evice.Authentication.Application.Commands.Requests.Authentication
{
    public class NewPasswordRequest
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}