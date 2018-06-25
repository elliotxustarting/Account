using System;
using System.Collections.Generic;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    /// <summary>
    /// Organization provider.
    /// </summary>
    public class OrganizationProvider : IOrganizationProvider
    {
        private OrganizationDao _organizationDaoDao = new OrganizationDao();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.OrganizationProvider"/> class.
        /// </summary>
        public OrganizationProvider()
        {
        }

        /// <summary>
        /// Creates the organization.
        /// </summary>
        /// <returns>The organization.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="organization">Organization.</param>
        public long CreateOrganization(int tenantId, int operatorId, Organization organization)
        {
            return _organizationDaoDao.CreateOrganization(tenantId, operatorId, new OrganizationDO
            {
                Id = organization.Id,
                Name = organization.Name,
                ParentId = organization.ParentId
            });
        }

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <returns>The organization.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public Organization GetOrganization(int tenantId, int operatorId, int id)
        {
            var organization = _organizationDaoDao.GetOrganization(tenantId, operatorId, id);
            return new Organization
            {
                Id = organization.Id,
                Name = organization.Name,
                ParentId = organization.ParentId
            };
        }

        /// <summary>
        /// Lists the by page.
        /// </summary>
        /// <returns>The by page.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        public IList<Organization> ListByPage(int tenantId, int operatorId, int pageIndex, int pageSize)
        {
            return new List<Organization>();
        }

        /// <summary>
        /// Updates the organization.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="organization">User.</param>
        public void UpdateOrganization(int tenantId, int operatorId, Organization organization)
        {
            _organizationDaoDao.UpdateOrganization(tenantId, operatorId, new OrganizationDO
            {
                Id = organization.Id,
                Name = organization.Name,
                ParentId = organization.ParentId
            });
        }
    }
}
