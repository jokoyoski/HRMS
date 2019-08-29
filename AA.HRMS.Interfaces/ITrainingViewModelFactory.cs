using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingViewModelFactory
    {
        #region //----------------------------------------------Training Section-------------------------------------------------//

        /// <summary>
        /// Creates the training view.
        /// </summary>
        /// <returns></returns>
        ITrainingView CreateTrainingView(int companyId);

        /// <summary>
        /// Creates the updated training view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITrainingView CreateUpdatedTrainingView(ITrainingView trainingInfo, string processingMessage);

        /// <summary>
        /// Creates the training update view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        ITrainingView CreateTrainingUpdateView(ITraining trainingInfo);

        /// <summary>
        /// Creates the edit training view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        ITrainingView CreateEditTrainingView(ITraining trainingInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="selectedTrainingID"></param>
        /// <param name="TrainingCollection"></param>
        /// <param name="company"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        ITrainingListView CreateTrainingListView(int? selectedCompanyId, string selectedTraining, IList<ITraining> TrainingCollection, ICompanyDetail company, string processingMessage);
        /// <summary>
        /// Creates the training calendar ListView.
        /// </summary>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITrainingCalendarListView CreateTrainingCalendarListView(int? selectedCompanyId, string selectedTrainingName, string selecctedLocation, IList<ITrainingCalendar> trainingCollection, IList<ICompanyDetail> companyCollection, string message);
        /// <summary>
        /// Creates the training calendar view.
        /// </summary>
        /// <param name="companyCollecction">The company collecction.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingStatusCollection">The training status collection.</param>
        /// <returns></returns>
        ITraininingCalendarView CreateTrainingCalendarView(int companyId, IList<ITraining> trainingCollection, IList<ITrainingStatus> trainingStatusCollection);
        /// <summary>
        /// Creates the training calendar view.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <param name="companyCollecction">The company collecction.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingStatusCollection">The training status collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITraininingCalendarView CreateTrainingCalendarView(ITraininingCalendarView traininingCalendarView, IList<ICompanyDetail> companyCollecction, IList<ITraining> trainingCollection, IList<ITrainingStatus> trainingStatusCollection, string message);
        /// <summary>
        /// Creates the edit training calendar view.
        /// </summary>
        /// <param name="trainingCalendar">The training calendar.</param>
        /// <param name="companyCollecction">The company collecction.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingStatusCollection">The training status collection.</param>
        /// <returns></returns>
        ITraininingCalendarView CreateEditTrainingCalendarView(ITrainingCalendar trainingCalendar, IList<ICompanyDetail> companyCollecction, IList<ITraining> trainingCollection, IList<ITrainingStatus> trainingStatusCollection);

        #endregion

        //---------------------------------------------------------------------------------Training Anaylsis Section---------------------------------------------------------------------------------------------------------------//        
        /// <summary>
        /// Creates the training need analysis view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="training">The training.</param>
        /// <param name="jobCollection">The job collection.</param>
        /// <param name="frequencyOfDeliveryCollection">The frequency of delivery collection.</param>
        /// <param name="currencyCollection">The currency collection.</param>
        /// <returns></returns>
        ITrainingNeedAnalysisView CreateTrainingNeedAnalysisView(int companyId, IList<ITraining> training, IList<IJobTitle> jobCollection, IList<IFrequencyOfDeliveryModel> frequencyOfDeliveryCollection, IList<ICurrency> currencyCollection, IList<IMethodOfDelivery> methodOfDeliveryCollection);

        /// <summary>
        /// Creates the training need analysis view.
        /// </summary>
        /// <param name="trainingNeedAnalysis">The training need analysis.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="training">The training.</param>
        /// <param name="jobCollection">The job collection.</param>
        /// <param name="frequencyOfDeliveryCollection">The frequency of delivery collection.</param>
        /// <param name="currencyCollection">The currency collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITrainingNeedAnalysisView CreateTrainingNeedAnalysisView(ITrainingNeedAnalysisView trainingNeedAnalysis, IList<ITraining> training, IList<IJobTitle> jobCollection, IList<IFrequencyOfDeliveryModel> frequencyOfDeliveryCollection, IList<ICurrency> currencyCollection, IList<IMethodOfDelivery> methodOfDeliveryCollection, string message);
        /// <summary>
        /// Creates the training need analysis ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="trainingNeedAnalysisCollection">The training need analysis collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITrainingNeedAnalysisListView CreateTrainingNeedAnalysisListView(int? selectedCompanyId, IList<ICompanyDetail> companyCollection, IList<ITrainingNeedAnalysis> trainingNeedAnalysisCollection, string message);
        /// <summary>
        /// Creates the edit training analysis view.
        /// </summary>
        /// <param name="trainingNeedAnalysis">The training need analysis.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="training">The training.</param>
        /// <param name="jobCollection">The job collection.</param>
        /// <param name="frequencyOfDeliveryCollection">The frequency of delivery collection.</param>
        /// <param name="currencyCollection">The currency collection.</param>
        /// <returns></returns>
        ITrainingNeedAnalysisView CreateEditTrainingAnalysisView(ITrainingNeedAnalysis trainingNeedAnalysis, IList<ITraining> training, IList<IJobTitle> jobCollection, IList<IFrequencyOfDeliveryModel> frequencyOfDeliveryCollection, IList<ICurrency> currencyCollection, IList<IMethodOfDelivery> methodOfDeliveryCollection, string message);
        //-----------------------------------------------------------------------------------Training Analysis Section Ends--------------------------------------------------------------------------------------------------------//        
        /// <summary>
        /// Creates the training report ListView.
        /// </summary>
        /// <param name="CompanyId">The company identifier.</param>
        /// <param name="selectedTrainingReportID">The selected training report identifier.</param>
        /// <param name="TrainingReportCollection">The training report collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITrainingReportListView CreateTrainingReportListView(int? selectedCompanyId, int? selectedTrainingReportID, IList<ITrainingReport>TrainingReportCollection, IList<ICompanyDetail> companyCollection, string processingMessage);
        
        /// <summary>
        /// Creates the training report.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingRatingCollection">The training rating collection.</param>
        /// <param name="trainingCalendarCollection">The training calendar collection.</param>
        /// <returns></returns>
        ITrainingReportViewModel CreateTrainingReport(ICompanyDetail companyInfo, IList<IEmployee> employeeCollection, int employeeId, ITraining traininginfo, IList<ITrainingEvaluationRating> trainingRatingCollection, IList<ITrainingCalendar> trainingCalendarCollection);
        
        /// <summary>
        /// Creates the training report.
        /// </summary>
        /// <param name="trainingReportViewModel">The training report view model.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingRatingCollection">The training rating collection.</param>
        /// <param name="trainingCalendarCollection">The training calendar collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITrainingReportViewModel CreateTrainingReport(ITrainingReportViewModel trainingReportViewModel, IList<ICompanyDetail> companyCollection, IList<IEmployee> employeeCollection, ITraining trainingInfo, IList<ITrainingEvaluationRating> trainingRatingCollection, IList<ITrainingCalendar> trainingCalendarCollection, string processingMessage);
        /// <summary>
        /// Creates the updated training report view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        ITrainingReportViewModel CreateUpdatedTrainingReportView(ITrainingReportViewModel trainingInfo, IList<ITrainingEvaluationRating> trainingEvaluationRatings, IList<ITrainingCalendar> trainingCalendars, string processingMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificateCollection"></param>
        /// <param name="trainingCollection"></param>
        /// <param name="trainingReport"></param>
        /// <returns></returns>
        ITrainingHistoryViewModel CreateTrainingHistoryView(IList<ICertificationModel> certificateCollection, IList<ITraining> trainingCollection, IList<ITrainingReport> trainingReport, int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessingMessage"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ITrainingHistoryListView CreateTrainingHistoryViewModel(IList<ITrainingHistoryModel> trainingHistoryCollection, IList<ICompanyDetail> companyCollection, int userId, string processingMessage);

        /// <summary>
        /// Creates the edit training report.
        /// </summary>
        /// <param name="trainingReportViewModel">The training report view model.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITrainingReportViewModel CreateEditTrainingReport(ITrainingReport trainingReport, ITraining trainingInfo, string message);


        ITrainingHistoryViewModel CreateEditViewById(IList<ITraining> training,
                                                            IList<ITrainingReport> trainingReport
                                                            , IList<ICertificationModel> certificationModel
                                                            , ITrainingHistoryModel trainingHistoryModel
                                                            , string processingMessage);
        
    }
}
