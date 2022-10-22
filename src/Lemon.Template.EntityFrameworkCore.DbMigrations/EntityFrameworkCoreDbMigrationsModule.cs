using System;
using Lemon.App.Core;
using Lemon.App.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
        typeof(EntityFrameworkCoreModule), 
        typeof(AppEntityFramworkCoreModule)
        )
    ]
    public class EntityFrameworkCoreDbMigrationsModule : AppModule
    {
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
            IConfiguration configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            serviceCollection.AddAppDbContext<EfDbMigrationsContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("Default")
                );
            });
            
            #region 自动迁移数据库

            serviceCollection.BuildServiceProvider().GetService<EfDbMigrationsContext>()?.Database.Migrate();

            #endregion 自动迁移数据库
        }
    }
}