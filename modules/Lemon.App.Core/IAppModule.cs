using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Core;

public interface IAppModule
{
    void Init();
}