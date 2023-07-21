using Evice.Authentication.Application.Commands.Requests;
using Evice.Authentication.Application.Commands.Responses;
using Evice.Authentication.Domain.SeedWork.Bases;

namespace Evice.Authentication.Application.Handlers.Interfaces
{
    public interface IUserHandler
    {
        Task<ResponseBase<AddUserResponse>> Handle(AddUserRequest request);
    }
}