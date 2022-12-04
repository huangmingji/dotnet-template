using System;
using Lemon.App.Domain.Shared.Entities;

namespace Lemon.App.Domain.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey> where TKey : notnull
    {

        public virtual TKey Id { get; protected set; }

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


        public void UpdateCreator(long creatorId)
        {
            this.CreatorId = creatorId;
            this.CreationTime = DateTime.Now;
        }

        public void UpdateModifier(long lastModifierId)
        {
            this.LastModifierId = lastModifierId;
            this.LastModifyTime = DateTime.Now;
        }
    }
}
