using System;

namespace Lemon.Template.Domain
{
    public class Entity
    {

        public Entity()
        {
            this.Id = IdGenerator.Create().ToString();
        }

        /// <summary>
        /// 主键
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; }
        
        /// <summary>
        /// 新增人员
        /// </summary>
        public string Adder { get; protected set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime AddTime { get; protected set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public string Modifier { get; protected set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; protected set; } = DateTime.Now;

        public void UpdateAdder(string adder)
        {
            this.Adder = adder;
            this.AddTime = DateTime.Now;
        }

        public void UpdateModifier(string modifier)
        {
            this.Modifier = modifier;
            this.ModifyTime = DateTime.Now;
        }
    }
}
