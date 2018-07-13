using System;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    public static class RoleConvertExtension
    {
        public static RoleDO ToDataObject(this Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var entity = new RoleDO
            {
                Id = role.Id,
                TenantId = role.TenantId,
                Name = role.Name,
                Description = role.Description,
                CreatedBy = role.CreatedBy,
                CreatedTime = role.CreatedTime,
                UpdatedBy = role.UpdatedBy,
                UpdatedTime = role.UpdatedTime
            };
            return entity;
        }

        public static Role ToBusinessObject(this RoleDO role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var entity = new Role
            {
                Id = role.Id,
                TenantId = role.TenantId,
                Name = role.Name,
                Description = role.Description,
                CreatedBy = role.CreatedBy,
                CreatedTime = role.CreatedTime,
                UpdatedBy = role.UpdatedBy,
                UpdatedTime = role.UpdatedTime
            };
            return entity;
        }
    }
}
