﻿using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

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
            permission.CreatedBy = operatorId;
            permission.CreatedTime = DateTime.Now;
            permission.UpdatedBy = operatorId;
            permission.UpdatedTime = DateTime.Now;
            var entity = permission.ToDataObject();
            return _permissionDao.CreatePermission(tenantId, operatorId, entity);
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
            Permission permission = null;
            var permissionDo = _permissionDao.GetPermission(tenantId, operatorId, id);
            if(permissionDo!=null)
            {
                permission = permissionDo.ToBusinessObject();
            }
            return permission;
        }

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <returns>The permissions.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<Permission> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _permissionDao.GetPermissions(tenantId, operatorId, paging, sortedFields).Select(permission => permission.ToBusinessObject()).ToList();
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="permission">Permission.</param>
        public void UpdatePermission(int tenantId, int operatorId, Permission permission)
        {
            permission.UpdatedBy = operatorId;
            permission.UpdatedTime = DateTime.Now;
            var entity = permission.ToDataObject();
            _permissionDao.UpdatePermission(tenantId, operatorId, entity);
        }
    }
}
