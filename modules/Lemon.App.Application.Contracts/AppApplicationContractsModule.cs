using System;
using Lemon.App.Core;
using Lemon.App.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Application.Contracts
{
    [DependsOn(typeof(AppDomainSharedModule))]
    public class AppApplicationContractsModule : AppModule
    {
        
    }
}

