using Evice.Authentication.Domain.SeedWork.Bases;
using FluentValidation;
using MediatR;
using System.Net;

namespace Evice.Authentication.Application.Behaviors
{
    public class PipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, ResponseBase<TResponse>>
        where TRequest : IRequest<ResponseBase<TResponse>>
    {
        private readonly IValidator<TRequest> _validator;

        public PipelineBehavior(IValidator<TRequest> validator)
        {
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<ResponseBase<TResponse>> Handle(TRequest request, RequestHandlerDelegate<ResponseBase<TResponse>> next, CancellationToken cancellationToken)
        {
            var response = new ResponseBase<TResponse>();

            var result = await this._validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                response.AddErrors(HttpStatusCode.BadRequest, result.Errors);
            }

            if (!response.Success)
            {
                return response;
            }

            return await next();
        }
    }
}