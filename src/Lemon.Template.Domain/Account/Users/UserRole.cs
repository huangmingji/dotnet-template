using Lemon.Template.Domain.Account.Role;

namespace Lemon.Template.Domain.Account.Users
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRole : Entity
    {
        public UserRole()
        {
        }

        public UserRole(string userId, string roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// 角色主键
        /// </summary>
        public string RoleId { get; set; }

        public RoleData RoleData { get; set; }
    }
}