﻿using System;
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
            return Json("");
        }

        public JsonResult Table()
        {
            return Json("");
        }
    }
}