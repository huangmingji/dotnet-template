using Lemon.App.Core;
using Lemon.App.Domain.Repositories;
using Lemon.App.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.EntityFrameworkCore;

public class AppEntityFramworkCoreModule : AppModule
{
    protected override void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));

        IConfiguration? configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();
        string? redisConfiguration = configuration?.GetSection("Redis:Configuration").Value ?? null;
        if(redisConfiguration == null)
        {
            serviceCollection.AddMemoryCache();
        } 
        else
        {
            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConfiguration;
            });
        }
    }
}