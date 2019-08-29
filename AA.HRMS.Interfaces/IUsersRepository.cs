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
    public interface IUsersRepository
    {

        /// <summary>
        /// Passwords the reset.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        string PasswordReset(IUser users);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// IUsers.
        /// </returns>
        IUser GetUserByEmail(string email);

        /// <summary>
        /// Saves the user regisration information.
        /// </summary>
        /// <param name="userRegistrationInfo">The user registration information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string SaveUserRegistrationInfo(IUsersView userRegistrationInfo, out int userId);

        /// <summary>
        /// Saves the edit user information.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        string SaveEditUserInfo(IUserViewModel users);

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="userRegistrationNotificationEmail">The user registration notification email.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string SendEmail(IEmailDetail userRegistrationNotificationEmail);

        /// <summary>
        /// Creates the activation code.
        /// </summary>
        /// <returns></returns>
        string CreateActivationCode();

        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns></returns>
        IList<IUserDetail> GetAllUser();


        IList<IUserDetail> GetAllUserListByCompanyId(int companyId);
        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IUserDetail GetUserById(int userId);

        /// <summary>
        /// Saves the user application role.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        string SaveUserAppRole(IUserAppRoleView userDetail);

        /// <summary>
        /// Saves the edit user application role.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        string SaveEditUserAppRole(IUserAppRoleView userDetail);

        /// <summary>
        /// Saves the delete user application role.
        /// </summary>
        /// <param name="userAppRoleId">The user application role identifier.</param>
        /// <returns></returns>
        string SaveDeleteUserAppRole(int userAppRoleId);

        /// <summary>
        /// Gets the application role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        IAppRole GetAppRole(int roleId);


        /// <summary>
        /// Gets the user application role by user application role identifier.
        /// </summary>
        /// <param name="userAppRole">The user application role.</param>
        /// <returns></returns>
        IUserAppRole GetUserAppRoleByUserAppRoleId(int userAppRole);

        /// <summary>
        /// Updates the user lock information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        string UpdateUserLockInfo(IUser userInfo);

        /// <summary>
        /// Gets the user application role by username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        IUserAppRole GetUserAppRoleByUsername(string userName);

        /// <summary>
        /// Saves the calendar event.
        /// </summary>
        /// <param name="calendarEvent">The calendar event.</param>
        /// <returns></returns>
        string SaveCalendarEvent(ICalendarEvent calendarEvent);

        /// <summary>
        /// Deletes the calendar event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        string DeleteCalendarEvent(int eventId);
    }
}