namespace Evice.Authentication.Domain.AggregatesModel.CompanyAggregate
{
    public interface ICompanyRepository
    {
        Task<bool> AddCompany(Company company);
    }
}