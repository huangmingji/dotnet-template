using Lemon.App.Core.ExceptionExtensions;
using Lemon.App.Domain.Entities;

namespace Lemon.Template.Domain.Account.Roles
{
    /// <summary>
    /// 权限
    /// </summary>
    public sealed class PermissionData : Entity<long>
    {
        public PermissionData()
        {
        }

        public PermissionData(string name, string permission, long parentId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(permission, nameof(permission));
            
            ParentId = parentId;
            Name = name;
            Permission = permission;
        }

        public void Set(string name, string permission, long parentId)
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
        public long ParentId { get; set; }
        
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