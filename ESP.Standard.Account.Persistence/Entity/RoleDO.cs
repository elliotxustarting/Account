using System;
namespace ESP.Standard.Account.Persistence.Entity
{
    /// <summary>
    /// Role entity mapping from database.
    /// </summary>
    public class RoleDO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.Entity.RoleDO"/> class.
        /// </summary>
        public RoleDO()
        {
        }

        /// <summary>
        /// primary key
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }

        /// <summary>
        /// user real name
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
    }
}
