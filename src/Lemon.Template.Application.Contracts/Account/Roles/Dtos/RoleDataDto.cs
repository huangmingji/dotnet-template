using System.Collections.Generic;
using Lemon.App.Application.Contracts.Entities;

namespace Lemon.Template.Application.Contracts.Account.Roles.Dtos
{
    /// <summary>
    /// 角色表
    /// </summary>
    public sealed class RoleDataDto : EntityDto<long>
    {
        
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

        public List<RolePermissionDataDto> RolePermissionDatas { get; set; } = new();

    }
}