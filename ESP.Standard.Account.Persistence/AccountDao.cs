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

        public void Add(int tenantId, int operatorId, AccountDO item)
        {
            Execute("INSERT INTO public.account (username, password) VALUES(@username,@password)", item);
        }

        public IEnumerable<AccountDO> FindAll()
        {
            return Query<AccountDO>("SELECT * FROM account");
        }

        public AccountDO FindByID(int id)
        {
            return Query<AccountDO>("SELECT * FROM account WHERE id = @id", new { Id = id }).FirstOrDefault();
        }

        public void Remove(int id)
        {
            Execute("DELETE FROM account WHERE id=@id", new { Id = id });
        }

        public void Update(AccountDO item)
        {
            Execute("UPDATE account SET username = @username,password=@password WHERE id = @Id", item);
        }
    }
}
