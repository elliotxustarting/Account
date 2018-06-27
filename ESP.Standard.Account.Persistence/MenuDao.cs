using System;
using System.Collections.Generic;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class MenuDao : AccountBaseDao
    {
        public MenuDao() : base("Account")
        {
            
        }

        /// <summary>
        /// Creates the menu.
        /// </summary>
        /// <returns>The menu.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="menu">Menu.</param>
        public int CreateMenu(int tenantId, int operatorId, MenuDO menu)
        {
            return (int)SafeProcedure.ExecuteScalar(Database,
                "Proc_Menu_Create"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("name", menu.Name);
                });
        }

        /// <summary>
        /// Updates the menu.
        /// </summary>
        /// <returns><c>true</c>, if menu was updated, <c>false</c> otherwise.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="menu">Menu.</param>
        public bool UpdateMenu(int tenantId, int operatorId, MenuDO menu)
        {
            SafeProcedure.ExecuteNonQuery(Database,
                "Proc_Menu_Update"
                , parameters =>
                {
                    parameters.AddWithValue("tenantid", tenantId);
                    parameters.AddWithValue("operatorid", operatorId);
                    parameters.AddWithValue("id", menu.Id);
                    parameters.AddWithValue("name", menu.Name);
                });
            return false;
        }

        /// <summary>
        /// Gets the menu.
        /// </summary>
        /// <returns>The menu.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public MenuDO GetMenu(int tenantId, int operatorId, int id)
        {
            return SafeProcedure.ExecuteAndGetInstance<MenuDO>(Database,
                "Proc_Menu_Get_By_Id"
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
        /// Gets the menus.
        /// </summary>
        /// <returns>The menus.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<MenuDO> GetMenus(int tenantId, int operatorId)
        {
            return SafeProcedure.ExecuteAndGetInstanceList<MenuDO>(Database,
                "Proc_Menu_List"
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
