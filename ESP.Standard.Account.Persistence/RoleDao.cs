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
            Execute("INSERT INTO public.role (name) VALUES(@name)", role);
            return role.Id;
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
            Execute("UPDATE public.role SET name = @name WHERE id = @Id", role);
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
            return Query<RoleDO>("SELECT * FROM public.role WHERE id = @id", new { Id = id }).FirstOrDefault();
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>The roles.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<RoleDO> GetRoles(int tenantId, int operatorId)
        {
            return Query<RoleDO>("SELECT * FROM public.role");
        }
    }
}
