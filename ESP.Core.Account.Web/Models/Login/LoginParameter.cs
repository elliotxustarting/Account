using System;
namespace ESP.Core.Account.Web.Models.Login
{
    public class LoginParameter
    {
        public LoginParameter()
        {
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string CheckCode { get; set; }
    }
}
