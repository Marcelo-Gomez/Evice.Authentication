using Evice.Authentication.Infrastructure.Services;
using Evice.Authentication.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC.Dependencies
{
    public static class ServicesDependency
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}