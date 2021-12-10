using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NengLong.Mailbox.Data
{
    public class EntityIdentity
    {

        /// <summary>
        /// 主键
        /// </summary>
        /// <value>The identifier.</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; protected set; }


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
