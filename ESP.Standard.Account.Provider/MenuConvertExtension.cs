using System;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    public static class MenuConvertExtension
    {
        public static MenuDO ToDataObject(this Menu menu)
        {
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }

            var entity = new MenuDO
            {
                Id = menu.Id,
                TenantId = menu.TenantId,
                Name = menu.Name,
                Description = menu.Description,
                CreatedBy = menu.CreatedBy,
                CreatedTime = menu.CreatedTime,
                UpdatedBy = menu.UpdatedBy,
                UpdatedTime = menu.UpdatedTime
            };
            return entity;
        }

        public static Menu ToBusinessObject(this MenuDO menu)
        {
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }

            var entity = new Menu
            {
                Id = menu.Id,
                TenantId = menu.TenantId,
                Name = menu.Name,
                Description = menu.Description,
                CreatedBy = menu.CreatedBy,
                CreatedTime = menu.CreatedTime,
                UpdatedBy = menu.UpdatedBy,
                UpdatedTime = menu.UpdatedTime
            };
            return entity;
        }
    }
}
