using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Services.RedisServices;

public interface IRedisService
{
    Task AddDataAsync<T>(string key, T value);
    Task<T> GetDataAsync<T>(string key);
    Task RemoveDataAsync(string key);

 }
