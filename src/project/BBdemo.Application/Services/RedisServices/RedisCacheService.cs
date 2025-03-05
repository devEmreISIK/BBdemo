using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BBdemo.Application.Services.RedisServices;

public class RedisCacheService : IRedisService
{
    private readonly IDistributedCache _distributedCache;

    public RedisCacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task AddDataAsync<T>(string key, T value)
    {
        var jsonData = JsonSerializer.Serialize(value);

        byte[] dataBytes = Encoding.UTF8.GetBytes(jsonData);

        // 3 dk cache de kalsın.
        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(3),
        };

        await _distributedCache.SetAsync(key, dataBytes, options);
    }

    public async Task<T> GetDataAsync<T>(string key)
    {
        byte[] datas = await _distributedCache.GetAsync(key);

        if (datas == null)
        {
            return default;
        }

        var jsonData = Encoding.UTF8.GetString(datas);

        T response = JsonSerializer.Deserialize<T>(jsonData);

        return response;
    }

    public async Task RemoveDataAsync(string key)
    {
        await _distributedCache.RemoveAsync(key);
    }
}
