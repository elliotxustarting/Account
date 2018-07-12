using System;
namespace ESP.Core.Account.Web.Models
{
    public class SearchParameter
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string SortField { get; set; }

        public SortEnum Sort { get; set; }
    }
}
