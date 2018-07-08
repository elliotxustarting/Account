using System;
using System.Collections.Generic;

namespace ESP.Standard.Account.Provider.Model
{
    /// <summary>
    /// Permission.
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.Model.Permission"/> class.
        /// </summary>
        public Permission()
        {
            Menus = new List<Menu>();
            Elements = new List<Element>();
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
        /// Gets or sets the menus.
        /// </summary>
        /// <value>The menus.</value>
        public IList<Menu> Menus {get;set;}

        /// <summary>
        /// Gets or sets the elements.
        /// </summary>
        /// <value>The elements.</value>
        public IList<Element> Elements { get; set; }
    }
}
