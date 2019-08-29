using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    public class UserListView : IUserListView 
    {
        public UserListView()
        {
            this.UserCollection = new List<IUserDetail>();
            this.ProcessingMessage = string.Empty;
            //this.SelectedUserId = string.Empty;
            //this.SelectedUserName = string.Empty;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is user verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is user verified; otherwise, <c>false</c>.
        /// </value>
        public bool IsUserVerified { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the is reset password.
        /// </summary>
        /// <value>
        /// The is reset password.
        /// </value>
        public Nullable<bool> IsResetPassword { get; set; }

        /// <summary>
        /// Gets or sets the is locked.
        /// </summary>
        /// <value>
        /// The is locked.
        /// </value>
        public Nullable<bool> IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date verified.
        /// </summary>
        /// <value>
        /// The date verified.
        /// </value>
        public Nullable<System.DateTime> DateVerified { get; set; }

        /// <summary>
        /// Gets or sets the user collection.
        /// </summary>
        /// <value>
        /// The user collection.
        /// </value>
        public IList<IUserDetail> UserCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected.
        /// </summary>
        /// <value>
        /// The name of the selected.
        /// </value>
        public string SelectedName { get; set; }


        /// <summary>
        /// Gets or sets the selected email.
        /// </summary>
        /// <value>
        /// The selected email.
        /// </value>
        public string SelectedEmail { get; set; }
    }
}
