using Lemon.App.Application.Contracts;
using Lemon.App.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.HttpApi;
[DependsOn(typeof(AppApplicationContractsModule))]
public class AppHttpApiModule : AppModule
{
    
}

