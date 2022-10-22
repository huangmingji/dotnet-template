using Lemon.App.Application.Contracts;
using Lemon.App.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Application.Contracts
{
    [DependsOn(typeof(AppApplicationContractsModule))]
    public class ApplicationContractsModule : AppModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}