using System;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class ElementController : Controller
    {
        private readonly IElementProvider _elementProvider;

        public ElementController(IElementProvider elementProvider)
        {
            _elementProvider = elementProvider;
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
