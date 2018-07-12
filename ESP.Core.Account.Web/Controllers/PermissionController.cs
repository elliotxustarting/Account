using System;
using ESP.Core.Account.Web.Models.Permission;
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

        [HttpGet]
        public JsonResult Search(PermissionSearchParameter parameter)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Create(PermissionVM permission)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Update(PermissionVM permission)
        {
            return Json("");
        }
    }
}
