using Lemon.App.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Application.Contracts
{
    public class ApplicationContractsModule : AppModule
    {
        public ApplicationContractsModule(IServiceCollection services) : base(services)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}