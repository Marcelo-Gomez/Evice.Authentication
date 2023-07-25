using Evice.Authentication.Application.Commands.Responses.Role;
using Evice.Authentication.Application.Queries.Interfaces;

namespace Evice.Authentication.Application.Queries
{
    public class RoleQuery : IRoleQuery
    {
        public async Task<bool> CheckNameExists(string companyId, string name)
        {
            return false;
            //throw new NotImplementedException();
        }

        public Task<bool> CheckRoleExists(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<RoleResponse> GetById(string roleId)
        {
            throw new NotImplementedException();
        }
    }
}