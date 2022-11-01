using System.Security.Claims;

namespace Lemon.App.Authentication.Security;

public interface ICurrentUser
{
    string? Id { get; }

    string UserName { get; }

    string Name { get; }
    
    string PhoneNumber { get; }

    bool PhoneNumberVerified { get; }

    string Email { get; }

    bool EmailVerified { get; }

    string? TenantId { get; }

    string[] Roles { get; }

    string[] Permissions { get; }

    Claim? FindClaim(string claimType);

    Claim[] FindClaims(string claimType);

    Claim[] GetAllClaims();

    bool IsInRole(string roleName);

    bool IsInPermission(string permission);
}