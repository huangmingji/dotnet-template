using System;
using System.Linq;
using Lemon.AutoMapper;
using Lemon.Template.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Application
{
    public static class ApplicationModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            AutoMapperExtensions.AddAutoMapperProfile<ApplicationAutoMapperProfile>();
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            
            // services.AddTransient<ICurrentUser, NullCurrentUser>();
            
            var storeAssebly = System.Reflection.Assembly.GetAssembly(typeof(ApplicationService)) ?? throw new NullReferenceException();
            var interfaces = storeAssebly.DefinedTypes.AsEnumerable().Where(x => x.IsInterface).ToList();
            foreach (var storeClass in storeAssebly.DefinedTypes.Where(x => x.IsClass && x.BaseType != null))
            {
                var targetInterface = storeClass.ImplementedInterfaces.FirstOrDefault(x => interfaces.Contains(x));
                if (targetInterface == null) continue;
                services.AddScoped(targetInterface, storeClass);
            }
            return services;
        }
    }
}