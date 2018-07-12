using System;
using ESP.Core.Account.Web.Models.Role;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleProvider _roleProvider;

        public RoleController(IRoleProvider roleProvider)
        {
            _roleProvider = roleProvider;
        }

        [HttpGet]
        public JsonResult Search(RoleSearchParameter parameter)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Create(RoleVM role)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Update(RoleVM role)
        {
            return Json("");
        }
    }
}
