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

        public int CreateAccount(int tenantId, int operatorId, AccountDO item)
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

        public AccountDO GetAccount(int tenantId, int operatorId, int id)
        {
            return Query<AccountDO>("SELECT * FROM account WHERE id = @id", new { Id = id }).FirstOrDefault();
        }


        public void UpdateAccount(int tenantId, int operatorId,AccountDO item)
        {
            Execute("UPDATE account SET username = @username,password=@password,updatedby=@updatedby,updatedtime=@updatedtime WHERE id = @Id", item);
        }
    }
}
