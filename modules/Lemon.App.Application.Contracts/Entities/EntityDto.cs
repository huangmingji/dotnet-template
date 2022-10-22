
namespace Lemon.App.Application.Contracts.Entities;

public class EntityDto<TKey> : IEntityDto<TKey> where TKey : notnull
{
    public virtual TKey Id { get; set; }

    /// <summary>
    /// 新增人员
    /// </summary>
    public long Adder { get; set; }

    /// <summary>
    /// 新增时间
    /// </summary>
    public DateTime AddTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 修改人
    /// </summary>
    public long Modifier { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime ModifyTime { get; set; } = DateTime.Now;
}