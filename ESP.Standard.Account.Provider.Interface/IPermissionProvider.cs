using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider.Interface
{
    public interface IPermissionProvider
    {
        int CreatePermission(int tenantId, int operatorId, Permission permission);

        void UpdatePermission(int tenantId, int operatorId, Permission permission);

        Permission GetPermission(int tenantId, int operatorId, int id);

        IList<Permission> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields);
    }
}
