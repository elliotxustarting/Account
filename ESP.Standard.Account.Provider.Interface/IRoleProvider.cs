using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider.Interface
{
    public interface IRoleProvider
    {
        int CreateRole(int tenantId, int operatorId, Role role);

        void UpdateRole(int tenantId, int operatorId, Role role);

        Role GetRole(int tenantId, int operatorId, int id);

        IList<Role> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields);
    }
}
