using System;
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
    }
}
