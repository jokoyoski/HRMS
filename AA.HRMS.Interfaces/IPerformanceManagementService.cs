using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPerformanceManagementService
    {
        #region //=============================Appraisal Question===================================//

        /// <summary>
        /// Processes the delete appraisal question information.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalQuestionInfo(IAppraisalQuestion appraisalQuestionInfo);

        /// <summary>
        /// Processes the edit appraisal question information.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <returns></returns>
        string ProcessEditAppraisalQuestionInfo(IAppraisalQuestion appraisalQuestionInfo);


        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="CompanyId">The company identifier.</param>
        /// <returns></returns>
        IAppraisalQuestionView CreateAppraisalQuestionDeleteView(IAppraisalQuestion appraisalInfo, string processingMessage);

        /// <summary>
        /// Creates the appraisal question update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionView CreateAppraisalQuestionUpdateView(IAppraisalQuestion appraisalInfo, string processingMessage);


        /// <summary>
        /// Creates the appraisal question update view.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionView CreateAppraisalQuestionUpdateView(IAppraisalQuestionView appraisalQuestionInfo, string processingMessage);


        #endregion

        #region //==========================APPRAISAL ACTION=================//

        /// <summary>
        /// Gets the appraisal action ListView by company identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalActionView GetAppraisalActionListViewByCompanyId(string ProcessingMessage);


        /// <summary>
        /// Gets the appraisal action registration view.
        /// </summary>
        /// <param name="loggedUserId">The logged user identifier.</param>
        /// <returns></returns>
        IAppraisalActionView GetAppraisalActionRegistrationView();

        /// <summary>
        /// Processes the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        string ProcessAppraisalActionInfo(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Gets the appraisal action edit view.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        IAppraisalActionView GetAppraisalActionEditView(int appraisalActionId);

        /// <summary>
        /// Processes the edit appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        string ProcessEditAppraisalActionInfo(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Processes the delete appraisal action information.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalActionInfo(int appraisalActionId);

        /// <summary>
        /// Creates the appraisal action update view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalActionView CreateAppraisalActionUpdateView(IAppraisalActionView appraisalActionInfo, string processingMessage);

        #endregion

        #region //==================APPRAISAL RATING=================//

        /// <summary>
        /// Gets the appraisal rating ListView.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalRating> GetAppraisalRatingListView();

        /// <summary>
        /// Gets the appraisal rating registration view.
        /// </summary>
        /// <returns></returns>
        IAppraisalRatingView GetAppraisalRatingRegistrationView();

        /// <summary>
        /// Getemployees the appraisal edit view.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        IAppraisalView GetemployeeAppraisalEditView(int employeeAppraisalId);

        /// <summary>
        /// Processes the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        string ProcessAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo);

        /// <summary>
        /// Gets the appraisal rating edit view.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        IAppraisalRatingView GetAppraisalRatingEditView(int appraisalRatingId);

        /// <summary>
        /// Processes the edit appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        string ProcessEditAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo);

        /// <summary>
        /// Processes the delete appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalRatingInfo(int appraisalRatingId);

        /// <summary>
        /// Creates the appraisal rating update view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalRatingView CreateAppraisalRatingUpdateView(IAppraisalRatingView appraisalRatingInfo, string processingMessage);

        #endregion

        #region //=================================Task Module Section================================//

        /// <summary>
        /// Gets the task ListView.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeTaskListView GetTaskListView(string message);

        /// <summary>
        /// Gets the employee task ListView.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeTaskListView GetEmployeeTaskListView(int employeeId, string message);

        /// <summary>
        /// Gets the employee task details view.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        IEmployeeTaskView GetEmployeeTaskDetailsView(int employeeTaskId);

        /// <summary>
        /// Gets the employee task registration view.
        /// </summary>
        /// <returns></returns>
        IEmployeeTaskView GetEmployeeTaskRegistrationView(int appraisalGoalId);

        /// <summary>
        /// Proceses the employee task information.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <returns></returns>
        string ProcessEmployeeTaskInfo(IEmployeeTaskView employeeTaskInfo);

        /// <summary>
        /// Gets the employee task edit view.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        IEmployeeTaskView GetEmployeeTaskEditView(int employeeTaskId);

        /// <summary>
        /// Processes the edit employee task information.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <returns></returns>
        string ProcessEditEmployeeTaskInfo(IEmployeeTaskView employeeTaskInfo);

        /// <summary>
        /// Gets the employee task delete view.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        IEmployeeTaskView GetEmployeeTaskDeleteView(int employeeTaskId);

        /// <summary>
        /// Processes the delete employee task information.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        string ProcessDeleteEmployeeTaskInfo(int employeeTaskId);

        /// <summary>
        /// Creates the employee task update view.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeTaskView CreateEmployeeTaskUpdateView(IEmployeeTaskView employeeTaskInfo, string processingMessage);

        #endregion

        #region //=================================Milestone Section=====================================//

        /// <summary>
        /// Gets the milestone view.
        /// </summary>
        /// <param name="milestoneId">The milestone identifier.</param>
        /// <returns></returns>
        IMilestoneView GetMilestoneView(int milestoneId);

        /// <summary>
        /// Gets the employee milestone list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IMilestoneListView GetMilestoneListByEmployee(int employeeId);

        /// <summary>
        /// Gets the milestone list by task.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IMilestoneListView GetMilestoneListByTask(int taskId, string processingMessage);

        #endregion

        #region //=========================APPRAISER========================//

        /// <summary>
        /// Gets the appraiser ListView.
        /// </summary>
        /// <returns></returns>
        IList<IAppraiser> GetAppraiserListView();

        /// <summary>
        /// Gets the appraiser registration view.
        /// </summary>
        /// <returns></returns>
        IAppraiserView GetAppraiserRegistrationView();

        /// <summary>
        /// Processes the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        string ProcessAppraiserInfo(IAppraiserView appraiserInfo);

        /// <summary>
        /// Gets the appraiser edit view.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        IAppraiserView GetAppraiserEditView(int appraiserId);

        /// <summary>
        /// Processes the edit appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        string ProcessEditAppraiserInfo(IAppraiserView appraiserInfo);

        /// <summary>
        /// Processes the delete appraiser information.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraiserInfo(int appraiserId);

        /// <summary>
        /// Creates the appraiser update view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraiserView CreateAppraiserUpdateView(IAppraiserView appraiserInfo, string processingMessage);

        #endregion

        #region //=======================APPRAISAL GOAL=======================//

        /// <summary>
        /// Gets the appraisal goal ListView.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IAppraisalGoalListView GetAppraisalGoalListView(int employeeAppraisalId, string message);

        /// <summary>
        /// Gets the appraisal goal registration view.
        /// </summary>
        /// <returns></returns>
        IAppraisalGoalView GetAppraisalGoalRegistrationView(int appraisalId);

        /// <summary>
        /// Processes the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        string ProcessAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo);

        /// <summary>
        /// Gets the appraisal goal edit view.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView GetAppraisalGoalEditView(int appraisalGoalId, string processingMessage);

        /// <summary>
        /// Processes the edit appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        string ProcessEditAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo);

        /// <summary>
        /// Processes the delete appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalGoalInfo(int appraisalGoalId);

        /// <summary>
        /// Creates the appraisal goal update view.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateAppraisalGoalUpdateView(IAppraisalGoalView appraisalGoalInfo, string processingMessage);

        #endregion

        #region //=========================APPRAISAL============================//
        
        /// <summary>
        /// Gets the appraisal registration view.
        /// </summary>
        /// <param name="CompanyId">The company identifier.</param>
        /// <returns></returns>
        IAppraisalView GetAppraisalRegistrationView();

        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateAppraisalUpdateView(IAppraisalView appraisalInfo, string processingMessage);

        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="appraisalQualitativeMetric">The appraisal qualitative metric.</param>
        /// <param name="appraisalQuantitativeMetric">The appraisal quantitative metric.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateAppraisalUpdateView(IAppraisal appraisalInfo, IEmployeeAppraisal employeeAppraisal, IEnumerable<IAppraisalQualitativeMetric> appraisalQualitativeMetric, IEnumerable<IAppraisalQuantitativeMetric> appraisalQuantitativeMetric, string processingMessage);

        /// <summary>
        /// Gets the appraisal list employee view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView GetAppraisalListEmployeeView(string processingMessage);

        /// <summary>
        /// Gets the appraisal ListView.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalListView GetAppraisalListView(string ProcessingMessage);

        /// <summary>
        /// Gets the appraisal question ListView.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionListView GetAppraisalQuestionListView(string processingMessage);

        /// <summary>
        /// Processes the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        string ProcessAppraisalInfo(IAppraisalView appraisalInfo);

        /// <summary>
        /// Processes the appraisal question information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        string ProcessAppraisalQuestionInfo(IAppraisalQuestionView appraisalInfo);

        /// <summary>
        /// Processes the edit appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="appraisalQualitativeMetric">The appraisal qualitative metric.</param>
        /// <param name="appraisalQuantitativeMetric">The appraisal quantitative metric.</param>
        /// <returns></returns>
        string ProcessEditAppraisalInfo(IAppraisal appraisalInfo, IEmployeeAppraisal employee, IEnumerable<IAppraisalQualitativeMetric> appraisalQualitativeMetric, IEnumerable<IAppraisalQuantitativeMetric> appraisalQuantitativeMetric);

        /// <summary>
        /// Processes the delete appraisal information.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalInfo(int appraisalId);
        
        /// <summary>
        /// Gets the appraisal edit view.
        /// </summary>
        /// <param name="LoggedUser">The logged user.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView GetAppraisalEditView(int LoggedUser, string processingMessage);

        /// <summary>
        /// Gets the appraisal question delete view.
        /// </summary>
        /// <param name="appraisalQuestionId">The appraisal question identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionView GetAppraisalQuestionDeleteView(int appraisalQuestionId, string processingMessage);

        /// <summary>
        /// Gets the appraisal question edit view.
        /// </summary>
        /// <param name="appraisalQuestionId">The appraisal question identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionView GetAppraisalQuestionEditView(int appraisalQuestionId, string processingMessage);

        /// <summary>
        /// Creates the employee appraisal update view.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IAppraisalView CreateEmployeeAppraisalUpdateView(IEmployeeAppraisal employeeAppraisal, string message);
        
        /// <summary>
        /// Processes the edit employee appraisal information.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <returns></returns>
        string ProcessEditEmployeeAppraisalInfo(IEmployeeAppraisal employeeAppraisal);

        /// <summary>
        /// Gets the employee every appraisal.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalListView GetEmployeeEveryAppraisal(string processingMessage);

        /// <summary>
        /// Gets the employee appraisee list.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalListView GetEmployeeAppraiseeList(string processingMessage);

        /// <summary>
        /// Gets the employee every appraisal.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IAppraisalListView GetEmployeeEveryAppraisal(string processingMessage, int employeeId);

        /// <summary>
        /// Gets the employee appraisal view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IAppraisalView GetEmployeeAppraisalView(int employeeId);

        /// <summary>
        /// Gets the employee appraisal update view.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IAppraisalView GetEmployeeAppraisalUpdateView(IAppraisalView appraisal, string message);

        /// <summary>
        /// Gets the create employee appraisal.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IAppraisalView GetCreateEmployeeAppraisal(int employeeId);

        /// <summary>
        /// Saves the employee appraisal.
        /// </summary>
        /// <param name="SaveEmployeeAppraisal">The save employee appraisal.</param>
        /// <returns></returns>
        string SaveEmployeeAppraisal(IAppraisalView SaveEmployeeAppraisal);

        /// <summary>
        /// Gets the create employee appraisal.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView GetCreateEmployeeAppraisal(IAppraisalView appraisalInfo, string processingMessage);

        /// <summary>
        /// Gets the employee appraisal ListView.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalListView GetEmployeeAppraisalListView(int employee, string processingMessage);

        /// <summary>
        /// Gets the appraisal question registration view.
        /// </summary>
        /// <returns></returns>
        IAppraisalQuestionView GetAppraisalQuestionRegistrationView();

        /// <summary>
        /// Gets the appraisee ListView.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IAppraisalView GetAppraiseeListView(int appraisalId, string message);

        #endregion

        #region //=====================================Feedback Module Section================================//

        /// <summary>
        /// Gets the employee feedback ListView.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeFeedbackView GetEmployeeFeedbackListView(string message);

        /// <summary>
        /// Gets all feed by company and year.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IFeedbackListview GetAllFeedByCompanyAndYear(string processingMessage);

        /// <summary>
        /// Creates the feedback view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IFeedbackViewModel CreateFeedbackView(string processingMessage);

        /// <summary>
        /// Creates the feedback view.
        /// </summary>
        /// <param name="feedback">The feedback.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IFeedbackViewModel CreateFeedbackView(IFeedbackModel feedback, string processingMessage);

        /// <summary>
        /// Processes the feedback information.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        string ProcessFeedbackInfo(IFeedbackModel viewModel);

        /// <summary>
        /// Gets the employee feedback view by identifier.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <returns></returns>
        IEmployeeFeedbackViewModel GetEmployeeFeedbackViewByID(int feedbackId);

        /// <summary>
        /// Processes the employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        string ProcessEmployeeFeedback(IEmployeeFeedbackViewModel employeeView);

        /// <summary>
        /// Processes the updated employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        string ProcessUpdatedEmployeeFeedback(IEmployeeFeedbackViewModel employeeView);

        /// <summary>
        /// Gets the feedback employee ListView.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeFeedbackView GetFeedbackEmployeeListView(int feedbackId, string message);

        /// <summary>
        /// Gets the employee feedback view.
        /// </summary>
        /// <param name="employeeFeedback">The employee feedback.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeFeedbackViewModel GetEmployeeFeedbackView(IEmployeeFeedbackViewModel employeeFeedback, string processingMessage);

        /// <summary>
        /// Gets the view employee feedback.
        /// </summary>
        /// <param name="employeeFeedbackId">The employee feedback identifier.</param>
        /// <returns></returns>
        IEmployeeFeedbackViewModel GetViewEmployeeFeedback(int employeeFeedbackId);

        #endregion

        #region //====================================Annual Assessing Performance Section Start====================================//

        /// <summary>
        /// Gets the annual performance.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAnnualAssessingPerformanceListView GetAnnualPerformance(string processingMessage);

        /// <summary>
        /// Gets the annual performance view.
        /// </summary>
        /// <returns></returns>
        IAnnualAssessingPerformanceView GetAnnualPerformanceView();

        /// <summary>
        /// Gets the annual performance view.
        /// </summary>
        /// <param name="annualAssessingPerformance">The annual assessing performance.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAnnualAssessingPerformanceView GetAnnualPerformanceView(IAnnualAssessingPerformanceView annualAssessingPerformance, string processingMessage);

        /// <summary>
        /// Processes the annual performance information.
        /// </summary>
        /// <param name="annualAssessingPerformance">The annual assessing performance.</param>
        /// <returns></returns>
        string ProcessAnnualPerformanceInfo(IAnnualAssessingPerformanceView annualAssessingPerformance);

        #endregion

        #region //====================================Employee Annual Assessing Performance Section Start====================================//
        

        /// <summary>
        /// Gets the employee annual performance view list employee.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceListView GetEmployeeAnnualPerformanceViewListEmployee(string message);


        /// <summary>
        /// Gets the employee annual performance view list reviewer.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceListView GetEmployeeAnnualPerformanceViewListReviewer(string message);

        /// <summary>
        /// Gets the employee annual performance view.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceView GetEmployeeAnnualPerformanceView(int annualAssessingPerformanceId);

        /// <summary>
        /// Gets the employee annual performance view.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <param name="processinMessage">The processin message.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceView GetEmployeeAnnualPerformanceView(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance, string processinMessage);

        /// <summary>
        /// Processings the employee annual assessing performance information.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        string ProcessingEmployeeAnnualAssessingPerformanceInfo(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance);
        /// <summary>
        /// Processings the edit employee annual assessing performance information.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        string ProcessingEditEmployeeAnnualAssessingPerformanceInfo(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance);

        /// <summary>
        /// Gets the edit employee annual performance view.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformanceId">The employee annual assessing performance identifier.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceView GetEditEmployeeAnnualPerformanceView(int employeeAnnualAssessingPerformanceId);

        /// <summary>
        /// Gets the employee annual performance view list.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceListView GetEmployeeAnnualPerformanceViewList(int annualAssessingPerformanceId, string message);

        #endregion

    }
}
