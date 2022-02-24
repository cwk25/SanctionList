using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SanctionList.Server.Application.Contracts;
using SanctionList.Server.Persistence.Configurations;
using SanctionList.Server.Persistence.Repositories;
using SanctionList.Server.Persistence.WatchlistConfigRepositories;

namespace SanctionList.Server.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var dbConfig = configuration.GetSection("Db").Get<DbConfig>();
            services.AddSingleton(dbConfig);

            services.AddScoped<IDowJonesIdentityRepo, DowJonesIdentityRepo>();
            services.AddScoped<IDowJonesIdentityNameRepo, DowJonesIdentityNameRepo>();
            services.AddScoped<IMatchingCriteriaRepo, MatchingCriteriaRepo>();
            services.AddScoped<IMatchingMethodRepo, MatchingMethodRepo>();
            return services;
        }
    }
}