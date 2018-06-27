using System;
using System.Collections.Generic;

namespace ESP.Standard.Account.Persistence.Entity
{
    /// <summary>
    /// Permission do.
    /// </summary>
    public class PermissionDO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.Entity.PermissionDO"/> class.
        /// </summary>
        public PermissionDO()
        {
            Menus = new List<MenuDO>();
            Elements = new List<ElementDO>();
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
        /// Gets or sets the menus.
        /// </summary>
        /// <value>The menus.</value>
        public IList<MenuDO> Menus { get; set; }

        /// <summary>
        /// Gets or sets the elements.
        /// </summary>
        /// <value>The elements.</value>
        public IList<ElementDO> Elements { get; set; }
    }
}
