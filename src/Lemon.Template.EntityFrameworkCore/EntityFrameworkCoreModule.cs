using System;
using System.Linq;
using System.Reflection;
using Lemon.Template.Domain.Repositories;
using Lemon.Template.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.EntityFrameworkCore
{
    public static class EntityFrameworkCoreModule
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services.AddDbContext();
        }
        
        private static IServiceCollection AddDbContext(this IServiceCollection services)
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
            return services;
        }
    }
}