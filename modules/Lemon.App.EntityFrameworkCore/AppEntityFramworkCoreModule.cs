using Lemon.App.Core;
using Lemon.App.Domain;
using Lemon.App.Domain.Repositories;
using Lemon.App.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.EntityFrameworkCore;

[DependsOn(typeof(AppDomainModule))]
public class AppEntityFramworkCoreModule : AppModule
{
    protected override void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
    }
}