using System;
using System.Collections.Generic;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider.Interface
{
    /// <summary>
    /// User provider.
    /// </summary>
    public interface IUserProvider
    {
        /// <summary>
        /// Login the specified tenantId, operatorId, username, password, checkcode and errorcode.
        /// </summary>
        /// <returns>The login.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="checkcode">Checkcode.</param>
        /// <param name="errorcode">Errorcode.</param>
        bool Login(int tenantId, int operatorId, string username, string password, string checkcode, out string errorcode);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        long CreateUser(int tenantId, int operatorId, User user);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        void UpdateUser(int tenantId, int operatorId, User user);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        User GetUser(int tenantId, int operatorId, int id);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="username">Username.</param>
        User GetUser(int tenantId, int operatorId , string username);

        /// <summary>
        /// Lists the by page.
        /// </summary>
        /// <returns>The by page.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        IList<User> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields);
    }
}
