using Evice.Authentication.Infrastructure.IoC.Dependencies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQueries();

            services.AddRepositories();

            services.AddServices();

            services.AddValidators();

            services.AddHandlers();
        }
    }
}