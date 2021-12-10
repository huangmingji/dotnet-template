using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Lemon.Template.DbMigrations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
#if DEBUG
                .MinimumLevel.Override("NengLong.Mailbox", LogEventLevel.Debug)
#else
                .MinimumLevel.Override("NengLong.Mailbox", LogEventLevel.Information)
#endif
                .Enrich.FromLogContext()
                .WriteTo.Async(c =>
                    c.File("Logs/log.txt",
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 31,
                        rollOnFileSizeLimit: true,
                        fileSizeLimitBytes: 31457280,
                        buffered: true))
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting");
                await CreateHostBuilder(args).RunConsoleAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<DbMigratorHostedService>();
                });
    }
}
