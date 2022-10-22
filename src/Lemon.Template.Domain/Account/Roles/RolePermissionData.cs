using Lemon.App.Core.ExceptionExtensions;
using Lemon.App.Domain.Entities;

namespace Lemon.Template.Domain.Account.Roles
{
    public class RolePermissionData : Entity<long>
    {
        public RolePermissionData()
        {
        }

        public RolePermissionData(long roleId, string permission)
        {
            Check.NotNullOrWhiteSpace(permission, nameof(permission));
            RoleId = roleId;
            Permission = permission;
        }

        public long RoleId { get; set; }

        public string Permission { get; set; }
    }
}