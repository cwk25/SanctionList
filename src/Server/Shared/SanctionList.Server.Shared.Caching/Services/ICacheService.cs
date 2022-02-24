namespace SanctionList.Server.Shared.Caching.Services;

public interface ICacheService
{
    Task<T> GetOrCreate<T>(string key, Func<Task<T>> entryCallBack);
    Task Set<T>(string key, T value);
}