using System;
using System.Collections.Generic;

namespace ESP.Standard.Account.Provider.Model
{
    /// <summary>
    /// Menu.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.Model.Menu"/> class.
        /// </summary>
        public Menu()
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
        /// Gets or sets the permissions.
        /// </summary>
        /// <value>The permissions.</value>
        public IList<Permission> Permissions { get; set; }
    }
}
