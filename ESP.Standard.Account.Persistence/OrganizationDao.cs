using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    /// <summary>
    /// Organization DAO.
    /// </summary>
    public class OrganizationDao : BaseRepository
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
            var sql = "INSERT INTO public.organization (tenantid, name, parentid, description, createdby, createdtime, updatedby, updatedtime) VALUES(@tenantid,@name,@parentid, @description, @createdby, @createdtime, @updatedby, @updatedtime) RETURNING id";
            return ExecuteScalar<long>(sql, org);
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
            var sql = "UPDATE public.organization SET name = @name, updatedby=@updatedby, updatedtime=@updatedtime WHERE tenantid=@tenantid and id = @Id";
            Execute(sql, org);
            return true;
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
            var sql = "SELECT * FROM public.organization WHERE tenantid=@tenantid and id = @id";
            return Query<OrganizationDO>(sql, new { tenantId, id }).FirstOrDefault();
        }

        /// <summary>
        /// Gets the organizations by level.
        /// </summary>
        /// <returns>The organizations by level.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="pId">P identifier.</param>
        public IList<OrganizationDO> GetOrganizationsByLevel(int tenantId, int operatorId, int pId, PagingObject paging, List<SortedField> sortedFields)
        {
            var sql = "SELECT * FROM public.organization where tenantid=@tenantid and parentid=@pid";
            sql = sql.Sort(sortedFields);
            if (paging != null)
            {
                sql = sql.Paging(paging);
            }
            return Query<OrganizationDO>(sql, new { tenantId, pId });
        }
    }
}
