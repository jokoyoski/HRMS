using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin()]
    public class PerformanceManagementController : Controller
    {
        private readonly IPerformanceManagementService performanceManagementService;
        private readonly IUserService userService;

        public PerformanceManagementController(IUserService userService, IPerformanceManagementService performanceManagementService)
        {
            this.performanceManagementService = performanceManagementService;
            this.userService = userService;
        }
        
        #region //=========================================Appraisal Action ==============================================//    

        /// <summary>
        /// Appraisals the action list.
        /// </summary>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">viewModel</exception>
        public ActionResult AppraisalActionList(string ProcessingMessage)
        {

            var viewModel = performanceManagementService.GetAppraisalActionListViewByCompanyId(ProcessingMessage);

            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            return View("AppraisalActionList", viewModel);
        }

        /// <summary>
        /// Creates the appraisal action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateAppraisalAction()
        {
            var viewModel = performanceManagementService.GetAppraisalActionRegistrationView();

            return this.PartialView("CreateAppraisalAction", viewModel);
        }

        /// <summary>
        /// Creates the appraisal action.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppraisalAction(AppraisalActionView appraisalActionInfo)
        {

            if (appraisalActionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalActionInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalActionUpdateView(appraisalActionInfo, string.Empty);

                return this.View("CreateAppraisalAction", model);
            }


            var processingMessage = performanceManagementService.ProcessAppraisalActionInfo(appraisalActionInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalActionUpdateView(appraisalActionInfo, processingMessage);

                return this.View("CreateAppraisalAction", model);
            }

            return RedirectToAction("AppraisalActionList");
        }

        /// <summary>
        /// Edits the appraisal action.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditAppraisalAction(int appraisalActionId)
        {
            var viewModel = performanceManagementService.GetAppraisalActionEditView(appraisalActionId);

            return this.PartialView("EditAppraisalAction", viewModel);
        }

        /// <summary>
        /// Edits the appraisal action.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppraisalAction(AppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalActionInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalActionUpdateView(appraisalActionInfo, string.Empty);

                return this.View("EditAppraisalAction", model);
            }

            var processingMessage = performanceManagementService.ProcessEditAppraisalActionInfo(appraisalActionInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalActionUpdateView(appraisalActionInfo, processingMessage);

                return this.View("EditAppraisalAction", model);
            }

            return RedirectToAction("AppraisalActionList");
        }

        /// <summary>
        /// Deletes the appraisal action.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteAppraisalAction(int appraisalActionId)
        {
            var viewModel = performanceManagementService.GetAppraisalActionEditView(appraisalActionId);

            return this.PartialView("DeleteAppraisalAction", viewModel);
        }

        /// <summary>
        /// Deletes the appraisal action.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalActionId</exception>
        [HttpPost]
        public ActionResult DeleteAppraisalAction(int appraisalActionId, string btnSubmit = "")
        {
            if (appraisalActionId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(appraisalActionId));
            }

            var returnModel = performanceManagementService.ProcessDeleteAppraisalActionInfo(appraisalActionId);


            return this.RedirectToAction("AppraisalActionList");
        }

        #endregion

        #region //============================================APPRAISAL RATING===================================// 

        /// <summary>
        /// Appraisals the rating list.
        /// </summary>
        /// <returns></returns>
        public ActionResult AppraisalRatingList()
        {
            var viewModel = performanceManagementService.GetAppraisalRatingListView();

            return View("AppraisalRatingList", viewModel);
        }

        /// <summary>
        /// Creates the appraisal rating.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateAppraisalRating()
        {
            var viewModel = performanceManagementService.GetAppraisalRatingRegistrationView();

            return View("CreateAppraisalRating", viewModel);
        }

        /// <summary>
        /// Creates the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppraisalRating(AppraisalRatingView appraisalRatingInfo)
        {

            if (appraisalRatingInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalRatingInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalRatingUpdateView(appraisalRatingInfo, "");
                return View("CreateAppraisalRating", model);
            }


            var processingMessage = performanceManagementService.ProcessAppraisalRatingInfo(appraisalRatingInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalRatingUpdateView(appraisalRatingInfo, processingMessage);
                return View("CreateAppraisalRating", model);
            }

            return RedirectToAction("AppraisalRatingList");
        }

        /// <summary>
        /// Edits the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        public ActionResult EditAppraisalRating(int appraisalRatingId)
        {
            var viewModel = performanceManagementService.GetAppraisalRatingEditView(appraisalRatingId);

            return View("EditAppraisalRating", viewModel);
        }

        /// <summary>
        /// Edits the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppraisalRating(AppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalRatingInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalRatingUpdateView(appraisalRatingInfo, string.Empty);

                return View("EditAppraisalRating", model);
            }

            var processingMessage = performanceManagementService.ProcessEditAppraisalRatingInfo(appraisalRatingInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalRatingUpdateView(appraisalRatingInfo, processingMessage);

                return View("EditAppraisalRating", model);
            }

            return RedirectToAction("AppraisalActionList");
        }

        /// <summary>
        /// Deletes the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteAppraisalRating(int appraisalRatingId)
        {
            var viewModel = performanceManagementService.GetAppraisalRatingEditView(appraisalRatingId);

            return View("DeleteAppraisalRating", viewModel);
        }

        /// <summary>
        /// Deletes the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalRatingId</exception>
        [HttpPost]
        public ActionResult DeleteAppraisalRating(int appraisalRatingId, string btnSubmit = "")
        {
            if (appraisalRatingId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(appraisalRatingId));
            }

            var returnModel = performanceManagementService.ProcessDeleteAppraisalRatingInfo(appraisalRatingId);


            return this.RedirectToAction("AppraisalRatingList");
        }

        #endregion

        #region //============================================APPRAISER==========================================//       
        
        /// <summary>
        /// Appraisers the list.
        /// </summary>
        /// <returns></returns>
        public ActionResult AppraiserList()
        {
            var viewModel = performanceManagementService.GetAppraiserListView();

            return View("AppraiserList", viewModel);
        }

        /// <summary>
        /// Creates the appraiser.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateAppraiser()
        {
            var viewModel = performanceManagementService.GetAppraiserRegistrationView();

            return View("CreateAppraiser", viewModel);
        }

        /// <summary>
        /// Creates the appraiser.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppraiser(AppraiserView appraiserInfo)
        {

            if (appraiserInfo == null)
            {
                throw new ArgumentNullException(nameof(appraiserInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraiserUpdateView(appraiserInfo, "");
                return View("CreateAppraiser", model);
            }


            var processingMessage = performanceManagementService.ProcessAppraiserInfo(appraiserInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraiserUpdateView(appraiserInfo, processingMessage);
                return View("CreateAppraiser", model);
            }

            return RedirectToAction("AppraiserList");
        }

        /// <summary>
        /// Edits the appraiser.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditAppraiser(int appraiserId)
        {
            var viewModel = performanceManagementService.GetAppraiserEditView(appraiserId);

            return View("EditAppraiser", viewModel);
        }

        /// <summary>
        /// Edits the appraiser.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppraiser(AppraiserView appraiserInfo)
        {
            if (appraiserInfo == null)
            {
                throw new ArgumentNullException(nameof(appraiserInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraiserUpdateView(appraiserInfo, string.Empty);

                return View("EditAppraiser", model);
            }

            var processingMessage = performanceManagementService.ProcessEditAppraiserInfo(appraiserInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraiserUpdateView(appraiserInfo, processingMessage);

                return View("EditAppraiser", model);
            }

            return RedirectToAction("AppraiserList");
        }

        /// <summary>
        /// Deletes the appraiser.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteAppraiser(int appraiserId)
        {
            var viewModel = performanceManagementService.GetAppraiserEditView(appraiserId);

            return View("DeleteAppraiser", viewModel);
        }

        /// <summary>
        /// Deletes the appraiser.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraiserId</exception>
        [HttpPost]
        public ActionResult DeleteAppraiser(int appraiserId, string btnSubmit = "")
        {
            if (appraiserId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(appraiserId));
            }

            var returnModel = performanceManagementService.ProcessDeleteAppraiserInfo(appraiserId);


            return this.RedirectToAction("AppraiserList");
        }

        #endregion

        #region //===========================================APPRAISAL GOAL=============================//    
        
        /// <summary>
        /// Appraisals the goal list.
        /// </summary>
        /// <returns></returns>
        public ActionResult AppraisalGoalList(int employeeAppraisalId, string message, string url)

        {
            var viewModel = performanceManagementService.GetAppraisalGoalListView(employeeAppraisalId, message);

            viewModel.URL = url;

            return this.View("AppraisalGoalList", viewModel);
        }

        /// <summary>
        /// Views the appraisal goal.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        public ActionResult ViewAppraisalGoal(int appraisalGoalId)
        {
            var viewModel = performanceManagementService.GetAppraisalGoalEditView(appraisalGoalId, "");

            return PartialView("ViewAppraisalGoal", viewModel);
        }

        /// <summary>
        /// Creates the appraisal goal.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateAppraisalGoal(int employeeAppraisalId, string url)
        {
            var viewModel = performanceManagementService.GetAppraisalGoalRegistrationView(employeeAppraisalId);

            viewModel.URL = url;

            return View("CreateAppraisalGoal", viewModel);
        }

        /// <summary>
        /// Creates the appraisal goal.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalGoalInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppraisalGoal(AppraisalGoalView appraisalGoalInfo, string url)
        {

            if (appraisalGoalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalGoalInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalGoalUpdateView(appraisalGoalInfo, "");
                return View("CreateAppraisalGoal", model);
            }


            var processingMessage = performanceManagementService.ProcessAppraisalGoalInfo(appraisalGoalInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalGoalUpdateView(appraisalGoalInfo, processingMessage);
                return View("CreateAppraisalGoal", model);
            }

            return RedirectToAction("AppraisalGoalList", new { employeeAppraisalId = appraisalGoalInfo.EmployeeAppraisalId, url = url });
        }

        /// <summary>
        /// Edits the appraisal goal.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        public ActionResult EditAppraisalGoal(int appraisalGoalId, string url)
        {
            var viewModel = performanceManagementService.GetAppraisalGoalEditView(appraisalGoalId, "");

            viewModel.URL = url;

            return PartialView("EditAppraisalGoal", viewModel);
        }

        /// <summary>
        /// Edits the appraisal goal.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalGoalInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppraisalGoal(AppraisalGoalView appraisalGoalInfo, string url)
        {
            if (appraisalGoalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalGoalInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalGoalUpdateView(appraisalGoalInfo, string.Empty);

                return View("EditAppraisalGoal", model);
            }

            var processingMessage = performanceManagementService.ProcessEditAppraisalGoalInfo(appraisalGoalInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalGoalUpdateView(appraisalGoalInfo, processingMessage);

                return View("EditAppraisalGoal", model);
            }

            return RedirectToAction("AppraisalGoalList", new { employeeAppraisalId = appraisalGoalInfo.EmployeeAppraisalId, url = url });
        }

        /// <summary>
        /// Deletes the appraisal goal.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteAppraisalGoal(int appraisalGoalId, string url)
        {
            var viewModel = performanceManagementService.GetAppraisalGoalEditView(appraisalGoalId, "");

            viewModel.URL = url;

            return PartialView("DeleteAppraisalGoal", viewModel);
        }

        /// <summary>
        /// Deletes the appraisal goal.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalGoalId</exception>
        [HttpPost]
        public ActionResult DeleteAppraisalGoal(int appraisalGoalId, string btnSubmit, string url)
        {
            if (appraisalGoalId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(appraisalGoalId));
            }

            var returnModel = performanceManagementService.ProcessDeleteAppraisalGoalInfo(appraisalGoalId);

            var viewModel = performanceManagementService.GetAppraisalGoalEditView(appraisalGoalId, "");

            return this.RedirectToAction("AppraisalGoalList", new { employeeAppraisalId = viewModel.EmployeeAppraisalId, url = url });
        }

        #endregion

        #region //============================================EMPLOYEE GOAL TASK===================================// 

        /// <summary>
        /// Appraisals the rating list.
        /// </summary>
        /// <returns></returns>
        public ActionResult TaskList(string processingMessage)
        {
            var viewModel = performanceManagementService.GetTaskListView(processingMessage);

            return View("TaskList", viewModel);
        }

        /// <summary>
        /// Appraisals the rating list.
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeTaskList(int employeeId, string processingMessage)
        {
            var viewModel = performanceManagementService.GetEmployeeTaskListView(employeeId, processingMessage);

            return View("EmployeeTaskList", viewModel);
        }
        
        /// <summary>
        /// Employees the task details.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmployeeTaskDetails(int employeeTaskId)
        {
            var viewModel = performanceManagementService.GetEmployeeTaskDetailsView(employeeTaskId);

            return this.PartialView("EmployeeTaskDetails", viewModel);
        }

        /// <summary>
        /// Creates the appraisal rating.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateEmployeeTask(int appraisalGoalId)
        {
            var viewModel = performanceManagementService.GetEmployeeTaskRegistrationView(appraisalGoalId);

            return this.PartialView("CreateEmployeeTask", viewModel);
        }

        /// <summary>
        /// Creates the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployeeTask(EmployeeTaskView employeeTaskInfo)
        {

            if (employeeTaskInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeTaskInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateEmployeeTaskUpdateView(employeeTaskInfo, "");
                return View("CreateEmployeeTask", model);
            }


            var processingMessage = performanceManagementService.ProcessEmployeeTaskInfo(employeeTaskInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateEmployeeTaskUpdateView(employeeTaskInfo, processingMessage);
                return View("CreateEmployeeTask", model);
            }

            return RedirectToAction("EmployeeTaskList");
        }

        /// <summary>
        /// Edits the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        public ActionResult EditEmployeeTask(int employeeTaskId)
        {
            var viewModel = performanceManagementService.GetEmployeeTaskEditView(employeeTaskId);

            return this.PartialView("EditEmployeeTask", viewModel);
        }

        /// <summary>
        /// Edits the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeeTask(EmployeeTaskView employeeTaskInfo)
        {
            if (employeeTaskInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeTaskInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateEmployeeTaskUpdateView(employeeTaskInfo, string.Empty);

                return View("EditEmployeeTask", model);
            }

            var processingMessage = performanceManagementService.ProcessEditEmployeeTaskInfo(employeeTaskInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateEmployeeTaskUpdateView(employeeTaskInfo, processingMessage);

                return View("EditEmployeeTask", model);
            }

            return RedirectToAction("EmployeeTaskList");
        }

        /// <summary>
        /// Deletes the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteEmployeeTask(int employeeTaskId)
        {
            var viewModel = performanceManagementService.GetEmployeeTaskDeleteView(employeeTaskId);

            return this.PartialView("DeleteEmployeeTask", viewModel);
        }

        /// <summary>
        /// Deletes the appraisal rating.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalRatingId</exception>
        [HttpPost]
        public ActionResult DeleteEmployeeTaskInfo(int employeeTaskId)
        {
            if (employeeTaskId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(employeeTaskId));
            }

            var returnModel = performanceManagementService.ProcessDeleteEmployeeTaskInfo(employeeTaskId);


            return this.RedirectToAction("EmployeeTaskList");
        }

        #endregion

        #region //===================================Milestone Section=================================//

        /// <summary>
        /// Milestoneses the specified task identifier.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult Milestones(int taskId, string processingMessage)
        {
            var viewModel = this.performanceManagementService.GetMilestoneListByTask(taskId, processingMessage);

            return this.View("Milestones", viewModel);
        }


        #endregion

        #region //======================================APPRAISAL====================================/ /       

        /// <summary>
        /// Appraisals the list. Appraisal list of a company 
        /// </summary>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult AppraisalList(string message)
        {
            var viewModel = performanceManagementService.GetAppraisalListView(message);

            viewModel.URL = "~/PerformanceManagement/AppraisalList";

            return View("AppraisalList", viewModel);
        }

        /// <summary>
        /// Appraisals the list employee.
        /// </summary>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult AppraisalListEmployee(string ProcessingMessage)
        {

            var viewModel = performanceManagementService.GetAppraisalListEmployeeView(ProcessingMessage);

            viewModel.URL = "~/PerformanceManagement/AppraisalListEmployee";

            return View("AppraisalList", viewModel);
        }

        /// <summary>
        /// Appraisees the list.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult AppraiseeList(int appraisalId, string message)
        {
            var viewModel = performanceManagementService.GetAppraiseeListView(appraisalId, message);

            viewModel.URL = "/PerformanceManagement/AppraiseeList?appraisalId=" + appraisalId + "&message=" + message;

            return View("AppraiseeList", viewModel);
        }

        /// <summary>
        /// Creates the appraisal.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserId</exception>
        [HttpGet]
        public ActionResult CreateAppraisal()
        {
            var viewModel = performanceManagementService.GetAppraisalRegistrationView();

            return this.PartialView("CreateAppraisal", viewModel);
        }

        /// <summary>
        /// Creates the appraisal.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="CompanyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppraisal(AppraisalView appraisalInfo)
        {

            if (appraisalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalUpdateView(appraisalInfo, string.Empty);
                return this.View("CreateAppraisal", model);
            }


            var processingMessage = performanceManagementService.ProcessAppraisalInfo(appraisalInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalUpdateView(appraisalInfo, processingMessage);
                return this.View("CreateAppraisal", model);
            }

            processingMessage = string.Format("New Appraisal created");

            return this.RedirectToAction("AppraisalList", new { message = processingMessage });
        }

        /// <summary>
        /// Edits the appraisal.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewEmployeeAppraisal(int employeeAppraisalId, string url)
        {
            var viewModel = performanceManagementService.GetemployeeAppraisalEditView(employeeAppraisalId);

            viewModel.URL = url;

            return View("ViewEmployeeAppraisal", viewModel);
        }
        
        /// <summary>
        /// Edits the appraisal.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditAppraisal(int employeeAppraisalId, string url)
        {
            var viewModel = performanceManagementService.GetemployeeAppraisalEditView(employeeAppraisalId);

            viewModel.URL = url;

            return View("EditAppraisal", viewModel);
        }

        /// <summary>
        /// Edits the appraisal.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppraisal(AppraisalModel appraisalInfo, EmployeeAppraisalModel employeeAppraisal, List<AppraisalQualitativeMetricModel> appraisalQualitativeMetric, List<AppraisalQuantitativeMetricModel> appraisalQuantitativeMetric, string url)
        {

            if (appraisalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalUpdateView(appraisalInfo, employeeAppraisal, appraisalQualitativeMetric, appraisalQuantitativeMetric, string.Empty);

                return View("EditAppraisal", model);
            }

            var processingMessage = performanceManagementService.ProcessEditAppraisalInfo(appraisalInfo, employeeAppraisal, appraisalQualitativeMetric, appraisalQuantitativeMetric);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalUpdateView(appraisalInfo, employeeAppraisal, appraisalQualitativeMetric, appraisalQuantitativeMetric, processingMessage);

                return View("EditAppraisal", model);
            }

            processingMessage = string.Format("You filled an successfull appraisal form");

            return Redirect(url);
        }


        /// <summary>
        /// Deletes the appraisal.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <param name="CompanyId">The company identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteAppraisal(int appraisalId)
        {
            var viewModel = performanceManagementService.GetAppraisalEditView(appraisalId, string.Empty);

            return PartialView("DeleteAppraisal", viewModel);
        }

        /// <summary>
        /// Deletes the appraisal.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalId</exception>
        [HttpPost]
        public ActionResult DeleteAppraisal(int appraisalId, string btnSubmit = "")
        {
            if (appraisalId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(appraisalId));
            }

            var returnModel = performanceManagementService.ProcessDeleteAppraisalInfo(appraisalId);


            return this.RedirectToAction("Appraisal" +
                "List");
        }

        /// <summary>
        /// Edits the employee appraisal.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditEmployeeAppraisal(int employeeAppraisalId, string url)
        {
            var viewModel = performanceManagementService.GetAppraisalEditView(employeeAppraisalId, string.Empty);

            viewModel.URL = url;

            return this.View("EditEmployeeAppraisal", viewModel);
        }

        /// <summary>
        /// Edits the employee appraisal.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeAppraisal</exception>
        [HttpPost]
        public ActionResult EditEmployeeAppraisal(EmployeeAppraisalModel employeeAppraisal, string url)
        {

            if (employeeAppraisal == null)
            {
                throw new ArgumentNullException(nameof(employeeAppraisal));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateEmployeeAppraisalUpdateView(employeeAppraisal, string.Empty);

                return View("EditEmployeeAppraisal", model);
            }

            var processingMessage = performanceManagementService.ProcessEditEmployeeAppraisalInfo(employeeAppraisal);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateEmployeeAppraisalUpdateView(employeeAppraisal, processingMessage);

                return View("EditEmployeeAppraisal", model);
            }

            processingMessage = string.Format("You filled an successfull appraisal form");

            return Redirect(url);
        }

        /// <summary>
        /// Deletes the employeeappraisal.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteEmployeeappraisal(int employeeAppraisalId)
        {
            return View();
        }

        /// <summary>
        /// Deletes the employeeappraisal.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <param name="submitBtn">The submit BTN.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteEmployeeappraisal(int employeeAppraisalId, string submitBtn)
        {
            return View();
        }

        /// <summary>
        /// Employees the appraisal list. An appraisal list for a logged in employee both (appraiser and appraisee)
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeAppraiseeList(string message)
        {

            var viewModel = performanceManagementService.GetEmployeeAppraiseeList(message);

            viewModel.URL = "/PerformanceManagement/EmployeeAppraisalList?message=" + message;

            return this.View("EmployeeAppraiseeList", viewModel);

        }

        /// <summary>
        /// Employees the appraisal list.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeAppraisalList(string message)
        {

            var viewModel = performanceManagementService.GetEmployeeEveryAppraisal(message);

            viewModel.URL = "/PerformanceManagement/EmployeeAppraisalList?message=" + message;

            return this.View("EmployeeSpecificAppraisalList", viewModel);

        }

        /// <summary>
        /// Employees the specific appraisal list. this list has the a specific employee list of appraisal
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeSpecificAppraisalList(int employeeId, string message)
        {

            var viewModel = performanceManagementService.GetEmployeeEveryAppraisal(message, employeeId);

            viewModel.URL = "/PerformanceManagement/EmployeeSpecificAppraisalList?employeeId=" + employeeId + "&message=" + message;

            return this.View("EmployeeSpecificAppraisalList", viewModel);

        }

        /// <summary>
        /// Creates the employee appraisal.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateEmployeeAppraisal(int employeeId)
        {

            var viewModel = performanceManagementService.GetEmployeeAppraisalView(employeeId);

            return this.PartialView("CreateEmployeeAppraisal", viewModel);
        }

        /// <summary>
        /// Creates the employee appraisal.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployeeAppraisal(AppraisalView appraisalInfo)
        {

            if (appraisalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.GetEmployeeAppraisalUpdateView(appraisalInfo, string.Empty);

                return View("CreateEmployeeAppraisal", model);
            }

            var processingMessage = performanceManagementService.ProcessAppraisalInfo(appraisalInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.GetEmployeeAppraisalUpdateView(appraisalInfo, processingMessage);

                return View("CreateEmployeeAppraisal", model);
            }

            processingMessage = string.Format("New Appraisal Added");

            return RedirectToAction("EmployeeSpecificAppraisalList", new { message = processingMessage });
        }

        /// <summary>
        /// Creates the employee appraisal request.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateEmployeeAppraisalRequest(int employeeId)
        {

            var viewModel = performanceManagementService.GetCreateEmployeeAppraisal(employeeId);

            return this.PartialView("CreateEmployeeAppraisalRequest", viewModel);

        }

        /// <summary>
        /// Creates the employee appraisal request.
        /// </summary>
        /// <param name="appraisalView">The appraisal view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalView</exception>
        [HttpPost]
        public ActionResult CreateEmployeeAppraisalRequest(AppraisalView appraisalView)
        {
            if (appraisalView == null) { throw new ArgumentNullException(nameof(appraisalView)); }

            if (!ModelState.IsValid)
            {
                var returnModel = this.performanceManagementService.GetCreateEmployeeAppraisal(appraisalView, string.Empty);

                return this.View("CreateEmployeeAppraisalRequest", returnModel);
            }

            var ProcessingMessage = performanceManagementService.SaveEmployeeAppraisal(appraisalView);

            if (!string.IsNullOrEmpty(ProcessingMessage))
            {
                var returnModel = this.performanceManagementService.GetCreateEmployeeAppraisal(appraisalView, ProcessingMessage);

                return this.View("CreateEmployeeAppraisalRequest", returnModel);
            }

            ProcessingMessage = string.Format("Employee Applied for Appraisal");

            return RedirectToAction("EmployeeSpecificAppraisalList", new { message = ProcessingMessage });
        } 

        #endregion

        #region //===============================Annual Assessment Region Start===============================//

        /// <summary>
        /// Annuals the assessment list.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult AnnualAssessmentList(string message)
        {
            var viewModel = performanceManagementService.GetAnnualPerformance(message);

            return this.View("AnnualAssessmentList", viewModel);
        }

        /// <summary>
        /// Annuals the assessment list employee.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult AnnualAssessmentListEmployee(string message)
        {
            var viewModel = performanceManagementService.GetAnnualPerformance(message);

            return this.View("AnnualAssessmentListEmployee", viewModel);
        }
        
        /// <summary>
        /// Creates the annual accessing performance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateAnnualAccessingPerformance()
        {
            var viewModel = this.performanceManagementService.GetAnnualPerformanceView();

            return this.PartialView("CreateAnnualAccessingPerformance", viewModel);
        }

        /// <summary>
        /// Creates the annual accessing performance.
        /// </summary>
        /// <param name="annualAssessingPerformance">The annual assessing performance.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">annualAssessingPerformance</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAnnualAccessingPerformance(AnnualAssessingPerformanceView annualAssessingPerformance)
        {

            if (annualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(annualAssessingPerformance));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.GetAnnualPerformanceView(annualAssessingPerformance, string.Empty);
                return View("CreateAnnualAccessingPerformance", model);
            }


            var processingMessage = performanceManagementService.ProcessAnnualPerformanceInfo(annualAssessingPerformance);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.GetAnnualPerformanceView(annualAssessingPerformance, processingMessage);
                return View("CreateAnnualAccessingPerformance", model);
            }

            processingMessage = string.Format("An Annual Assessing Performance created");

            return this.RedirectToAction("AnnualAssessmentList", new { message = processingMessage });
        }

        /// <summary>
        /// Employees the annual assessment form.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmployeeAnnualAssessmentForm(int employeennualAssessingPerformanceId)
        {

            var viewModel = this.performanceManagementService.GetEditEmployeeAnnualPerformanceView(employeennualAssessingPerformanceId);

            return this.View("EmployeeAnnualAssessmentForm", viewModel);;
        }

        /// <summary>
        /// Employees the annual assessment form.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EmployeeAnnualAssessmentForm(EmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance)
        {

            if (employeeAnnualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(employeeAnnualAssessingPerformance));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.GetEmployeeAnnualPerformanceView(employeeAnnualAssessingPerformance, string.Empty);
                return View("EmployeeAnnualAssessmentForm", model);
            }


            var processingMessage = performanceManagementService.ProcessingEditEmployeeAnnualAssessingPerformanceInfo(employeeAnnualAssessingPerformance);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.GetEmployeeAnnualPerformanceView(employeeAnnualAssessingPerformance, processingMessage);
                return View("EmployeeAnnualAssessmentForm", model);
            }

            processingMessage = string.Format("Successfully Fill Your Annual Assessing Performance");

            return this.RedirectToAction("EmployeeAnnualAssessmentListEmployee", new { message = processingMessage });
        }
        
        /// <summary>
        /// Employees the annual assessment list employee.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeAnnualAssessmentListEmployee(string message)
        {
            var viewModel = this.performanceManagementService.GetEmployeeAnnualPerformanceViewListEmployee(message);

            viewModel.URL = "/PerformanceManagement/EmployeeAnnualAssessmentListEmployee?message=" + message;

            return this.View("EmployeeAnnualAssessmentList", viewModel);
        }

        /// <summary>
        /// Employees the annual assessment list employee.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeAnnualAssessmentListReviewer(string message)
        {
            var viewModel = this.performanceManagementService.GetEmployeeAnnualPerformanceViewListReviewer(message);

            viewModel.URL = "/PerformanceManagement/EmployeeAnnualAssessmentListReviewer?message=" + message;

            return this.View("EmployeeAnnualAssessmentListReviewer", viewModel);
        }


        /// <summary>
        /// Employees the annual assessment list.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformanceId">The employee annual assessing performance identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmployeeAnnualAssessmentList(int annualAssessingPerformanceId, string message)
        {
            var viewModel = this.performanceManagementService.GetEmployeeAnnualPerformanceViewList(annualAssessingPerformanceId, message);

            viewModel.URL = "/PerformanceManagement/EmployeeAnnualAssessmentList?annualAssessingPerformanceId=" + annualAssessingPerformanceId + "&message=" + message;

            return this.View("EmployeeAnnualAssessmentList", viewModel);
        }
        
        /// <summary>
        /// Views the employee annual assessment form.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformanceId">The employee annual assessing performance identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewEmployeeAnnualAssessmentForm(int employeeAnnualAssessingPerformanceId)
        {
            var viewModel = this.performanceManagementService.GetEditEmployeeAnnualPerformanceView(employeeAnnualAssessingPerformanceId);

            return this.View("ViewEmployeeAnnualAssessmentForm", viewModel);
        }

        /// <summary>
        /// Reviewers the employee annual assessment form.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ReviewerEmployeeAnnualAssessmentForm(int employeeAnnualAssessingPerformanceId, string url)
        {
            var viewModel = this.performanceManagementService.GetEditEmployeeAnnualPerformanceView(employeeAnnualAssessingPerformanceId);

            viewModel.URL = url;

            return this.View("ReviewerEmployeeAnnualAssessmentForm", viewModel);
        }

        /// <summary>
        /// Employees the annual assessment form.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">employeeAnnualAssessingPerformance</exception>
        [HttpPost]
        public ActionResult ReviewerEmployeeAnnualAssessmentForm(EmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance, string url)
        {

            if (employeeAnnualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(employeeAnnualAssessingPerformance));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.GetEmployeeAnnualPerformanceView(employeeAnnualAssessingPerformance, string.Empty);
                return View("ReviewerEmployeeAnnualAssessmentForm", model);
            }


            var processingMessage = performanceManagementService.ProcessingEditEmployeeAnnualAssessingPerformanceInfo(employeeAnnualAssessingPerformance);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.GetEmployeeAnnualPerformanceView(employeeAnnualAssessingPerformance, processingMessage);
                return View("ReviewerEmployeeAnnualAssessmentForm", model);
            }

            processingMessage = string.Format("Successfully Fill Your Annual Assessing Performance");

            return this.Redirect(url);
        }

        #endregion
        
        #region //=============================APPRAISAL Question==========================//     

        /// <summary>
        /// Appraisals Questions list.
        /// </summary>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult AppraisalQuestionsList(string message)
        {
            var viewModel = performanceManagementService.GetAppraisalQuestionListView(message);

            return this.View("AppraisalQuestionsList", viewModel);
        }

        /// <summary>
        /// Creates the appraisal.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserId</exception>
        [HttpGet]
        public ActionResult CreateAppraisalQuestion()
        {
            var viewModel = performanceManagementService.GetAppraisalQuestionRegistrationView();

            return this.PartialView("CreateAppraisalQuestion", viewModel);
        }

        /// <summary>
        /// Creates the appraisal question.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">appraisalQuestionInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppraisalQuestion(AppraisalQuestionView appraisalQuestionInfo)
        {
            if (appraisalQuestionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestionInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalQuestionUpdateView(appraisalQuestionInfo, string.Empty);
                return View("CreateAppraisalQuestion", model);
            }
            
            var processingMessage = performanceManagementService.ProcessAppraisalQuestionInfo(appraisalQuestionInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalQuestionUpdateView(appraisalQuestionInfo, processingMessage);
                return View("CreateAppraisalQuestion", model);
            }

            return RedirectToAction("AppraisalQuestionsList");
        }

        /// <summary>
        /// Edits the appraisal question.
        /// </summary>
        /// <param name="appraisalQuestionId">The appraisal question identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditAppraisalQuestion(int appraisalQuestionId)
        {
            var viewModel = performanceManagementService.GetAppraisalQuestionEditView(appraisalQuestionId, string.Empty);

            return this.PartialView("EditAppraisalQuestion", viewModel);
        }

        /// <summary>
        /// Edits the appraisal.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppraisalQuestion(AppraisalQuestionModel appraisalQuestionInfo)
        {

            if (appraisalQuestionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestionInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalQuestionUpdateView(appraisalQuestionInfo, string.Empty);

                return this.PartialView("EditAppraisalQuestion", model);
            }

            var processingMessage = performanceManagementService.ProcessEditAppraisalQuestionInfo(appraisalQuestionInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalQuestionUpdateView(appraisalQuestionInfo, processingMessage);

                return this.PartialView("EditAppraisalQuestion", model);
            }

            processingMessage = string.Format("You successfully edited an appraisal question");

            return RedirectToAction("AppraisalQuestionsList", new { message = processingMessage });
        }

        /// <summary>
        /// Deletes the appraisal question.
        /// </summary>
        /// <param name="appraisalQuestionId">The appraisal question identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteAppraisalQuestion(int appraisalQuestionId)
        {
            var viewModel = performanceManagementService.GetAppraisalQuestionDeleteView(appraisalQuestionId, string.Empty);

            return this.PartialView("DeleteAppraisalQuestion", viewModel);
        }

        /// <summary>
        /// Deletes the appraisal question.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">appraisalQuestionInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppraisalQuestion(AppraisalQuestionModel appraisalQuestionInfo)
        {

            if (appraisalQuestionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestionInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateAppraisalQuestionDeleteView(appraisalQuestionInfo, string.Empty);

                return this.PartialView("DeleteAppraisalQuestion", model);
            }

            var processingMessage = performanceManagementService.ProcessDeleteAppraisalQuestionInfo(appraisalQuestionInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.performanceManagementService.CreateAppraisalQuestionDeleteView(appraisalQuestionInfo, processingMessage);

                return this.PartialView("DeleteAppraisalQuestion", model);
            }

            processingMessage = string.Format("You successfully Deleted an appraisal question.");

            return RedirectToAction("AppraisalQuestionsList", new { message = processingMessage });
        }

        #endregion

        #region //--------------------------------------FeedBack Section-----------------------------------------//

        /// <summary>
        /// Feedbacks the employee list.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <param name="selectedcompanyId">The selectedcompany identifier.</param>
        /// <param name="selectedemployeeId">The selectedemployee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult FeedbackEmployeeList(int feedbackId, int? selectedcompanyId, int? selectedemployeeId, string message)
        {
            var viewModel = performanceManagementService.GetFeedbackEmployeeListView(feedbackId, message);

            return View("EmployeeFeedbackList", viewModel);
        }
        
        /// <summary>
        /// Employees the feedback list.
        /// </summary>
        /// <param name="selectedcompanyId">The selectedcompany identifier.</param>
        /// <param name="selectedemployeeId">The selectedemployee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeFeedbackList(int? selectedcompanyId, int? selectedemployeeId, string message)
        {

            var viewModel = performanceManagementService.GetEmployeeFeedbackListView(message);
             
            return View("EmployeeFeedbackList", viewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateEmployeeFeedback(int feedbackId)
        {
            if (feedbackId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(feedbackId));
            }


            var viewModel = performanceManagementService.GetEmployeeFeedbackViewByID(feedbackId);

            return this.PartialView(viewModel);
        }

        /// <summary>
        /// Creates the employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeView</exception>
        [HttpPost]
        public ActionResult CreateEmployeeFeedback(EmployeeFeedbackViewModel employeeView)
        {
            if (employeeView == null)
            {
                throw new ArgumentNullException(nameof(employeeView));
            }

            if (!ModelState.IsValid)
            {
                var model = performanceManagementService.GetEmployeeFeedbackView(employeeView, string.Empty);

                return View("CreateEmployeeFeedback", model);
            }

            var message = performanceManagementService.ProcessEmployeeFeedback(employeeView);

            if (!string.IsNullOrEmpty(message))
            {
                var model = performanceManagementService.GetEmployeeFeedbackView(employeeView , message);

                return View("CreateEmployeeFeedback", model);
            }

            message = string.Format("NewEmployee Feedback Added ");

            return RedirectToAction("EmployeeFeedbackList", new { message = message });
        }


        /// <summary>
        /// Views the employee feedback.
        /// </summary>
        /// <param name="employeeFeedbackId">The employee feedback identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeFeedbackId</exception>
        [HttpGet]
        public ActionResult ViewEmployeeFeedback(int employeeFeedbackId)
        {
            if (employeeFeedbackId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(employeeFeedbackId));
            }
            
            var viewModel = performanceManagementService.GetViewEmployeeFeedback(employeeFeedbackId);

            return this.PartialView(viewModel);
        }

        /// <summary>
        /// Edits the employee feedback.
        /// </summary>
        /// <param name="employeeFeedbackId">The employee feedback identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeFeedbackId</exception>
        [HttpGet]
        public ActionResult EditEmployeeFeedback(int employeeFeedbackId)
        {
            if (employeeFeedbackId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(employeeFeedbackId));
            }

            var viewModel = performanceManagementService.GetEmployeeFeedbackViewByID(employeeFeedbackId);

            return this.PartialView(viewModel);
        }

        /// <summary>
        /// Edits the employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeView</exception>
        [HttpPost]
        public ActionResult EditEmployeeFeedback(EmployeeFeedbackViewModel employeeView)
        {
            if (employeeView == null)
            {
                throw new ArgumentNullException(nameof(employeeView));
            }

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.GetEmployeeFeedbackView(employeeView, string.Empty);

                return this.View("EditEmployeeFeedback", model);
            }

            var viewModel = this.performanceManagementService.ProcessUpdatedEmployeeFeedback(employeeView);

            if (!string.IsNullOrEmpty(viewModel))
            {
                var model = this.performanceManagementService.GetEmployeeFeedbackView(employeeView, viewModel);

                return this.View("EditEmployeeFeedback", model);

            }

            var returnMessage = string.Format("Employee Feedback Modified Successfully");


            return RedirectToAction("EmployeeFeedbackList", new { message = viewModel });

        }

        /// <summary>
        /// Feedbacklists the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult Feedbacklist(string message)
        {
            var viewModel = this.performanceManagementService.GetAllFeedByCompanyAndYear(message);

            return this.View("FeedbackList", viewModel);
        }

        /// <summary>
        /// Mies the feedback list.
        /// </summary>
        /// <returns></returns>
        public ActionResult MyFeedbackList()
        {
            var viewModel = this.performanceManagementService.GetAllFeedByCompanyAndYear(string.Empty);

            return this.View("FeedbackList", viewModel);
        }

        /// <summary>
        /// Creates the feedback.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult CreateFeedback (string processingMessage)
        {

            var viewModel = this.performanceManagementService.CreateFeedbackView(processingMessage);

            return this.PartialView("CreateFeedback", viewModel);

        }

        /// <summary>
        /// Creates the feedback.
        /// </summary>
        /// <param name="feedbackModel">The feedback model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">feedbackModel</exception>
        [HttpPost]
        public ActionResult CreateFeedback(FeedbackModel feedbackModel)
        {
            if (feedbackModel == null) throw new ArgumentNullException(nameof(feedbackModel));

            if (!ModelState.IsValid)
            {
                var model = this.performanceManagementService.CreateFeedbackView(feedbackModel, string.Empty);

                return this.View("CreateFeedback", model);
            }

            var viewModel = this.performanceManagementService.ProcessFeedbackInfo(feedbackModel);

            if (!string.IsNullOrEmpty(viewModel))
            {
                var model = this.performanceManagementService.CreateFeedbackView(feedbackModel, viewModel);

                return this.View("CreateFeedback", model);
            }

            viewModel = string.Format("You successfully Created FeedBack.");

            return RedirectToAction("FeedbackList", new { message = viewModel });
        }

        #endregion
    }
}