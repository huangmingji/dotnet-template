#nullable enable
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Lemon.App.Core.Extend;
using Microsoft.AspNetCore.Http;

namespace Lemon.App.Authentication.Security;

public class CurrentUser : ICurrentUser
{
   private readonly IHttpContextAccessor _httpContextAccessor;
   public CurrentUser(IHttpContextAccessor httpContextAccessor)
   {
       _httpContextAccessor = httpContextAccessor;
   }
    
   public string? Id
   {
       get
       {
           var id = FindClaim(JwtClaimTypes.Subject)?.Value ?? "";
           if(string.IsNullOrWhiteSpace(id)) return null;
           return id;
       }
   }
   public string UserName => FindClaim(JwtClaimTypes.Name)?.Value ?? "";
   public string Name => FindClaim(JwtClaimTypes.NickName)?.Value ?? "";
   public string PhoneNumber => FindClaim(JwtClaimTypes.PhoneNumber)?.Value ?? "";
   public bool PhoneNumberVerified => FindClaim(JwtClaimTypes.PhoneNumberVerified)?.Value.ToBool() ?? false;
   public string Email => FindClaim(JwtClaimTypes.Email)?.Value ?? "";
   public bool EmailVerified => FindClaim(JwtClaimTypes.EmailVerified)?.Value.ToBool() ?? false;
   public string? TenantId => FindClaim("tenant_id")?.Value ?? "";
   public string[] Roles => FindClaims(JwtClaimTypes.Role).ToList().ConvertAll(x => x.Value).ToArray();
   public string[] Permissions => FindClaims("permission").ToList().ConvertAll(x => x.Value).ToArray();

   public Claim? FindClaim(string claimType)
   {
       return GetAllClaims().FirstOrDefault(x => x.Type == claimType);
   }

   public Claim[] FindClaims(string claimType)
   {
       return GetAllClaims().Where(x => x.Type == claimType).ToArray();
   }

   public Claim[] GetAllClaims()
   {
        return _httpContextAccessor.HttpContext?.User.Claims.ToArray() ?? new Claim[0];
   }

   public bool IsInRole(string roleName)
   {
       return FindClaims(JwtClaimTypes.Role).Any(x => x.Value == roleName);
   }

   public bool IsInPermission(string permission)
   {
       return FindClaims("permission").Any(x => x.Value == permission);
   }
}