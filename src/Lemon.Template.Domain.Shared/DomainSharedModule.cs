using Lemon.App.Core;
using Lemon.App.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Domain.Shared;

[DependsOn(typeof(AppDomainSharedModule))]
public class DomainSharedModule : AppModule
{
    
}