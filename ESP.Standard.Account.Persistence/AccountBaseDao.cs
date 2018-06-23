using System;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class AccountBaseDao
    {
        protected Database Database;

        public AccountBaseDao(string instanceName)
        {
            Database = Database.GetDatabase(instanceName);
        }
    }
}
