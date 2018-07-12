using System;
using System.Collections.Generic;

namespace ESP.Standard.Data.PostgreSql
{
    public static class SortedExtension
    {
        public static string Sort(this string sql, List<SortedField> sortedFields)
        {
            sql += " ORDER BY ";
            foreach(var field in sortedFields)
            {
                sql += field.Field;
                if (field.Direction == SortedDirection.ASC)
                    sql += " ASC";
                else
                    sql += " DESC";
            }
            return sql;
        }
    }
}
