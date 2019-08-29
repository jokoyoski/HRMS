using System;
using System.Collections.Generic;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Domain.Factories
{
    public class AccountViewsModelFactory : IAccountViewsModelFactory
    {

        #region Login/Logoff

        /// <summary>
        /// Creates the authentication page.
        /// </summary>
        /// <param name="registrationView">The registration view.</param>
        /// <param name="logOnView">The log on view.</param>
        /// <param name="changePasswordView">The change password view.</param>
        /// <returns></returns>
        public IHomeView CreateAuthenticationPage(IRegistrationView registrationView, ILogOnView logOnView, IChangePasswordView changePasswordView, string processingMessage)
        {
            var model = new HomeModelView
            {
                Registration = registrationView,
                LogOn = logOnView,
                ChangePassword = changePasswordView,
                ProcessingMessage = processingMessage,
            };

            return model;
        }

        /// <summary>
        /// Creates the log on view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        public ILogOnView CreateLogOnView(string infoMessage, string errorMessage, string userName, string returnUrl)
        {
            var model = new LogOnView
            {
                InfoMessage = infoMessage ?? "",
                ErrorMessage = errorMessage ?? "",
                UserName = userName ?? "",
                ReturnUrl = returnUrl ?? ""
            };

            return model;
        }

        /// <summary>
        /// Gets my companyies.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processsingMessage">The processsing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyCollection</exception>
        public ICompanyListView GetMyCompanyies(IList<ICompanyDetail> companyCollection, string processsingMessage)
        {
            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            var result = new CompanyListView
            {
                CompanyCollection = companyCollection,
                ProcessingMessage = processsingMessage,
            };

            return result;
        }
        
        #endregion

        #region Registration Section

        /// <summary>
        /// Creates the registration view.
        /// </summary>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns>
        /// Returns Registration view model
        /// </returns>
        /// <exception cref="ArgumentNullException">aboutUsSourceCollection</exception>
        public IRegistrationView CreateRegistrationView(IList<IHowSource> aboutUsSourceCollection, string selectedRole)
        {
            if (aboutUsSourceCollection == null)
            {
                throw new ArgumentNullException("aboutUsSourceCollection");
            }

            var aboutUsSourceDDL = GetDropDownList.AboutUsSourceListItems(aboutUsSourceCollection, -1);

            var view = new RegistrationView
            {
                AboutUsSourceDropDown = aboutUsSourceDDL,
                ProcessingMessage = string.Empty,
                SelectedRole = selectedRole
            };

            return view;
        }

        /// <summary>
        /// Creates the updated registraion view.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="aboutUsSourceCollection">The about us source collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// registrationInfo
        /// or
        /// aboutUsSourceCollection
        /// </exception>
        public IRegistrationView CreateUpdatedRegistraionView(IRegistrationView registrationInfo,
            string processingMessage, IList<IHowSource> aboutUsSourceCollection)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            if (aboutUsSourceCollection == null)
            {
                throw new ArgumentNullException(nameof(aboutUsSourceCollection));
            }

            var aboutUsSourceDDL =
                GetDropDownList.AboutUsSourceListItems(aboutUsSourceCollection, registrationInfo.AboutUsSourceId);

            registrationInfo.AboutUsSourceDropDown = aboutUsSourceDDL;

            return registrationInfo;
        }


        /// <summary>
        /// Generates the activation view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IUserActivationCode GenerateActivationView(string processingMessage)
        {
            var view = new UserActivationCodeModel
            {
                ProcessingMessage = processingMessage
            };

            return view;
        }

        #endregion

        #region Changee Password
        
        /// <summary>
        /// Creates the change password view.
        /// </summary>
        /// <returns></returns>
        public IChangePasswordView CreateChangePasswordView()
        {
            var result = new ChangePasswordView
            {
                ProcessingMessage = string.Empty
            };

            return result;
        }

        /// <summary>
        /// Creates the change password view.
        /// </summary>
        /// <param name="changePasswordView">The change password view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IChangePasswordView CreateChangePasswordView(IChangePasswordView changePasswordView, string processingMessage)
        {
            changePasswordView.ProcessingMessage = processingMessage;

            return changePasswordView;
        }

        /// <summary>
        /// Creates the change password view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IChangePasswordView CreateChangePasswordView(string processingMessage)
        {
            var view = new ChangePasswordView
            {
                ProcessingMessage = processingMessage
            };

            return view;
        }

        /// <summary>
        /// Creates the change password page view.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">changePassword</exception>
        public IChangePasswordView CreateChangePasswordPageView(IChangePassword changePassword, string code)
        {

            if (changePassword == null)
            {
                throw new ArgumentNullException(nameof(changePassword));
            }

            var result = new ChangePasswordView
            {
                Email = changePassword.Email,
                Code = changePassword.Code,
            };

            return result;
        }

        /// <summary>
        /// Creates the change password page view.
        /// </summary>
        /// <param name="changePasswordView">The change password view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IChangePasswordView CreateChangePasswordPageView(IChangePasswordView changePasswordView, string processingMessage)
        {

            if (changePasswordView == null)
            {
                throw new ArgumentNullException(nameof(changePasswordView));
            }

            changePasswordView.ProcessingMessage = processingMessage;

            return changePasswordView;
        }

        /// <summary>
        /// Creates the change password page view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IChangePasswordView CreateChangePasswordPageView(string processingMessage)
        {
            var view = new ChangePasswordView
            {
                ProcessingMessage = processingMessage
            };

            return view;
        }

        #endregion
        
    }
}