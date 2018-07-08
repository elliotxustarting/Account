﻿using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    /// <summary>
    /// Permission DAO.
    /// </summary>
    public class PermissionDao : BaseRepository
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
            Execute("INSERT INTO public.permission (name) VALUES(@name)", permission);
            return permission.Id;
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
            Execute("UPDATE public.permission SET name = @name WHERE id = @Id", permission);
            return true;
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
            return Query<PermissionDO>("SELECT * FROM public.permission WHERE id = @id", new { Id = id }).FirstOrDefault();
        }

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <returns>The permissions.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<PermissionDO> GetPermissions(int tenantId, int operatorId)
        {
            return Query<PermissionDO>("SELECT * FROM public.permission");
        }
    }
}
