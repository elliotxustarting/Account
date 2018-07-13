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
    /// User provider.
    /// </summary>
    public class UserProvider : IUserProvider
    {
        private UserDao _userDao = new UserDao();
        private AccountDao _accountDao = new AccountDao();

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
            //var id = _accountDao.CreateAccount(tenantId, operatorId, new AccountDO
            //{
            //    UserName = user.Name,
            //    Password = "123456",
            //    CreatedBy = 122233333,
            //    CreatedTime = DateTime.Now,
            //    UpdatedBy = 123123,
            //    UpdatedTime = DateTime.Now
            //});
            var accounts = _accountDao.SearchAccount(tenantId, operatorId, new PagingObject { PageIndex = 1, PageSize = 10 }, new List<SortedField> { new SortedField { Field = "username", Direction = SortedDirection.ASC } });
            var account = _accountDao.GetAccount(tenantId, operatorId, 1);
            account.Password = "123456789";
            account.UpdatedBy = 2222;
            account.UpdatedTime = DateTime.Now;
            _accountDao.UpdateAccount(tenantId, operatorId, account);
            return 0;
            //return _userDao.CreateUser(tenantId, operatorId, new UserDO
            //{
            //    Id = user.Id,
            //    Name = user.Name,
            //    OrgId = user.OrgId
            //});
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
            User user = null;
            var userDo = _userDao.GetUser(tenantId, operatorId, id);
            if (userDo != null)
            {
                user = new User
                {
                    Id = userDo.Id,
                    Name = userDo.Name,
                    OrgId = userDo.OrgId
                };
            }
            return user;
        }

        /// <summary>
        /// Lists the by page.
        /// </summary>
        /// <returns>The by page.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        public IList<User> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _userDao.SearchUser(tenantId, operatorId, paging, sortedFields).Select(user => new User
            {
                Id = user.Id,
                Name = user.Name
            }).ToList();
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
