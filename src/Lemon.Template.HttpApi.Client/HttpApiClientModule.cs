using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.Template.HttpApi.Client
{
    public static class HttpApiClientModule
    {

        public static void ConfigureServices(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddHttpClient();
            // services.AddHttpClient("account", config =>
            // {
            //     config.BaseAddress= new Uri(configuration.GetSection("RemoteServices:Account:BaseUrl").Value);
            //     config.DefaultRequestHeaders.Add("Accept", "application/json");
            // });
            // context.Services.AddSingleton<IAccountService, AccountService>();
        }

    }
}