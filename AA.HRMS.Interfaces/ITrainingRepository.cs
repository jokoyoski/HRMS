using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingRepository
    {
        /// <summary>
        /// Gets the training by identifier.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        ITraining GetTrainingById(int trainingId);
        /// <summary>
        /// Gets the name of the training by.
        /// </summary>
        /// <param name="trainingName">Name of the training.</param>
        /// <returns></returns>
        ITraining GetTrainingByName(string trainingName);
        /// <summary>
        /// Gets the pending training by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeTrainingModel> GetPendingTrainingByCompanyId(int companyId);
        /// <summary>
        /// Saves the training information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        string SaveTrainingInfo(ITrainingView trainingInfo, out int trainingId);
        /// <summary>
        /// Saves the edit training information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        string SaveEditTrainingInfo(ITrainingView trainingInfo);
        /// <summary>
        /// Saves the delete training information.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        string SaveDeleteTrainingInfo(int trainingId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ITraining> GetAllMyTrainings(int companyId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainingReportId"></param>
        /// <returns></returns>
        ITrainingReport GetTrainingReportById(int trainingReportId);
        /// <summary>
        /// Gets the training calendar by identifier.
        /// </summary>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        ITrainingCalendar GetTrainingCalendarById(int trainingCalendarId);
        /// <summary>
        /// Gets all training calendar by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ITrainingCalendar> GetAllTrainingCalendarByCompanyId(int companyId);
        /// <summary>
        /// Gets the training calendar by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ITrainingCalendar> GetTrainingCalendarByCompanyId(int companyId);
        /// <summary>
        /// Gets the training calendar by company idand training identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        ITrainingCalendar GetTrainingCalendarByCompanyIdandTrainingId(int companyId, int trainingId);
        /// <summary>
        /// Saves the training calendar information.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <returns></returns>
        string SaveTrainingCalendarInfo(ITraininingCalendarView traininingCalendarView);
        /// <summary>
        /// Saves the edit training calendar information.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <returns></returns>
        string SaveEditTrainingCalendarInfo(ITraininingCalendarView traininingCalendarView);
        /// <summary>
        /// Saves the delete training calendar information.
        /// </summary>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        string SaveDeleteTrainingCalendarInfo(int trainingCalendarId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainingNeedAnalysisId"></param>
        /// <returns></returns>
        ITrainingNeedAnalysis GetTrainingNeedAnalysisById(int trainingNeedAnalysisId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ITrainingNeedAnalysis> GetAllMyTrainingNeedAnalysis(int companyId);
        /// <summary>
        /// Saves the training need analysis.
        /// </summary>
        /// <param name="trainingAnalysisViewModel">The training analysis view model.</param>
        /// <returns></returns>
        string SaveTrainingNeedAnalysis(ITrainingNeedAnalysisView trainingAnalysisViewModel);
        /// <summary>
        /// Saves the edt training need analysis.
        /// </summary>
        /// <param name="trainingAnalysisViewModel">The training analysis view model.</param>
        /// <returns></returns>
        string SaveEdtTrainingNeedAnalysis(ITrainingNeedAnalysisView trainingAnalysisViewModel);
        /// <summary>
        /// Gets the training analysis by company idand training idand job identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trainingId">The training identifier.</param>
        /// <param name="jobId">The job identifier.</param>
        /// <returns></returns>
        ITrainingNeedAnalysis GetTrainingAnalysisByCompanyIdandTrainingIdandJobId(int companyId, int trainingId, int jobId);
        /// <summary>
        /// Gets the training analysis by identifier.
        /// </summary>
        /// <param name="trainingAnalysisId">The training analysis identifier.</param>
        /// <returns></returns>
        ITrainingNeedAnalysis GetTrainingAnalysisById(int trainingAnalysisId);

        string SaveDeleteTrainingAnalysisInfo(int trainingAnalysisId);
        /// <summary>
        /// Gets the training report.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ITrainingReport> GetTrainingReport(int companyId);
        /// <summary>
        /// Saves the training report information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        string SaveTrainingReportInfo(ITrainingReportViewModel trainingInfo);
        /// <summary>
        /// Trainings the calendar model.
        /// </summary>
        /// <param name="companyID">The company identifier.</param>
        /// <returns></returns>
        IList<ITrainingCalendar> TrainingCalendarModel(int companyID);
        /// <summary>
        /// Gets the name of the training by.
        /// </summary>
        /// <param name="trainingName">Name of the training.</param>
        /// <returns></returns>
        IList<ITrainingReport> GetAllMyTrainingReport(int companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        IList<IEmployeeTrainingModel> GetAllMyTrainingsByEmployeeId(int employeeId);

       
        /// <summary>
        /// TrainingHistoryList by UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
       //IList<ITrainingHistoryModel> GetTrainingHistoryById(int UserId);

        string SaveTrainingHistoryInfo(ITrainingHistoryViewModel Certinfo);

        string ProcessTrainingHistoryEdit(ITrainingHistoryViewModel trainingHistoryViewModel);

        string DeleteTrainingHistory(int trainingId);

        ITrainingHistoryModel GetTrainingTariningHistoryById(int UserId);

        IList<ITrainingHistoryModel> GetTrainingHistoryByHistoryId(int UserId);
     
        /// <summary>
        /// Gets the employee trainings by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmployeeTrainingModel GetEmployeeTrainingsByEmployeeId(int employeeId);

        /// <summary>
        /// Gets the training request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeTrainingModel> GetTrainingRequestByCompanyId(int companyId);
    }
}
