using Evice.Authentication.Domain.AggregatesModel.UserAggregate;

namespace Evice.Authentication.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}