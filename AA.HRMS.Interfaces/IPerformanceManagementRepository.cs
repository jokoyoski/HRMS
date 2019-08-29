using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPerformanceManagementRepository
    {

        #region //=============================Appraisal Questions=================================//

        /// <summary>
        /// Saves the delete appraisal question.
        /// </summary>
        /// <param name="AppraisalQuestion">The appraisal question.</param>
        /// <returns></returns>
        string SaveDeleteAppraisalQuestion(IAppraisalQuestion AppraisalQuestion);

        /// <summary>
        /// Saves the update appraisal question.
        /// </summary>
        /// <param name="AppraisalQuestion">The appraisal question.</param>
        /// <returns></returns>
        string SaveUpdateAppraisalQuestion(IAppraisalQuestion AppraisalQuestion);

        /// <summary>
        /// Gets the appraisal question by identifier.
        /// </summary>
        /// <param name="appraisalQuestionId">The appraisal question identifier.</param>
        /// <returns></returns>
        IAppraisalQuestion GetAppraisalQuestionById(int appraisalQuestionId);

        #endregion
        
        #region    //====================APPRAISAL ACTION====================================//
        
        /// <summary>
        /// Gets the appraisal action list.
        /// </summary>
        /// <param name="CompanyId">The company identifier.</param>
        /// <returns></returns>
        IList<IAppraisalAction> GetAppraisalActionList(int CompanyId);

        /// <summary>
        /// Saves the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        string SaveAppraisalActionInfo(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Gets the appraisal by company year period.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <param name="peeriodId">The peeriod identifier.</param>
        /// <returns></returns>
        IAppraisal GetAppraisalByCompanyYearPeriod(int companyId, int yearId, int peeriodId);

        /// <summary>
        /// Updates the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        string UpdateAppraisalActionInfo(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Gets the appraisal action by identifier.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        IAppraisalAction GetAppraisalActionById(int appraisalActionId);

        /// <summary>
        /// Deletes the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        string DeleteAppraisalActionInfo(int appraisalActionId);

        #endregion
        
        #region //=======================APPRAISAL RATING============//

        /// <summary>
        /// Gets the appraisal rating list.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalRating> GetAppraisalRatingList();

        /// <summary>
        /// Saves the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        string SaveAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo);

        /// <summary>
        /// Updates the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        string UpdateAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo);

        /// <summary>
        /// Gets the appraisal rating by identifier.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        IAppraisalRating GetAppraisalRatingById(int appraisalRatingId);

        /// <summary>
        /// Deletes the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        string DeleteAppraisalRatingInfo(int appraisalRatingId);

        #endregion

        #region //================================Task Module Section====================================//

        /// <summary>
        /// Gets the task list by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeTask> GetTaskListByCompanyId(int companyId);

        /// <summary>
        /// Gets the employee task list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeTask> GetEmployeeTaskList(int employeeId);

        /// <summary>
        /// Saves the employee task information.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <returns></returns>
        string SaveEmployeeTaskInfo(IEmployeeTaskView employeeTaskInfo);

        /// <summary>
        /// Updates the employee task information.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <returns></returns>
        string UpdateEmployeeTaskInfo(IEmployeeTaskView employeeTaskInfo);

        /// <summary>
        /// Deletes the employee task information.
        /// </summary>
        /// <param name="employeeTaskInfoId">The employee task information identifier.</param>
        /// <returns></returns>
        string DeleteEmployeeTaskInfo(int employeeTaskInfoId);

        /// <summary>
        /// Gets the employee task by identifier.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        IEmployeeTask GetEmployeeTaskById(int employeeTaskId);

        #endregion

        #region //===================APPRAISER========================//   
        
        /// <summary>
        /// Gets the appraisal question list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IAppraisalQuestion> GetAppraisalQuestionList(int companyId);

        /// <summary>
        /// Gets the appraiser list.
        /// </summary>
        /// <returns></returns>
        IList<IAppraiser> GetAppraiserList();

        /// <summary>
        /// Saves the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        string SaveAppraiserInfo(IAppraiserView appraiserInfo);

        /// <summary>
        /// Updates the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        string UpdateAppraiserInfo(IAppraiserView appraiserInfo);

        /// <summary>
        /// Gets the appraiser by identifier.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        IAppraiser GetAppraiserById(int appraiserId);

        /// <summary>
        /// Deletes the appraiser information.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        string DeleteAppraiserInfo(int appraiserId);

        #endregion

        #region //===================APPRAISER GOAL=========================//

        /// <summary>
        /// Gets the appraisal goal list.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        IList<IAppraisalGoal> GetAppraisalGoalList(int employeeAppraisalId);

        /// <summary>
        /// Saves the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        string SaveAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo);

        /// <summary>
        /// Updates the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        string UpdateAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo);

        /// <summary>
        /// Gets the appraisal goal by identifier.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        IAppraisalGoal GetAppraisalGoalById(int appraisalGoalId);

        /// <summary>
        /// Deletes the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        string DeleteAppraisalGoalInfo(int appraisalGoalId);

        #endregion

        #region //=======================APPRAISAL=========================//

        /// <summary>
        /// Gets the appraisal list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IAppraisal> GetAppraisalList(int employeeId);

        /// <summary>
        /// Gets the appraisal list employee.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAppraisal> GetAppraisalListEmployee(int companyId, int employeeId);

        /// <summary>
        /// Saves the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        string SaveAppraisalInfo(IAppraisalView appraisalInfo, out int appraisalId);

        /// <summary>
        /// Saves the appraisal question information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        string SaveAppraisalQuestionInfo(IAppraisalQuestionView appraisalInfo);

        /// <summary>
        /// Saves the apraisal qualitative information.
        /// </summary>
        /// <param name="appraisalQualitativeMetric">The appraisal qualitative metric.</param>
        /// <returns></returns>
        string SaveApraisalQualitativeInfo(IAppraisalQualitativeMetric appraisalQualitativeMetric);

        /// <summary>
        /// Saves the apraisal quantitative information.
        /// </summary>
        /// <param name="appraisalQuantitativeMetric">The appraisal quantitative metric.</param>
        /// <returns></returns>
        string SaveApraisalQuantitativeInfo(IAppraisalQuantitativeMetric appraisalQuantitativeMetric);

        /// <summary>
        /// Updates the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="appraiser">The appraiser.</param>
        /// <returns></returns>
        string UpdateAppraisalInfo(IAppraisal appraisalInfo);

        /// <summary>
        /// Gets the appraisal by identifier.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        IAppraisal GetAppraisalById(int appraisalId);

        /// <summary>
        /// Deletes the appraisal information.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        string DeleteAppraisalInfo(int appraisalId);

        /// <summary>
        /// Gets all my appraisals by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IAppraisal> GetAllMyAppraisalsByEmployeeId(int employeeId);

        /// <summary>
        /// Saves the employee appraisal.
        /// </summary>
        /// <param name="appraisalView">The appraisal view.</param>
        /// <returns></returns>
        string saveEmployeeAppraisal(IAppraisalView appraisalView);

        /// <summary>
        /// Gets all my appraisals.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IAppraisal> GetAllMyAppraisals(int companyId);

        /// <summary>
        /// Gets the appraisal list by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAppraisal> GetAppraisalBySupervisorId(int supervisorId, int companyId, int appraisalId);

        /// <summary>
        /// Gets the appraisal by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAppraisal> GetAppraisalByEmployeeId(int employeeId, int companyId, int appraisalId);

        /// <summary>
        /// Gets the appraisal by employee identifier supervisor identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAppraisal> GetAppraisalByEmployeeIdSupervisorId(int employeeId, int companyId, int appraisalId);
        /// <summary>
        /// Gets the employee appraisal by company identifier appraisal identifier employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        IEmployeeAppraisal GetEmployeeAppraisalByCompanyIdAppraisalIdEmployeeId(int employeeId, int companyId, int appraisalId);
        
        /// <summary>
        /// Gets the appraisal action list.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalAction> GetAppraisalActionList();

        /// <summary>
        /// Gets the appraisal question.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IAppraisalQuestion> GetAppraisalQuestion(int companyId);

        /// <summary>
        /// Saves the employee appraisal information.
        /// </summary>
        /// <param name="employeeAppraisalInfo">The employee appraisal information.</param>
        /// <returns></returns>
        string SaveEmployeeAppraisalInfo(IEmployeeAppraisalView employeeAppraisalInfo);

        /// <summary>
        /// Saves the update employee appraisal.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <returns></returns>
        string SaveUpdateEmployeeAppraisal(IEmployeeAppraisal employeeAppraisal);

        /// <summary>
        /// Gets the appraisal by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IAppraisal GetAppraisalByCompanyId(int companyId);

        /// <summary>
        /// Saves the employee appraisal question information.
        /// </summary>
        /// <param name="employeeQuestionAppraisalInfo">The employee question appraisal information.</param>
        /// <returns></returns>
        string SaveEmployeeAppraisalQuestionInfo(IEmployeeQuestionRating employeeQuestionAppraisalInfo);

        /// <summary>
        /// Gets the employee appraisal by identifier.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        IEmployeeAppraisal GetEmployeeAppraisalById(int employeeAppraisalId);

        /// <summary>
        /// Updates the employee appraisal question information.
        /// </summary>
        /// <param name="employeeQuestionAppraisalInfo">The employee question appraisal information.</param>
        /// <returns></returns>
        string UpdateEmployeeAppraisalQuestionInfo(IEmployeeQuestionRating employeeQuestionAppraisalInfo);

        /// <summary>
        /// Gets the appraisee list employee.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="supervisorId">The supervisor identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAppraisal> GetAppraiseeListEmployee(int companyId, int supervisorId);

        /// <summary>
        /// Gets the employee appraisal question rating.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        IList<IEmployeeQuestionRating> GetEmployeeAppraisalQuestionRating(int employeeId, int appraisalId);

        /// <summary>
        /// Gets the employee appraisal by appraisal identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAppraisal> GetEmployeeAppraisalByAppraisalId(int companyId, int appraisalId);

        /// <summary>
        /// Gets the employee feedback by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeFeedbackModel> GetEmployeeFeedbackByCompanyId(int companyId);

        /// <summary>
        /// Saves the employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        string SaveEmployeeFeedback(IEmployeeFeedbackViewModel employeeView);

        #endregion

        #region //=============================================Annual Assessing Performance Start================================//

        /// <summary>
        /// Gets the annual assessing performance by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IAnnualAssesingPerformance> GetAnnualAssessingPerformanceByCompanyId(int companyId);

        /// <summary>
        /// Gets the annual assessing performance by identifier.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        IAnnualAssesingPerformance GetAnnualAssessingPerformanceById(int annualAssessingPerformanceId);

        /// <summary>
        /// Gets the annual assessing performance by company identifier year identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        IAnnualAssesingPerformance GetAnnualAssessingPerformanceByCompanyIdYearId(int companyId, int yearId);

        /// <summary>
        /// Saves the annual performance information.
        /// </summary>
        /// <param name="annualAssesingPerformance">The annual assesing performance.</param>
        /// <returns></returns>
        string SaveAnnualPerformanceInfo(IAnnualAssessingPerformanceView annualAssesingPerformance, out int annualAssessingPerformanceId);

        /// <summary>
        /// Saves the close annual performance information.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        string SaveCloseAnnualPerformanceInfo(int annualAssessingPerformanceId);

        //=============================================Annual Assessing Performance End================================//

        #endregion

        #region //==================================================Employeee Annual Performance Section Starts===========================//       


        /// <summary>
        /// Gets the employee annual assessing performance by identifier.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformanceId">The employee annual assessing performance identifier.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformance GetEmployeeAnnualAssessingPerformanceById(int employeeAnnualAssessingPerformanceId);

        /// <summary>
        /// Saves the employee annual performance information.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        string SaveEmployeeAnnualPerformanceInfo(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance);

        /// <summary>
        /// Edits the employee annual performance information.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        string EditEmployeeAnnualPerformanceInfo(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance);

        /// <summary>
        /// Gets the employee annual assessing performance list by identifier.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAnnualAssessingPerformance> GetEmployeeAnnualAssessingPerformanceListByAnnualAssessingPerformanceId(int annualAssessingPerformanceId);

        /// <summary>
        /// Gets the employee annual assessing performance list by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAnnualAssessingPerformance> GetEmployeeAnnualAssessingPerformanceListByEmployeeId(int employeeId);

        /// <summary>
        /// Gets the employee annual assessing performance list by supervisor identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeAnnualAssessingPerformance> GetEmployeeAnnualAssessingPerformanceListBySupervisorId(int employeeId);

        /// <summary>
        /// Gets the employee annual assessing performance list by employee year identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformance GetEmployeeAnnualAssessingPerformanceListByEmployeeYearId(int employeeId, int yearId);

        /// <summary>
        /// Gets the appraisal quantitative metric by employee appraisal identifier.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        IList<IAppraisalQuantitativeMetric> GetAppraisalQuantitativeMetricByEmployeeAppraisalId(int employeeAppraisalId);

        /// <summary>
        /// Gets the appraisal qualitative metric by employee appraisal identifier.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        IList<IAppraisalQualitativeMetric> GetAppraisalQualitativeMetricByEmployeeAppraisalId(int employeeAppraisalId);

        //==================================================Employeee Annual Performance Section Starts===========================//

        #endregion

        #region //======================================Employee Feedback====================================//

        /// <summary>
        /// Gets the feed back by identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IFeedbackModel> GetFeedBackById(int companyId);

        /// <summary>
        /// Saves the feedback information.
        /// </summary>
        /// <param name="feedbackViewModel">The feedback view model.</param>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <returns></returns>
        string SaveFeedbackInfo(IFeedbackModel feedbackViewModel, out int feedbackId);

        /// <summary>
        /// Gets the employee feed back by identifier.
        /// </summary>
        /// <param name="employeeFeebackId">The employee feeback identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <returns></returns>
        IList<IEmployeeFeedbackModel> GetEmployeeFeedBackById(int employeeFeebackId, int employeeId, int companyId, int feedbackId);

        /// <summary>
        /// Processes the edit feedback.
        /// </summary>
        /// <param name="feedbackViewModel">The feedback view model.</param>
        /// <returns></returns>
        string ProcessEditFeedback(IFeedbackViewModel feedbackViewModel);

        /// <summary>
        /// Saves the update employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        string SaveUpdateEmployeeFeedback(IEmployeeFeedbackViewModel employeeView);

        /// <summary>
        /// Gets the employee feedback byemployee feedback identifier.
        /// </summary>
        /// <param name="employeefeedbackId">The employeefeedback identifier.</param>
        /// <returns></returns>
        IEmployeeFeedbackModel GetEmployeeFeedbackByemployeeFeedbackId(int employeefeedbackId);

        /// <summary>
        /// Gets the employee feedback by employee feedback identifier.
        /// </summary>
        /// <param name="employeeFeebackId">The employee feeback identifier.</param>
        /// <returns></returns>
        IList<IEmployeeFeedbackModel> GetEmployeeFeedbackByEmployeeFeedbackId(int employeeFeebackId);

        /// <summary>
        /// Saves the edited employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        string SaveEditedEmployeeFeedback(IEmployeeFeedbackViewModel employeeView);

        /// <summary>
        /// Gets the employee feedback by feedback identifier.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <returns></returns>
        IList<IEmployeeFeedbackModel> GetEmployeeFeedbackByFeedbackId(int feedbackId);

        /// <summary>
        /// Gets the employee feedback by feedback identifier employee identifier feedback on employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="feebackId">The feeback identifier.</param>
        /// <param name="feedbackOnEmployeeId">The feedback on employee identifier.</param>
        /// <returns></returns>
        IEmployeeFeedbackModel GetEmployeeFeedbackByFeedbackIdEmployeeIdFeedbackOnEmployeeId(int employeeId, int feebackId, int feedbackOnEmployeeId);

        /// <summary>
        /// Gets the feedback by company year identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        IFeedbackModel GetFeedbackByCompanyYearId(int companyId, int yearId);

        #endregion


        #region //=========================================Milestone Section==================================//

        /// <summary>
        /// Gets the milestone list by task identifier.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <returns></returns>
        IList<IMilestone> GetMilestoneListByTaskId(int taskId);

        #endregion
    }
}
