using Lemon.App.Application.Contracts.Entities;

namespace Lemon.Template.Application.Contracts.Account.Roles.Dtos
{
    public class RolePermissionDataDto : EntityDto<long>
    {
        public long RoleId { get; set; }

        public string Permission { get; set; }
    }
}