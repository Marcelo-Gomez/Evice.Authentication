using Evice.Authentication.Application.Commands.Requests.Company;
using Evice.Authentication.Application.Commands.Responses.Company;
using Evice.Authentication.Domain.SeedWork.Bases;

namespace Evice.Authentication.Application.Handlers.Interfaces
{
    public interface ICompanyHandler
    {
        Task<ResponseBase<AddCompanyResponse>> Handle(AddCompanyRequest request);
    }
}