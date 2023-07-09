using Evice.Authentication.Domain.AggregatesModel.UserAggregate;

namespace Evice.Authentication.Application.Queries.Interfaces
{
    public interface IUserQuery
    {
        Task<User> GetUser(string email);
    }
}