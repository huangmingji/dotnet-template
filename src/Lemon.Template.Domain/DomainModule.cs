using Lemon.App.Core;
using Lemon.Template.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Domain;

[DependsOn(typeof(DomainSharedModule))]
public class DomainModule : AppModule
{
    public DomainModule(IServiceCollection services) : base(services)
    {
    }
}