using Lemon.App.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Domain.Shared;

public class DomainSharedModule : AppModule
{
    public DomainSharedModule(IServiceCollection services) : base(services)
    {
        
    }
}