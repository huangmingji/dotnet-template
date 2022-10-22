using Lemon.Template.Domain.Account.Roles;
using Lemon.Template.Domain.Account.Users;
using Microsoft.EntityFrameworkCore;

namespace Lemon.Template.EntityFrameworkCore
{
    public class EfDbMigrationsContext : DbContext
    {
        private DbSet<UserData> UserDatas {get;set;}
        private DbSet<UserRole> UserRoles {get;set;}
        private DbSet<PermissionData> PermissionDatas {get;set;}
        private DbSet<RoleData> RoleDatas {get;set;}
        private DbSet<RolePermissionData> RolePermissionDatas {get;set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lemon.Commerce.Data.CommerceContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public EfDbMigrationsContext(DbContextOptions<EfDbMigrationsContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// On the model creating.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
            base.OnModelCreating(modelBuilder);
        }
    }
}