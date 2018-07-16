using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ESP.Core.Account.Web.Permission
{
    public class PermissionMiddlewareOption
    {
        public string LoginAction { get; set; }

        public string NoPermissionAction { get; set; }
    }
}
