using System;
namespace ESP.Standard.Data.PostgreSql
{
    public class PagingObject
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
