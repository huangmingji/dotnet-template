using Lemon.App.Application.Contracts.Entities;

namespace Lemon.Template.Application.Contracts.Account.Roles.Dtos
{
    /// <summary>
    /// 权限
    /// </summary>
    public sealed class PermissionDataDto : EntityDto<long>
    {

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