using System;
using ESP.Core.Account.Web.Models.Menu;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuProvider _menuProvider;

        public MenuController(IMenuProvider menuProvider)
        {
            _menuProvider = menuProvider;
        }

        [HttpGet]
        public JsonResult Search(MenuSearchParameter parameter)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Create(MenuVM organization)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Update(MenuVM organization)
        {
            return Json("");
        }
    }
}
