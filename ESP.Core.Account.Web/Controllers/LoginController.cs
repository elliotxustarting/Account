using System;
using ESP.Core.Account.Web.Filter;
using ESP.Core.Account.Web.Models.Login;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserProvider _userProvider;

        private int _tenantId;

        private int _operatorId;

        public LoginController(IUserProvider userProvider)
        {
            _tenantId = 0;
            _operatorId = 0;
            _userProvider = userProvider;
        }

        [RestApi]
        [HttpPost]
        public JsonResult Login(LoginParameter parameter)
        {
            var code = string.Empty;
            var success = _userProvider.Login(_tenantId, _operatorId, parameter.UserName, parameter.Password, parameter.CheckCode, out code);
            return Json(new
            {
                success,
                code
            });
        }
    }
}
