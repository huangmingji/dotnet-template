namespace Lemon.App.Domain.Entities;

public interface ITenant<TKey>
{
    TKey TenantId { get; set;}
}