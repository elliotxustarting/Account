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
            Execute("INSERT INTO public.account (tenantid, username, password, createdby, createdtime, updatedby, updatedtime) VALUES (@tenantid,@username,@password, @createdby, @createdtime, @updatedby, @updatedtime)", item);
        }

        public IEnumerable<AccountDO> FindAll(int tenantId, int operatorId)
        {
            return Query<AccountDO>("SELECT * FROM account where tenantid=@tenantid", new { TenantId = tenantId });
        }

        public AccountDO FindByID(int tenantId, int operatorId,int id)
        {
            return Query<AccountDO>("SELECT * FROM account WHERE tenantid=@tenantid and id = @id", new { TenantId = tenantId, Id = id }).FirstOrDefault();
        }

        public void Remove(int tenantId, int operatorId,int id)
        {
            Execute("DELETE FROM account WHERE tenantid=@tenantid and id=@id", new { TenantId = tenantId, Id = id });
        }

        public void Update(int tenantId, int operatorId,AccountDO item)
        {
            Execute("UPDATE account SET username = @username,password=@password,updatedby=@updatedby,updatedtime=@updatedtime WHERE tenantid=@tenantid and id = @Id", item);
        }
    }
}
