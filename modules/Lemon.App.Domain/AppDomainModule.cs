using System;
using Lemon.App.Core;
using Lemon.App.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Domain
{
    [DependsOn(typeof(AppDomainSharedModule))]
    public class AppDomainModule : AppModule
    {
        
    }
}

