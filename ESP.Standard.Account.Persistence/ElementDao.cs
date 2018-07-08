using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    /// <summary>
    /// Element DAO.
    /// </summary>
    public class ElementDao : BaseRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.ElementDao"/> class.
        /// </summary>
        public ElementDao() : base("Account")
        {
        }

        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <returns>The element.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="element">Element.</param>
        public int CreateElement(int tenantId, int operatorId, ElementDO element)
        {
            Execute("INSERT INTO public.element (name) VALUES(@name)", element);
            return element.Id;
        }

        /// <summary>
        /// Updates the element.
        /// </summary>
        /// <returns><c>true</c>, if element was updated, <c>false</c> otherwise.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="element">Element.</param>
        public bool UpdateElement(int tenantId, int operatorId, ElementDO element)
        {
            Execute("UPDATE public.element SET name = @name WHERE id = @Id", element);
            return true;
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <returns>The element.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public ElementDO GetElement(int tenantId, int operatorId, int id)
        {
            return Query<ElementDO>("SELECT * FROM public.element WHERE id = @id", new { Id = id }).FirstOrDefault();
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns>The elements.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<ElementDO> GetElements(int tenantId, int operatorId)
        {
            return Query<ElementDO>("SELECT * FROM public.element");
        }
    }
}
