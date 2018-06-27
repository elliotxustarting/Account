using System;
using System.Collections.Generic;

namespace ESP.Standard.Account.Persistence.Entity
{
    /// <summary>
    /// Element entity mapping from database.
    /// </summary>
    public class ElementDO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.Entity.ElementDO"/> class.
        /// </summary>
        public ElementDO()
        {
            Permissions = new List<PermissionDO>();
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
        /// Gets or sets the permissions.
        /// </summary>
        /// <value>The permissions.</value>
        public IList<PermissionDO> Permissions { get; set; }
    }
}
