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
        public long Adder { get; protected set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime AddTime { get; protected set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public long Modifier { get; protected set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; protected set; } = DateTime.Now;


        public void UpdateAdder(long adder)
        {
            this.Adder = adder;
            this.AddTime = DateTime.Now;
        }

        public void UpdateModifier(long modifier)
        {
            this.Modifier = modifier;
            this.ModifyTime = DateTime.Now;
        }
    }
}
