using System;
using System.ComponentModel.DataAnnotations;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence.Entity
{
    /// <summary>
    /// User entity mapping from database.
    /// </summary>
    public class UserDO : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.Entity.UserDO"/> class.
        /// </summary>
        public UserDO()
        {
        }

        /// <summary>
        /// primary key
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// user real name
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }


        /// <summary>
        /// belong to orinazation
        /// </summary>
        /// <value>The org identifier.</value>
        public long OrgId { get; set; }
    }
}
