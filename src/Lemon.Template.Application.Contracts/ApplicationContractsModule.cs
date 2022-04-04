using Lemon.App.Core;
using Lemon.Template.Application.Contracts.Security;
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
        public override void ConfigureServices()
        {
            services.AddTransient<ICurrentUser, CurrentUser>();
        }
    }
}