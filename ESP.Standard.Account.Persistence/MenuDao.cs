using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class MenuDao : BaseRepository
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
            return ExecuteScalar("INSERT INTO public.menu (tenantid, name, description, createdby, createdtime, updatedby, updatedtime) VALUES(@tenantid,@name, @description, @createdby, @createdtime, @updatedby, @updatedtime) RETURNING id", menu);
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
            Execute("UPDATE public.menu SET name = @name, updatedby=@updatedby, updatedtime=@updatedtime WHERE tenantid=@tenantid and id = @Id", menu);
            return true;
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
            return Query<MenuDO>("SELECT * FROM public.menu WHERE tenantid=@tenantid and id = @id", new { TenantId = tenantId, Id = id }).FirstOrDefault();
        }

        /// <summary>
        /// Gets the menus.
        /// </summary>
        /// <returns>The menus.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IList<MenuDO> GetMenus(int tenantId, int operatorId)
        {
            return Query<MenuDO>("SELECT * FROM public.menu where tenantid=@tenantid", new { TenantId = tenantId });
        }
    }
}
