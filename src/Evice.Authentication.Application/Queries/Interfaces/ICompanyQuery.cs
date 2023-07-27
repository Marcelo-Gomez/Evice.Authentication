namespace Evice.Authentication.Application.Queries.Interfaces
{
    public interface ICompanyQuery
    {
        Task<bool> CheckCompanyExists(Guid id);

        Task<bool> CheckCompanyExists(string document);

        Task<bool> CheckCompanyExistsById(string Id);
    }
}