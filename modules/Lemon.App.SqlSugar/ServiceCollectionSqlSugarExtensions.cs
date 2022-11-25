using System;
using Lemon.App.EntityFrameworkCore;
using Lemon.App.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace Lemon.App.SqlSugar
{
	public static class ServiceCollectionSqlSugarExtensions
    {
        public static void AddAppDbContext<TDbContext>(this IServiceCollection serviceCollection, Func<IServiceProvider, ISqlSugarClient> optionsFunc)
             where TDbContext : DbContext
        {
            serviceCollection.AddScoped<TDbContext>();
            serviceCollection.AddScoped<IDbContextProvider<TDbContext>, DbContextProvider<TDbContext>>();
            serviceCollection.AddScoped<ISqlSugarClient>(optionsFunc);

            var assemblies = System.Reflection.Assembly.GetAssembly(typeof(TDbContext)) ?? throw new NullReferenceException();
            List<string> types = new List<string> { typeof(SqlSugarRepository<,,>).Name };
            foreach (var definedType in assemblies.DefinedTypes.Where(x => x.IsClass && x.BaseType != null && types.Contains(x.BaseType.Name)))
            {
                var targetInterface = definedType.ImplementedInterfaces.LastOrDefault();
                if (targetInterface == null) continue;
                serviceCollection.AddScoped(targetInterface, definedType);
            }
        }
    }
}

