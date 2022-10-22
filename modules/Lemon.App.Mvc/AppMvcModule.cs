using Lemon.App.Authentication;
using Lemon.App.Core;

namespace Lemon.App.Mvc;

[DependsOn(typeof(AppAuthenticationModule))]
public class AppMvcModule : AppModule
{

}

