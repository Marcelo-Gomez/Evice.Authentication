namespace Evice.Authentication.Application.Commands.Requests
{
    public class NewPasswordRequest
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}