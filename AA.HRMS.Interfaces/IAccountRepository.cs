using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    public interface IAccountRepository
    {

        #region Registration

        /// <summary>
        /// Gets the registration by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        IRegistration GetRegistrationByUsername(string username);

        /// <summary>
        /// Gets the registration by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        IRegistration GetRegistrationByEmail(string email);

        /// <summary>
        /// Saves the user information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        string SaveUserInfo(IRegistrationView registrationInfo, out int registrationId);

        /// <summary>
        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        string SaveRegistrationInfo(IRegistrationView registrationInfo, out int registrationId);

        /// <summary>
        /// Gets the activation code.
        /// </summary>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        IUserActivationCode GetActivationCode(string activationCode);
        
        /// <summary>
        /// Stores the activation code.
        /// </summary>
        /// <param name="registrationId">The registration identifier.</param>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        string StoreActivationCode(int registrationId, string activationCode);
        
        /// <summary>
        /// Updates the actviation code.
        /// </summary>
        /// <param name="userActivationCodeId">The user activation code identifier.</param>
        /// <returns></returns>
        string UpdateActviationCode(int userActivationCodeId);
        
        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        string CreateUserRole(IRegistrationView registrationInfo);
        
        /// <summary>
        /// Updates the user company.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        string UpdateUserCompany(IUserDetail user);
        
        /// <summary>
        /// Updates the user record.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        string UpdateUserRecord(int userId);

        #endregion

        #region Login

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        IUser GetUserByUsername(string userName);


        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        IUser GetUserByEmail(string email);

        /// <summary>
        /// Gets the user role actions.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        IList<string> GetUserRoleActions(string username);
        #endregion

        #region Password Reset

        /// <summary>
        /// Saves the change password.
        /// </summary>
        /// <param name="changePasswordView">The change password view.</param>
        /// <returns></returns>
        string SaveChangePassword(IChangePasswordView changePasswordView);


        /// <summary>
        /// Updates the ChangePassword Table
        /// </summary>
        /// <returns></returns>
        string SaveChangePasswordDetails(IChangePassword changeP);

        /// <summary>
        /// Gets the emailby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IChangePassword GetChangePasswordByCode(string code);

        #endregion
        
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="registrationRequestEmail">The registration request email.</param>
        /// <returns></returns>
        string SendEmail(IEmailDetail registrationRequestEmail);
        
        /// <summary>
        /// Gets the user by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IUser GetUserByUserId(int userId);
        
        /// <summary>
        /// Saves the company admin.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        string SaveCompanyAdmin(IUserDetail user);
    }
}