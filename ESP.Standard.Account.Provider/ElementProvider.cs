using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider
{
    /// <summary>
    /// Element provider.
    /// </summary>
    public class ElementProvider : IElementProvider
    {
        private ElementDao _elementDao = new ElementDao();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.ElementProvider"/> class.
        /// </summary>
        public ElementProvider()
        {
        }

        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <returns>The element.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="element">Element.</param>
        public int CreateElement(int tenantId, int operatorId, Element element)
        {
            element.CreatedBy = operatorId;
            element.CreatedTime = DateTime.Now;
            element.UpdatedBy = operatorId;
            element.UpdatedTime = DateTime.Now;
            var entity = element.ToDataObject();
            return _elementDao.CreateElement(tenantId, operatorId, entity);
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <returns>The element.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public Element GetElement(int tenantId, int operatorId, int id)
        {
            Element element = null;
            var elementDo = _elementDao.GetElement(tenantId, operatorId, id);
            if (elementDo != null)
            {
                element = elementDo.ToBusinessObject();
            }
            return element;
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns>The elements.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<Element> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _elementDao.GetElements(tenantId, operatorId, paging, sortedFields).Select(element => element.ToBusinessObject()).ToList();
        }

        /// <summary>
        /// Updates the element.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="element">Element.</param>
        public void UpdateElement(int tenantId, int operatorId, Element element)
        {
            element.UpdatedBy = operatorId;
            element.UpdatedTime = DateTime.Now;
            var entity = element.ToDataObject();
            _elementDao.UpdateElement(tenantId, operatorId, entity);
        }
    }
}
