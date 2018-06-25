using System;
using System.Collections.Generic;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    /// <summary>
    /// Organization DAO.
    /// </summary>
    public class OrganizationDao : AccountBaseDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.OrganizationDao"/> class.
        /// </summary>
        public OrganizationDao() : base("Account")
        {
        }

        /// <summary>
        /// Creates the organization.
        /// </summary>
        /// <returns>The organization.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="org">Org.</param>
        public long CreateOrganization(int tenantId, int operatorId, OrganizationDO org)
        {
            return (long)SafeProcedure.ExecuteScalar(Database,
                "Proc_Organization_Create"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("name", org.Name);
                    parameters.AddWithValue("pid", org.ParentId);
                });
        }

        /// <summary>
        /// Updates the organization.
        /// </summary>
        /// <returns><c>true</c>, if organization was updated, <c>false</c> otherwise.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="org">Org.</param>
        public bool UpdateOrganization(int tenantId, int operatorId, OrganizationDO org)
        {
            SafeProcedure.ExecuteNonQuery(Database,
                "Proc_Organization_Update"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", org.Id);
                    parameters.AddWithValue("name", org.Name);
                    parameters.AddWithValue("pid", org.ParentId);
                });
            return false;
        }

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <returns>The organization.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public OrganizationDO GetOrganization(int tenantId, int operatorId, int id)
        {
            return SafeProcedure.ExecuteAndGetInstance<OrganizationDO>(Database,
                "Proc_Organization_Get_By_Id"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", id);
                }
                , (record, entity) =>
                {
                    entity.Id = record.Get<long>("id");
                    entity.Name = record.Get<string>("name");
                    entity.ParentId = record.Get<long>("pid");
                });
        }

        /// <summary>
        /// Gets the organizations by level.
        /// </summary>
        /// <returns>The organizations by level.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="pId">P identifier.</param>
        public IList<OrganizationDO> GetOrganizationsByLevel(int tenantId, int operatorId, int pId)
        {
            return SafeProcedure.ExecuteAndGetInstanceList<OrganizationDO>(Database,
                "Proc_Organization_Get_By_Id"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", pId);
                }
                , (record, entity) =>
                {
                    entity.Id = record.Get<long>("id");
                    entity.Name = record.Get<string>("name");
                    entity.ParentId = record.Get<long>("pid");
                });
        }
    }
}
