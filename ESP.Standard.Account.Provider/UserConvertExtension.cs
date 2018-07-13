using System;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Model;

namespace ESP.Standard.Account.Provider
{
    public static class UserConvertExtension
    {
        public static UserDO ToDataObject(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var entity = new UserDO
            {
                Id = user.Id,
                TenantId = user.TenantId,
                RealName = user.RealName,
                Email = user.Email,
                Mobile = user.Mobile,
                QQ = user.QQ,
                WeChat = user.WeChat,
                CreatedBy = user.CreatedBy,
                CreatedTime = user.CreatedTime,
                UpdatedBy = user.UpdatedBy,
                UpdatedTime = user.UpdatedTime
            };
            return entity;
        }

        public static User ToBusinessObject(this UserDO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var entity = new User
            {
                Id = user.Id,
                TenantId = user.TenantId,
                RealName = user.RealName,
                Email = user.Email,
                Mobile = user.Mobile,
                QQ = user.QQ,
                WeChat = user.WeChat,
                CreatedBy = user.CreatedBy,
                CreatedTime = user.CreatedTime,
                UpdatedBy = user.UpdatedBy,
                UpdatedTime = user.UpdatedTime
            };
            return entity;
        }

        public static AccountDO ToDataObject(this Model.Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var entity = new AccountDO
            {
                Id = account.Id,
                UserName = account.UserName,
                Password = account.Password,
                CreatedBy = account.CreatedBy,
                CreatedTime = account.CreatedTime,
                UpdatedBy = account.UpdatedBy,
                UpdatedTime = account.UpdatedTime
            };
            return entity;
        }

        public static Model.Account ToBusinessObject(this AccountDO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var entity = new Model.Account
            {
                Id = account.Id,
                UserName = account.UserName,
                Password = account.Password,
                CreatedBy = account.CreatedBy,
                CreatedTime = account.CreatedTime,
                UpdatedBy = account.UpdatedBy,
                UpdatedTime = account.UpdatedTime
            };
            return entity;
        }
    }
}
