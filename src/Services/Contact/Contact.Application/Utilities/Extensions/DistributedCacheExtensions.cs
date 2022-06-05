using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Contact.Application.Utilities.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key)
        {
            var json = await cache.GetStringAsync(key);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task SetAsync<T>(this IDistributedCache cache, string key, T value, DistributedCacheEntryOptions options)
        {
            var json = JsonConvert.SerializeObject(value);
            await cache.SetStringAsync(key, json, options);
        }
    }
}
