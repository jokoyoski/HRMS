using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Services;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ITrainingViewModelFactory" />
    public class TrainingViewModelFactory : ITrainingViewModelFactory
    {
        /// <summary>
        /// Creates the training view.
        /// </summary>
        /// <returns></returns>
        public ITrainingView CreateTrainingView(int companyId)
        {
            //throw an exception if the companyCollection is null
            if (companyId <= null) throw new ArgumentNullException(nameof(companyId));
            

            var viewModel = new TrainingView
            {
                //Assigning the drop down to the View model
                CompanyID = companyId
            };

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="selectedCompanyId"></param>
        /// <param name="selectedTraining"></param>
        /// <param name="TrainingCollection"></param>
        /// <param name="companyCollection"></param>
        /// <param name="company"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public ITrainingListView CreateTrainingListView(int? selectedCompanyId, string selectedTraining, IList<ITraining> TrainingCollection, 
            ICompanyDetail company, string processingMessage)
        {
            

            //Filter by companyId 
            var filteredList = TrainingCollection.Where(x => x.CompanyID.Equals(selectedCompanyId < 1 ? x.CompanyID : selectedCompanyId)).ToList();

            //Filter training name 
            filteredList = filteredList.Where(x => x.TrainingName.Contains(string.IsNullOrEmpty(selectedTraining)
                ? x.TrainingName
                : selectedTraining))
                .ToList();

            //Create a return view model of type TrainingListView
            var viewModel = new TrainingListView
            {
                TrainingCollection = filteredList,
                Company = company,
                ProcessingMessage = processingMessage
            };

            return viewModel;

        }
        /// <summary>
        /// Creates the updated training view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public ITrainingView CreateUpdatedTrainingView(ITrainingView trainingInfo, string processingMessage)
        {

            //Throw exception for null companyCollection
            if (trainingInfo == null) throw new ArgumentNullException(nameof(trainingInfo));
            
            //Assigning processingMessage if any back to the view
            trainingInfo.ProcessingMessage = processingMessage;

            return trainingInfo;
        }

        /// <summary>
        /// Creates the training update view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public ITrainingView CreateTrainingUpdateView(ITraining trainingInfo)
        {
            if (trainingInfo == null) throw new ArgumentNullException(nameof(trainingInfo));

            var trainingView = new TrainingView
            {
                TrainingID = trainingInfo.TrainingID,
                TrainingName = trainingInfo.TrainingName,
                CompanyID = trainingInfo.CompanyID,
                IsActive = trainingInfo.IsActive,
                DateCreated = trainingInfo.DateCreated,
                TrainingDescription = trainingInfo.TrainingDescription

            };

            return trainingView;
        }

        /// <summary>
        /// Creates the edit training view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public ITrainingView CreateEditTrainingView(ITraining trainingInfo)
        {
            if (trainingInfo == null) throw new ArgumentNullException(nameof(trainingInfo));

            var returnTraining = new TrainingView
            {
                TrainingID = trainingInfo.TrainingID,
                TrainingName = trainingInfo.TrainingName,
                CompanyID = trainingInfo.CompanyID,
                IsActive = trainingInfo.IsActive,
                DateCreated = trainingInfo.DateCreated,
                TrainingDescription = trainingInfo.TrainingDescription,

            };

            return returnTraining;
        }

        /// <summary>
        /// Creates the training report.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingRatingCollection">The training rating collection.</param>
        /// <param name="trainingCalendarCollection">The training calendar collection.</param>
        /// <returns></returns>
        public ITrainingReportViewModel CreateTrainingReport(ICompanyDetail companyInfo, IList<IEmployee> employeeCollection, int employeeId, ITraining trainingInfo, IList<ITrainingEvaluationRating> trainingRatingCollection, IList<ITrainingCalendar> trainingCalendarCollection )
        {

            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var evaluationDDL = GetDropDownList.TrainingEvaluationListItems(trainingRatingCollection, -1);
            var trainingcalendarDDL = GetDropDownList.TrainingCalendarListItems(trainingCalendarCollection, -1);
            



            var viewModel = new TrainingReportViewModel
            {
                EmployeeDropDownlist = employeeDDL,
                EmployeeID = employeeId,
                Training = trainingInfo,
                
                TrainingCalendarDropDownlist = trainingcalendarDDL,
                TrainingEvaluationRatingDropDownlist = evaluationDDL,
               CompanyID = companyInfo.CompanyId,
               
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the training report.
        /// </summary>
        /// <param name="trainingReportViewModel">The training report view model.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingRatingCollection">The training rating collection.</param>
        /// <param name="trainingCalendarCollection">The training calendar collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITrainingReportViewModel CreateTrainingReport(ITrainingReportViewModel trainingReportViewModel, IList<ICompanyDetail> companyCollection, IList<IEmployee> employeeCollection, ITraining trainingInfo, IList<ITrainingEvaluationRating> trainingRatingCollection, IList<ITrainingCalendar> trainingCalendarCollection, string message)
        {
            //if (trainingId == null) throw new ArgumentNullException(nameof(trainingId));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var evaluationDDL = GetDropDownList.TrainingEvaluationListItems(trainingRatingCollection, -1);
            var trainingcalendarDDL = GetDropDownList.TrainingCalendarListItems(trainingCalendarCollection, -1);


            trainingReportViewModel.CompanyDropDownlist = companyDDL;
            trainingReportViewModel.EmployeeDropDownlist = employeeDDL;
            trainingReportViewModel.Training = trainingInfo;
            trainingReportViewModel.TrainingEvaluationRatingDropDownlist = evaluationDDL; 
            trainingReportViewModel.TrainingCalendarDropDownlist = trainingcalendarDDL;

            trainingReportViewModel.ProcessingMessage = message;

            return trainingReportViewModel;
        }
        /// <summary>
        /// Creates the edit training report.
        /// </summary>
        /// <param name="trainingReportViewModel">The training report view model.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingReportViewModel</exception>
        public ITrainingReportViewModel CreateEditTrainingReport(ITrainingReport trainingReportViewModel, ITraining training, string message)
        {
            if (trainingReportViewModel == null) throw new ArgumentNullException(nameof(trainingReportViewModel));

            var result = new TrainingReportViewModel
            {
                TrainingReportID = trainingReportViewModel.TrainingReportId,
                Training = training,
                EmployeeID = trainingReportViewModel.EmployeeId,
                EmployeeName = trainingReportViewModel.EmployeeName,
                CompanyID = trainingReportViewModel.CompanyId,
                CompanyName = trainingReportViewModel.CompanyName,
                TrainingCalendarID = trainingReportViewModel.TrainingCalendarId,
                TrainingStarts = trainingReportViewModel.TrainingStarts,
                TrainingEnds = trainingReportViewModel.TrainingEnds,
                TrainerName = trainingReportViewModel.TrainerName,
                TrainerEvaluationRating = trainingReportViewModel.TrainerEvaluationRating,
                TrainerEvaluationRatingName = trainingReportViewModel.TrainingEvaluationRatingName,
                TrainerEvaluationComment = trainingReportViewModel.TrainerEvaluationComment,
                TrainingEvaluationRating = trainingReportViewModel.TrainingEvaluationRating,
                TrainingEvaluationRatingName = trainingReportViewModel.TrainingEvaluationRatingName,
                TrainingEvaluationComment = trainingReportViewModel.TrainingEvaluationComment,
                DateCreated = trainingReportViewModel.DateCreated,
                ProcessingMessage = message
            };

            return result;
        }

        /// <summary>
        /// Creates the updated training report view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public ITrainingReportViewModel CreateUpdatedTrainingReportView(ITrainingReportViewModel trainingReportInfo, IList<ITrainingEvaluationRating>  trainingEvaluationRatings, IList<ITrainingCalendar> trainingCalendars, string message)
        {
            if (trainingReportInfo == null) throw new ArgumentNullException(nameof(trainingReportInfo));

            if (trainingEvaluationRatings == null) throw new ArgumentNullException(nameof(trainingEvaluationRatings));

            if (trainingCalendars == null) throw new ArgumentNullException(nameof(trainingCalendars));

            var traingCalendarDDL = GetDropDownList.TrainingCalendarListItems(trainingCalendars, trainingReportInfo.TrainingCalendarID);
            
            var traingRatingDDL = GetDropDownList.TrainingEvaluationListItems(trainingEvaluationRatings, trainingReportInfo.TrainerEvaluationRating);

            trainingReportInfo.TrainingEvaluationRatingDropDownlist = traingRatingDDL;

            trainingReportInfo.TrainingCalendarDropDownlist = traingCalendarDDL;

            trainingReportInfo.ProcessingMessage = message;

            return trainingReportInfo;
        }

        /// <summary>
        /// Creates the training calendar ListView.
        /// </summary>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// trainingCollection
        /// or
        /// companyCollection
        /// </exception>
        public ITrainingCalendarListView CreateTrainingCalendarListView(int? selectedCompanyId, string selectedTrainingName, string selectedLocation, IList<ITrainingCalendar> trainingCollection, IList<ICompanyDetail> companyCollection, string message)
        {
            if (trainingCollection == null) throw new ArgumentNullException(nameof(trainingCollection));

            if (companyCollection == null) throw new ArgumentNullException(nameof(companyCollection));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            var filteredList = trainingCollection
                .Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();

            filteredList = filteredList.Where(x =>
                x.TrainingName.Contains(string.IsNullOrEmpty(selectedTrainingName)
                    ? x.TrainingName
                    : selectedTrainingName)).ToList();

            filteredList = filteredList.Where(x =>
                x.Location.Contains(string.IsNullOrEmpty(selectedLocation)
                    ? x.Location
                    : selectedLocation)).ToList();



            var result = new TrainingCalendarListView
            {
                TrainingCalendarCollection = filteredList.ToList(),
                CompanyDropDown = companyDDL,
                SelectedCompanyId = selectedCompanyId,
                SelectedLocation = selectedLocation,
                SelectedTrainingName = selectedTrainingName,
                ProcessingMessage = message,
            };

            return result;
        }

        /// <summary>
        /// Creates the training calendar view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingStatusCollection">The training status collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// trainingCollection
        /// or
        /// trainingStatusCollection
        /// </exception>
        public ITraininingCalendarView CreateTrainingCalendarView(int companyId, IList<ITraining> trainingCollection, IList<ITrainingStatus> trainingStatusCollection)
        {
            if (trainingCollection == null) throw new ArgumentNullException(nameof(trainingCollection));
            if (trainingStatusCollection == null) throw new ArgumentNullException(nameof(trainingStatusCollection));
            
            var trainingDDL = GetDropDownList.TrainingListItems(trainingCollection, -1);
            var trainingStatusDDL = GetDropDownList.TrainingStatusListItems(trainingStatusCollection, -1);

            var result = new TrainingCalendarView
            {
                TrainingStatusDropDown = trainingStatusDDL,
                TrainingDropDown = trainingDDL,
                CompanyId = companyId, 
                ProcessingMessage = string.Empty,
            };

            return result;
        }

        /// <summary>
        /// Creates the training calendar view.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingStatusCollection">The training status collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// trainingCollection
        /// or
        /// trainingStatusCollection
        /// </exception>
        public ITraininingCalendarView CreateTrainingCalendarView(ITraininingCalendarView traininingCalendarView, IList<ICompanyDetail> companyCollection, IList<ITraining> trainingCollection, IList<ITrainingStatus> trainingStatusCollection, string message)
        {
            if (companyCollection == null) throw new ArgumentNullException(nameof(companyCollection));
            if (trainingCollection == null) throw new ArgumentNullException(nameof(trainingCollection));
            if (trainingStatusCollection == null) throw new ArgumentNullException(nameof(trainingStatusCollection));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, traininingCalendarView.CompanyId);
            var trainingDDL = GetDropDownList.TrainingListItems(trainingCollection, traininingCalendarView.TrainingId);
            var trainingStatusDDL = GetDropDownList.TrainingStatusListItems(trainingStatusCollection, traininingCalendarView.TrainingStatusId);

            traininingCalendarView.CompanyDropDown = companyDDL;
            traininingCalendarView.TrainingDropDown = trainingDDL;
            traininingCalendarView.TrainingStatusDropDown = trainingStatusDDL;
            traininingCalendarView.ProcessingMessage = message;

            return traininingCalendarView;

        }

        /// <summary>
        /// Creates the edit training calendar view.
        /// </summary>
        /// <param name="trainingCalendar">The training calendar.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingStatusCollection">The training status collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// trainingCollection
        /// or
        /// trainingStatusCollection
        /// </exception>
        public ITraininingCalendarView CreateEditTrainingCalendarView(ITrainingCalendar trainingCalendar, IList<ICompanyDetail> companyCollection, IList<ITraining> trainingCollection, IList<ITrainingStatus> trainingStatusCollection)
        {
            if (companyCollection == null) throw new ArgumentNullException(nameof(companyCollection));
            if (trainingCollection == null) throw new ArgumentNullException(nameof(trainingCollection));
            if (trainingStatusCollection == null) throw new ArgumentNullException(nameof(trainingStatusCollection));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, trainingCalendar.CompanyId);
            var trainingDDL = GetDropDownList.TrainingListItems(trainingCollection, trainingCalendar.TrainingId);
            var trainingStatusDDL = GetDropDownList.TrainingStatusListItems(trainingStatusCollection, trainingCalendar.TrainingStatusId);

            var result = new TrainingCalendarView
            {
                CompanyDropDown = companyDDL,
                TrainingDropDown = trainingDDL,
                TrainingStatusDropDown = trainingStatusDDL,
                CompanyId = trainingCalendar.CompanyId,
                TrainingId = trainingCalendar.TrainingId,
                TrainingStatusId = trainingCalendar.TrainingStatusId,
                Location = trainingCalendar.Location,
                DeliveryEndDate = trainingCalendar.DeliveryEndDate,
                DeliveryStartDate = trainingCalendar.DeliveryStartDate,
                TrainingCalenderId = trainingCalendar.TrainingCalenderId, 
            };
            return result;
        }

        //----------------------------------------------Training Calendar Section End----------------------------------------------------------------//

        //-----------------------------------------------Training Analysis Section-----------------------------------------------------------------------//      
        
        /// <summary>
        /// Creates the training need analysis view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="training">The training.</param>
        /// <param name="jobCollection">The job collection.</param>
        /// <param name="frequencyOfDeliveryCollection">The frequency of delivery collection.</param>
        /// <param name="currencyCollection">The currency collection.</param>
        /// <returns></returns>
        public ITrainingNeedAnalysisView CreateTrainingNeedAnalysisView(int companyId, IList<ITraining> training, IList<IJobTitle> jobCollection, IList<IFrequencyOfDeliveryModel> frequencyOfDeliveryCollection, IList<ICurrency> currencyCollection, IList<IMethodOfDelivery> methodOfDeliveryCollection)
        {
            var TrainingDDL = GetDropDownList.TrainingListItems(training, -1);
            var jobDDL = GetDropDownList.JobTitlesListItems(jobCollection, -1);
            var FrequencyOfDeliveryDDL = GetDropDownList.FrequencyOfDeliveryListItems(frequencyOfDeliveryCollection, -1);
            var CurrencyDDL = GetDropDownList.CurrencyListItems(currencyCollection, -1);
            var methodOfDeliveryDDL = GetDropDownList.MethondOfDeliveryListItems(methodOfDeliveryCollection, -1);

            var Model = new TrainingNeedAnalysisView
            {
                TrainingDropDownList = TrainingDDL,
                JobDropDownList = jobDDL,
                FrequencyOfDeliveryDropDownList = FrequencyOfDeliveryDDL,
                CurrencyDropDownList = CurrencyDDL,
                MethodOfDeliveryDropDown = methodOfDeliveryDDL,
                CompanyID = companyId
            };

            return Model;
        }

        /// <summary>
        /// Creates the training need analysis view.
        /// </summary>
        /// <param name="trainingNeedAnalysus">The training need analysus.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="training">The training.</param>
        /// <param name="jobCollection">The job collection.</param>
        /// <param name="frequencyOfDeliveryCollection">The frequency of delivery collection.</param>
        /// <param name="currencyCollection">The currency collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITrainingNeedAnalysisView CreateTrainingNeedAnalysisView(ITrainingNeedAnalysisView trainingNeedAnalysus, IList<ITraining> training, IList<IJobTitle> jobCollection, IList<IFrequencyOfDeliveryModel> frequencyOfDeliveryCollection, IList<ICurrency> currencyCollection, IList<IMethodOfDelivery> methodOfDeliveryCollection, string message)
        {
            var TrainingDDL = GetDropDownList.TrainingListItems(training, trainingNeedAnalysus.TrainingID);
            var jobDDL = GetDropDownList.JobTitlesListItems(jobCollection, trainingNeedAnalysus.JobID);
            var FrequencyOfDeliveryDDL = GetDropDownList.FrequencyOfDeliveryListItems(frequencyOfDeliveryCollection, trainingNeedAnalysus.FrequencyOfDeliveryID);
            var CurrencyDDL = GetDropDownList.CurrencyListItems(currencyCollection, trainingNeedAnalysus.Currency);
            var methodOfDeliveryDDL = GetDropDownList.MethondOfDeliveryListItems(methodOfDeliveryCollection, trainingNeedAnalysus.MethodOfDelivery);
            
            trainingNeedAnalysus.JobDropDownList = jobDDL;
            trainingNeedAnalysus.TrainingDropDownList = TrainingDDL;
            trainingNeedAnalysus.CurrencyDropDownList = CurrencyDDL;
            trainingNeedAnalysus.FrequencyOfDeliveryDropDownList = FrequencyOfDeliveryDDL;
            trainingNeedAnalysus.MethodOfDeliveryDropDown = methodOfDeliveryDDL;

            trainingNeedAnalysus.ProcessingMessage = message;

            return trainingNeedAnalysus;
        }

        /// <summary>
        /// Creates the training need analysis ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="trainingNeedAnalysisCollection">The training need analysis collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">trainingNeedAnalysisCollection</exception>
        public ITrainingNeedAnalysisListView CreateTrainingNeedAnalysisListView(int? selectedCompanyId, IList<ICompanyDetail> companyCollection, IList<ITrainingNeedAnalysis> trainingNeedAnalysisCollection, string message)
        {
            if(trainingNeedAnalysisCollection == null)
            {
                throw new ArgumentNullException(nameof(trainingNeedAnalysisCollection));
            }

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            var filteredList = trainingNeedAnalysisCollection
                .Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();

            var returnModel = new TrainingNeedAnalysisListView
            {
                TrainingNeedAnalysisCollection = filteredList,
                ProcessingMessage = message,
                SelectedCompanyID = selectedCompanyId,
                CompanyDropDownList = companyDDL
            };

            return returnModel;

        }

        /// <summary>
        /// Creates the edit training analysis view.
        /// </summary>
        /// <param name="trainingNeedAnalysis">The training need analysis.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="training">The training.</param>
        /// <param name="jobCollection">The job collection.</param>
        /// <param name="frequencyOfDeliveryCollection">The frequency of delivery collection.</param>
        /// <param name="currencyCollection">The currency collection.</param>
        /// <param name="methodOfDeliveryCollection">The method of delivery collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITrainingNeedAnalysisView CreateEditTrainingAnalysisView(ITrainingNeedAnalysis trainingNeedAnalysis, IList<ITraining> training, 
            IList<IJobTitle> jobCollection, IList<IFrequencyOfDeliveryModel> frequencyOfDeliveryCollection, IList<ICurrency> currencyCollection, IList<IMethodOfDelivery> methodOfDeliveryCollection, string message)
        {
            var TrainingDDL = GetDropDownList.TrainingListItems(training, trainingNeedAnalysis.TrainingId);
            var jobDDL = GetDropDownList.JobTitlesListItems(jobCollection, trainingNeedAnalysis.JobId);
            var FrequencyOfDeliveryDDL = GetDropDownList.FrequencyOfDeliveryListItems(frequencyOfDeliveryCollection, trainingNeedAnalysis.FrequecyOfDeliveryId);
            var CurrencyDDL = GetDropDownList.CurrencyListItems(currencyCollection, trainingNeedAnalysis.CurrencyId);
            var approvedBudgetCurrencyDDL = GetDropDownList.CurrencyListItems(currencyCollection, trainingNeedAnalysis.ApprovedBudgetCurrency);
            var methodOfDeliveryDDL = GetDropDownList.MethondOfDeliveryListItems(methodOfDeliveryCollection, trainingNeedAnalysis.MethodOfDelivery);

            var Model = new TrainingNeedAnalysisView
            {
                TrainingNeedAnalysisID = trainingNeedAnalysis.TrainingNeedAnaylsisId,
                TrainingID = trainingNeedAnalysis.TrainingId,
                TrainingDescription = trainingNeedAnalysis.TrainingDescription,
                JobID = trainingNeedAnalysis.JobId,
                TrainingDuration = trainingNeedAnalysis.TrainingDuration,
                TrainingName = trainingNeedAnalysis.TrainingName,
                TrainingProvider = trainingNeedAnalysis.TrainingProvider,
                MethodOfDelivery = trainingNeedAnalysis.MethodOfDelivery,
                Cost = trainingNeedAnalysis.Cost,
                Location = trainingNeedAnalysis.Location,
                IsProviderApproved = trainingNeedAnalysis.IsProviderApproved,
                ApprovedBudget = trainingNeedAnalysis.ApprovedBudget,
                ApprovedBudgetCurrency = trainingNeedAnalysis.ApprovedBudgetCurrency,
                FrequencyOfDeliveryID = trainingNeedAnalysis.FrequecyOfDeliveryId,
                CompanyID = trainingNeedAnalysis.CompanyId,
                CertificateIssued = trainingNeedAnalysis.CertificateIssued,
                TrainingDropDownList = TrainingDDL,
                JobDropDownList = jobDDL,
                FrequencyOfDeliveryDropDownList = FrequencyOfDeliveryDDL,
                CurrencyDropDownList = CurrencyDDL,
                MethodOfDeliveryDropDown = methodOfDeliveryDDL,
                Currency = trainingNeedAnalysis.CurrencyId,
                ProcessingMessage = message,
                ApprovedBudgetCurrencyDropDownList = approvedBudgetCurrencyDDL
            };

            return Model;
        }

        /// <summary>
        /// Creates the training report ListView.
        /// </summary>
        /// <param name="selectedCompanyId"></param>
        /// <param name="selectedTrainingReportID">The selected training report identifier.</param>
        /// <param name="TrainingReportCollection">The training report collection.</param>
        /// <param name="companyCollection"></param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TrainingReportCollection</exception>
        public ITrainingReportListView CreateTrainingReportListView(int? selectedCompanyId, int? selectedTrainingReportID, IList<ITrainingReport> TrainingReportCollection, IList<ICompanyDetail> companyCollection, string processingMessage)
        {
            if(TrainingReportCollection == null)
            {
                throw new ArgumentNullException(nameof(TrainingReportCollection));
            }

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            var filteredList = TrainingReportCollection
                .Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();


            var result = new TrainingReportListView
            {
                TrainingReportCollection = filteredList,
                CompanyDropDown = companyDDL,
                SelectedCompanyID = selectedCompanyId,
                ProcessingMessage = processingMessage
            };

            return result;
        }

        //----------------------------------------------Training Analysis Section End-------------------------------------------------------------------//

        //----------------------------------------------Training History Section Begins-----------------------------------------------------------------//

        public ITrainingHistoryViewModel CreateTrainingHistoryView(IList<ICertificationModel> certificateCollection, IList<ITraining> trainingCollection, IList<ITrainingReport> trainingReport, int userId)
        {
            
            if (certificateCollection == null) throw new ArgumentNullException(nameof(certificateCollection));

            
            var certificateDDL = GetDropDownList.CertificateListItem(certificateCollection, -1);
            var TrainingDDL = GetDropDownList.TrainingListItems(trainingCollection, -1);
            var trainingReportDDL = GetDropDownList.TrainingReportListItem(trainingReport, -1);

            var viewModel = new TrainingHistoryViewModel
            {
                //Assigning the drop down to the View model
                CertificateDropDownList = certificateDDL,
                TrainingDropDownList = TrainingDDL,
                TrainingVendorDropList = trainingReportDDL,
                UserId = userId
            };

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="trainingHistoryCollection"></param>
        /// <param name="companyCollection"></param>
        /// <param name="userId"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public ITrainingHistoryListView CreateTrainingHistoryViewModel (IList<ITrainingHistoryModel> trainingHistoryCollection, IList<ICompanyDetail> companyCollection, int userId, string processingMessage)
        {
            var view = new TrainingHistoryListView
            {
                trainingHistoryModel = trainingHistoryCollection,
                UserId = userId, 
                ProcessingMessage = processingMessage
            };
            return view;
        }

        /// <summary>
        /// Creates the edit view by identifier.
        /// </summary>
        /// <param name="training">The training.</param>
        /// <param name="trainingReport">The training report.</param>
        /// <param name="certificationModel">The certification model.</param>
        /// <param name="trainingHistoryModel">The training history model.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ITrainingHistoryViewModel CreateEditViewById (IList<ITraining> training, 
                                                            IList<ITrainingReport> trainingReport
                                                            , IList<ICertificationModel> certificationModel
                                                            , ITrainingHistoryModel trainingHistoryModel
                                                            , string processingMessage)
        {

            var certificateDDL = GetDropDownList.CertificateListItem(certificationModel, trainingHistoryModel.CertificationId);
            var TrainingDDL = GetDropDownList.TrainingListItems(training, trainingHistoryModel.TrainingNameId);
            var trainingReportDDL = GetDropDownList.TrainingReportListItem(trainingReport, trainingHistoryModel.TrainingVendorId);

            var viewModel = new TrainingHistoryViewModel
            {
                TrainingHistoryId = trainingHistoryModel.TrainingHistoryId,
                CertificateDropDownList = certificateDDL,
                TrainingDropDownList = TrainingDDL,
                TrainingVendorDropList = trainingReportDDL,
                processingmessage = processingMessage,
                TrainingId = trainingHistoryModel.TrainingNameId,
                TrainingVendorId = trainingHistoryModel.TrainingVendorId,
                Year = trainingHistoryModel.Year,
                UserId = trainingHistoryModel.UserId,
                CertificationId = trainingHistoryModel.CertificationId,
                IsActive = trainingHistoryModel.IsActive

            };
            return viewModel;
        }

       


        //public ITrainingHistoryViewModel CreateTrainingHistoryView(ITrainingHistoryModel trainingHistoryModel)
        //{
        //    var model  = new TrainingHistoryModel
        //    {
        //        TrainingHistoryId = trainingHistoryModel.TrainingHistoryId,
        //        TrainingName = trainingHistoryModel.TrainingName,
        //        TrainingVendor = trainingHistoryModel.TrainingVendor,
        //        Certification = trainingHistoryModel.Certification,
        //        UserId= trainingHistoryModel.UserId

        //    };
        //    return model;
        //}
    }
}

