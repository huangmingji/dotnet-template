using Lemon.App.Application;
using Lemon.App.Authentication;
using Lemon.App.Core;

namespace Lemon.App.Mvc;

[DependsOn(typeof(AppAuthenticationModule), typeof(AppApplicationModule))]
public class AppMvcModule : AppModule
{

}

