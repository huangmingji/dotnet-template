using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Core;

public class AppModule : IAppModule
{
    private readonly IServiceCollection _services;
    public AppModule(IServiceCollection services)
    {
        this._services = services;
    }

    public void Init()
    {
        ConfigureServices(_services);
    }
    
    protected virtual void ConfigureServices(IServiceCollection serviceCollection)
    {
    }
}