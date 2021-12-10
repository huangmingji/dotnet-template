using Microsoft.AspNetCore.Authorization;

namespace Lemon.Template.Web.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
        
    }
}