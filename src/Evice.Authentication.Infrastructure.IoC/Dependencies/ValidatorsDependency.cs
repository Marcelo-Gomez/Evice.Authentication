using Evice.Authentication.Application.Commands.Requests;
using Evice.Authentication.Application.Validators.User;
using Evice.Authentication.Domain.SeedWork.Bases;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Evice.Authentication.Infrastructure.IoC.Dependencies
{
    public static class ValidatorsDependency
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            var response = new ResponseBase<object>();

                            var errorMessages = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);

                            response.AddErrors(errorMessages);

                            return new ObjectResult(response)
                            {
                                StatusCode = (int?)HttpStatusCode.BadRequest
                            };
                        };
                    });

            services.AddFluentValidationAutoValidation();

            services.AddTransient<IValidator<AddUserRequest>, AddUserRequestValidator>();
        }
    }
}