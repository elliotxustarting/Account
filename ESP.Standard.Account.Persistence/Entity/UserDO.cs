using System;
using System.ComponentModel.DataAnnotations;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Persistence.Entity
{
    /// <summary>
    /// User entity mapping from database.
    /// </summary>
    public class UserDO : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Persistence.Entity.UserDO"/> class.
        /// </summary>
        public UserDO()
        {
        }

        /// <summary>
        /// primary key
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// user real name
        /// </summary>
        /// <value>The name.</value>
        public string RealName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the we chat.
        /// </summary>
        /// <value>The we chat.</value>
        public string WeChat { get; set; }

        /// <summary>
        /// Gets or sets the qq.
        /// </summary>
        /// <value>The qq.</value>
        public string QQ { get; set; }
    }
}
