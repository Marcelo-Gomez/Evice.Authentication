using Evice.Authentication.Application.Queries;
using Evice.Authentication.Application.Queries.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Evice.Authentication.Infrastructure.IoC.Dependencies
{
    public static class QueriesDependency
    {
        public static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IUserQuery, UserQuery>();
        }
    }
}