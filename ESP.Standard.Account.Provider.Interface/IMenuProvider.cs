using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider.Interface
{
    public interface IMenuProvider
    {
        int CreateMenu(int tenantId, int operatorId, Menu menu);

        void UpdateMenu(int tenantId, int operatorId, Menu menu);

        Menu GetMenu(int tenantId, int operatorId, int id);

        IList<Menu> GetMenus(int tenantId, int operatorId);
    }
}
