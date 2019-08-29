using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
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
    public class TrainingController : Controller
    {
        private readonly ITrainingService trainingService;
        
        public TrainingController(ITrainingService trainingService)
        {
            this.trainingService = trainingService;
        }

        #region //----------------------------------------------------Training-----------------------------------------//

        /// <summary>
        /// Training the list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <returns></returns>
        /// Creating a list for training
        public ActionResult TrainingList(int? selectedCompany, string selectedTraining,
            string message)
        {

            //Get the display model from the services 
            var viewModel = this.trainingService.CreateTrainingList(selectedCompany ?? -1, selectedTraining, message);

            //return to the view 
            return this.View("TrainingList", viewModel);
        }

        /// <summary>
        /// Trainings the report list.
        /// </summary>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="selectedTrainingReportId">The selected training report identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult TrainingReportList(int? selectedCompany, int? selectedTrainingReportId,
            string message)
        {
            var viewModel = this.trainingService.CreateTrainingReportList(selectedCompany ?? -1, selectedTrainingReportId, message);

            return this.View("TrainingReportList", viewModel);
        }

        /// <summary>
        /// Requests the training.
        /// </summary>
        /// <returns></returns>
        public ActionResult RequestTraining()
        {
            return View();
        }
        
        /// <summary>
        /// Creates the training.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateTraining()
        {

            var viewModel = trainingService.GetTrainingRegistrationView();

            return PartialView("CreateTraining", viewModel);
        }
        /// <summary>
        /// Creates the training.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        [HttpPost]
        public ActionResult CreateTraining(TrainingView trainingInfo)
        {
            //Check that Training Info is Not Null
            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var model = this.trainingService.CreateTrainingUpdatedView(trainingInfo, "");
                return View("CreateTraining", model);
            }

            //Process The Training Information
            var processingMessage = trainingService.ProcessTrainingInfo(trainingInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.trainingService.CreateTrainingUpdatedView(trainingInfo, processingMessage);
                return this.View("CreateTraining", model);
            }

            processingMessage = string.Format("{0} is Created", trainingInfo.TrainingName);

            return this.RedirectToAction("TrainingList", new { message = processingMessage });
        }

        /// <summary>
        /// Edits the training.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingId</exception>
        [HttpGet]
        public ActionResult EditTraining(int trainingId)
        {

            if (trainingId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingId));
            }

            var viewModel = trainingService.GetTrainingEditView(trainingId);

            return this.PartialView(viewModel);
        }

        /// <summary>
        /// Edits the training.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        [HttpPost]
        public ActionResult EditTraining(TrainingView trainingInfo)
        {
            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.trainingService.CreateTrainingUpdatedView(trainingInfo, "");

                return View("EditTraining", model);
            }

            var processingMessage = trainingService.ProcessEditTrainingInfo(trainingInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.trainingService.CreateTrainingUpdatedView(trainingInfo, processingMessage);

                return this.View("EditTraining", model);
            }

            processingMessage = string.Format("{0} Updated", trainingInfo.TrainingName);

            return this.RedirectToAction("TrainingList", new { message = processingMessage });
        }

        /// <summary>
        /// Deletes the training.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteTraining(int trainingId)
        {
            var viewModel = trainingService.GetTrainingEditView(trainingId);

            return PartialView(viewModel);
        }

        /// <summary>
        /// Deletes the training.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">trainingId</exception>
        [HttpPost]
        public ActionResult DeleteTraining(int trainingId, string btnSubmit)
        {
            if (trainingId < 1)
            {
                throw new ArgumentOutOfRangeException("trainingId");
            }

            var message = trainingService.ProcessDeleteTrainingInfo(trainingId);

            var returnMessage = string.Format("Selected Training Deleted");

            return this.RedirectToAction("TrainingList", new { message = returnMessage, });
        }

        /// <summary>
        /// Views the training.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">trainingId</exception>
        [HttpGet]
        public ActionResult ViewTraining(int trainingId)
        {
            //Show the detials of a selected Training
            if (trainingId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(trainingId));
            }
            
            //Get The View
            var viewModel = this.trainingService.GetTrainingEditView(trainingId);

            return PartialView("ViewTraining", viewModel);
        }

        #endregion

        #region //-----------------------------------------------------------Training Calendar Section------------------------------------------------------//

        /// <summary>
        /// Trainings the calendar list.
        /// </summary>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedTrainingName">Name of the selected training.</param>
        /// <param name="selectedLocation">The selected location.</param>
        /// <returns></returns>
        public ActionResult TrainingCalendarList(int? selectedCompanyId, string selectedTrainingName, string selectedLocation, string message)
        {

            var returnModel = this.trainingService.GetTrainingCalenderListView(selectedCompanyId ?? -1, selectedTrainingName, selectedLocation, message);

            return this.View("TrainingCalendarList", returnModel);
        }

        /// <summary>
        /// Adds the training calendar.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddTrainingCalendar()
        {
            var returnModel = this.trainingService.GetTrainingCalendarView();

            return this.PartialView("AddTrainingCalendar", returnModel);
        }

        /// <summary>
        /// Adds the training calendar.
        /// </summary>
        /// <param name="trainingCalendarInfo">The training calendar information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingCalendarInfo</exception>
        [HttpPost]
        public ActionResult AddTrainingCalendar(TrainingCalendarView trainingCalendarInfo)
        {

            if (trainingCalendarInfo == null) throw new ArgumentNullException(nameof(trainingCalendarInfo));


            if (!ModelState.IsValid)
            {
                var model = this.trainingService.GetTrainingCalendarView(trainingCalendarInfo, string.Empty);

                return this.View("AddTrainingCalendar", model);
            }

            var returnModel = this.trainingService.ProcessTrainingCalendarInfo(trainingCalendarInfo);

            if (!string.IsNullOrEmpty(returnModel))
            {
                var model = this.trainingService.GetTrainingCalendarView(trainingCalendarInfo, returnModel);

                return this.View("AddTrainingCalendar", model);
            }

            returnModel = string.Format("New Training Calendar Created");

            return this.RedirectToAction("TrainingCalendarList", new { message = returnModel });

        }


        /// <summary>
        /// Edits the training calendar.
        /// </summary>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingCalendarId</exception>
        [HttpGet]
        public ActionResult EditTrainingCalendar(int trainingCalendarId)
        {
            var returnModel = this.trainingService.GetEditTrainingCalendarEditView(trainingCalendarId);

            return this.PartialView("EditTrainingCalendar", returnModel);
        }

        /// <summary>
        /// Edits the training calendar.
        /// </summary>
        /// <param name="trainingCalendarInfo">The training calendar information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingCalendarInfo</exception>
        [HttpPost]
        public ActionResult EditTrainingCalendar(TrainingCalendarView trainingCalendarInfo)
        {
            if (trainingCalendarInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingCalendarInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.trainingService.GetTrainingCalendarView(trainingCalendarInfo, string.Empty);

                return this.View("EditTrainingCalendar", model);
            }

            var returnModel = this.trainingService.ProcessEditCalendarInfo(trainingCalendarInfo);

            if (!string.IsNullOrEmpty(returnModel))
            {
                var model = this.trainingService.GetTrainingCalendarView(trainingCalendarInfo, returnModel);

                return this.View("EditTrainingCalendar", model);
            }

            returnModel = string.Format("Updated Training Calendar Successful");

            return this.RedirectToAction("TrainingCalendarList", new { message = returnModel });
        }

        /// <summary>
        /// Deletes the training calendar.
        /// </summary>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingCalendarId</exception>
        [HttpGet]
        public ActionResult DeleteTrainingCalendar(int trainingCalendarId)
        {
            if (trainingCalendarId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingCalendarId));
            }

            var returnModel = this.trainingService.GetEditTrainingCalendarEditView(trainingCalendarId);

            return this.PartialView("DeleteTrainingCalendar", returnModel);
        }

        /// <summary>
        /// Deletes the training calendar.
        /// </summary>
        /// <param name="trainingCalendar">The training calendar.</param>
        /// <param name="submitBtn">The submit BTN.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingCalendar</exception>
        [HttpPost]
        public ActionResult DeleteTrainingCalendar(int trainingCalendar, string submitBtn)
        {
            if (trainingCalendar <= 0)
            {
                throw new ArgumentNullException(nameof(trainingCalendar));
            }

            var returnModel = this.trainingService.ProcessDeleteTrainingCalendarInfo(trainingCalendar);

            returnModel = string.Format("Deleted Training Calendar");

            return this.RedirectToAction("TrainingCalendarList", new { message = returnModel });
        }




        #endregion

        #region //===================TrainingReportlogic========================================//

        /// <summary>
        /// Views the training report.
        /// </summary>
        /// <param name="trainingReportId">The training report identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewTrainingReport(int trainingReportId)
        {

            var ViewModel = this.trainingService.GetTrainingReportView(trainingReportId);

            return this.PartialView("ViewTrainingReport", ViewModel);
        }

        /// <summary>
        /// Creates the training report.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateTrainingReport(int trainingId)
        {
            var ViewModel = this.trainingService.GetTrainingReportView(trainingId, string.Empty);
            
            return this.PartialView("CreateTrainingReport", ViewModel);
        }

        /// <summary>
        /// Creates the training report.
        /// </summary>
        /// <param name="trainingReportViewModel">The training report view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingReportViewModel</exception>
        [HttpPost]
        public ActionResult CreateTrainingReport(TrainingReportViewModel trainingReportViewModel)
        {

            if (trainingReportViewModel == null)
            {
                throw new ArgumentNullException(nameof(trainingReportViewModel));
            }

            if (!ModelState.IsValid)
            {
                var model = this.trainingService.CreateTrainingReportUpdatedView(trainingReportViewModel, string.Empty);
                return View("CreateTrainingReport", model);
            }

            var ViewModel = this.trainingService.ProcessTrainingReportInfo(trainingReportViewModel);

            if (!string.IsNullOrEmpty(ViewModel))
            {
                var model = this.trainingService.CreateTrainingReportUpdatedView(trainingReportViewModel, ViewModel);
                return View("CreateTrainingReport", model);
            }

            ViewModel = string.Format("Training Report Successfully Submitted");

            return RedirectToAction("TrainingReportList", "Training", new { ViewModel });
        }

       
        #endregion

        #region //-----------------------------------------------------------------------Training Analysis Section-------------------------------------------------------//      
        
        /// <summary>
        /// Trainings the need analysis list.
        /// </summary>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="selectedTrainingNeedAnalysisId">The selected training need analysis identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult TrainingNeedAnalysisList(int? selectedCompany, string message)
        {
            var viewModel = this.trainingService.GetTrainingNeedAnalysisList(selectedCompany ?? -1, message);

            return this.View("TrainingNeedAnalysisList", viewModel);
        }

        /// <summary>
        /// Views the training analysis.
        /// </summary>
        /// <param name="trainingAnalysis">The training analysis.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">trainingAnalysis</exception>
        public ActionResult ViewTrainingAnalysis(int trainingAnalysis)
        {
            if (trainingAnalysis <= 0)
            {
                throw new ArgumentNullException(nameof(trainingAnalysis));
            }

            var returnModel = this.trainingService.GetEditTrainingAnalysisView(trainingAnalysis, string.Empty);

            return this.PartialView("ViewTrainingAnalysis", returnModel);
        }

        /// <summary>
        /// Creates the training analysis.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateTrainingAnalysis()
        {
            var viewModel = trainingService.GetTrainingAnalysisView();

            return this.PartialView("CreateTrainingAnalysis", viewModel);
        }

        /// <summary>
        /// Creates the training analysis.
        /// </summary>
        /// <param name="trainingAnalysisViewModel">The training analysis view model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">trainingAnalysisViewModel</exception>
        [HttpPost]
        public ActionResult CreateTrainingAnalysis(TrainingNeedAnalysisView trainingAnalysisViewModel)
        {
            if (trainingAnalysisViewModel == null)
            {
                throw new ArgumentNullException(nameof(trainingAnalysisViewModel));
            }
            

            if (!ModelState.IsValid)
            {
                var returnModel = this.trainingService.GetTrainingAnalysisView(trainingAnalysisViewModel, string.Empty);

                return this.View("CreateTrainingAnalysis", returnModel);
            }

            var processTrainingAnalysis = trainingService.ProcessTrainingNeedAnalysisInfo(trainingAnalysisViewModel);

            if (!string.IsNullOrEmpty(processTrainingAnalysis))
            {
                var returnModel = this.trainingService.GetTrainingAnalysisView(trainingAnalysisViewModel, processTrainingAnalysis);

                return this.View("CreateTrainingAnalysis", returnModel);
            }

            processTrainingAnalysis = string.Format("Training Analysis of {0} Successfully Submitted", trainingAnalysisViewModel.TrainingName);

            return RedirectToAction("TrainingNeedAnalysisList", new { processTrainingAnalysis });

        }

        /// <summary>
        /// Creates the training analysis.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditTrainingAnalysis(int trainingNeedAnalysisId)
        {

            var viewModel = trainingService.GetEditTrainingAnalysisView(trainingNeedAnalysisId, string.Empty);

            return this.PartialView("EditTrainingAnalysis", viewModel);
        }

        /// <summary>
        /// Creates the training analysis.
        /// </summary>
        /// <param name="trainingAnalysisViewModel">The training analysis view model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">trainingAnalysisViewModel</exception>
        [HttpPost]
        public ActionResult EditTrainingAnalysis(TrainingNeedAnalysisView trainingAnalysisViewModel)
        {
            if (trainingAnalysisViewModel == null)
            {
                throw new ArgumentNullException(nameof(trainingAnalysisViewModel));
            }
            if (!ModelState.IsValid)
            {
                var returnModel = this.trainingService.GetTrainingAnalysisView(trainingAnalysisViewModel, string.Empty);

                return this.View("EditTrainingAnalysis", returnModel);
            }

            var processTrainingAnalysis = trainingService.ProcessEditTrainingNeedAnalysisInfo(trainingAnalysisViewModel);

            if (!string.IsNullOrEmpty(processTrainingAnalysis))
            {
                var returnModel = this.trainingService.GetTrainingAnalysisView(trainingAnalysisViewModel, processTrainingAnalysis);

                return this.View("EditTrainingAnalysis", returnModel);
            }

            processTrainingAnalysis = string.Format("Training Analysis of {0} Successfully Submitted", trainingAnalysisViewModel.TrainingName);

            return RedirectToAction("TrainingNeedAnalysisList", new { processTrainingAnalysis });

        }

        /// <summary>
        /// Deletes the training analysis.
        /// </summary>
        /// <param name="trainingAnalysisId">The training analysis identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingAnalysisId</exception>
        [HttpGet]
        public ActionResult DeleteTrainingAnalysis(int trainingAnalysisId)
        {
            if (trainingAnalysisId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingAnalysisId));
            }
            

            var returnModel = this.trainingService.GetEditTrainingAnalysisView(trainingAnalysisId, string.Empty);

            return this.PartialView("DeleteTrainingAnalysis", returnModel);
        }

        /// <summary>
        /// Deletes the Training Analysis.
        /// </summary>
        /// <param name="trainingAnalysis">The training Analysis.</param>
        /// <param name="submitBtn">The submit BTN.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingAnalysis</exception>
        [HttpPost]
        public ActionResult DeleteTrainingAnalysis(int trainingAnalysisId, string submitBtn)
        {
            if (trainingAnalysisId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingAnalysisId));
            }

            var returnModel = this.trainingService.ProcessDeleteTrainingAnalysisInfo(trainingAnalysisId);

            returnModel = string.Format("Deleted Training Analysis");

            return this.RedirectToAction("TrainingNeedAnalysisList", new { message = returnModel });
        }

        #endregion
        
    }
}