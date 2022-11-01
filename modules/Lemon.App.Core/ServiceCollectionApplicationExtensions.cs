using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Core;

public static class ServiceCollectionApplicationExtensions
{
    public static IServiceCollection AddApplication<TStartupModule>(this IServiceCollection services) where TStartupModule : IAppModule
    {
        return services.AddApplication(typeof(TStartupModule)).ApplicationInit();
    }


    private static List<Type> _types = new List<Type>();
    private static IServiceCollection AddApplication(this IServiceCollection services, Type startupModuleType)
    {
        object[] attributeObjects = startupModuleType.GetCustomAttributes(typeof(DependsOnAttribute), true);
        foreach (DependsOnAttribute attribute in attributeObjects)
        {
            var types = attribute.GetDependedTypes().ToList();
            _types.AddRange(types);
            foreach (var type in types)
            {
                services.AddApplication(type);
            }
        }
        return services;
    }

    private static IServiceCollection ApplicationInit(this IServiceCollection services)
    {
        foreach(var type in _types)
        {
            services.AddSingleton(type);
            var appModule = services.BuildServiceProvider().GetService(type) as IAppModule;
            appModule?.AppInit(services);
        }
        return services;
    }
}