namespace Evice.Authentication.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(string id);
    }
}