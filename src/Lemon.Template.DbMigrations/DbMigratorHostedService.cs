using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Lemon.Template.Application;
using Lemon.Template.EntityFrameworkCore;
using Lemon.Template.EntityFrameworkCore.DbMigrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lemon.Template.DbMigrations
{
    public class DbMigratorHostedService: IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton<IConfiguration>(configuration);

            EntityFrameworkCoreModule.ConfigureServices(services);
            ApplicationModule.ConfigureServices(services);
            EntityFrameworkCoreDbMigrationsModule.ConfigureServices(services);
            
            _hostApplicationLifetime.StopApplication();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
