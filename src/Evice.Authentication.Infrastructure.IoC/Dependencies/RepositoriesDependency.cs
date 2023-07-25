using Evice.Authentication.Domain.AggregatesModel.RoleAggregate;
using Evice.Authentication.Domain.AggregatesModel.UserAggregate;
using Evice.Authentication.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC.Dependencies
{
    public static class RepositoriesDependency
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}