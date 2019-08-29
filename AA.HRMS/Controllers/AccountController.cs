using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AA.HRMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly ISessionStateService session;

        public AccountController(IAccountService accountService, ISessionStateService session)
        {
            this.accountService = accountService;
            this.session = session;
        }
        
        #region Login/Logoff Section
        
        /// <summary>
        /// Indexes the specified home model view.
        /// </summary>
        /// <param name="homeModelView">The home model view.</param>
        /// <returns></returns>
        public ActionResult Index(string message)
        {
            var viewModel = this.accountService.GetAutthenicationPage(message);

            return this.View("Index", viewModel);
        }

        /// <summary>
        /// Logins the specified information message.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        public ActionResult Login(string infoMessage = "", string errorMessage = "", string userName = "",
            string returnUrl = "")
        {
            var viewModel = this.accountService.GetLogOnView(infoMessage, errorMessage, userName, returnUrl);

            return this.View("Login", viewModel);
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">model</exception>
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LogOnView model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            

            if (!this.ModelState.IsValid)
            {
                return View("Login", model);
            }
            

            var isUserValid = this.accountService.SignIn(model);


            if (isUserValid)
            {
                var url = string.Empty;

                var roles = (String[])this.session.GetSessionValue(SessionKey.UserRoles);

                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    url = model.ReturnUrl;
                }else

                if (roles.Contains("Administration") || roles.Contains("CompanyAdmin"))
                {
                    url = "/Account/MyCompanies";
                }
                
                else if (roles.Contains("Employee"))
                {
                    url = "/Home/EmployeeDashBoard";
                }

                return Redirect(url);
            }

            this.ModelState.AddModelError("", Messages.IncorrectPasswordText);

            return this.View("Login", model);
        }

        /// <summary>
        /// Mies the companies.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [CheckUserLogin]
        public ActionResult MyCompanies(string message)
        {
            var viewModel = this.accountService.GetMyCompanies(message);
            

            return this.View("MyCompanies", viewModel);
        }

        /// <summary>
        /// Mies the companies.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">companyId</exception>
        [HttpPost]
        [Authorize]
        [CheckUserLogin]
        public ActionResult MyCompanies(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            
            if (!ModelState.IsValid)
            {
                var viewModel = this.accountService.GetMyCompanies("");
                return View("MyCompanies", viewModel);
            }

            var processingMessage = this.accountService.SwitchCompanies(companyId);
            
            return this.RedirectToAction("AdminDashboard", "Home");
        }

        /// <summary>
        /// Logs the off.
        /// </summary>  
        /// <returns></returns>
        public ActionResult LogOff()
        { 
            // this service signs the user off/logs off
            this.accountService.SignOff();

            return this.RedirectToAction("Login");
        }

        #endregion
        
        #region Register Region

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        public ActionResult Register(string selectedRole)
        {

            if (string.IsNullOrEmpty(selectedRole))
            {
                return RedirectToAction("Index", "Account", new { message = "You must choose whether you are an Employee or Company Administrator" });
            }

            var viewModel = this.accountService.GetRegistrationView(selectedRole);

            return this.View("Register", viewModel);
        }

        /// <summary>
        /// Registers the specified registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        [AllowAnonymous, HttpPost]
        public ActionResult Register(RegistrationView register)
        {
            
            if (register == null)
            {
                throw new ArgumentNullException("registrationInfo");
            }
            

            // check if entries are valid based on definitions in RegistrationView model
            if (!this.ModelState.IsValid)
            {
                
                var returnMode = this.accountService.GetRegistrationView(register);
                
                return this.View("Register", returnMode);
            }

            // call service in domain to process Registration information
            var returnModel = this.accountService.ProcessRegistrationInfo(register);

            // check if there is error message then redisplay view using model
            if (!string.IsNullOrEmpty(returnModel.ProcessingMessage))
            {
 
                return this.View("Register", returnModel);
            }
            
            returnModel.ProcessingMessage = string.Format("{0}, you have successfully registered for AALHRMS. Check your email to validate you account.", returnModel.FirstName + " " + returnModel.LastName);
            
            return this.RedirectToAction("login", new { infoMessage = returnModel.ProcessingMessage });
        }
        
        /// <summary>
        /// email confirmation
        /// </summary>
        /// <returns></returns>
        public ActionResult Confirm(string message)
        {
            return this.View("Confirm", new { message });
        }

        /// <summary>
        /// Activates the specified activation code.
        /// </summary>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">activationCode</exception>
        [HttpGet]
        public ActionResult Activate(string activationCode)
        {
            if (activationCode == null)
            {
                throw new ArgumentNullException(nameof(activationCode));
            }

            var message = accountService.ActivateAccount(activationCode);

            if (message == string.Empty)
            {
                message = "Your account is activated";
            }

            //Generate the View From the Factory
            var model = accountService.GenerateActivationView(message);


            return this.View("Activate",model);
        }

        #endregion

        #region Password Reset

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangePassword()
        {
            var viewModel = accountService.GetChangePassword();
            
            return this.View("ChangePassword", viewModel);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="change">The change.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">change</exception>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordView change)
        {
            if (change == null)
            {
                throw new ArgumentNullException(nameof(change));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.accountService.GetChangePassword(change, string.Empty);

                return this.View("ChangePassword", viewModel);
            }

            var message = accountService.ChangePassword(change.Email);
            
            return this.RedirectToAction("Login", new { infoMessage = message.ProcessingMessage });
        }

        /// <summary>
        /// Changes the password page.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangePasswordPage(string code)
        {

            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            var viewModel = accountService.GetChangePasswordPage(code);

            return this.View("ChangePasswordPage", viewModel);

        }

        /// <summary>
        /// Changes the password page.
        /// </summary>
        /// <param name="change">The change.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePasswordPage(ChangePasswordView changePasswordView)
        {
            if (changePasswordView == null)
            {
                throw new ArgumentNullException(nameof(changePasswordView));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.accountService.GetChangePasswordPage(changePasswordView, string.Empty);

                return this.View("ChangePasswordPage", viewModel);
            }
            
            var message = accountService.ProcessChangePasswordPage(changePasswordView);

            if (!string.IsNullOrEmpty(message))
            {
                var viewModel = this.accountService.GetChangePasswordPage(changePasswordView, message);

                return this.View("ChangePasswordPage", viewModel);
            }

            message = string.Format("{0} has successfully change password", changePasswordView.Email);

            return this.RedirectToAction("Login", new { infoMessage = message });
        }

        #endregion
    }
}