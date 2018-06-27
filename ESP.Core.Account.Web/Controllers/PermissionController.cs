using System;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IPermissionProvider _permissionProvider;

        public PermissionController(IPermissionProvider permissionProvider)
        {
            _permissionProvider = permissionProvider;
        }
    }
}
