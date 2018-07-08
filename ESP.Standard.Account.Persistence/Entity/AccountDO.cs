using System;
using System.ComponentModel.DataAnnotations;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence.Entity
{
    public class AccountDO : BaseEntity
    {
        public AccountDO()
        {
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
