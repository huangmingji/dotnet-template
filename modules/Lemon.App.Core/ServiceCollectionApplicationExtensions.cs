using Lemon.App.Core.Services;
using Microsoft.AspNetCore.Http;
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
            List<Type> types = attribute.GetDependedTypes().ToList();
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
            services.AddApplicationServices(type);
        }
        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection, Type moduleType)
    {
        var assemblies = System.Reflection.Assembly.GetAssembly(moduleType) ?? throw new NullReferenceException();
        List<Type> types = new List<Type> { typeof(ApplicationService), typeof(TransientService) };
        foreach (var definedType in assemblies.DefinedTypes.Where(x => x.IsClass && x.BaseType != null && types.Contains(x.BaseType)))
        {
            var targetInterface = definedType.ImplementedInterfaces.FirstOrDefault();
            if (targetInterface == null) continue;
            if (definedType.BaseType == typeof(ApplicationService))
            {
                serviceCollection.AddScoped(targetInterface, definedType);
            }
            else if (definedType.BaseType == typeof(TransientService))
            {
                serviceCollection.AddTransient(targetInterface, definedType);
            }
        }
        return serviceCollection;
    }

}