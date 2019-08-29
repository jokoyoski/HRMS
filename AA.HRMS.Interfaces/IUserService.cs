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
    public interface IUserService
    {
        /// <summary>
        /// Gets the user registration view.
        /// </summary>
        /// <returns>
        /// IUsersView.
        /// </returns>
        IUsersView GetUserRegistrationView();

        /// <summary>
        /// Processes the user registration view.
        /// </summary>
        /// <param name="userRegistrationInfo">The user registration information.</param>
        /// <returns>
        /// IUsersView.
        /// </returns>
        IUsersView ProcessUserRegistrationInfo(IUsersView userRegistrationInfo);

        /// <summary>
        /// Gets the edit user view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IUserViewModel GetEditUserView(int userId);

        /// <summary>
        /// Gets the edit user view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IUserViewModel GetEditUserView(IUserViewModel user, string message);

        /// <summary>
        /// Processes the edit user.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        string ProcessEditUser(IUserViewModel users);

        /// <summary>
        /// Gets the user role view list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IUsersView GetUserRoleViewList(int userId);

        /// <summary>
        /// Gets the user role view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IUserAppRoleView GetUserRoleView(int userId);

        /// <summary>
        /// Gets the edit create user role view.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        IUserAppRoleView GetEditCreateUserRoleView(int roleId, string userName);
        

        /// <summary>
        /// Processes the user application role.
        /// </summary>
        /// <param name="userView">The user view.</param>
        /// <returns></returns>
        string ProcessUserAppRole(IUserAppRoleView userView);

        /// <summary>
        /// Processes the edit user role information.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        string ProcessEditUserRoleInfo(IUserAppRoleView users);

        /// <summary>
        /// Processes the delete user role information.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        string ProcessDeleteUserRoleInfo(int userAppRoleId);

        /// <summary>
        /// Gets the updated user role view.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUserAppRoleView GetUpdatedUserRoleView(IUserAppRoleView users, string processingMessage);


        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IUsersView GetUserInfo(int userId);

        /// <summary>
        /// Gets the deleteuser role view.
        /// </summary>
        /// <param name="userRoleId">The user role identifier.</param>
        /// <returns></returns>
        IUserAppRoleView GetDeleteuserRoleView(int userAppRoleId);

        /// <summary>
        /// Gets the content of the header.
        /// </summary>
        /// <returns></returns>
        IHeaderViewModel GetHeaderContent();
    }
}