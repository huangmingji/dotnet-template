
using System;

namespace Lemon.App.Application.Contracts.Entities;

public class EntityDto<TKey> : IEntityDto<TKey> where TKey : notnull
{
    public virtual TKey Id { get; set; }
    /// <summary>
    /// 新增人员
    /// </summary>
    public long CreatorId { get; protected set; }

    /// <summary>
    /// 新增时间
    /// </summary>
    public DateTime CreationTime { get; protected set; } = DateTime.Now;

    /// <summary>
    /// 修改人
    /// </summary>
    public long LastModifierId { get; protected set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime LastModifyTime { get; protected set; } = DateTime.Now;
}