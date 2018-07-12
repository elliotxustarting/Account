using ESP.Core.Account.Web.Models.Oraganization;
using ESP.Standard.Account.Provider.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class OrganizationController : Controller
    {

        private IOrganizationProvider _organizationProvider;

        private IUserProvider _userProvider;


        public OrganizationController(IOrganizationProvider organizationProvider, IUserProvider userProvider)
        {
            _organizationProvider = organizationProvider;
            _userProvider = userProvider;
        }

        [HttpGet]
        public JsonResult Search(OraganizationSearchParameter parameter)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Create(OraganizationVM organization)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult Update(OraganizationVM organization)
        {
            return Json("");
        }
    }
}
