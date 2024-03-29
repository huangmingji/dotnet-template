﻿using System;
using Lemon.App.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Lemon.App.Application
{
    public static class ServiceCollectionApplicationExtensions
    {
        public static void AddApplicationService(this IServiceCollection serviceCollection, Type appModule)
        {
            var assemblies = System.Reflection.Assembly.GetAssembly(appModule) ?? throw new NullReferenceException();
            foreach (var definedType in assemblies.DefinedTypes.Where(x => x.IsClass && x.BaseType != null))
            {
                var targetInterface = definedType.ImplementedInterfaces.LastOrDefault();
                if (targetInterface == null) continue;
                if (definedType.BaseType == typeof(TransientService))
                {
                    serviceCollection.AddTransient(targetInterface, definedType);
                }
                else if (definedType.BaseType == typeof(ApplicationService))
                {
                    serviceCollection.AddScoped(targetInterface, definedType);
                }
                else if (definedType.BaseType.Name == typeof(DefaultApplicationService<,,,,>).Name)
                {
                    serviceCollection.AddScoped(targetInterface, definedType);
                }
            }
        }
    }
}

