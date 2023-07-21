using Evice.Authentication.Application.Handlers;
using Evice.Authentication.Application.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC.Dependencies
{
    public static class HandlersDependency
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IUserHandler, UserHandler>();
        }
    }
}