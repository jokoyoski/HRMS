using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingService
    {

        #region //-------------------------------------------------------------Training Section----------------------------------------------------//

        /// <summary>
        /// Gets the training registration view.
        /// </summary>
        /// <returns></returns>
        ITrainingView GetTrainingRegistrationView();

        /// <summary>
        /// Processes the training information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        string ProcessTrainingInfo(ITrainingView trainingInfo);

        /// <summary>
        /// Gets the training edit view.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        ITrainingView GetTrainingEditView(int trainingId);

        /// <summary>
        /// Processes the edit training information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        string ProcessEditTrainingInfo(ITrainingView trainingInfo);

        /// <summary>
        /// Processes the delete training information.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        string ProcessDeleteTrainingInfo(int trainingId);

        /// <summary>
        /// Creates the training updated view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITrainingView CreateTrainingUpdatedView(ITrainingView trainingInfo, string processingMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="selectedTraining"></param>
        /// <param name="selectedCompany"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        ITrainingListView CreateTrainingList(int? selectedCompanyId, string selectedTraining, string processingMessage);

        #endregion

        #region //----------------------------------------------------------------------------Training Calendar Section-------------------------------------------------//

        /// <summary>
        /// Gets the training calender ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedTrainingName">Name of the selected training.</param>
        /// <param name="location">The location.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITrainingCalendarListView GetTrainingCalenderListView(int? selectedCompanyId, string selectedTrainingName, string location, string message);

        /// <summary>
        /// Gets the training calendar view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        ITraininingCalendarView GetTrainingCalendarView();

        /// <summary>
        /// Gets the training calendar view.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITraininingCalendarView GetTrainingCalendarView(ITraininingCalendarView traininingCalendarView, string message);

        /// <summary>
        /// Processes the training calendar information.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <returns></returns>
        string ProcessTrainingCalendarInfo(ITraininingCalendarView traininingCalendarView);

        /// <summary>
        /// Gets the edit training calendar edit view.
        /// </summary>
        /// <param name="trainingCalendarInfo">The training calendar information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        ITraininingCalendarView GetEditTrainingCalendarEditView(int trainingCalendarInfo);

        /// <summary>
        /// Processes the edit calendar information.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <returns></returns>
        string ProcessEditCalendarInfo(ITraininingCalendarView traininingCalendarView);

        /// <summary>
        /// Processes the delete training calendar information.
        /// </summary>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        string ProcessDeleteTrainingCalendarInfo(int trainingCalendarId);

        #endregion
        
        #region //--------------------------------------------------------------------Training Analysis Section-------------------------------------------------------//

        /// <summary>
        /// Gets the trainingNeedAnalysis registration view.
        /// </summary>
        /// <returns></returns>
        ITrainingNeedAnalysisView GetTrainingAnalysisView();

        /// <summary>
        /// Gets the training analysis view.
        /// </summary>
        /// <param name="trainingNeedAnalysis">The training need analysis.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITrainingNeedAnalysisView GetTrainingAnalysisView(ITrainingNeedAnalysisView trainingNeedAnalysis, string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainingNeedAnalysisInfo"></param>
        /// <returns></returns>
        string ProcessTrainingNeedAnalysisInfo(ITrainingNeedAnalysisView trainingNeedAnalysisInfo);

        /// <summary>
        /// Processes the edit training need analysis information.
        /// </summary>
        /// <param name="trainingNeedAnalysisInfo">The training need analysis information.</param>
        /// <returns></returns>
        string ProcessEditTrainingNeedAnalysisInfo(ITrainingNeedAnalysisView trainingNeedAnalysisInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="selectedTrainingNeedAnalysisId"></param>
        /// <param name="selectedCompany"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        ITrainingNeedAnalysisListView GetTrainingNeedAnalysisList(int? selectedCompany, string processingMessage);

        /// <summary>
        /// Gets the edit training analysis view.
        /// </summary>
        /// <param name="trainingNeedAnalysisId">The training need analysis identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITrainingNeedAnalysisView GetEditTrainingAnalysisView(int trainingNeedAnalysisId, string message);

        /// <summary>
        /// Processes the delete training analysis information.
        /// </summary>
        /// <param name="trainingAnalysisId">The training analysis identifier.</param>
        /// <returns></returns>
        string ProcessDeleteTrainingAnalysisInfo(int trainingAnalysisId);

        #endregion

        #region //-------------------------------------------------------------------Training Analysis Section End-----------------------------------------------------//


        /// <summary>
        /// Gets the training report view.
        /// </summary>
        /// <returns></returns>
        ITrainingReportViewModel GetTrainingReportView(int trainingId, string processingMessage);

        /// <summary>
        /// Gets the training report view.
        /// </summary>
        /// <param name="trainingReportId">The training report identifier.</param>
        /// <returns></returns>
        ITrainingReportViewModel GetTrainingReportView(int trainingReportId);

        ITrainingReportViewModel CreateTrainingReportUpdatedView(ITrainingReportViewModel trainingInfo, string processingMessage);

        string ProcessTrainingReportInfo(ITrainingReportViewModel trainingInfo);

        ITrainingReportListView CreateTrainingReportList(int? selectedCompany, int? selectedTrainingReportId,  string processingMessage);

        ITrainingHistoryViewModel getTrainingHistoryById(int userId);
        /// <summary>
        /// s
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        ITrainingHistoryListView CreateTrainigHistoryView(string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="historyViewModel"></param>
        /// <returns></returns>
        string processTrainingHistory(ITrainingHistoryViewModel historyViewModel);


        ITrainingHistoryViewModel getTrainingHistoryEditView(int TrainingHistoryId, int userId, string Message);

        string ProcessTrainingHistoryEdit(ITrainingHistoryViewModel HistoryModel);

        string ProcessDeleteOnTrainingHistory(int TrainingHistoryId);

        #endregion


    }
}

