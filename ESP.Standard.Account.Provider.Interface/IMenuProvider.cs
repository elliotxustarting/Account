using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider.Interface
{
    public interface IMenuProvider
    {
        int CreateMenu(int tenantId, int operatorId, Menu menu);

        void UpdateMenu(int tenantId, int operatorId, Menu menu);

        Menu GetMenu(int tenantId, int operatorId, int id);

        IList<Menu> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields);
    }
}
