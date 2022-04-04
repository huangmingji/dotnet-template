using System;
using System.Linq;
using System.Reflection;
using Lemon.App.Core;
using Lemon.Template.Domain.Repositories;
using Lemon.Template.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.EntityFrameworkCore
{
    public class EntityFrameworkCoreModule : AppModule
    {

        public EntityFrameworkCoreModule(IServiceCollection services) : base(services)
        {
        }
        
        public override void ConfigureServices()
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddDbContextFactory<EfDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("Default")
                );
            });

            services.AddScoped<IDbContextProvider<EfDbContext>, DbContextProvider<EfDbContext>>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        }
    }
}