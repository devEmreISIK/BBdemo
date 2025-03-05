using BBdemo.Application.Services.RedisServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRedisService, RedisCacheService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
    public static bool StartsWithA(this string text)
    {
        return text.StartsWith("A");
    }
}
