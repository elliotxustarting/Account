using System;
namespace ESP.Standard.Data.PostgreSql
{
    public static class PagingExtension
    {
        public static string Paging(this string sql, PagingObject pagingObject)
        {
            var offset = (pagingObject.PageIndex - 1) * pagingObject.PageSize;
            sql += string.Format(" LIMIT {0} OFFSET {1}", pagingObject.PageSize, offset);
            return sql;
        }
    }
}
