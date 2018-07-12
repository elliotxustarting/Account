using System;
namespace ESP.Standard.Data.PostgreSql
{
    public class SortedField
    {
        public SortedField()
        {
        }

        public string Field { get; set; }

        public SortedDirection Direction { get; set; }
    }
}
