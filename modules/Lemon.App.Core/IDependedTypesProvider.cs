using System;

namespace Lemon.App.Core;

public interface IDependedTypesProvider
{
    Type[] GetDependedTypes();
}