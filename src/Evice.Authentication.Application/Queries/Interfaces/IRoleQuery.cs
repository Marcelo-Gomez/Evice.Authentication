using Evice.Authentication.Application.Commands.Responses.Role;

namespace Evice.Authentication.Application.Queries.Interfaces
{
    public interface IRoleQuery
    {
        Task<bool> CheckRoleExists(string roleId);

        Task<bool> CheckNameExists(string companyId, string name);

        Task<RoleResponse> GetById(string roleId);
    }
}