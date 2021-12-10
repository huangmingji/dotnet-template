using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.EntityFrameworkCore.DbMigrations
{
    public static class EntityFrameworkCoreDbMigrationsModule
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            #region 自动迁移数据库

            var dbContext = services.BuildServiceProvider().GetService<DbContext>();
            if (dbContext != null)
            { 
                dbContext.Database.Migrate();
            }

            #endregion 自动迁移数据库

            return services;
        }
    }
}