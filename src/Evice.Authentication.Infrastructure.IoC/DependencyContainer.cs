using Evice.Authentication.Infrastructure.IoC.Dependencies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("Evice.Authentication.Application"));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddQueries();

            services.AddRepositories();

            services.AddServices();

            services.AddValidators();

            services.AddHandlers();
        }
    }
}