using System;
namespace ESP.Standard.Account.Provider.Model
{
    /// <summary>
    /// Organization.
    /// </summary>
    public class Organization
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
        public long Id { get; set; }

        /// <summary>
        /// user real name
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Parent Id
        /// </summary>
        /// <value>The identifier.</value>
        public long ParentId { get; set; }
    }
}
