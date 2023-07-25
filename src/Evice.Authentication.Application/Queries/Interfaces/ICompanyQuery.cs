namespace Evice.Authentication.Application.Queries.Interfaces
{
    public interface ICompanyQuery
    {
        Task<bool> CheckCompanyExists(string id);

        Task<bool> CheckCompanyExistsById(string Id);
    }
}