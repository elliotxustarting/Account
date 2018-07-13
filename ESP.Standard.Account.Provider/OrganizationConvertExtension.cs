using System;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    public static class OrganizationConvertExtension
    {
        public static OrganizationDO ToDataObject(this Organization organization)
        {
            if (organization == null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            var entity = new OrganizationDO
            {
                Id = organization.Id,
                TenantId = organization.TenantId,
                ParentId = organization.ParentId,
                Name = organization.Name,
                Description = organization.Description,
                CreatedBy = organization.CreatedBy,
                CreatedTime = organization.CreatedTime,
                UpdatedBy = organization.UpdatedBy,
                UpdatedTime = organization.UpdatedTime
            };
            return entity;
        }

        public static Organization ToBusinessObject(this OrganizationDO organization)
        {
            if (organization == null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            var entity = new Organization
            {
                Id = organization.Id,
                TenantId = organization.TenantId,
                ParentId = organization.ParentId,
                Name = organization.Name,
                Description = organization.Description,
                CreatedBy = organization.CreatedBy,
                CreatedTime = organization.CreatedTime,
                UpdatedBy = organization.UpdatedBy,
                UpdatedTime = organization.UpdatedTime
            };
            return entity;
        }
    }
}
