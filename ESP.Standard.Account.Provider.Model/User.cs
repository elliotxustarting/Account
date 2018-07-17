using System;
using System.Collections.Generic;

namespace ESP.Standard.Account.Provider.Model
{
    /// <summary>
    /// User.
    /// </summary>
    public class User: DataModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.Model.User"/> class.
        /// </summary>
        public User()
        {
            Accounts = new List<Account>();
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

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public List<Account> Accounts { get; set; }
    }
}
