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
            return _menuDao.CreateMenu(tenantId, operatorId, new MenuDO
            {
                Id = menu.Id,
                Name = menu.Name
            });
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
            var menu = _menuDao.GetMenu(tenantId, operatorId, id);
            return new Menu
            {
                Id = menu.Id,
                Name = menu.Name
            };
        }

        /// <summary>
        /// Gets the menus.
        /// </summary>
        /// <returns>The menus.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<Menu> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _menuDao.GetMenus(tenantId, operatorId, paging, sortedFields).Select(menu => new Menu
            {
                Id = menu.Id,
                Name = menu.Name
            }).ToList();
        }

        /// <summary>
        /// Updates the menu.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="menu">Menu.</param>
        public void UpdateMenu(int tenantId, int operatorId, Menu menu)
        {
            _menuDao.UpdateMenu(tenantId, operatorId, new MenuDO
            {
                Id = menu.Id,
                Name = menu.Name
            });
        }
    }
}
