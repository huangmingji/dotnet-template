using System;
using System.Collections.Generic;
using System.Linq;
using Lemon.App.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.EntityFrameworkCore;

public static class ServiceCollectionEntityFramworkCoreExtensions
{
    public static void AddAppDbContext<TDbContext>(this IServiceCollection serviceCollection, Action<DbContextOptionsBuilder> optionsAction)
        where TDbContext : DbContext
    {
        serviceCollection.AddScoped<IDbContextProvider<TDbContext>, DbContextProvider<TDbContext>>();
        serviceCollection.AddDbContextFactory<TDbContext>(optionsAction, ServiceLifetime.Scoped);

        var assemblies = System.Reflection.Assembly.GetAssembly(typeof(TDbContext)) ?? throw new NullReferenceException();
        List<string> types = new List<string> { typeof(EfCoreRepository<,,>).Name };
        foreach (var definedType in assemblies.DefinedTypes.Where(x => x.IsClass && x.BaseType != null && types.Contains(x.BaseType.Name)))
        {
            var targetInterface = definedType.ImplementedInterfaces.LastOrDefault();
            if (targetInterface == null) continue;
            serviceCollection.AddScoped(targetInterface, definedType);
        }
    }
}