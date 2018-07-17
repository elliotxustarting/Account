using ESP.Core.Account.Web.Models.Oraganization;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Data.PostgreSql;
using Microsoft.AspNetCore.Mvc;

namespace ESP.Core.Account.Web.Controllers
{
    public class OrganizationController : Controller
    {

        private IOrganizationProvider _organizationProvider;

        private IUserProvider _userProvider;

        private int _tenantId;
        private int _operatorId;

        public OrganizationController(IOrganizationProvider organizationProvider, IUserProvider userProvider)
        {
            _organizationProvider = organizationProvider;
            _userProvider = userProvider;
            _tenantId = 0;
            _operatorId = 0;
        }

        [HttpGet]
        public JsonResult Search(OraganizationSearchParameter parameter)
        {
            var result = _organizationProvider.Search(_tenantId, _operatorId, parameter.PId, parameter.Paging, parameter.SortedFields);
            return Json(result);
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
