using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class RoleDao: BaseRepository
    {
        public RoleDao() : base("Account")
        {
        }

        public int CreateRole(int tenantId, int operatorId, RoleDO role)
        {
            return ExecuteScalar("INSERT INTO public.role (tenantid, name, description, createdby, createdtime, updatedby, updatedtime) VALUES(@tenantid,@name, @description, @createdby, @createdtime, @updatedby, @updatedtime) RETURNING id", role);
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
            Execute("UPDATE public.role SET name = @name, updatedby=@updatedby, updatedtime=@updatedtime WHERE tenantid=@tenantid and id = @Id", role);
            return true;
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
            return Query<RoleDO>("SELECT * FROM public.role WHERE tenantid=@tenantid and id = @id", new { TenantId = tenantId, Id = id }).FirstOrDefault();
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>The roles.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<RoleDO> GetRoles(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            var sql = "SELECT * FROM public.role WHERE tenantid=@tenantid";
            sql = sql.Sort(sortedFields);
            if (paging != null)
            {
                sql = sql.Paging(paging);
            }
            return Query<RoleDO>(sql, new { TenantId = tenantId });
        }
    }
}
