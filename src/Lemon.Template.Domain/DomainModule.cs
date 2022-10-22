using Lemon.App.Core;
using Lemon.App.Domain;
using Lemon.Template.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Domain;

[DependsOn(typeof(DomainSharedModule), typeof(AppDomainModule))]
public class DomainModule : AppModule
{
    
}