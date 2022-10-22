
namespace Lemon.App.Application.Contracts.Entities
{
    public interface IEntityDto<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value>The identifier.</value>
        TKey Id { get; }
    }
}       