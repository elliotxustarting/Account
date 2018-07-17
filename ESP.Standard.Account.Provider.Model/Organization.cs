using System;

namespace ESP.Standard.Account.Provider.Model
{
    /// <summary>
    /// Organization.
    /// </summary>
    public class Organization: DataModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.Model.Organization"/> class.
        /// </summary>
        public Organization()
        {
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

        /// <summary>
        /// Parent Id
        /// </summary>
        /// <value>The identifier.</value>
        public int ParentId { get; set; }
    }
}
