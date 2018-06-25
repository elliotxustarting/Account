using System;
namespace ESP.Standard.Account.Persistence.Entity
{
    /// <summary>
    /// Organization entity mapping from database.
    /// </summary>
    public class OrganizationDO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.Entity.OrganizationDO"/> class.
        /// </summary>
        public OrganizationDO()
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
