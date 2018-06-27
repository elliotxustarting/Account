using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider.Interface
{
    public interface IPermissionProvider
    {
        int CreatePermission(int tenantId, int operatorId, Permission permission);

        void UpdatePermission(int tenantId, int operatorId, Permission permission);

        Permission GetPermission(int tenantId, int operatorId, int id);

        IList<Permission> GetPermissions(int tenantId, int operatorId);
    }
}
