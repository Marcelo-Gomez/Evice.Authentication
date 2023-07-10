namespace Evice.Authentication.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(string id);
    }
}