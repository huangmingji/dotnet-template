using System.Collections.Generic;
using Lemon.Template.Domain.Shared;

namespace Lemon.Template.Domain.Account.Role
{
    /// <summary>
    /// 角色表
    /// </summary>
    public sealed class RoleData : Entity
    {
        public RoleData()
        {
        }


        public RoleData(string name, bool isDefault, bool isStatic, bool isPublic)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            
            Name = name;
            IsDefault = isDefault;
            IsStatic = isStatic;
            IsPublic = isPublic;
        }
        
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 默认角色自动分配给新用户
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 静态角色无法删除/重命名
        /// </summary>
        /// <returns></returns>
        public bool IsStatic { get; set; }

        /// <summary>
        /// 允许其他用户查看，一般只有超管才分配为 false 的角色
        /// </summary>
        /// <returns></returns>
        public bool IsPublic { get; set; }

        public List<RolePermissionData> RolePermissionDatas { get; set; } = new List<RolePermissionData>();

    }
}