using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin]
    public class ExitManagementController : Controller
    {
        private readonly IExitManagementService exitManagementService;

        public ExitManagementController(IExitManagementService exitManagementService)
        {
            this.exitManagementService = exitManagementService;
        }

        /// <summary>
        /// Employees the exit list.
        /// </summary>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeExitId">The selected employee exit identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeExitList(string selectedCompanyName, int? selectedEmployeeExitId,
            string message)
        {

            var viewModel = this.exitManagementService.CreateEmployeeExitList(selectedEmployeeExitId, selectedCompanyName, message);

            return this.View("EmployeeExitList", viewModel);
        }

        /// <summary>
        /// Adds the employee exit.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        [HttpGet]
        public ActionResult AddEmployeeExit(int employeeId)
        {
            if (employeeId <= 0) throw new ArgumentNullException(nameof(employeeId));
            
            var viewModel = exitManagementService.GetEmployeeExitView(employeeId);

            return this.View("AddEmployeeExit", viewModel);
        }

        /// <summary>
        /// Adds the employee exit.
        /// </summary>
        /// <param name="employeeExitView">The employee exit view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeExitView</exception>
        [HttpPost]
        public ActionResult AddEmployeeExit(EmployeeExitView employeeExitView)
        {

            //Check that Training Info is Not Null
            if (employeeExitView == null)
            {
                throw new ArgumentNullException(nameof(employeeExitView));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.exitManagementService.CreateEmployeeExitUpdatedView(employeeExitView, string.Empty);
                return PartialView("AddEmployeeExit", model);
            }

            //Process The Training Information
            var processingMessage = this.exitManagementService.ProcessEmployeeExitInfo(employeeExitView);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.exitManagementService.CreateEmployeeExitUpdatedView(employeeExitView, processingMessage);
                return this.View("AddEmployeeExit", model);
            }

            processingMessage = string.Format("{0} Exited", employeeExitView.Name);

            return this.RedirectToAction("AddEmployeeExit", new { employeeId = employeeExitView.EmployeeId,  message = processingMessage });
        }
    }
}