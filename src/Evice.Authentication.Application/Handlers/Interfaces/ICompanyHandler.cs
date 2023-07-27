using Evice.Authentication.Application.Commands.Requests.Company;
using Evice.Authentication.Application.Commands.Responses.Company;
using Evice.Authentication.Domain.SeedWork.Bases;

namespace Evice.Authentication.Application.Handlers.Interfaces
{
    public interface ICompanyHandler
    {
        Task<ResponseBase<AddCompanyResponse>> Add(AddCompanyRequest request);

        Task<ResponseBase<object>> Update(UpdateCompanyRequest request);

        Task<ResponseBase<object>> Delete(Guid id);
    }
}