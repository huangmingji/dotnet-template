using Lemon.App.Domain.Entities;
using Lemon.Template.Domain.Account.Roles;

namespace Lemon.Template.Domain.Account.Users
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRole : Entity<long>
    {
        public UserRole()
        {
        }

        public UserRole(long userId, long roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// 用户主键
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// 角色主键
        /// </summary>
        public long RoleId { get; set; }

        public RoleData RoleData { get; set; }
    }
}