using System;
using System.Collections.Generic;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    /// <summary>
    /// Permission DAO.
    /// </summary>
    public class PermissionDao : AccountBaseDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.PermissionDao"/> class.
        /// </summary>
        public PermissionDao() : base("Account")
        {
        }

        /// <summary>
        /// Creates the permission.
        /// </summary>
        /// <returns>The permission.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="permission">Permission.</param>
        public int CreatePermission(int tenantId, int operatorId, PermissionDO permission)
        {
            return (int)SafeProcedure.ExecuteScalar(Database,
                "Proc_Permission_Create"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("name", permission.Name);
                });
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <returns><c>true</c>, if permission was updated, <c>false</c> otherwise.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="permission">Permission.</param>
        public bool UpdatePermission(int tenantId, int operatorId, PermissionDO permission)
        {
            SafeProcedure.ExecuteNonQuery(Database,
                "Proc_Permission_Update"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", permission.Id);
                    parameters.AddWithValue("name", permission.Name);
                });
            return false;
        }

        /// <summary>
        /// Gets the permission.
        /// </summary>
        /// <returns>The permission.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public PermissionDO GetPermission(int tenantId, int operatorId, int id)
        {
            return SafeProcedure.ExecuteAndGetInstance<PermissionDO>(Database,
                "Proc_Permission_Get_By_Id"
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
        /// Gets the permissions.
        /// </summary>
        /// <returns>The permissions.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<PermissionDO> GetPermissions(int tenantId, int operatorId)
        {
            return SafeProcedure.ExecuteAndGetInstanceList<PermissionDO>(Database,
                "Proc_Permission_List"
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
