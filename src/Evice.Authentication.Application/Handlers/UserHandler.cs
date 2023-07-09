using AutoMapper;
using Evice.Authentication.Application.Commands.Requests;
using Evice.Authentication.Application.Commands.Responses;
using Evice.Authentication.Application.Queries.Interfaces;
using Evice.Authentication.Domain.AggregatesModel.UserAggregate;
using Evice.Authentication.Domain.SeedWork.Bases;
using Evice.Authentication.Infrastructure.Services;
using FluentValidation;
using MediatR;
using System.Net;

namespace Evice.Authentication.Application.Handlers
{
    public class UserHandler : IRequestHandler<AddUserRequest, ResponseBase<AddUserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserQuery _userQuery;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<AddUserRequest> _validator;

        public UserHandler(IMapper mapper, IUserQuery userQuery, IUserRepository userRepository, IValidator<AddUserRequest> validator)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._userQuery = userQuery ?? throw new ArgumentNullException(nameof(userQuery));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<ResponseBase<AddUserResponse>> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var response = await this.ValidateRequest(request);

            if (!response.Success)
            {
                return response;
            }

            var user = this._mapper.Map<User>(request);
            user.EncryptedPassword = EncryptionService.GetHashedPassword(user.EncryptedPassword);
            user.Active = true;

            var userAdded = await this._userRepository.AddUser(user);

            if (!userAdded)
            {
                response.AddError(HttpStatusCode.InternalServerError, "An error occurred while adding the user to the database.");

                return response;
            }

            response.Data = this._mapper.Map<AddUserResponse>(user);

            return response;
        }

        private async Task<ResponseBase<AddUserResponse>> ValidateRequest(AddUserRequest request)
        {
            var response = new ResponseBase<AddUserResponse>();

            var result = await this._validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                response.AddErrors(HttpStatusCode.BadRequest, result.Errors);
            }

            var user = await this._userQuery.GetUser(request.Email);
            if (user != null)
            {
                response.AddError(HttpStatusCode.BadRequest, "E-mail has already been registered.");
            }

            return response;
        }
    }
}