using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Services;
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
    [CheckUserLogin]
    public class OverTimesheetController : Controller
    {
        private readonly ICompanySetupServices companySetupServices;


        public OverTimesheetController(ICompanySetupServices companySetupServices)
        {
            this.companySetupServices = companySetupServices;
        }

        /// <summary>
        /// Overs the timesheet list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult OverTimesheetList(int? selectedCompanyId, string selectedEmployeeName, string processingMessage)
        {
            var viewModel = this.companySetupServices.GetCreateOverTimeSheetView(selectedEmployeeName, selectedCompanyId ?? -1, processingMessage);

            return this.View("OverTimesheetList", viewModel);
        }

        /// <summary>
        /// Creates the over timesheet view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateOverTimesheetView()
        {

           var viewModel = companySetupServices.GetCreateOverTimeSheetView();

            return PartialView("CreateOverTimesheetView", viewModel);
        }

        /// <summary>
        /// Creates the over timesheet view.
        /// </summary>
        /// <param name="OverTimesheetinfo">The over timesheetinfo.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">OverTimesheetinfo</exception>
        [HttpPost]
        public ActionResult CreateOverTimesheetView(OverTimesheetView OverTimesheetinfo)
        {

            //Check that Departmnet Info is Not Null 
            if (OverTimesheetinfo == null)
            {
                throw new ArgumentNullException(nameof(OverTimesheetinfo));
            }
            
            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.companySetupServices.GetCreateOverTimeSheetView(OverTimesheetinfo, string.Empty);

                return this.View("CreateOverTimesheetView", model);
            }

            //Process The Department Information
            var processingMessage = companySetupServices.ProcessOverTimeSheetInfo(OverTimesheetinfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.companySetupServices.GetCreateOverTimeSheetView(OverTimesheetinfo, processingMessage);

                return this.View("CreateOverTimesheetView", model);
            }

            return this.RedirectToAction("OverTimesheetList");

        }

        /// <summary>
        /// Edits the over timesheet view.
        /// </summary>
        /// <param name="overTimeSheetId">The over time sheet identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditOverTimesheetView(int overTimeSheetId)
        {
            var viewModel = companySetupServices.GetEditCreateOverTimeSheetView(overTimeSheetId);

            return PartialView("EditOverTimesheetView", viewModel);
        }

        /// <summary>
        /// Edits the over timesheet view.
        /// </summary>
        /// <param name="OverTimesheetinfo">The over timesheetinfo.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">OverTimesheetinfo</exception>
        [HttpPost]
        public ActionResult EditOverTimesheetView(OverTimesheetView OverTimesheetinfo)
        {

            //Check that Departmnet Info is Not Null 
            if (OverTimesheetinfo == null)
            {
                throw new ArgumentNullException(nameof(OverTimesheetinfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.companySetupServices.GetCreateOverTimeSheetView(OverTimesheetinfo, string.Empty);

                return this.View("EditOverTimesheetView", model);
            }

            //Process The Department Information
            var processingMessage = companySetupServices.ProcessEditOverTimeSheetInfo(OverTimesheetinfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.companySetupServices.GetCreateOverTimeSheetView(OverTimesheetinfo, processingMessage);

                return this.View("EditOverTimesheetView", model);
            }

            return this.RedirectToAction("OverTimesheetList");

        }

        /// <summary>
        /// Deletes the over timesheet view.
        /// </summary>
        /// <param name="overTimeSheetId">The over time sheet identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteOverTimesheetView(int overTimeSheetId)
        {
            var viewModel = companySetupServices.GetEditCreateOverTimeSheetView(overTimeSheetId);

            return PartialView("DeleteOverTimesheetView", viewModel);
        }

        /// <summary>
        /// Deletes the over timesheet view.
        /// </summary>
        /// <param name="OverTimesheetId">The over timesheet identifier.</param>
        /// <param name="submitBtn">The submit BTN.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">OverTimesheetId</exception>
        [HttpPost]
        public ActionResult DeleteOverTimesheetView(int OverTimesheetId, string submitBtn)
        {

            //Check that Departmnet Info is Not Null 
            if (OverTimesheetId <= 0)
            {
                throw new ArgumentNullException(nameof(OverTimesheetId));
            }

            //Process The Department Information
            var processingMessage = companySetupServices.ProcessDeleteOverTimeSheetInfo(OverTimesheetId);

            return this.RedirectToAction("OverTimesheetList");
        }


    }
}