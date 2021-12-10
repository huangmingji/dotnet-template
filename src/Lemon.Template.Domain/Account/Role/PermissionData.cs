using Lemon.Template.Domain.Shared;

namespace Lemon.Template.Domain.Account.Role
{
    /// <summary>
    /// 权限
    /// </summary>
    public sealed class PermissionData : Entity
    {
        public PermissionData()
        {
        }

        public PermissionData(string name, string permission, string parentId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(permission, nameof(permission));
            
            ParentId = parentId;
            Name = name;
            Permission = permission;
        }

        public void Set(string name, string permission, string parentId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(permission, nameof(permission));
            ParentId = parentId;
            Name = name;
            Permission = permission;
        }

        /// <summary>
        /// 上级主键
        /// </summary>
        public string ParentId { get; set; }
        
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 权限
        /// </summary>
        public string Permission { get; set; }
    }
}