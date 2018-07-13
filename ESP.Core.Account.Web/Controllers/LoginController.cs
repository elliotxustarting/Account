using System;
using System.Security.Claims;
using ESP.Core.Account.Web.Filter;
using ESP.Core.Account.Web.Models.Login;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

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
        public async Task<JsonResult> Login(LoginParameter parameter)
        {
            var code = string.Empty;
            var success = _userProvider.Login(_tenantId, _operatorId, parameter.UserName, parameter.Password, parameter.CheckCode, out code);
            if(success)
            {
                var user = _userProvider.GetUser(_tenantId, _operatorId, parameter.UserName);
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, parameter.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, ""));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }

            return Json(new
            {
                success,
                code
            });
        }
    }
}
