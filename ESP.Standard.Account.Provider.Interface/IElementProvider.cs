using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider.Interface
{
    public interface IElementProvider
    {
        int CreateElement(int tenantId, int operatorId, Element element);

        void UpdateElement(int tenantId, int operatorId, Element element);

        Element GetElement(int tenantId, int operatorId, int id);

        IList<Element> GetElements(int tenantId, int operatorId);
    }
}
