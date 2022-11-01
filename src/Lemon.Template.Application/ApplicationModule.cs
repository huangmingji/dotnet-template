using System;
using Lemon.App.Application;
using Lemon.App.Application.Services;
using Lemon.App.Core;
using Lemon.App.Core.AutoMapper;
using Lemon.Template.Application.Contracts;
using Lemon.Template.Application.Services.Account;
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
            serviceCollection.AddApplicationService(typeof(ApplicationModule));
            AutoMapperExtensions.AddAutoMapperProfile<ApplicationAutoMapperProfile>(true);
            IConfiguration configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();
        }
    }
}