using Lemon.App.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.EntityFrameworkCore.DbMigrations
{
    [DependsOn(typeof(EntityFrameworkCoreModule))]
    public class EntityFrameworkCoreDbMigrationsModule : AppModule
    {

        public EntityFrameworkCoreDbMigrationsModule(IServiceCollection services) : base(services)
        {
        }

        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
            #region 自动迁移数据库

            var dbContext = serviceCollection.BuildServiceProvider().GetService<DbContext>();
            if (dbContext != null)
            { 
                dbContext.Database.Migrate();
            }

            #endregion 自动迁移数据库
        }
    }
}