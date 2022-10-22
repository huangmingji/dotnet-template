using AutoMapper;
using Lemon.Template.Application.Contracts.Account.Roles.Dtos;
using Lemon.Template.Application.Contracts.Account.Users.Dtos;
using Lemon.Template.Domain.Account.Roles;
using Lemon.Template.Domain.Account.Users;

namespace Lemon.Template.Application
{
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            CreateMap<UserData, UserDataDto>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<PermissionData, PermissionDataDto>();
            CreateMap<RolePermissionData, RolePermissionDataDto>();
            CreateMap<RoleData, RoleDataDto>();
        }
    }
}