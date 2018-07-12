using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class UserDao : BaseRepository
    {
        public UserDao() : base("Account")
        {
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        public long CreateUser(int tenantId, int operatorId, UserDO user)
        {
            return ExecuteScalar<long>("INSERT INTO public.user (tenantid, accountid, realname, email, mobile, createdby, createdtime, updatedby, updatedtime) VALUES(@tenantid, @accountid, @realname, @email, @mobile, @createdby, @createdtime, @updatedby, @updatedtime) RETURNING id", user);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <returns><c>true</c>, if user was updated, <c>false</c> otherwise.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="user">User.</param>
        public bool UpdateUser(int tenantId, int operatorId, UserDO user)
        {
            Execute("UPDATE public.user SET name = @name, realname=@realname, email=@email, mobile=@mobile, updatedby=@updatedby, updatedtime=@updatedtime WHERE tenantid=@tenantid AND id = @Id", user);
            return true;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        /// <param name="id">Identifier.</param>
        public UserDO GetUser(int tenantId, int operatorId, int id)
        {
            return Query<UserDO>("SELECT * FROM public.user WHERE tenantid=@tenantid AND id = @id", new { TenantId = tenantId, Id = id }).FirstOrDefault();
        }

        /// <summary>
        /// Searchs the account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="tenantId">Tenant identifier.</param>
        /// <param name="operatorId">Operator identifier.</param>
        public IEnumerable<UserDO> SearchUser(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            var sql = "SELECT * FROM public.user WHERE tenantid=@tenantid";
            sql = sql.Sort(sortedFields);
            if (paging != null)
            {
                sql = sql.Paging(paging);
            }
            return Query<UserDO>(sql, new
            {
                tenantId
            });
        }
    }
}
