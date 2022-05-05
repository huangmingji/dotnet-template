using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Core;

public class AppModule
{
    protected readonly IServiceCollection services;
    public AppModule(IServiceCollection services)
    {
        this.services = services;
    }

    public virtual void ConfigureServices()
    {
    }
}