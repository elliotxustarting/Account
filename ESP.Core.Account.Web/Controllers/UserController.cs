using System;
using ESP.Core.Account.Web.Models.User;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class UserController : Controller
    {
        private IOrganizationProvider _organizationProvider;

        private IUserProvider _userProvider;


        public UserController(IOrganizationProvider organizationProvider, IUserProvider userProvider)
        {
            _organizationProvider = organizationProvider;
            _userProvider = userProvider;
        }

        public JsonResult Index()
        {
            _userProvider.CreateUser(1, 1, new Standard.Account.Provider.Model.User
            {
                RealName = "xuyan"
            });
            return Json("");
        }

        [HttpGet]
        public JsonResult Search(UserSearchParameter parameter)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Create(UserVM user)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Update(UserVM user)
        {
            return Json("");
        }
    }
}
