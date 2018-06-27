using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ESP.Core.Account.Web.Models;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Provider.Interface;

namespace ESP.Core.Account.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrganizationProvider _organizationProvider;

        private readonly IUserProvider _userProvider;

        public HomeController(IOrganizationProvider organizationProvider, IUserProvider userProvider)
        {
            _organizationProvider = organizationProvider;
            _userProvider = userProvider;
        }


        public IActionResult Index()
        {
            //var user = _userProvider.GetUser(1, 1, 1);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
