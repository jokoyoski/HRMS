using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{ 
    [Authorize]
    [CheckUserLogin]
    public class UserRoleController : Controller
    {
        IUserService userService;

        public UserRoleController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Role        
        /// <summary>
        /// Indexes the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public ActionResult Index(int userId)
        {
            if (userId < 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var viewModel = this.userService.GetUserRoleViewList(userId);

            return this.View("Index", viewModel);
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create        
        /// <summary>
        /// Adds the user role.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">userId</exception>
        [HttpGet]
        public ActionResult AddUserRole(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }


            //Generate View
            var returnView = this.userService.GetUserRoleView(userId);

            return this.PartialView("AddUserRole", returnView);
        }

        // POST: Role/Create        
        /// <summary>
        /// Adds the user role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">user</exception>
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

            returnUrl = string.Format("{0} Created", user.Username);

            return RedirectToAction("Index", "UserRole", new { message = returnUrl});
        }

        // GET: Role/Delete/5        
        /// <summary>
        /// Deletes the user role.
        /// </summary>
        /// <param name="userRoleId">The user role identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRoleId</exception>
        [HttpGet]
        public ActionResult DeleteUserRole(int userAppRoleId)
        {
            if (userAppRoleId < 0)
            {
                throw new ArgumentNullException(nameof(userAppRoleId));
            }

            var returnModel = this.userService.GetDeleteuserRoleView(userAppRoleId);

            return this.PartialView("DeleteUserRole", returnModel);
        }

        // POST: Role/Delete/5        
        /// <summary>
        /// Deletes the user role.
        /// </summary>
        /// <param name="userAppRoleId">The user application role identifier.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userAppRoleId</exception>
        [HttpPost]
        public ActionResult DeleteUserRole(int userAppRoleId, int userId)
        {
            if (userAppRoleId <= 0)
            {
                throw new ArgumentNullException(nameof(userAppRoleId));
            }

            var viewModel = this.userService.ProcessDeleteUserRoleInfo(userAppRoleId);

            viewModel = string.Format("Deleted");

            return RedirectToAction("Index", "UserRole", new {message = viewModel, userId = userId });
        }
    }
}