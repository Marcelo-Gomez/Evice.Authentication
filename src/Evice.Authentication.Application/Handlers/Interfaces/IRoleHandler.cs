using Evice.Authentication.Application.Commands.Requests.Role;
using Evice.Authentication.Application.Commands.Responses.Role;
using Evice.Authentication.Domain.SeedWork.Bases;

namespace Evice.Authentication.Application.Handlers.Interfaces
{
    public interface IRoleHandler
    {
        Task<ResponseBase<RoleResponse>> Add(RoleRequest request);

        Task<ResponseBase<RoleResponse>> Update(RoleRequest request);

        Task<ResponseBase<RoleResponse>> Delete(string roleId);
    }
}