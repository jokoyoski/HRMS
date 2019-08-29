namespace AA.HRMS.Interfaces
{
    public interface IAccountService
    {


        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IUserProfileView GetUserProfile(string message);
        
        #region Registration Section

        /// <summary>
        /// Gets the registration view.
        /// </summary>
        /// <param name="selectedRole">The selected role.</param>
        /// <returns></returns>
        IRegistrationView GetRegistrationView(string selectedRole);

        /// <summary>
        /// Processes the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        IRegistrationView ProcessRegistrationInfo(IRegistrationView registrationInfo);
        
        /// <summary>
        /// Gets the registration view.
        /// </summary>
        /// <param name="registrationData">The registration data.</param>
        /// <returns></returns>
        IRegistrationView GetRegistrationView(IRegistrationView registrationData);

        /// <summary>
        /// Generates the activation view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IUserActivationCode GenerateActivationView(string message);

        /// <summary>
        /// Activates the account.
        /// </summary>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        string ActivateAccount(string activationCode);

        #endregion

        #region Login/Logoff
        
        /// <summary>
        /// Gets the autthenication page.
        /// </summary>
        /// <returns></returns>
        IHomeView GetAutthenicationPage(string message);

        /// <summary>
        /// Gets the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        ILogOnView GetLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl);

        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="logonModel">The logon model.</param>
        /// <returns></returns>
        bool SignIn(ILogOnView logonModel);

        /// <summary>
        /// Gets my companies.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ICompanyListView GetMyCompanies(string message);

        /// <summary>
        /// Switches the companies.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        string SwitchCompanies(int companyId);

        /// <summary>
        /// Signs the off.
        /// </summary>
        void SignOff();

        #endregion
        
        #region Change Password Section

        /// <summary>
        /// Gets the change password.
        /// </summary>
        /// <returns></returns>
        IChangePasswordView GetChangePassword();

        /// <summary>
        /// Gets the change password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IChangePasswordView GetChangePassword(IChangePasswordView changePassword, string message);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        IChangePasswordView ChangePassword(string Email);

        /// <summary>
        /// Gets the change password page.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IChangePasswordView GetChangePasswordPage(string code);

        /// <summary>
        /// Gets the change password page.
        /// </summary>
        /// <param name="changePasswordView">The change password view.</param>
        /// <param name="messagee">The messagee.</param>
        /// <returns></returns>
        IChangePasswordView GetChangePasswordPage(IChangePasswordView changePasswordView, string messagee);

        /// <summary>
        /// Gets the change password page.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="NewPassword">The new password.</param>
        /// <param name="ConfirmNewPassword">The confirm new password.</param>
        /// <returns></returns>
        string ProcessChangePasswordPage(IChangePasswordView changePasswordView);

        #endregion
    }
}