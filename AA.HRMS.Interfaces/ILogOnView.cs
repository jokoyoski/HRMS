using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogOnView
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to [remember me].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [remember me]; otherwise, <c>false</c>.
        /// </value>
        bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        string ReturnUrl { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the info message.
        /// </summary>
        /// <value>
        /// The info message.
        /// </value>
        string InfoMessage { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has info message.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has info message; otherwise, <c>false</c>.
        /// </value>
        bool HasInfoMessage { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has invalid credentials.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has invalid credentials; otherwise, <c>false</c>.
        /// </value>
        bool HasInvalidCredentials { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has invalid user name.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has invalid user name; otherwise, <c>false</c>.
        /// </value>
        bool HasInvalidUserName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has invalid password.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has invalid password; otherwise, <c>false</c>.
        /// </value>
        bool HasInvalidPassword { get; set; }
    }
}