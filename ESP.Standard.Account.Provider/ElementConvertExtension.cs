using System;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    public static class ElementConvertExtension
    {
        public static ElementDO ToDataObject(this Element element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var entity = new ElementDO
            {
                Id = element.Id,
                TenantId = element.TenantId,
                Name = element.Name,
                Description = element.Description,
                CreatedBy = element.CreatedBy,
                CreatedTime = element.CreatedTime,
                UpdatedBy = element.UpdatedBy,
                UpdatedTime = element.UpdatedTime
            };
            return entity;
        }

        public static Element ToBusinessObject(this ElementDO element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var entity = new Element
            {
                Id = element.Id,
                TenantId = element.TenantId,
                Name = element.Name,
                Description = element.Description,
                CreatedBy = element.CreatedBy,
                CreatedTime = element.CreatedTime,
                UpdatedBy = element.UpdatedBy,
                UpdatedTime = element.UpdatedTime
            };
            return entity;
        }
    }
}
