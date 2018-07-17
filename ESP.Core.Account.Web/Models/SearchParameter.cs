using System;
using System.Collections.Generic;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Core.Account.Web.Models
{
    public class SearchParameter
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public PagingObject Paging { get; set; }

        public List<SortedField> SortedFields { get; set; }
    }
}
