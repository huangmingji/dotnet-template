
namespace Lemon.App.Domain.Entities
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