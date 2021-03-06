﻿using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Code;
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
        private UserDao _userDao;
        private AccountDao _accountDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.UserProvider"/> class.
        /// </summary>
        public UserProvider(UserDao userDao, AccountDao accountDao)
        {
            _userDao = userDao;
            _accountDao = accountDao;
        }

        public void Register(int tenantId, int operatorId, User user)
        {
            foreach(var account in user.Accounts)
            {
                account.CreatedBy = operatorId;
                account.CreatedTime = DateTime.Now;
                account.UpdatedBy = operatorId;
                account.UpdatedTime = DateTime.Now;
                _accountDao.CreateAccount( account.ToDataObject());
            }
        }

        public void ChangePassword(int tenantId, int operatorId, string username, string password, string newpassword, string checkcode)
        {
            if (password != newpassword)
            {

            }
        }

        public User Login(string username, string password, string checkcode, out string errorcode)
        {
            errorcode = null;
            var account = _accountDao.GetAccount(username);
            if (account == null)
            {
                errorcode = LoginCode.UserNameNotExist;
            }

            if (account.Password != password)
            {
                errorcode = LoginCode.AccountNotMatch;
            }

            User user = null;
            if(string.IsNullOrEmpty(errorcode))
            {
                if(account.User !=null)
                {
                    user = account.User.ToBusinessObject();
                }
            }
            return user;
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
            user.CreatedBy = operatorId;
            user.CreatedTime = DateTime.Now;
            user.UpdatedBy = operatorId;
            user.UpdatedTime = DateTime.Now;
            var entity = user.ToDataObject();
            return _userDao.CreateUser(tenantId, operatorId, entity);
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
                user = userDo.ToBusinessObject();
            }
            return user;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="username">Username.</param>
        public User GetUser(int tenantId, int operatorId, string username)
        {
            User user = null;
            var userDo = _userDao.GetUser(tenantId, operatorId, username);
            if (userDo != null)
            {
                user = userDo.ToBusinessObject();
            }
            return user;
        }

        /// <summary>
        /// Search the specified tenantId, operatorId, paging and sortedFields.
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="paging">Paging.</param>
        /// <param name="sortedFields">Sorted fields.</param>
        public IList<User> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _userDao.SearchUser(tenantId, operatorId, paging, sortedFields).Select(user => user.ToBusinessObject()).ToList();
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        public void UpdateUser(int tenantId, int operatorId, User user)
        {
            user.UpdatedBy = operatorId;
            user.UpdatedTime = DateTime.Now;
            var entity = user.ToDataObject();
            _userDao.UpdateUser(tenantId, operatorId, entity);
        }
    }
}
