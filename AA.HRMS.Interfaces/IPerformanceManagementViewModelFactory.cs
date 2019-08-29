using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPerformanceManagementViewModelFactory
    {
        #region //====================APPRAISAL ACTION============//

        /// <summary>
        /// Creates the appraisal action view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IAppraisalActionView CreateAppraisalActionView(int companyId);

        /// <summary>
        /// Creates the updated appraisal action view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalActionView CreateUpdatedAppraisalActionView(IAppraisalActionView appraisalActionInfo, string processingMessage);

        /// <summary>
        /// Creates the appraisal action update view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        IAppraisalActionView CreateAppraisalActionUpdateView(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Creates the edit appraisal action view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        IAppraisalActionView CreateEditAppraisalActionView(IAppraisalAction appraisalActionInfo);

        #endregion

        #region //=======================APPRAISAL RATING==========//

        /// <summary>
        /// Creates the appraisal rating view.
        /// </summary>
        /// <returns></returns>
        IAppraisalRatingView CreateAppraisalRatingView();

        /// <summary>
        /// Creates the updated appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalRatingView CreateUpdatedAppraisalRatingView(IAppraisalRatingView appraisalRatingInfo, string processingMessage);

        /// <summary>
        /// Creates the appraisal rating update view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        IAppraisalRatingView CreateAppraisalRatingUpdateView(IAppraisalRatingView appraisalRatingInfo);

        /// <summary>
        /// Creates the edit appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        IAppraisalRatingView CreateEditAppraisalRatingView(IAppraisalRating appraisalRatingInfo);

        #endregion

        #region //=======================EMPLOYEE TASK RATING==========//

        /// <summary>
        /// Creates the appraisal rating view.
        /// </summary>
        /// <returns></returns>
        //IEmployeeTaskView CreateEmployeeTaskView();

        IEmployeeTaskListView CreateEmployeeTaskListView(IList<IEmployeeTask> employeeTaskCollection, string processingMessage);

        /// <summary>
        /// Creates the updated appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeTaskView CreateUpdatedEmployeeTaskView(IEmployeeTaskView employeeTaskViewInfo, string processingMessage);
        
        /// <summary>
        /// Creates the edit appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        IEmployeeTaskView CreateEditEmployeeTaskView(IEmployeeTask employeeTaskInfo);

        /// <summary>
        /// Creates the employee task view.
        /// </summary>
        /// <returns></returns>
        IEmployeeTaskView CreateEmployeeTaskView(int appraisalGoalId);

        #endregion

        #region //==================APPRAISER======================//

        /// <summary>
        /// Creates the appraiser view.
        /// </summary>
        /// <returns></returns>
        IAppraiserView CreateAppraiserView();

        /// <summary>
        /// Creates the updated appraiser view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraiserView CreateUpdatedAppraiserView(IAppraiserView appraiserInfo, string processingMessage);

        /// <summary>
        /// Creates the appraiser update view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        IAppraiserView CreateAppraiserUpdateView(IAppraiserView appraiserInfo);

        /// <summary>
        /// Creates the edit appraiser view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        IAppraiserView CreateEditAppraiserView(IAppraiser appraiserInfo);

        #endregion

        #region //==================APPRAISAL GOAL========================//

        /// <summary>
        /// Creates the appraisal goal ListView.
        /// </summary>
        /// <param name="appraisalGoalCollection">The appraisal goal collection.</param>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalListView CreateAppraisalGoalListView(IList<IAppraisalGoal> appraisalGoalCollection, IEmployeeAppraisal employeeAppraisal, string processingMessage);

        /// <summary>
        /// Creates the appraisal goal view.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="Appraisee">The appraisee.</param>
        /// <param name="Appraiser">The appraiser.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateAppraisalGoalView(IAppraisal appraisal, IEmployeeAppraisal employeeAppraisal, IEmployee Appraisee, IEmployee Appraiser);

        /// <summary>
        /// Creates the updated appraisal goal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateUpdatedAppraisalGoalView(IList<IAppraiser> appraisersCollection, IAppraisalGoalView appraisalGoalInfo, IList<IEmployee> employeeCollection, string processingMessage);

        /// <summary>
        /// Creates the appraisal goal update view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateAppraisalGoalUpdateView(IList<IAppraiser> appraisersCollection, IAppraisalGoalView appraisalGoalInfo, IList<IEmployee> employeeCollection, string processingMessage);

        /// <summary>
        /// Creates the edit appraisal goal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateEditAppraisalGoalView(IList<IAppraiser> appraisersCollection, IAppraisalGoal appraisalGoalInfo, IList<IEmployee> employeeCollection, string processingMessage);

        #endregion

        #region //=====================================================APPRAISAL=======================================================//

        /// <summary>
        /// Creates the delete appraisal question view.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionView CreateDeleteAppraisalQuestionView(IAppraisalQuestion appraisalQuestionInfo, int companyId, string processingMessage);

        /// <summary>
        /// Creates the edit appraisal question view.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionView CreateEditAppraisalQuestionView(IAppraisalQuestion appraisalQuestionInfo, int companyId, string processingMessage);

        /// <summary>
        /// Gets the appraisal action ListView.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalActionView GetAppraisalActionListView(IList<IAppraisalAction> appraisal, string ProcessingMessage);

        /// <summary>
        /// Gets the appraisal question ListView.
        /// </summary>
        /// <param name="appraisalQuestionView">The appraisal question view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionListView GetAppraisalQuestionListView(IList<IAppraisalQuestion> appraisalQuestionView, string processingMessage);


        /// <summary>
        /// Gets the appraisal ListView.
        /// </summary>
        /// <param name="appraisalView">The appraisal view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalListView GetAppraisalListView(IList<IAppraisal> appraisalView, string processingMessage);

        /// <summary>
        /// Gets the employee appraisal ListView.
        /// </summary>
        /// <param name="employeeAppraisalView">The employee appraisal view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView GetEmployeeAppraisalListView(IList<IEmployeeAppraisal> employeeAppraisalView, string processingMessage);


        /// <summary>
        /// Creates the appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalPeriodCollection">The appraisal period collection.</param>
        /// <param name="yearCollection">The year collection.</param>
        /// <returns></returns>
        IAppraisalView CreateAppraisalView(IList<IAppraiser> appraisersCollection,
                                           IList<IAppraisalRating> appraisalRatingsCollection,
                                           IList<IAppraisalAction> appraisalActionsCollection,
                                           IList<IAppraisalPeriod> appraisalPeriodCollection,
                                           IList<IEmployee> employeeCollection,
                                           IList<IYear> yearCollection, int companyId);

        /// <summary>
        /// Creates the appraisal question view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IAppraisalQuestionView CreateAppraisalQuestionView(int companyId);

        /// <summary>
        /// Creates the updated appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="companyDetail">The company detail.</param>
        /// <returns></returns>
        IAppraisalView CreateUpdatedAppraisalView(IAppraisal appraisalInfo, IEmployeeAppraisal employeeAppraisal, IEnumerable<IAppraisalQualitativeMetric> appraisalQualitativeMetric, IEnumerable<IAppraisalQuantitativeMetric> appraisalQuantitativeMetric, IList<IAppraisalQuestion> appraisalQuestion, IList<IAppraisalRating> appraisalRatingsList,
            IEmployee employeeInfo, ICompanyDetail companyInfo, string processingMessage);

        /// <summary>
        /// Creates the updated appraisal question view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalQuestionView CreateUpdatedAppraisalQuestionView(IList<ICompanyDetail> companyCollection,
                                                  IAppraisalQuestionView appraisalInfo,
                                                  string processingMessage);

        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="appraisalPeriodCollection">The appraisal period collection.</param>
        /// <param name="yearCollection">The year collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateAppraisalUpdateView(IAppraisalView appraisalInfo, IList<IAppraisalPeriod> appraisalPeriodCollection,
            IList<IYear> yearCollection, string processingMessage);

        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateAppraisalUpdateView(IList<IAppraiser> appraisersCollection,
                                                 IList<IAppraisalRating> appraisalRatingsCollection,
                                                 IList<IAppraisalAction> appraisalActionsCollection,
                                                 IAppraisalView appraisalInfo, IList<IEmployee> employeeCollection,
                                                 string processingMessage);
        /// <summary>
        /// Creates the edit appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateEditAppraisalView(IAppraisal appraisal, IEmployeeAppraisal employeeAppraisal, IList<IAppraisalQualitativeMetric> appraisalQualitativeMetric, IList<IAppraisalQuantitativeMetric> appraisalQuantitativeMetric, IList<IEmployeeAppraisal> employeeAppraisalCollection,
            IList<IAppraisalQuestion> appraisalQuestions, IEmployee employee, IEmployee supervisor, IUserDetail user, IList<IAppraisalRating> appraisalRatingCollection, 
            IList<IEmployeeQuestionRating> employeeQuestionRationg, IList<IAppraisalGoal> appraisalGoalCollection, IList<IResult> resultCollection);

        /// <summary>
        /// Creates the edit appraisal view.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        IAppraisalView CreateDeleteAppraisalView(IAppraisal appraisal, ICompanyDetail company);


        /// <summary>
        /// Creates the specific employee appraisal view.
        /// </summary>
        /// <param name="employeeAppraisalCollection">The employee appraisal collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="supervisor">The supervisor.</param>
        /// <param name="company">The company.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalListView CreateSpecificEmployeeAppraisalView(IList<IEmployeeAppraisal> employeeAppraisalCollection, IEmployee employee, IEmployee supervisor, ICompanyDetail company, int employeeId, string processingMessage);
        
        /// <summary>
        /// Creates the employee appraisal request view.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        IAppraisalView CreateEmployeeAppraisalRequestView(IList<IAppraisal> appraisal, IList<ICompanyDetail> companyCollection,  IList<IEmployee> employee, IEmployee employeeModel);
        
        /// <summary>
        /// Creates the employee appraisal view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateEmployeeAppraisalView(IAppraisalView appraisalInfo, int companyId, IList<IAppraisal> appraisal, IList<IEmployee> employee, string processingMessage);

        /// <summary>
        /// Creates the updated employee appraisal view.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="employeeQuestionRatings">The employee question ratings.</param>
        /// <param name="appraisalRatings">The appraisal ratings.</param>
        /// <param name="appraisee">The appraisee.</param>
        /// <param name="appraiser">The appraiser.</param>
        /// <param name="companyDetail">The company detail.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IAppraisalView CreateUpdatedEmployeeAppraisalView(IEmployeeAppraisal employeeAppraisal, IAppraisal appraisal, IList<IEmployeeQuestionRating> employeeQuestionRatings,
            IList<IAppraisalRating> appraisalRatings, IEmployee appraisee, IEmployee appraiser, ICompanyDetail companyDetail, string message);

        /// <summary>
        /// Creates the specific employee appraisal view.
        /// </summary>
        /// <param name="appraisalCollection">The appraisal collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="company">The company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeAppraisalListView CreateSpecificEmployeeAppraisalView(IList<IEmployeeAppraisal> appraisalCollection, IEmployee employee, ICompanyDetail company, string processingMessage);

        #endregion

        #region  //================================================Annual Performance Assessing Start=========================================================//

        /// <summary>
        /// Creates the annual performance ListView.
        /// </summary>
        /// <param name="annualAssesingPerformanceCollection">The annual assesing performance collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAnnualAssessingPerformanceListView CreateAnnualPerformanceListView(IList<IAnnualAssesingPerformance> annualAssesingPerformanceCollection, string processingMessage);

        /// <summary>
        /// Creates the annual performance view.
        /// </summary>
        /// <param name="yearsCollection">The years collection.</param>
        /// <returns></returns>
        IAnnualAssessingPerformanceView CreateAnnualPerformanceView(IUserDetail user, IList<IYear> yearsCollection);

        /// <summary>
        /// Creates the annual performance view.
        /// </summary>
        /// <param name="annualAssessingPerformanceView">The annual assessing performance view.</param>
        /// <param name="yearsCollection">The years collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAnnualAssessingPerformanceView CreateAnnualPerformanceView(IAnnualAssessingPerformanceView annualAssessingPerformanceView, IUserDetail user, IList<IYear> yearsCollection, string processingMessage);

        #endregion
        
        #region //-------------------------------------------Employee Annual Performance---------------------------------------------//

        /// <summary>
        /// Creates the employee annual assessing performance ListView.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformanceCollection">The employee annual assessing performance collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceListView CreateEmployeeAnnualAssessingPerformanceListView(IList<IEmployeeAnnualAssessingPerformance> employeeAnnualAssessingPerformanceCollection, string message);

        /// <summary>
        /// Creates the employee annual performance view.
        /// </summary>
        /// <param name="annualPerformanceAssessmentInfo">The annual performance assessment information.</param>
        /// <param name="revieweeInfo">The reviewee information.</param>
        /// <param name="reviewerInfo">The reviewer information.</param>
        /// <param name="ratingCollection">The rating collection.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceView CreateEmployeeAnnualPerformanceView(IAnnualAssesingPerformance annualPerformanceAssessmentInfo, IEmployee revieweeInfo, IEmployee reviewerInfo, IList<IAppraisalRating> ratingCollection, ICompanyDetail companyInfo);

        /// <summary>
        /// Creates the employee annual performance view.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <param name="annualPerformanceAssessmentInfo">The annual performance assessment information.</param>
        /// <param name="revieweeInfo">The reviewee information.</param>
        /// <param name="reviewerInfo">The reviewer information.</param>
        /// <param name="ratingCollection">The rating collection.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceView CreateEmployeeAnnualPerformanceView(IEmployeeAnnualAssessingPerformance employeeAnnualAssessingPerformance, IAnnualAssesingPerformance annualPerformanceAssessmentInfo, IEmployee revieweeInfo, IEmployee reviewerInfo, IList<IAppraisalRating> ratingCollection, ICompanyDetail companyInfo);

        /// <summary>
        /// Creates the employee annual performance view.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <param name="annualPerformanceAssessmentInfo">The annual performance assessment information.</param>
        /// <param name="revieweeInfo">The reviewee information.</param>
        /// <param name="reviewerInfo">The reviewer information.</param>
        /// <param name="ratingCollection">The rating collection.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        IEmployeeAnnualAssessingPerformanceView CreateEmployeeAnnualPerformanceView(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance, IAnnualAssesingPerformance annualPerformanceAssessmentInfo, IEmployee revieweeInfo, IEmployee reviewerInfo, IList<IAppraisalRating> ratingCollection, ICompanyDetail companyInfo);

        #endregion
        
        #region //---------------------------------------Feedback Section------------------------------------------------------//

        /// <summary>
        /// Gets the employee feedback ListView.
        /// </summary>
        /// <param name="employDetails">The employ details.</param>
        /// <param name="feedbackCollection">The feedback collection.</param>
        /// <param name="EmployeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeFeedbackView GetEmployeeFeedbackListView(
            IList<IEmployee> employDetails, IList<IEmployeeFeedbackModel> feedbackCollection, int EmployeeId, string message);

        /// <summary>
        /// Creates the feed back view.
        /// </summary>
        /// <param name="feedbackModel">The feedback model.</param>
        /// <param name="company">The company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IFeedbackListview CreateFeedBackView(IList<IFeedbackModel> feedbackModel, IList<ICompanyDetail> company, string processingMessage);

        /// <summary>
        /// Creates the feedback view.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IFeedbackViewModel CreateFeedbackView(IList<IYear> year, ICompanyDetail companyCollection, string processingMessage);

        /// <summary>
        /// Creates the feedback view.
        /// </summary>
        /// <param name="feed">The feed.</param>
        /// <param name="year">The year.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IFeedbackViewModel CreateFeedbackView(IFeedbackModel feed, IList<IYear> year, ICompanyDetail companyInfo, string processingMessage);

        /// <summary>
        /// Creates the employee feedback view by identifier.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <param name="employeeList">The employee list.</param>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        IEmployeeFeedbackViewModel CreateEmployeeFeedbackViewByID(int feedbackId, IList<IEmployee> employeeList,IEmployee employee);

        /// <summary>
        /// Creates the employee feedback view.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <param name="employeeList">The employee list.</param>
        /// <returns></returns>
        IEmployeeFeedbackViewModel CreateEmployeeFeedbackView(IEmployee employee, int feedbackId, IList<IEmployee> employeeList);

        /// <summary>
        /// Creates the employee feedback view by identifier.
        /// </summary>
        /// <param name="employeeFeedback">The employee feedback.</param>
        /// <param name="employeeList">The employee list.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeFeedbackViewModel CreateEmployeeFeedbackViewByID(IEmployeeFeedbackViewModel employeeFeedback, IList<IEmployee> employeeList, string message);

        /// <summary>
        /// Creates the view employee feedback.
        /// </summary>
        /// <param name="employeeFeedback">The employee feedback.</param>
        /// <param name="employeeList">The employee list.</param>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        IEmployeeFeedbackViewModel CreateViewEmployeeFeedback(IEmployeeFeedbackModel employeeFeedback, IList<IEmployee> employeeList, IEmployee employee);

        #endregion


        #region //==========================================Milestone Section==========================================================//

        /// <summary>
        /// Creates the task mile stone list.
        /// </summary>
        /// <param name="milestoneCollection">The milestone collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IMilestoneListView CreateTaskMileStoneList(IList<IMilestone> milestoneCollection, string processingMessage);

        #endregion
    }
}

