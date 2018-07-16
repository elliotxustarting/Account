using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ESP.Core.Account.Web.Permission
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly PermissionMiddlewareOption _option;

        public PermissionMiddleware(RequestDelegate next, PermissionMiddlewareOption option)
        {
            _option = option;
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var questUrl = context.Request.Path.Value.ToLower();
            var isAuthenticated = context.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                return _next(context);
            }
            else
            {
                context.Response.Redirect(_option.NoPermissionAction);
            }
            return _next(context);
        }
    }
}
