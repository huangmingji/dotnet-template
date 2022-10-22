using Lemon.App.Core;
using Lemon.App.Core.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Application;
public class AppApplicationModule : AppModule
{
    protected override void ConfigureServices(IServiceCollection serviceCollection)
    {
        base.ConfigureServices(serviceCollection);
    }
}