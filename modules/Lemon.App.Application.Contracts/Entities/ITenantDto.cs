namespace Lemon.App.Application.Contracts;

public interface ITenantDto<TKey>
{
    TKey TenantId { get; set;}
}