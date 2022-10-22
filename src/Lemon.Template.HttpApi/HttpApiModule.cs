using Lemon.App.Core;
using Lemon.App.HttpApi;
using Lemon.Template.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.Web
{

    [DependsOn(
        typeof(ApplicationContractsModule), 
        typeof(AppHttpApiModule))]
    public class HttpApiModule : AppModule
    {
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {

        }
    }

}