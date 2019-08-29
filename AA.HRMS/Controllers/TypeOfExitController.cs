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
    public class TypeOfExitController : Controller
    {
        private readonly ITypeOfExitService typeOfExitService;
        
        public TypeOfExitController(ITypeOfExitService typeOfExitService)
        {
            this.typeOfExitService = typeOfExitService;
        }

        /// <summary>
        /// Types the of exit list.
        /// </summary>
        /// <param name="selectedTypeOfExitID">The selected type of exit identifier.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult TypeOfExitList(int? selectedTypeOfExitID, string selectedCompany,
            string message)
        {
            
            var viewModel = this.typeOfExitService.CreateTypeOfExitList(selectedTypeOfExitID, selectedCompany, message);

            return this.View("TypeOfExitList", viewModel);
        }
        
        /// <summary>
        /// Creates the type of exit.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateTypeOfExit()
        {

            var viewModel = typeOfExitService.GetTypeOfExitRegistrationView();

            return PartialView("CreateTypeOfExit", viewModel);
        }

        /// <summary>
        /// Creates the type of exit.
        /// </summary>
        /// <param name="typeOfExitInfo">The type of exit information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">typeOfExitInfo</exception>
        [HttpPost]
        public ActionResult CreateTypeOfExit(TypeOfExitView typeOfExitInfo, HttpPostedFileBase typeOfExitExcelFile)
        {

            var processingMessage = string.Empty;

            if (typeOfExitExcelFile != null)
            {
                processingMessage = this.typeOfExitService.ProcessUploadExceltypeOfExit(typeOfExitExcelFile);

                if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.typeOfExitService.GetTypeOfExitUpdateView(typeOfExitInfo, processingMessage);

                return this.View("CreateTypeOfExit", viewModel);
            }

            processingMessage = string.Format("{0} successful added", typeOfExitInfo.TypeOfExitName);

            return this.RedirectToAction("TypeOfExitList", "TypeOfExit", new { message = processingMessage });

        }

            //Check that TypeOfExit Info is Not Null
            if (typeOfExitInfo == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.typeOfExitService.GetTypeOfExitUpdateView(typeOfExitInfo, string.Empty);
                return View("CreateTypeOfExit", model);
            }

            //Process The TypeOfExit Information
             processingMessage = typeOfExitService.ProcessTypeOfExitInfo(typeOfExitInfo);

            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.typeOfExitService.GetTypeOfExitUpdateView(typeOfExitInfo, processingMessage);
                return this.View("CreateTypeOfExit", model);
            }

            processingMessage = string.Format("{0} created successfully", typeOfExitInfo.TypeOfExitName);

            return this.RedirectToAction("TypeOfExitList");
        }

        /// <summary>
        /// Edits the type of exit.
        /// </summary>
        /// <param name="TypeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExitId</exception>
        [HttpGet]
        public ActionResult EditTypeOfExit(int TypeOfExitId)
        {
                if (TypeOfExitId <= 0)
                {
                    throw new ArgumentNullException(nameof(TypeOfExitId));
                }

                var viewModel = this.typeOfExitService.GetTypeOfExitEditView(TypeOfExitId);

                return this.PartialView("EditTypeOfExit", viewModel);
        }

        /// <summary>
        /// Edits the type of exit.
        /// </summary>
        /// <param name="TypeOfExit">The type of exit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExit</exception>
        [HttpPost]
        public ActionResult EditTypeOfExit(TypeOfExitView TypeOfExit)
        {
            if (TypeOfExit == null)
            {
                throw new ArgumentNullException(nameof(TypeOfExit));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.typeOfExitService.GetTypeOfExitUpdateView(TypeOfExit, string.Empty);

                return this.View("EditTypeOfExit", viewModel);
            }

            var returnMessage = this.typeOfExitService.ProcessEditTypeOfExitInfo(TypeOfExit);

            if (!string.IsNullOrEmpty(returnMessage))
            {
                var viewModel = this.typeOfExitService.GetTypeOfExitUpdateView(TypeOfExit, returnMessage);

                return this.View("EditTypeOfExit", viewModel);
            }

            returnMessage = string.Format("{0} Edited", TypeOfExit.TypeOfExitName);

            return this.RedirectToAction("TypeOfExitList", new { message = returnMessage });
        }

        /// <summary>
        /// Deletes the type of exit.
        /// </summary>
        /// <param name="TypeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExitId</exception>
        public ActionResult DeleteTypeOfExit(int TypeOfExitId)
        {

            if (TypeOfExitId <= 0)
            {
                throw new ArgumentNullException(nameof(TypeOfExitId));
            }

            var viewModel = this.typeOfExitService.GetTypeOfExitEditView(TypeOfExitId);

            return this.PartialView("DeleteTypeOfExit", viewModel);
        }

        /// <summary>
        /// Deletes the type of exit.
        /// </summary>
        /// <param name="TypeOfExitId">The type of exit identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExitId</exception>
        [HttpPost]
        public ActionResult DeleteTypeOfExit(int TypeOfExitId, string btnSubmit)
        {
            if (TypeOfExitId <= 0)
            {
                throw new ArgumentNullException(nameof(TypeOfExitId));
            }

            var returnModel = this.typeOfExitService.ProcessDeleteTypeOfExitInfo(TypeOfExitId);


            returnModel = "TypeOfExit Deleted";

            return this.RedirectToAction("TypeOfExitList", new { message = returnModel });

        }
    }
}