namespace Evice.Authentication.Application.Commands.Requests
{
    public class ChangePasswordRequest
    {
        public Guid UserId { get; set; }

        public Guid Code { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}