using Lemon.App.Core;
using Lemon.App.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.EntityFrameworkCore;

public class AppEntityFramworkCoreModule : AppModule
{
    public AppEntityFramworkCoreModule(IServiceCollection services) : base(services)
    {
    }

    protected override void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDbContextProvider<DbContext>, DbContextProvider<DbContext>>();
        serviceCollection.AddScoped<IRepository, Repository>();
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}