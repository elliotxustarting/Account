using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider
{
    /// <summary>
    /// Menu provider.
    /// </summary>
    public class MenuProvider : IMenuProvider
    {
        private MenuDao _menuDao = new MenuDao();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.MenuProvider"/> class.
        /// </summary>
        public MenuProvider()
        {
        }

        /// <summary>
        /// Creates the menu.
        /// </summary>
        /// <returns>The menu.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="menu">Menu.</param>
        public int CreateMenu(int tenantId, int operatorId, Menu menu)
        {
            menu.CreatedBy = operatorId;
            menu.CreatedTime = DateTime.Now;
            menu.UpdatedBy = operatorId;
            menu.UpdatedTime = DateTime.Now;
            var entity = menu.ToDataObject();
            return _menuDao.CreateMenu(tenantId, operatorId, entity);
        }

        /// <summary>
        /// Gets the menu.
        /// </summary>
        /// <returns>The menu.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public Menu GetMenu(int tenantId, int operatorId, int id)
        {
            Menu menu = null;
            var menuDo = _menuDao.GetMenu(tenantId, operatorId, id);
            if (menuDo != null)
            {
                menu = menuDo.ToBusinessObject();
            }
            return menu;
        }

        /// <summary>
        /// Gets the menus.
        /// </summary>
        /// <returns>The menus.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<Menu> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _menuDao.GetMenus(tenantId, operatorId, paging, sortedFields).Select(menu => menu.ToBusinessObject()).ToList();
        }

        /// <summary>
        /// Updates the menu.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="menu">Menu.</param>
        public void UpdateMenu(int tenantId, int operatorId, Menu menu)
        {
            var entity = menu.ToDataObject();
            _menuDao.UpdateMenu(tenantId, operatorId, entity);
        }
    }
}
