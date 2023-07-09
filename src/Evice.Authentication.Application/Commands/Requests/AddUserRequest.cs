using Evice.Authentication.Application.Commands.Responses;
using Evice.Authentication.Domain.SeedWork.Bases;
using MediatR;

namespace Evice.Authentication.Application.Commands.Requests
{
    public class AddUserRequest : IRequest<ResponseBase<AddUserResponse>>
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}