using AutoMapper;
using Evice.Authentication.Application.Commands.Requests.Company;
using Evice.Authentication.Application.Commands.Requests.Role;
using Evice.Authentication.Application.Commands.Requests.User;
using Evice.Authentication.Application.Commands.Responses.Company;
using Evice.Authentication.Application.Handlers.Interfaces;
using Evice.Authentication.Application.Queries.Interfaces;
using Evice.Authentication.Domain.AggregatesModel.CompanyAggregate;
using Evice.Authentication.Domain.Consts;
using Evice.Authentication.Domain.SeedWork.Bases;
using System.Net;

namespace Evice.Authentication.Application.Handlers
{
    public class CompanyHandler : ICompanyHandler
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyQuery _companyQuery;
        private readonly IUserHandler _userHandler;
        private readonly IRoleHandler _roleHandler;
        private readonly IMapper _mapper;

        public CompanyHandler(ICompanyRepository companyRepository, ICompanyQuery companyQuery,
            IUserHandler userHandler, IRoleHandler roleHandler, IMapper mapper)
        {
            this._companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            this._companyQuery = companyQuery ?? throw new ArgumentNullException(nameof(companyQuery));
            this._userHandler = userHandler ?? throw new ArgumentNullException(nameof(userHandler));
            this._roleHandler = roleHandler ?? throw new ArgumentNullException(nameof(roleHandler));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResponseBase<AddCompanyResponse>> Add(AddCompanyRequest request)
        {
            var response = await this.ValidateRequest(request);
            if (!response.Success)
            {
                return response;
            }

            var company = this._mapper.Map<Company>(request);

            var companyAdded = await this._companyRepository.Add(company);
            if (!companyAdded)
            {
                response.AddError(HttpStatusCode.InternalServerError, "An error occurred while adding the user to the database.");
                return response;
            }

            // Creates administrator role with full access.
            var roleHandler = await this._roleHandler.Add(new RoleRequest()
            {
                Name = "Admin",
                Description = "Default description",
                CompanyId = company.Id
            });
            if (!roleHandler.Success)
            {
                return response;
            }

            // Creates administrator user linked to the company.
            var userHandler = await this._userHandler.Add(new AddUserRequest()
                {
                    Name = "Admin",
                    Email = request.Email,
                });
            if (!userHandler.Success)
            {
                return response;
            }

            response.Data = this._mapper.Map<AddCompanyResponse>(company);

            return response;
        }

        public async Task<ResponseBase<object>> Update(UpdateCompanyRequest request)
        {
            var response = await this.ValidateRequest(request.Id);
            if (!response.Success)
            {
                return response;
            }

            var company = this._mapper.Map<Company>(request);

            var companyUpdated = await this._companyRepository.Update(company);
            if (!companyUpdated)
            {
                response.AddError(HttpStatusCode.InternalServerError, "An error occurred while adding the user to the database.");
                return response;
            }

            return response;
        }

        public async Task<ResponseBase<object>> Delete(Guid id)
        {
            var response = await this.ValidateRequest(id);
            if (!response.Success)
            {
                return response;
            }

            var companyDeleted = await this._companyRepository.Delete(id);
            if (!companyDeleted)
            {
                response.AddError(HttpStatusCode.InternalServerError, "An error occurred while adding the user to the database.");
                return response;
            }

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

        private async Task<ResponseBase<object>> ValidateRequest(Guid id)
        {
            var response = new ResponseBase<object>();

            var companyExists = await this._companyQuery.CheckCompanyExists(id);
            if (!companyExists)
            {
                response.AddError(HttpStatusCode.BadRequest,
                    string.Format(ErrorMessagesConst.NotExists, nameof(id)));
            }

            return response;
        }
    }
}