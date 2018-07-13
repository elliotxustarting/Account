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
            organization.CreatedBy = operatorId;
            organization.CreatedTime = DateTime.Now;
            organization.UpdatedBy = operatorId;
            organization.UpdatedTime = DateTime.Now;
            var entity = organization.ToDataObject();
            return _organizationDaoDao.CreateOrganization(tenantId, operatorId, entity);
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
                organization = organizationDo.ToBusinessObject();
            }
            return organization;
        }

        /// <summary>
        /// Search the specified tenantId, operatorId, pId, paging and sortedFields.
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="pId">P identifier.</param>
        /// <param name="paging">Paging.</param>
        /// <param name="sortedFields">Sorted fields.</param>
        public IList<Organization> Search(int tenantId, int operatorId, int pId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _organizationDaoDao.GetOrganizationsByLevel(tenantId, operatorId, pId, paging, sortedFields).Select(org => org.ToBusinessObject()).ToList();
        }

        /// <summary>
        /// Updates the organization.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="organization">User.</param>
        public void UpdateOrganization(int tenantId, int operatorId, Organization organization)
        {
            organization.UpdatedBy = operatorId;
            organization.UpdatedTime = DateTime.Now;
            var entity = organization.ToDataObject();
            _organizationDaoDao.UpdateOrganization(tenantId, operatorId, entity);
        }
    }
}
