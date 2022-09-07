using System;
using System.Linq;
using Lemon.App.Core;
using Lemon.AutoMapper;
using Lemon.Template.Application.Contracts;
using Lemon.Template.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Application
{
    [DependsOn(typeof(ApplicationContractsModule))]
    public class ApplicationModule : AppModule
    {
        public ApplicationModule(IServiceCollection services)
            : base(services)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
            AutoMapperExtensions.AddAutoMapperProfile<ApplicationAutoMapperProfile>();
            IConfiguration configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();
            
            // services.AddTransient<ICurrentUser, NullCurrentUser>();
            
            var storeAssebly = System.Reflection.Assembly.GetAssembly(typeof(ApplicationService)) ?? throw new NullReferenceException();
            var interfaces = storeAssebly.DefinedTypes.AsEnumerable().Where(x => x.IsInterface).ToList();
            foreach (var storeClass in storeAssebly.DefinedTypes.Where(x => x.IsClass && x.BaseType != null))
            {
                var targetInterface = storeClass.ImplementedInterfaces.FirstOrDefault(x => interfaces.Contains(x));
                if (targetInterface == null) continue;
                serviceCollection.AddScoped(targetInterface, storeClass);
            }
        }
    }
}