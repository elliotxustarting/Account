using System;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class UserDao : AccountBaseDao
    {
        public UserDao() : base("Account")
        {
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        public long CreateUser(int tenantId, int operatorId, UserDO user)
        {
            return (long)SafeProcedure.ExecuteScalar(Database,
                "Proc_User_Create"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("name", user.Name);
                    parameters.AddWithValue("orgid", user.OrgId);
                });
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <returns><c>true</c>, if user was updated, <c>false</c> otherwise.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        public bool UpdateUser(int tenantId, int operatorId, UserDO user)
        {
            SafeProcedure.ExecuteNonQuery(Database,
                "Proc_User_Update"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", user.Id);
                    parameters.AddWithValue("realname", user.Name);
                    parameters.AddWithValue("pid", user.OrgId);
                });
            return true;
        }

        public UserDO GetUser(int tenantId, int operatorId, int id)
        {
            return SafeProcedure.ExecuteAndGetInstance<UserDO>(Database,
                "Fun_User_Get_By_Id"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
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
