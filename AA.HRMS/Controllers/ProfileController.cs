using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using System;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Domain.Attributes;


namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IAccountService accountService;
        
        public ProfileController(IProfileService profileService,  IAccountService accountService)
        {
            this.profileService = profileService;
            this.accountService = accountService;
        }

        /// <summary>
        /// Indexes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult Index(string message)
        {
            //Get User Profile
            var profileView = this.accountService.GetUserProfile(message);

            if (profileView == null)
            {
                return RedirectToAction("Create", "Profile");
            }

            return this.View("Index", profileView);
        }
        

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = this.profileService.GetProfileView();
            return this.View("Create", viewModel);
        }

        /// <summary>
        /// Creates the specified profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="profileCv">The profile cv.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">profile</exception>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ProfileModelView profile, HttpPostedFileBase profilePicture, HttpPostedFileBase profileCv)
        {
            

            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            if (!ModelState.IsValid)
            {
                var model = this.profileService.GetProfileView(profile, string.Empty);
                return this.View("Create", model);
            }

            var message = this.profileService.SaveProfileInfo(profile,profilePicture,profileCv);

            if (!string.IsNullOrEmpty(message))
            {
                var model = this.profileService.GetProfileView(profile, message);
                return this.View("Create", model);
            }

            message = string.Format("Profile Created, You need to complete your profile");

            return RedirectToAction("Index", "Profile", new { message });
        }

        /// <summary>
        /// Edits this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            var viewModel = this.profileService.GetProfileEditView();

            return PartialView("Edit", viewModel);
        }

        /// <summary>
        /// Edits the specified profile model information.
        /// </summary>
        /// <param name="profileModelInfo">The profile model information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="profileCV">The profile cv.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">profileModelInfo</exception>
        [HttpPost]
        public ActionResult Edit(ProfileModelView profileModelInfo, HttpPostedFileBase profilePicture,
            HttpPostedFileBase profileCV)
        {
          
            if (profileModelInfo == null)
            {
                throw new ArgumentNullException(nameof(profileModelInfo));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.profileService.GetProfileView(profileModelInfo, string.Empty);

                return this.PartialView("Edit", viewModel);
            }

            var processingMessage = profileService.ProcessProfileEditView(profileModelInfo, profilePicture, profileCV);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.profileService.GetProfileView(profileModelInfo, processingMessage);

                return this.PartialView("Edit", viewModel);
            }

            processingMessage = string.Format("You Successfully Edit your Profile");

            return this.RedirectToAction("Index", "Profile", new { message = processingMessage });
        }
    }
}