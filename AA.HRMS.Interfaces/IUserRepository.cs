using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IUserRepository
    {

        /// <summary>
        /// Saves the user registration information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        string SaveUserRegistrationInfo(IUserRegistrationView userInfo);
        /// <summary>
        /// Deletes the user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        string DeleteUserInfo(IUserRegistrationView userInfo);
        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IUserDetail GetUserById(int userId);
        /// <summary>
        /// Updates the user registration information.
        /// </summary>
        /// <param name="userRegistrationInfo">The user registration information.</param>
        /// <returns></returns>
        string UpdateUserRegistrationInfo(IUserRegistrationView userRegistrationInfo);
    }
}
