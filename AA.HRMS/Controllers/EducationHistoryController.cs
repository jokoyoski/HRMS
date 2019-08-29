using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin()]
    public class EducationHistoryController : Controller
    {
        private readonly IEducationHistoryService educationHistoryService;
        
        public EducationHistoryController(IEducationHistoryService educationHistoryService)
        {
            this.educationHistoryService = educationHistoryService;
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
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int? employeeId, string URL)
        {
            var viewModel = educationHistoryService.GetEducationHistoryView(employeeId ?? 0, URL);

            return this.PartialView("Create", viewModel);
        }

        /// <summary>
        /// Creates the specified application information.
        /// </summary>
        /// <param name="applicationInfo">The application information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">applicationInfo</exception>
        [HttpPost]
        public ActionResult Create(EducationHistoryView applicationInfo)
        {
            //Check that Grade Info is Not Null
            if (applicationInfo == null)
            {
                throw new ArgumentNullException(nameof(applicationInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = educationHistoryService.GetEducationHistoryView(applicationInfo, string.Empty);
                return View("Create", model);
            }

            //Process The Education History Information
            var message = educationHistoryService.ProcessEducationHistoryInfo(applicationInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(message))
            {
                var model = educationHistoryService.GetEducationHistoryView(applicationInfo, message);
                return this.View("Create", model);
            }


            message = String.Format("New Education History Added name {0}", applicationInfo.SchoolName);

            if (applicationInfo.URL == "/Profile/Index?message=")
            {
                applicationInfo.URL += message;
            }
            else
            {
                applicationInfo.URL += "&message=" + message;
            }
            
            return this.Redirect(applicationInfo.URL);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int educationHistoryId, string URL)
        {
            var model = this.educationHistoryService.GetEducationalEditView(educationHistoryId, URL);

            return this.PartialView("Edit", model);
        }

        /// <summary>
        /// Edits this instance.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(EducationHistoryView educationHistoryInfo)
        {
            if (educationHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(educationHistoryInfo));
            }


            if (!ModelState.IsValid)
            {
                var model = educationHistoryService.GetEducationHistoryView(educationHistoryInfo, string.Empty);
                return View("Edit", educationHistoryInfo);
            }


            var message = educationHistoryService.ProcessEducationHistoryEditView(educationHistoryInfo);

            if (!string.IsNullOrEmpty(message))
            {
                var model = educationHistoryService.GetEducationHistoryView(educationHistoryInfo, message);
                return View("Edit", educationHistoryInfo);
            }
            
            message = String.Format("{0} Education History Updated", educationHistoryInfo.SchoolName);

            if (educationHistoryInfo.URL == "/Profile/Index?message=")
            {
                educationHistoryInfo.URL += message;
            }
            else
            {
                educationHistoryInfo.URL += "&message=" + message;
            }
            
            return this.Redirect(educationHistoryInfo.URL);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int educationHistoryId, string URL)
        {
            var viewModel = this.educationHistoryService.GetEducationHistoryDeleteView(educationHistoryId, URL);

            return PartialView("Delete", viewModel);
        }

        /// <summary>
        /// Deletes the specified education history information.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">educationHistoryInfo</exception>
        [HttpPost]
        public ActionResult Delete(int educationHistoryId, string URL, string btnSubmit)
        {
            if (educationHistoryId <= 0)
            {
                throw new ArgumentNullException(nameof(educationHistoryId));
            }
            //TODO: Add delete logic here
            var viewModel = educationHistoryService.ProcessEducationHistoryDeleteView(educationHistoryId);

            var returnMessage = string.Format("Education History Delete");
            

            if (URL == "/Profile/Index?message=")
            {
                URL += returnMessage;
            }
            else
            {
                URL += "&message=" + returnMessage;
            }

            return this.Redirect(URL);
        }
    }
}