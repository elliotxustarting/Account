using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider.Interface
{
    public interface IElementProvider
    {
        int CreateElement(int tenantId, int operatorId, Element element);

        void UpdateElement(int tenantId, int operatorId, Element element);

        Element GetElement(int tenantId, int operatorId, int id);

        IList<Element> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields);
    }
}
