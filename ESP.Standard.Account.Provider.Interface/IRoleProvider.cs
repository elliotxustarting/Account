using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider.Interface
{
    public interface IRoleProvider
    {
        int CreateRole(int tenantId, int operatorId, Role role);

        void UpdateRole(int tenantId, int operatorId, Role role);

        Role GetRole(int tenantId, int operatorId, int id);

        IList<Role> GetRoles(int tenantId, int operatorId);
    }
}
