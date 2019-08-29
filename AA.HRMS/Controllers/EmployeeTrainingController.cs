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
    [CheckUserLogin()]
    public class EmployeeTrainingController : Controller
    {

        private readonly IEmployeeTrainingService employeeTrainingService;
        private readonly IUserService userService;

        public EmployeeTrainingController(IEmployeeTrainingService employeeTrainingService, IUserService userService)
        {
            this.employeeTrainingService = employeeTrainingService;
            this.userService = userService;
        }


        /// <summary>
        /// Creates the employee training.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateEmployeeTraining()
        {

            int reportId = 0;

            var viewModel = employeeTrainingService.GetCreateEmployeeTrainingByUserId(reportId);

            return View(viewModel);
        }

        /// <summary>
        /// Creates the employee training.
        /// </summary>
        /// <param name="epmloyeeTrainingView">The epmloyee training view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">epmloyeeTrainingView</exception>
        [HttpPost]
        public ActionResult CreateEmployeeTraining (EmployeeTrainingView epmloyeeTrainingView, TrainingView trainingView)
        {
            if (epmloyeeTrainingView == null) { throw new ArgumentNullException(nameof(epmloyeeTrainingView)); }
            
            if (!ModelState.IsValid)
            {
                var returnModel = this.employeeTrainingService.GetCreateEmployeeTraining(epmloyeeTrainingView, string.Empty);

                return this.View("CreateEmployeeTraining", returnModel);
            }

            var ProcessingMessage = employeeTrainingService.SaveEmployeeTraining(epmloyeeTrainingView, trainingView);

            if (!string.IsNullOrEmpty(ProcessingMessage))
            {
                var returnModel = this.employeeTrainingService.GetCreateEmployeeTraining(epmloyeeTrainingView, ProcessingMessage);

                return this.View("CreateEmployeeTraining", returnModel);
            }

            ProcessingMessage = string.Format("Employee Applied for Training");

            return RedirectToAction("EmployeeTrainingList", new { ProcessingMessage });
        }

        /// <summary>
        /// Edits the employee training.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditEmployeeTraining (int id, string url)
        {

            var ViewModel = employeeTrainingService.GetEmployeeTrainingView(id);

            ViewModel.URL = url;

            return PartialView("EditEmployeeTraining", ViewModel);
        }

        /// <summary>
        /// Edits the employee training.
        /// </summary>
        /// <param name="employeeTrainingView">The employee training view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTrainingView</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeeTraining(EmployeeTrainingView employeeTrainingView)
        {

            if (employeeTrainingView == null) throw new ArgumentNullException(nameof(employeeTrainingView));

            if (!ModelState.IsValid)
            {
                var returnModel = this.employeeTrainingService.GetCreateEmployeeTraining(employeeTrainingView, string.Empty);

                return this.View("EditEmployeeTraining", returnModel);
            }


            var processmessage = employeeTrainingService.ProcessEditEmployeeTraining(employeeTrainingView);

            if (!string.IsNullOrEmpty(processmessage))
            {
                var returnModel = this.employeeTrainingService.GetCreateEmployeeTraining(employeeTrainingView, processmessage);

                return this.View("EditEmployeeTraining", returnModel);
            }

            processmessage = string.Format("Employee Training Updated");
            

            return Redirect(employeeTrainingView.URL);
        }


        /// <summary>
        /// Deletes the employee training.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteEmployeeTraining(int Id)
        {
            var viewModel = employeeTrainingService.GetEmployeeTrainingView(Id);

            return this.PartialView("DeleteEmployeeTraining", viewModel);
        }

        /// <summary>
        /// Deletes the employee training.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        [HttpPost]
        public ActionResult DeleteEmployeeTraining(int employeeTrainingId, string btnSubmit = "")
        {
            if (employeeTrainingId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(employeeTrainingId));
            }

            var returnModel = employeeTrainingService.ProcessDeleteEmployeeTrainingInfo(employeeTrainingId);

            returnModel = string.Format("Employee Training Deleted");

            return RedirectToAction("EmployeeRequestTraining", new { message = returnModel });
        }

        /// <summary>
        /// Employees the training list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeTrainingList(int? companyId, string message)
        {
            var ViewModel = employeeTrainingService.GetEmployeeEveryTraining(companyId ?? -1, message);

            return this.View("EmployeeSpecificTrainingList", ViewModel);

        }

        /// <summary>
        /// Employees the request leave.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeRequestTraining(int? companyId, string message)
        {

            var ViewModel = employeeTrainingService.GetAllRequestedTrainingByCompany(companyId ?? -1, message);

            ViewModel.URL = "/EmployeeTraining/EmployeeRequestTraining";

            return this.View("EmployeeTrainingList", ViewModel);

        }


        /// <summary>
        /// Employees the specific training list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeSpecificTrainingList(int employeeId, int? companyId, string message)
        {

            var ViewModel = employeeTrainingService.GetEmployeeEveryTraining(companyId ?? -1, message, employeeId);

            ViewModel.URL = "/EmployeeTraining/EmployeeSpecificTrainingList?employeeId=" + employeeId + "&message=";

            return this.View("EmployeeSpecificTrainingList", ViewModel);

        }

        /// <summary>
        /// Creates the employee training request.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateEmployeeTrainingRequest(int employeeId)
        {

            var viewModel = employeeTrainingService.GetCreateEmployeeTrainingById(employeeId);

            return this.PartialView(viewModel);

        }
        
        /// <summary>
        /// Creates the employee training request.
        /// </summary>
        /// <param name="epmloyeeTrainingView">The epmloyee training view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">epmloyeeTrainingView</exception>
        [HttpPost]
        public ActionResult CreateEmployeeTrainingRequest(EmployeeTrainingView epmloyeeTrainingView, TrainingView training)
        {
            if (epmloyeeTrainingView == null) { throw new ArgumentNullException(nameof(epmloyeeTrainingView)); }

            if (!ModelState.IsValid)
            {
                var returnModel = this.employeeTrainingService.GetCreateEmployeeTraining(epmloyeeTrainingView, string.Empty);

                return this.View("CreateEmployeeTrainingRequest", returnModel);
            }

            var ProcessingMessage = employeeTrainingService.SaveEmployeeTraining(epmloyeeTrainingView, training);

            if (!string.IsNullOrEmpty(ProcessingMessage))
            {
                var returnModel = this.employeeTrainingService.GetCreateEmployeeTraining(epmloyeeTrainingView, ProcessingMessage);

                return this.View("CreateEmployeeTrainingRequest", returnModel);
            }

            ProcessingMessage = string.Format("Employee Applied for Training");

            return RedirectToAction("EmployeeSpecificTrainingList", new { message = ProcessingMessage, employeeId = epmloyeeTrainingView.EmployeeId });
        }


    }
}