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
            Organization organization = null;
            var organizationDo = _organizationDaoDao.GetOrganization(tenantId, operatorId, id);
            if (organizationDo != null)
            {
                organization = new Organization
                {
                    Id = organizationDo.Id,
                    Name = organizationDo.Name,
                    ParentId = organizationDo.ParentId
                };
            }
            return organization;
        }

        /// <summary>
        /// Lists the by page.
        /// </summary>
        /// <returns>The by page.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        public IList<Organization> Search(int tenantId, int operatorId, int pId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _organizationDaoDao.GetOrganizationsByLevel(tenantId, operatorId, pId, paging, sortedFields).Select(org => new Organization
            {
                Id = org.Id,
                Name = org.Name,
                ParentId = org.ParentId
            }).ToList();
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
