using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;

namespace Lemon.Template.Application
{
    public static class AccessTokenGenerator
    {
        public static string Create(string userId, 
            List<string> permissions, 
            DateTime expires,
            string securityKey,
            string issuer,
            string audience)
        {
            var claims = new List<Claim> { new Claim(JwtClaimTypes.Subject, userId) };
            claims.AddRange(permissions.Select(permission => new Claim("permission", permission)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}