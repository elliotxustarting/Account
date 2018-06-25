using System;

namespace ESP.Standard.Account.Provider.Model
{
    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.Model.User"/> class.
        /// </summary>
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
