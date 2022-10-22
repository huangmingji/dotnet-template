
using Lemon.App.Application.Contracts.Entities;
using Lemon.Template.Application.Contracts.Account.Roles.Dtos;

namespace Lemon.Template.Application.Contracts.Account.Users.Dtos
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRoleDto : EntityDto<long>
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// 角色主键
        /// </summary>
        public long RoleId { get; set; }

        public RoleDataDto RoleData { get; set; }
    }
}