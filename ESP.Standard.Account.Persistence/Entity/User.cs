using System;

namespace ESP.Standard.Account.Persistence.Entity
{
    /// <summary>
    /// User entity mapping from database.
    /// </summary>
    public class User
    {
        public User()
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


        /// <summary>
        /// belong to orinazation
        /// </summary>
        /// <value>The org identifier.</value>
        public long OrgId { get; set; }
    }
}
