
namespace Lemon.App.Domain.Shared.Entities
{
    public interface IEntity<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value>The identifier.</value>
        TKey Id { get; }
    }
}       