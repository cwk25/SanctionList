using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using SanctionList.Server.Shared.Caching.Services;

namespace SanctionList.Server.Shared.Caching
{
    public static class CacheServicesRegistration
    {
        public static IServiceCollection ConfigureCacheServices(this IServiceCollection services)
        {
            services.AddSingleton<ICacheService, MemoryCacheService>();

            return services;
        }
    }
}