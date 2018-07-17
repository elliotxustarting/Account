using System;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider.Model
{
    public abstract class DataModel : Tenant
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        /// <value>The created time.</value>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated time.
        /// </summary>
        /// <value>The updated time.</value>
        public DateTime UpdatedTime { get; set; }
    }
}
