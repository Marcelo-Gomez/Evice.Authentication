using Evice.Authentication.Application.Queries.Interfaces;

namespace Evice.Authentication.Application.Queries
{
    public class CompanyQuery : ICompanyQuery
    {
        public Task<bool> CheckCompanyExists(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckCompanyExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckCompanyExistsById(string Id)
        {
            return false;
            //throw new NotImplementedException();
        }

        public async Task<bool> CompanyExists(string document)
        {
            return false;
            //throw new NotImplementedException();
        }
    }
}