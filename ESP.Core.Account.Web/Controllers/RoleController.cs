using System;
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

        public JsonResult Create()
        {
            return Json("");
        }

        public JsonResult Index()
        {
            return Json("");
        }

        public JsonResult Table()
        {
            return Json("");
        }
    }
}
