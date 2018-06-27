using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    /// <summary>
    /// Permission provider.
    /// </summary>
    public class PermissionProvider : IPermissionProvider
    {
        private PermissionDao _permissionDao = new PermissionDao();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.PermissionProvider"/> class.
        /// </summary>
        public PermissionProvider()
        {
        }

        /// <summary>
        /// Creates the permission.
        /// </summary>
        /// <returns>The permission.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="permission">Permission.</param>
        public int CreatePermission(int tenantId, int operatorId, Permission permission)
        {
            return _permissionDao.CreatePermission(tenantId, operatorId, new PermissionDO
            {
                Id = permission.Id,
                Name = permission.Name
            });
        }

        /// <summary>
        /// Gets the permission.
        /// </summary>
        /// <returns>The permission.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public Permission GetPermission(int tenantId, int operatorId, int id)
        {
            var permission = _permissionDao.GetPermission(tenantId, operatorId, id);
            return new Permission
            {
                Id = permission.Id,
                Name = permission.Name
            };
        }

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <returns>The permissions.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<Permission> GetPermissions(int tenantId, int operatorId)
        {
            return _permissionDao.GetPermissions(tenantId, operatorId).Select(permission => new Permission
            {
                Id = permission.Id,
                Name = permission.Name
            }).ToList();
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="permission">Permission.</param>
        public void UpdatePermission(int tenantId, int operatorId, Permission permission)
        {
            _permissionDao.UpdatePermission(tenantId, operatorId, new PermissionDO
            {
                Id = permission.Id,
                Name = permission.Name
            });
        }
    }
}
