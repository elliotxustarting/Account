using System.Security.Claims;
using System.Threading.Tasks;
using ESP.Core.Account.Web.Filter;
using ESP.Core.Account.Web.Models.Login;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserProvider _userProvider;

        public LoginController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [AllowAnonymous]
        [RestApi]
        [HttpGet]
        public JsonResult Index()
        {
            return Json("");
        }

        [AllowAnonymous]
        [RestApi]
        [HttpPost]
        public async Task<JsonResult> Login(LoginParameter parameter)
        {
            var code = string.Empty;
            var user = _userProvider.Login(parameter.UserName, parameter.Password, parameter.CheckCode, out code);
            if (user != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, parameter.UserName));
                identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/tenant", user.TenantId.ToString()));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }

            return Json(new
            {
                success = user != null,
                code
            });
        }

        [RestApi]
        [HttpGet]
        public async Task<JsonResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Json(new
            {
                success = true
            });
        }
    }
}
