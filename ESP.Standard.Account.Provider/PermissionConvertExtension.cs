using System;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    public static class PermissionConvertExtension
    {
        public static PermissionDO ToDataObject(this Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            var entity = new PermissionDO
            {
                Id = permission.Id,
                TenantId = permission.TenantId,
                Name = permission.Name,
                Description = permission.Description,
                CreatedBy = permission.CreatedBy,
                CreatedTime = permission.CreatedTime,
                UpdatedBy = permission.UpdatedBy,
                UpdatedTime = permission.UpdatedTime
            };
            return entity;
        }

        public static Permission ToBusinessObject(this PermissionDO permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            var entity = new Permission
            {
                Id = permission.Id,
                TenantId = permission.TenantId,
                Name = permission.Name,
                Description = permission.Description,
                CreatedBy = permission.CreatedBy,
                CreatedTime = permission.CreatedTime,
                UpdatedBy = permission.UpdatedBy,
                UpdatedTime = permission.UpdatedTime
            };
            return entity;
        }
    }
}
