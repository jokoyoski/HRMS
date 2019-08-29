using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class UserAppRoleView : IUserAppRoleView
    {
        public UserAppRoleView()
        {
            this.AppRoleCollection = new List<SelectListItem>();
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
        /// Gets or sets the application role identifier.
        /// </summary>
        /// <value>
        /// The application role identifier.
        /// </value>
        public int AppRoleId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the create by username.
        /// </summary>
        /// <value>
        /// The create by username.
        /// </value>
        public string CreateByUsername { get; set; }

        /// <summary>
        /// Gets or sets the porcesssing message.
        /// </summary>
        /// <value>
        /// The porcesssing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the name of the application role.
        /// </summary>
        /// <value>
        /// The name of the application role.
        /// </value>
        public string AppRoleName { get; set; }

        /// <summary>
        /// Gets or sets the application role collection.
        /// </summary>
        /// <value>
        /// The application role collection.
        /// </value>
        public IList<SelectListItem> AppRoleCollection { get; set; }

        /// <summary>
        /// Gets or sets the user application role identifier.
        /// </summary>
        /// <value>
        /// The user application role identifier.
        /// </value>
        public int UserAppRoleId { get; set; }
    }
}