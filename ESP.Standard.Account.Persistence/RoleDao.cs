using System;
using System.Collections.Generic;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class RoleDao: AccountBaseDao
    {
        public RoleDao() : base("Account")
        {
        }

        public int CreateRole(int tenantId, int operatorId, RoleDO role)
        {
            return (int)SafeProcedure.ExecuteScalar(Database,
                "Proc_Role_Create"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("name", role.Name);
                });
        }

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <returns><c>true</c>, if role was updated, <c>false</c> otherwise.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="role">Org.</param>
        public bool UpdateRole(int tenantId, int operatorId, RoleDO role)
        {
            SafeProcedure.ExecuteNonQuery(Database,
                "Proc_Role_Update"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", role.Id);
                    parameters.AddWithValue("name", role.Name);
                });
            return false;
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <returns>The role.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public RoleDO GetRole(int tenantId, int operatorId, int id)
        {
            return SafeProcedure.ExecuteAndGetInstance<RoleDO>(Database,
                "Proc_Role_Get_By_Id"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", id);
                }
                , (record, entity) =>
                {
                    entity.Id = record.Get<int>("id");
                    entity.Name = record.Get<string>("name");
                });
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>The roles.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<RoleDO> GetRoles(int tenantId, int operatorId)
        {
            return SafeProcedure.ExecuteAndGetInstanceList<RoleDO>(Database,
                "Proc_Role_List"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                }
                , (record, entity) =>
                {
                    entity.Id = record.Get<int>("id");
                    entity.Name = record.Get<string>("name");
                });
        }
    }
}
