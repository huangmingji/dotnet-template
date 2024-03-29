﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lemon.App.Authentication.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Lemon.App.Authentication
{
    public static class AuthenticationExtensions
    {

        /// <summary>
        /// 使用cookie验证
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void UseCookieAuthentication(this IServiceCollection services, List<string> permissions)
        {
            services.AddAuthorization(options =>
                {
                    foreach (var permission in permissions)
                    {
                        options.AddPolicy(permission, policy => policy.Requirements.Add(new PermissionRequirement(permission)));
                    }
                })
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, c =>
                {
                    c.LoginPath = new PathString("/user/login");
                    c.Events.OnRedirectToLogin = (context) =>
                    {
                        if (context.Request.IsAjax())
                        {
                            context.HttpContext.Response.StatusCode = 401;
                        }
                        else
                        {
                            context.Response.Redirect(context.RedirectUri);
                        }
                        context.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                });
            services.AddTransient<IAuthorizationHandler, PermissionHandler>();
            services.AddScoped<ICurrentUser, CurrentUser>();
        }

        public static void UseJwtBearerAuthentication(this IServiceCollection services, List<string> permissions)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>() ?? throw new NullReferenceException();
            services.AddAuthorization(options =>
            {
                foreach (var permission in permissions)
                {
                    options.AddPolicy(permission, policy => policy.Requirements.Add(new PermissionRequirement(permission)));
                }
            }).AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                (jwtBearerOptions) =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecurityKey").Value)),//秘钥
                        ValidateIssuer = true,
                        ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
                        ValidateAudience = true,
                        ValidAudience = configuration.GetSection("Jwt:Audience").Value,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1),
                        RequireExpirationTime = true
                    };
                }
            );
            services.AddHttpContextAccessor();
            // services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthorizationHandler, PermissionHandler>();
            // services.AddScoped<ICurrentUser, CurrentUser>();
        }
    }
}
