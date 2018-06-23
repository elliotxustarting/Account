using System;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class UserDao : AccountBaseDao
    {
        public UserDao():base("Account")
        {
        }

        public User GetUser(int tenantId, int userId, int id)
        {
            return SafeProcedure.ExecuteAndGetInstance<User>(Database,
                "Fun_User_Get_By_Id"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("id", id);
                }
                , (record, entity) =>
                {
                    entity.Id = record.Get<long>("id");
                    entity.Name = record.Get<string>("realname");
                    entity.OrgId = record.Get<long>("orgid");
                });
        }
    }
}
