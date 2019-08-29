using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IUserAppRole
    {

        /// <summary>
        /// Gets or sets the user application role identifier.
        /// </summary>
        /// <value>
        /// The user application role identifier.
        /// </value>
        int UserAppRoleId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the application role identifier.
        /// </summary>
        /// <value>
        /// The application role identifier.
        /// </value>
        int AppRoleId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the create by username.
        /// </summary>
        /// <value>
        /// The create by username.
        /// </value>
        string CreateByUsername { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        string RoleName { get; set; }


       
    }
}
