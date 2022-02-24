using Microsoft.Extensions.Caching.Memory;

namespace SanctionList.Server.Shared.Caching.Services;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task<T> GetOrCreate<T>(string key, Func<Task<T>> entryCallBack)
    {
        var cachedValue = await _memoryCache.GetOrCreateAsync<T>(key, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
            return await entryCallBack();
        });
        return cachedValue;
    }

    public Task Set<T>(string key, T value)
    {
        _memoryCache.Set(key, value);
        return Task.CompletedTask;
    }
}