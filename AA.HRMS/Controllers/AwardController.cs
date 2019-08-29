using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin]
    public class AwardController : Controller
    {
        private readonly IAwardService awardService;
        
        public AwardController(IAwardService awardService)
        {
            this.awardService = awardService;
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
        /// Creates the award.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateAward()
        {
            var viewModel = awardService.GetAwardRegistrationView();

            return View("CreateAward", viewModel);
        }

        /// <summary>
        /// Creates the award.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        [HttpPost]
        public ActionResult CreateAward(AwardView awardInfo)
        {
            //Check that Departmnet Info is Not Null
            if (awardInfo == null)
            {
                throw new ArgumentNullException(nameof(awardInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.awardService.CreateAwardUpdatedView(awardInfo, "");
                return View("CreateAward", model);
            }

            //Process The Department Information
            var processingMessage = awardService.ProcessAwardInfo(awardInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.awardService.CreateAwardUpdatedView(awardInfo, processingMessage);
                return this.View("CreateAward", model);
            }

            return this.RedirectToAction("AwardList");
        }

        /// <summary>
        /// Edits the award.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditAward(int awardId)
        {
            var viewModel = awardService.GetAwardEditView(awardId);

            return this.View(viewModel);
        }

        /// <summary>
        /// Edits the award.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        [HttpPost]
        public ActionResult EditAward(AwardView awardInfo)
        {
            if (awardInfo == null)
            {
                throw new ArgumentNullException(nameof(awardInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.awardService.CreateAwardUpdatedView(awardInfo, "");

                return View("EditAward", model);
            }

            var processingMessage = awardService.ProcessEditAwardInfo(awardInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.awardService.CreateAwardUpdatedView(awardInfo, processingMessage);

                return this.View("EditAward", model);
            }

            return this.RedirectToAction("AwardList", new { awardInfo.AwardId });
        }

        /// <summary>
        /// Deletes the award.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteAward(int awardId)
        {
            var viewModel = awardService.GetAwardEditView(awardId);

            return this.View(viewModel);
        }

        /// <summary>
        /// Deletes the award.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <param name="btnSumit">The BTN sumit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">awardId</exception>
        [HttpPost]
        public ActionResult DeleteAward(int awardId, string btnSumit)
        {
            if (awardId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(awardId));
            }

            var returnModel = awardService.ProcessDeleteAwardInfo(awardId);


            return this.RedirectToAction("AwardList");
        }
    }
}