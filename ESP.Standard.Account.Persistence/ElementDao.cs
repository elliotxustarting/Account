using System;
using System.Collections.Generic;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    /// <summary>
    /// Element DAO.
    /// </summary>
    public class ElementDao : AccountBaseDao
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
            return (int)SafeProcedure.ExecuteScalar(Database,
                "Proc_Element_Create"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("name", element.Name);
                });
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
            SafeProcedure.ExecuteNonQuery(Database,
                "Proc_Element_Update"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", element.Id);
                    parameters.AddWithValue("name", element.Name);
                });
            return false;
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
            return SafeProcedure.ExecuteAndGetInstance<ElementDO>(Database,
                "Proc_Element_Get_By_Id"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", id);
                }
                , (record, entity) =>
                {
                    entity.Id = record.Get<int>("id");
                    entity.Name = record.Get<string>("name");
                });
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns>The elements.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<ElementDO> GetElements(int tenantId, int operatorId)
        {
            return SafeProcedure.ExecuteAndGetInstanceList<ElementDO>(Database,
                "Proc_Element_List"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                }
                , (record, entity) =>
                {
                    entity.Id = record.Get<int>("id");
                    entity.Name = record.Get<string>("name");
                });
        }
    }
}
