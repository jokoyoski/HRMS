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
    public class SuspensionController : Controller
    {
        private readonly ISuspensionService suspensionService;
        
        public SuspensionController(ISuspensionService suspensionService)
        {
            this.suspensionService = suspensionService;
        }

        /// <summary>
        /// Suspensions the list.
        /// </summary>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="selectedQueryId">The selected query identifier.</param>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult SuspensionList(int? selectedCompany, int? selectedQueryId, int?  selectedEmployeeId,
            string message)
        {

            //Get the display model from the services 
            var viewModel = this.suspensionService.CreateSuspensionList(selectedCompany ?? -1, selectedEmployeeId ?? -1, selectedQueryId ?? -1,  message);

            //return to the view 
            return this.View("SuspensionList", viewModel);
        }



        /// <summary>
        /// Requests the suspension.
        /// </summary>
        /// <returns></returns>
        public ActionResult RequestSuspension()
        {
            return View();
        }

        /// <summary>
        /// Creates the suspension.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateSuspension()
        {
            var viewModel = suspensionService.GetSuspensionRegistrationView();

            return this.PartialView("CreateSuspension", viewModel);
        }

        /// <summary>
        /// Creates the suspension.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionInfo</exception>
        [HttpPost]
        public ActionResult CreateSuspension(SuspensionView suspensionInfo)
        {

            //Check that Suspension Info is Not Null
            if (suspensionInfo == null)
            {
                throw new ArgumentNullException(nameof(suspensionInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.suspensionService.CreateSuspensionUpdatedView(suspensionInfo, string.Empty);
                return View("CreateSuspension", model);
            }
            

            //Process The Suspension Information
            var processingMessage = suspensionService.ProcessSuspensionInfo(suspensionInfo);
            
            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.suspensionService.CreateSuspensionUpdatedView(suspensionInfo, processingMessage);
                return this.View("CreateSuspension", model);
            }

            processingMessage = string.Format("New Suspension Record  Created", suspensionInfo.SuspensionId);

            return this.RedirectToAction("SuspensionList", new { message = processingMessage });
        }

        /// <summary>
        /// Edits the suspension.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionId</exception>
        [HttpGet]
        public ActionResult EditSuspension(int suspensionId)
        {

            if (suspensionId <= 0)
            {
                throw new ArgumentNullException(nameof(suspensionId));
            }

            var viewModel = suspensionService.GetSuspensionEditView(suspensionId);

            return this.PartialView(viewModel);
        }

        /// <summary>
        /// Edits the suspension.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionInfo</exception>
        [HttpPost]
        public ActionResult EditSuspension(SuspensionView suspensionInfo)
        {
            if (suspensionInfo == null)
            {
                throw new ArgumentNullException(nameof(suspensionInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.suspensionService.CreateSuspensionUpdatedView(suspensionInfo, "");

                return View("EditSuspension", model);
            }

            var processingMessage = suspensionService.ProcessEditSuspensionInfo(suspensionInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.suspensionService.CreateSuspensionUpdatedView(suspensionInfo, processingMessage);

                return this.View("EditSuspension", model);
            }

            processingMessage = string.Format("{0} Updated", suspensionInfo.SuspensionId);

            return this.RedirectToAction("SuspensionList", new { message = processingMessage });
        }

        /// <summary>
        /// Deletes the suspension.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">suspensionId</exception>
        [HttpGet]
        public ActionResult DeleteSuspension(int suspensionId)
        {
            if (suspensionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(suspensionId));
            }
            
            var viewModel = suspensionService.GetSuspensionEditView(suspensionId);

            return PartialView("DeleteSuspension", viewModel);
        }

        /// <summary>
        /// Deletes the suspension.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">suspensionId</exception>
        [HttpPost]
        public ActionResult DeleteSuspension(int suspensionId, string btnSubmit)
        {
            if (suspensionId <= 0)
            {
                throw new ArgumentOutOfRangeException("suspensionId");
            }
            
            var message = suspensionService.ProcessDeleteSuspensionInfo(suspensionId);

            var returnMessage = string.Format("Selected Suspension Deleted");

            return this.RedirectToAction("SuspensionList", new { message = returnMessage, });
        }

        /// <summary>
        /// Views the suspension.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">suspensionId</exception>
        [HttpGet]
        public ActionResult ViewSuspension(int suspensionId)
        {
            //Show the detials of a selected Suspension
            if (suspensionId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(suspensionId));
            }

            //Get The View
            var viewModel = this.suspensionService.GetSuspensionEditView(suspensionId);

            return View("ViewSuspension", viewModel);
        }
    }
}