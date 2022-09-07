namespace Lemon.App.Core;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class DependsOnAttribute : Attribute, IDependedTypesProvider
{
    public Type[] DependedTypes { get; }

    public DependsOnAttribute(params Type[] dependedTypes) => this.DependedTypes = dependedTypes ?? new Type[0];

    public virtual Type[] GetDependedTypes() => this.DependedTypes;
}