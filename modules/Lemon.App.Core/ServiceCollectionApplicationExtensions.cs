using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Core;

public static class ServiceCollectionApplicationExtensions
{
    public static IServiceCollection AddApplication<TStartupModule>(this IServiceCollection services) where TStartupModule : IAppModule
    {
        return services.AddApplication(typeof(TStartupModule));
    }

    private static IServiceCollection AddApplication(this IServiceCollection services, Type startupModuleType)
    {
        object[] attributeObjects = startupModuleType.GetCustomAttributes(typeof(DependsOnAttribute), true);
        foreach (DependsOnAttribute attribute in attributeObjects)
        {
            Type[] types = attribute.GetDependedTypes();
            foreach (var type in types)
            {
                services.AddApplication(type);
            }
        }
        services.AddSingleton(startupModuleType);
        var appModule = services.BuildServiceProvider().GetService(startupModuleType) as IAppModule;
        appModule?.Init();
        return services;
    }
}