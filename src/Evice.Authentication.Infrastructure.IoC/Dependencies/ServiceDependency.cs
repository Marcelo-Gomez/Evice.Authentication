using Evice.Authentication.Infrastructure.Services;
using Evice.Authentication.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC.Dependencies
{
    public static class ServiceDependency
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();
        }
    }
}