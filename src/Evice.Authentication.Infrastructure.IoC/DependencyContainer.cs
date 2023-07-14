using Evice.Authentication.Infrastructure.IoC.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddValidators();

            services.AddQueries();

            services.AddRepositories();

            var assembly = AppDomain.CurrentDomain.Load("Evice.Authentication.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);
        }
    }
}