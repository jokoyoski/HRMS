using System;
using System.Web.Mvc;
using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        public ActionResult Register()
        {
            var viewModel = this.userService.GetUserRegistrationView();

            return this.View("Register", viewModel);
        }

        /// <summary>
        /// Registers the specified registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        [AllowAnonymous, HttpPost]
        public ActionResult Register(UsersView registrationInfo)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException("registrationInfo");
            }

            // check if entries are valid based on definations in RegistrationView model
            if (!this.ModelState.IsValid)
            {
                return this.View("Register", registrationInfo);
            }

            // call service in domain to process Registration information
            var returnModel = this.userService.ProcessUserRegistrationInfo(registrationInfo);

            // check if there is error message then redisplay view using model
            if (!string.IsNullOrEmpty(returnModel.ProcessingMessage))
            {
                return this.View("Register", returnModel);
            }

            return this.RedirectToAction("Register", "Company",
                new {companyId = returnModel.CompanyId, companyAdministratorId = 1});
        }

        /// <summary>
        /// Edits the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        [HttpGet]
        public ActionResult AddUserRole(int userId)
        {
            if (userId == null )
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var returnView = this.userService.GetUserRoleView(userId);
            
            return this.View("AddUserRole", returnView);
        }

        /// <summary>
        /// Edits the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddUserRole(UserAppRoleView user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.userService.GetUpdatedUserRoleView(user, string.Empty);

                return this.View("AddUserRole", viewModel);
            }

            var returnUrl = this.userService.ProcessUserAppRole(user);

            if (!string.IsNullOrEmpty(returnUrl))
            {
                var viewModel = this.userService.GetUpdatedUserRoleView(user, returnUrl);

                return this.View("AddUserRole", viewModel);
            }

            returnUrl = string.Format("{0} Added", user.Username);

            return RedirectToAction("Administration", "User", new { message = returnUrl });
        }

        /// <summary>
        /// Edits the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        [HttpGet]
        public ActionResult EditUser(int userId)
        {

            if (userId <= 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var returnView = this.userService.GetEditUserView(userId);

            return this.PartialView("EditUser", returnView);
        }

        /// <summary>
        /// Edits the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">user</exception>
        [HttpPost]
        public ActionResult EditUser(UserViewModel user)
        {

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            //if (!ModelState.IsValid)
            //{
            //    var returnModel = this.userService.GetEditUserView(user, string.Empty);

            //    return this.View("EditUser", returnModel);
            //}

            var returnUrl = this.userService.ProcessEditUser(user);

            if (!string.IsNullOrEmpty(returnUrl))
            {
                var returnModel = this.userService.GetEditUserView(user, returnUrl);

                return this.View("EditUser", returnModel);
            }

            returnUrl = string.Format("{0} Updated", user.Username);

            return RedirectToAction("User", "Administration", new { message = returnUrl });
        }

    }
}