using System;
using System.Collections.Generic;
using Lemon.App.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Lemon.App.Application.Services;
using Lemon.App.Application.Contracts;
using Lemon.App.Domain;

namespace Lemon.App.Application;
[DependsOn(typeof(AppApplicationContractsModule), typeof(AppDomainModule))]
public class AppApplicationModule : AppModule
{
    protected override void ConfigureServices(IServiceCollection serviceCollection)
    {
        base.ConfigureServices(serviceCollection);
    }
}