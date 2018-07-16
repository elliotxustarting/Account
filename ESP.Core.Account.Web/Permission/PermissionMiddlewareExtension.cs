using System;
using Microsoft.AspNetCore.Builder;

namespace ESP.Core.Account.Web.Permission
{
    public static class PermissionMiddlewareExtension
    {
        public static IApplicationBuilder UsePermission(this IApplicationBuilder builder, PermissionMiddlewareOption option)
        {
            return builder.UseMiddleware<PermissionMiddleware>(option);
        }
    }
}
