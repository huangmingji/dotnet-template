using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Core;

public class AppModule : IAppModule
{

    public void AppInit(IServiceCollection services)
    {
        ConfigureServices(services);
    }

    protected virtual void ConfigureServices(IServiceCollection serviceCollection)
    {
    }
}