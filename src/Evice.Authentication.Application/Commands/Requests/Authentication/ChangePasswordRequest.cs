namespace Evice.Authentication.Application.Commands.Requests.Authentication
{
    public class ChangePasswordRequest
    {
        public Guid UserId { get; set; }

        public Guid Code { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}