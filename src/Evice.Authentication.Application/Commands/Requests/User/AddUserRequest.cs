using Evice.Authentication.Application.Commands.Responses;
using Evice.Authentication.Domain.SeedWork.Bases;

namespace Evice.Authentication.Application.Commands.Requests.User
{
    public class AddUserRequest
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}