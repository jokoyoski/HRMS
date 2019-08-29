using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    public interface IAccountViewsModelFactory
    {

        #region Login/Logoff
        
        /// <summary>
        /// Creates the authentication page.
        /// </summary>
        /// <param name="registrationView">The registration view.</param>
        /// <param name="logOnView">The log on view.</param>
        /// <param name="changePasswordView">The change password view.</param>
        /// <returns></returns>
        IHomeView CreateAuthenticationPage(IRegistrationView registrationView, ILogOnView logOnView, IChangePasswordView changePasswordView, string processingMessage);

        /// <summary>
        /// Creates the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        ILogOnView CreateLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl);

        /// <summary>
        /// Gets my companyies.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processsingMessage">The processsing message.</param>
        /// <returns></returns>
        ICompanyListView GetMyCompanyies(IList<ICompanyDetail> companyCollection, string processsingMessage);

        #endregion

        #region Registration Section

        /// <summary>
        /// Creates the registration view.
        /// </summary>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns></returns>
        IRegistrationView CreateRegistrationView(IList<IHowSource> aboutUsSourceCollection, string selectedRole);

        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns></returns>
        IRegistrationView CreateUpdatedRegistraionView(IRegistrationView registrationInfo, string processingMessage, IList<IHowSource> aboutUsSourceCollection);



        /// <summary>
        /// Generates the activation view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUserActivationCode GenerateActivationView(string processingMessage);

        #endregion
        
        #region Change Password Section

        /// <summary>
        /// Creates the change password view.
        /// </summary>
        /// <returns></returns>
        IChangePasswordView CreateChangePasswordView();

        /// <summary>
        /// Creates the change password view.
        /// </summary>
        /// <param name="changePasswordView">The change password view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IChangePasswordView CreateChangePasswordView(IChangePasswordView changePasswordView, string processingMessage);

        /// <summary>
        /// Creates the change password view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IChangePasswordView CreateChangePasswordView(string processingMessage);

        /// <summary>
        /// Creates the change password page view.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IChangePasswordView CreateChangePasswordPageView(IChangePassword email, string code);

        /// <summary>
        /// Creates the change password page view.
        /// </summary>
        /// <param name="changePasswordView">The change password view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IChangePasswordView CreateChangePasswordPageView(IChangePasswordView changePasswordView, string processingMessage);

        /// <summary>
        /// Creates the change password page view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IChangePasswordView CreateChangePasswordPageView(string processingMessage);

        #endregion


    }
}
