using Evice.Authentication.Application.Commands.Requests.User;
using Evice.Authentication.Application.Commands.Responses.User;
using Evice.Authentication.Domain.SeedWork.Bases;

namespace Evice.Authentication.Application.Handlers.Interfaces
{
    public interface IUserHandler
    {
        Task<ResponseBase<AddUserResponse>> Add(AddUserRequest request);
    }
}