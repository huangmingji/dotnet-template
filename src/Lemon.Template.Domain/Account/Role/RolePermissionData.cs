using Lemon.Template.Domain.Shared;

namespace Lemon.Template.Domain.Account.Role
{
    public class RolePermissionData : Entity
    {
        public RolePermissionData()
        {
        }

        public RolePermissionData(string roleId, string permission)
        {
            Check.NotNullOrWhiteSpace(permission, nameof(permission));
            RoleId = roleId;
            Permission = permission;
        }

        public string RoleId { get; set; }

        public string Permission { get; set; }
    }
}