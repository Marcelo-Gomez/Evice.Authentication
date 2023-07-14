using Evice.Authentication.Domain.SeedWork.Bases;
using FluentValidation;
using System.Net;

namespace Evice.Authentication.Application.Handlers
{
    public class CommonHandler<TRequest, TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public CommonHandler(IValidator<TRequest> validator)
        {
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public virtual async Task<ResponseBase<TResponse>> ValidateRequest(TRequest request)
        {
            var response = new ResponseBase<TResponse>();

            var result = await this._validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                response.AddErrors(HttpStatusCode.BadRequest, result.Errors);
            }

            return response;
        }
    }
}