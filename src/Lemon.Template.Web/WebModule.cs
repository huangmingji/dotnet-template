using System.Collections.Generic;
using Lemon.App.Authentication;
using Lemon.App.Core;
using Lemon.App.Mvc;
using Lemon.Common.Extend;
using Lemon.Template.Application;
using Lemon.Template.EntityFrameworkCore.DbMigrations;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Web
{

    [DependsOn(
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(ApplicationModule), 
        typeof(HttpApiModule),
        typeof(AppMvcModule))]
    public class WebModule : AppModule
    {
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }

}