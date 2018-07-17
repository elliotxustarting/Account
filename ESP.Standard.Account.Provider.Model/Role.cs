using System;
using System.Collections.Generic;

namespace ESP.Standard.Account.Provider.Model
{
    /// <summary>
    /// Role.
    /// </summary>
    public class Role: DataModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.Model.Role"/> class.
        /// </summary>
        public Role()
        {
            Permissions = new List<Permission>();
        }

        /// <summary>
        /// primary key
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// user real name
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        public List<Permission> Permissions { get; set; }

    }
}
