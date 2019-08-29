using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using AA.HRMS.Domain.Attributes;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin()]
    public class EmploymentHistoryController : Controller
    {

        private readonly IEmploymentHistoryService employmentHistoryService;
        
        public EmploymentHistoryController(IEmploymentHistoryService employmentHistoryService)
        {
            this.employmentHistoryService = employmentHistoryService;
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
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details(int id)
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

            //Get The Currenly Logged In User Id
          
            var viewModel = employmentHistoryService.GetEmploymentHistoryView(employeeId ?? 0, URL);

            return PartialView("Create",viewModel);
        }

        /// <summary>
        /// Creates the specified employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryInfo</exception>
        [HttpPost]
        public ActionResult Create(EmploymentHistoryView employmentHistoryInfo)
        {


            if (employmentHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(employmentHistoryInfo));
            }
            
            if (!ModelState.IsValid)
            {
                var model = this.employmentHistoryService.GetEmploymentHistoryView(employmentHistoryInfo, string.Empty);
                return this.View("Create", model);
            }
            
            var message = employmentHistoryService.ProcessEmploymentHistoryInfo(employmentHistoryInfo);

            if (!string.IsNullOrEmpty(message))
            {
                var model = this.employmentHistoryService.GetEmploymentHistoryView(employmentHistoryInfo, message);
                return this.View("Create", model);
            }

            message = string.Format("{0} Employment History Added", employmentHistoryInfo.CompanyName);
            

            if (employmentHistoryInfo.URL == "/Profile/Index?message=")
            {
                employmentHistoryInfo.URL += message;
            }
            else
            {
                employmentHistoryInfo.URL += "&message=" + message;
            }


            return this.Redirect(employmentHistoryInfo.URL);
        }

        /// <summary>
        /// Edits the specified employment history identifier.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int employmentHistoryId, string URL)
        {
            var viewModel = employmentHistoryService.GetEmploymentHistoryEditView(employmentHistoryId, URL);

            return PartialView("Edit", viewModel);
        }

        /// <summary>
        /// Edits the specified employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryInfo</exception>
        [HttpPost]
        public ActionResult Edit(EmploymentHistoryView employmentHistoryInfo)
        {
            if (employmentHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(employmentHistoryInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.employmentHistoryService.GetEmploymentHistoryView(employmentHistoryInfo, "");

                return View("Edit", model);
            }

            var message = employmentHistoryService.ProcessEditEmploymentHistoryInfo(employmentHistoryInfo);

            if (!string.IsNullOrEmpty(message))
            {
                var model = this.employmentHistoryService.GetEmploymentHistoryView(employmentHistoryInfo, message);

                return this.View("Edit", model);
            }

            message = String.Format("Selected Employment History Updated");
            

            if (employmentHistoryInfo.URL == "/Profile/Index?message=")
            {
                employmentHistoryInfo.URL += message;
            }
            else
            {
                employmentHistoryInfo.URL += "&message=" + message;
            }


            return this.Redirect(employmentHistoryInfo.URL);
        }

        /// <summary>
        /// Deletes the specified employment history identifier.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryId</exception>
        [HttpGet]
        public ActionResult Delete(int employmentHistoryId, string URL)
        {
            if (employmentHistoryId < 0)
            {
                throw new ArgumentNullException(nameof(employmentHistoryId));
            }

            var viewModel = this.employmentHistoryService.GetEmploymentHistoryEditView(employmentHistoryId, URL);

            return PartialView("Delete", viewModel);
        }

        /// <summary>
        /// Deletes the specified employment history identifier.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryId</exception>
        [HttpPost]
        public ActionResult Delete(int employmentHistoryId, string URL, string btnSubmit)
        {
            if (employmentHistoryId <= 0)
            {
                throw new ArgumentNullException(nameof(employmentHistoryId));
            }

            var returnMessage = this.employmentHistoryService.DeleteEmploymentHistoryInfo(employmentHistoryId);

            returnMessage = string.Format("Deleted Employment History");

            URL += returnMessage;


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