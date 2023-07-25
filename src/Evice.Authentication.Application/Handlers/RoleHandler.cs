using AutoMapper;
using Evice.Authentication.Application.Commands.Requests.Role;
using Evice.Authentication.Application.Commands.Responses.Role;
using Evice.Authentication.Application.Handlers.Interfaces;
using Evice.Authentication.Application.Queries.Interfaces;
using Evice.Authentication.Domain.AggregatesModel.RoleAggregate;
using Evice.Authentication.Domain.Consts;
using Evice.Authentication.Domain.SeedWork.Bases;
using System.Net;

namespace Evice.Authentication.Application.Handlers
{
    public class RoleHandler : IRoleHandler
    {
        private readonly IMapper _mapper;
        private readonly IRoleQuery _roleQuery;
        private readonly ICompanyQuery _companyQuery;
        private readonly IRoleRepository _roleRepository;

        public RoleHandler(IMapper mapper, IRoleQuery roleQuery, ICompanyQuery companyQuery, IRoleRepository roleRepository)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._roleQuery = roleQuery ?? throw new ArgumentNullException(nameof(roleQuery));
            this._companyQuery = companyQuery ?? throw new ArgumentNullException(nameof(companyQuery));
            this._roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<ResponseBase<RoleResponse>> Add(RoleRequest request)
        {
            var response = await this.ValidateRequest(request);
            if (!response.Success)
            {
                return response;
            }

            var role = this._mapper.Map<Role>(request);

            var roleAdded = await this._roleRepository.Add(role);
            if (!roleAdded)
            {
                response.AddError(HttpStatusCode.InternalServerError, ErrorMessagesConst.DatabaseAddInternalServerError);
                return response;
            }

            response.Data = this._mapper.Map<RoleResponse>(role);

            return response;
        }

        public async Task<ResponseBase<RoleResponse>> Update(RoleRequest request)
        {
            var response = await this.ValidateRequest(request);
            if (!response.Success)
            {
                return response;
            }

            var role = this._mapper.Map<Role>(request);

            var roleUpdated = await this._roleRepository.Update(role);
            if (!roleUpdated)
            {
                response.AddError(HttpStatusCode.InternalServerError, ErrorMessagesConst.DatabaseAddInternalServerError);
                return response;
            }

            response.Data = this._mapper.Map<RoleResponse>(role);

            return response;
        }

        public async Task<ResponseBase<RoleResponse>> Delete(string roleId)
        {
            var response = await this.ValidateRequest(roleId);
            if (!response.Success)
            {
                return response;
            }

            var roleDeleted = await this._roleRepository.Delete(roleId);
            if (!roleDeleted)
            {
                response.AddError(HttpStatusCode.InternalServerError, ErrorMessagesConst.DatabaseAddInternalServerError);
                return response;
            }

            return response;
        }

        private async Task<ResponseBase<RoleResponse>> ValidateRequest(RoleRequest request)
        {
            var response = new ResponseBase<RoleResponse>();

            var companyExists = await this._companyQuery.CheckCompanyExists(request.CompanyId);
            if (!companyExists)
            {
                response.AddError(HttpStatusCode.BadRequest, 
                    string.Format(ErrorMessagesConst.NotExists, nameof(request.CompanyId)));
                return response;
            }

            var nameExists = await this._roleQuery.CheckNameExists(request.CompanyId, request.Name);
            if (nameExists)
            {
                response.AddError(HttpStatusCode.BadRequest,
                    string.Format(ErrorMessagesConst.AlreadyExists, nameof(request.Name)));
            }

            return response;
        }

        private async Task<ResponseBase<RoleResponse>> ValidateRequest(string roleId)
        {
            var response = new ResponseBase<RoleResponse>();

            var roleExists = await this._roleQuery.CheckRoleExists(roleId);
            if (!roleExists)
            {
                response.AddError(HttpStatusCode.BadRequest, string.Format(ErrorMessagesConst.NotExists, nameof(roleId)));
            }

            return response;
        }
    }
}