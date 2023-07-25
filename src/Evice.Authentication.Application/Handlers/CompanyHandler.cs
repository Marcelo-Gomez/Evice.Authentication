using AutoMapper;
using Evice.Authentication.Application.Commands.Requests.Company;
using Evice.Authentication.Application.Commands.Responses.Company;
using Evice.Authentication.Application.Queries.Interfaces;
using Evice.Authentication.Domain.AggregatesModel.CompanyAggregate;
using Evice.Authentication.Domain.SeedWork.Bases;
using System.Net;

namespace Evice.Authentication.Application.Handlers
{
    public class CompanyHandler
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyQuery _companyQuery;
        private readonly IMapper _mapper;

        public CompanyHandler(ICompanyRepository companyRepository, ICompanyQuery companyQuery, IMapper mapper)
        {
            this._companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            this._companyQuery = companyQuery ?? throw new ArgumentNullException(nameof(companyQuery));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResponseBase<AddCompanyResponse>> Handle(AddCompanyRequest request)
        {
            var response = await this.ValidateRequest(request);
            if (!response.Success)
            {
                return response;
            }

            var company = this._mapper.Map<Company>(request);

            var companyAdded = await this._companyRepository.AddCompany(company);
            if (!companyAdded)
            {
                response.AddError(HttpStatusCode.InternalServerError, "An error occurred while adding the user to the database.");
                return response;
            }

            response.Data = this._mapper.Map<AddCompanyResponse>(company);

            return response;
        }

        private async Task<ResponseBase<AddCompanyResponse>> ValidateRequest(AddCompanyRequest request)
        {
            var response = new ResponseBase<AddCompanyResponse>();

            var companyExists = await this._companyQuery.CheckCompanyExists(request.Document);
            if (companyExists)
            {
                response.AddError(HttpStatusCode.BadRequest, "Company has already been registered.");
            }

            return response;
        }
    }
}