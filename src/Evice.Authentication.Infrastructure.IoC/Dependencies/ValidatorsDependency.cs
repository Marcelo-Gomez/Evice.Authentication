using Evice.Authentication.Application.Commands.Requests;
using Evice.Authentication.Application.Validators.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC.Dependencies
{
    public static class ValidatorsDependency
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AddUserRequest>, AddUserRequestValidator>();
        }
    }
}