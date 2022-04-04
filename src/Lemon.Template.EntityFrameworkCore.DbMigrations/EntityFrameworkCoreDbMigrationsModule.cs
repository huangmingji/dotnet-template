using Lemon.App.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.EntityFrameworkCore.DbMigrations
{
    public class EntityFrameworkCoreDbMigrationsModule : AppModule
    {

        public EntityFrameworkCoreDbMigrationsModule(IServiceCollection services) : base(services)
        {
        }

        public override void ConfigureServices()
        {
            #region 自动迁移数据库

            var dbContext = services.BuildServiceProvider().GetService<DbContext>();
            if (dbContext != null)
            { 
                dbContext.Database.Migrate();
            }

            #endregion 自动迁移数据库
        }
    }
}