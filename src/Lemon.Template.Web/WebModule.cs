using Lemon.App.Core;
using Lemon.Template.Application;
using Lemon.Template.EntityFrameworkCore.DbMigrations;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Web
{

    [DependsOn(
        typeof(EntityFrameworkCoreDbMigrationsModule),
        typeof(ApplicationModule))]
    public class WebModule : AppModule
    {
        public WebModule(IServiceCollection services) : base(services)
        {
        }

        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {

        }
    }

}