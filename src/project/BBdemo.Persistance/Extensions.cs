using BBdemo.Application.Services.JwtServices;
using BBdemo.Application.Services.Repositories;
using BBdemo.Persistance.Context;
using BBdemo.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Persistance;

public static class Extensions
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IJwtService, JwtService>();

        services.AddDbContext<BaseDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
        });
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
