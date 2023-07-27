using AutoMapper;
using Evice.Authentication.Application.Commands.Requests.User;
using Evice.Authentication.Application.Commands.Responses.User;
using Evice.Authentication.Application.Handlers.Interfaces;
using Evice.Authentication.Application.Queries.Interfaces;
using Evice.Authentication.Domain.AggregatesModel.UserAggregate;
using Evice.Authentication.Domain.Consts;
using Evice.Authentication.Domain.SeedWork.Bases;
using Evice.Authentication.Infrastructure.Services;
using System.Net;

namespace Evice.Authentication.Application.Handlers
{
    public class UserHandler : IUserHandler
    {
        private readonly IMapper _mapper;
        private readonly IUserQuery _userQuery;
        private readonly IUserRepository _userRepository;

        public UserHandler(IMapper mapper, IUserQuery userQuery, IUserRepository userRepository)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._userQuery = userQuery ?? throw new ArgumentNullException(nameof(userQuery));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<ResponseBase<AddUserResponse>> Add(AddUserRequest request)
        {
            var response = await this.ValidateRequest(request);

            if (!response.Success)
            {
                return response;
            }

            var user = this._mapper.Map<User>(request);
            user.EncryptedPassword = EncryptionService.GetHashedPassword(user.EncryptedPassword);

            var userAdded = await this._userRepository.AddUser(user);

            if (!userAdded)
            {
                response.AddError(HttpStatusCode.InternalServerError, ErrorMessagesConst.DatabaseAddInternalServerError);

                return response;
            }

            response.Data = this._mapper.Map<AddUserResponse>(user);

            return response;
        }

        private async Task<ResponseBase<AddUserResponse>> ValidateRequest(AddUserRequest request)
        {
            var response = new ResponseBase<AddUserResponse>();

            var user = await this._userQuery.GetUser(request.Email);
            if (user != null)
            {
                response.AddError(HttpStatusCode.BadRequest, "E-mail has already been registered.");
            }

            return response;
        }
    }
}