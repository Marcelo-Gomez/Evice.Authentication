using Evice.Authentication.Application.Queries.Interfaces;
using Evice.Authentication.Domain.AggregatesModel.UserAggregate;

namespace Evice.Authentication.Application.Queries
{
    public class UserQuery : IUserQuery
    {
        public Task<User> GetUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}