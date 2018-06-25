using System;
using System.Collections.Generic;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    /// <summary>
    /// User provider.
    /// </summary>
    public class UserProvider : IUserProvider
    {
        private UserDao _userDao = new UserDao();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.UserProvider"/> class.
        /// </summary>
        public UserProvider()
        {
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        public long CreateUser(int tenantId, int operatorId, User user)
        {
            return _userDao.CreateUser(tenantId, operatorId, new UserDO
            {
                Id = user.Id,
                Name = user.Name,
                OrgId = user.OrgId
            });
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public User GetUser(int tenantId, int operatorId, int id)
        {
            var user = _userDao.GetUser(tenantId, operatorId, id);
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                OrgId = user.OrgId
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
        public IList<User> ListByPage(int tenantId, int operatorId, int pageIndex, int pageSize)
        {
            return new List<User>();
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        public void UpdateUser(int tenantId, int operatorId, User user)
        {
            _userDao.UpdateUser(tenantId, operatorId, new UserDO
            {
                Id = user.Id,
                Name = user.Name,
                OrgId = user.OrgId
            });
        }
    }
}
