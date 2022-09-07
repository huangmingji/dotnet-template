using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.EntityFrameworkCore;

public static class ServiceCollectionEntityFramworkCoreExtensions
{
    public static void AddAppDbContext<TDbContext>(this IServiceCollection serviceCollection, Action<DbContextOptionsBuilder> optionsAction) where TDbContext : DbContext
    {
        serviceCollection.AddDbContext<DbContext, TDbContext>(optionsAction);
        serviceCollection.AddDbContextFactory<TDbContext>(optionsAction);
        serviceCollection.AddScoped<IDbContextProvider<TDbContext>, DbContextProvider<TDbContext>>();
    }
}