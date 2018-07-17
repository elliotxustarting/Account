using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence
{
    public class AccountDao : BaseRepository
    {
        public AccountDao() : base("Account")
        {
        }

        public int CreateAccount(AccountDO item)
        {
            return ExecuteScalar("INSERT INTO public.account (username, password, createdby, createdtime, updatedby, updatedtime) VALUES (@username,@password, @createdby, @createdtime, @updatedby, @updatedtime) RETURNING id", item);
        }

        public IEnumerable<AccountDO> SearchAccount(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            var sql = "SELECT * FROM account";
            sql = sql.Sort(sortedFields);
            if (paging != null)
            {
                sql = sql.Paging(paging);
            }
            return Query<AccountDO>(sql, new
            {
                tenantId
            });
        }

        public AccountDO GetAccount(int id)
        {
            return Query<AccountDO>("SELECT * FROM account WHERE id = @id", new { Id = id }).FirstOrDefault();
        }

        public AccountDO GetAccount(string username)
        {
            var sql = "SELECT a.id, a.username, a.password, a.createdby, a.createdtime, a.updatedby, a.updatedtime, " +
                "u.id as userid, u.* " +
                "FROM public.account a  LEFT JOIN rel_user_account rel on a.id = rel.accountid LEFT JOIN public.user u on rel.userid = u.id " +
                "WHERE a.username = @username";
            return Query<AccountDO, UserDO>(sql,(account, user) => 
            {
                if (user != null && user.Id > 0)
                {
                    account.User = user;
                }
                return account;
            }, "userid", new { username }).FirstOrDefault();
        }

        public void UpdateAccount(AccountDO item)
        {
            Execute("UPDATE account SET username = @username,password=@password,updatedby=@updatedby,updatedtime=@updatedtime WHERE id = @Id", item);
        }
    }
}
