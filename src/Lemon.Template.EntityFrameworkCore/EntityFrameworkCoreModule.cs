using System;
using Lemon.App.Core;
using Lemon.App.EntityFrameworkCore;
using Lemon.Template.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.EntityFrameworkCore
{
    [DependsOn(typeof(DomainModule), typeof(AppEntityFramworkCoreModule))]
    public class EntityFrameworkCoreModule : AppModule
    {
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
            IConfiguration configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            serviceCollection.AddAppDbContext<EfDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("Default")
                );
            });
        }
    }
}