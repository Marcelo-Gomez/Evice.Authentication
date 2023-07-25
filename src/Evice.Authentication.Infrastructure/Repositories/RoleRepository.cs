using Evice.Authentication.Domain.AggregatesModel.RoleAggregate;

namespace Evice.Authentication.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<bool> Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}