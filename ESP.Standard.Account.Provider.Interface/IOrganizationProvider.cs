using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider.Interface
{
    /// <summary>
    /// Organization provider.
    /// </summary>
    public interface IOrganizationProvider
    {
        /// <summary>
        /// Creates the organization.
        /// </summary>
        /// <returns>The organization.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        long CreateOrganization(int tenantId, int operatorId, Organization organization);

        /// <summary>
        /// Updates the organization.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        void UpdateOrganization(int tenantId, int operatorId, Organization organization);

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <returns>The organization.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        Organization GetOrganization(int tenantId, int operatorId, int id);

        /// <summary>
        /// Lists the by page.
        /// </summary>
        /// <returns>The by page.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        IList<Organization> ListByPage(int tenantId, int operatorId, int pageIndex, int pageSize);
    }
}
