using Lemon.App.Application;
using Lemon.App.Core;
using Lemon.AutoMapper;
using Lemon.Template.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Application
{
    [DependsOn(typeof(ApplicationContractsModule), typeof(AppApplicationModule))]
    public class ApplicationModule : AppModule
    {               
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
            AutoMapperExtensions.AddAutoMapperProfile<ApplicationAutoMapperProfile>(true);
            IConfiguration configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();
        }
    }
}