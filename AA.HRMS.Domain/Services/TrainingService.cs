using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Services
{
    public class TrainingService : ITrainingService
    {
        
        private readonly ITrainingViewModelFactory trainingViewModelFactory;
        private readonly ITrainingRepository trainingRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ISessionStateService serviceProvider;
        private readonly ICertificationRepository certificationRepository;
        
        public TrainingService(ITrainingViewModelFactory trainingViewModelFactory, ILookupRepository lookupRepository, ISessionStateService serviceProvider,
            ITrainingRepository trainingRepository, ICompanyRepository companyRepository, IUsersRepository usersRepository, IEmployeeRepository employeeRepository,
            ICertificationRepository certificationRepository)
        {
            this.trainingViewModelFactory = trainingViewModelFactory;
            this.trainingRepository = trainingRepository;
            this.lookupRepository = lookupRepository;
            this.companyRepository = companyRepository;
            this.usersRepository = usersRepository;
            this.employeeRepository = employeeRepository;
            this.serviceProvider = serviceProvider;
            this.certificationRepository = certificationRepository;
        }

        #region //------------------------------------------------Training Section----------------------------------------------------//

        /// <summary>
        /// Creates the training list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedTraining">The selected training.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        /// Call the methods from the repositories, the send the View Model Factory to produce a view the returns back here where it is sentt back to the controller
        public ITrainingListView CreateTrainingList(int? selectedCompanyId, string selectedTraining, string processingMessage)
        {
            //Get the user information by userId, by calling the GetUserById(int userId) from the UsersRepository
            var userInfo = this.usersRepository.GetUserById((int)this.serviceProvider.GetSessionValue(SessionKey.UserId));


            var companyIdSession = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            //Get The Selected Company Information, by calling the GetCompanyById(int companyId) for the companyRepository
            var companyInfo = this.companyRepository.GetCompanyById(companyIdSession);


            //Check if the companyInfo is null and Throw an Exception 
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            //Create a variable of training collection where all the trainings for each company will be be stored 
            var trainingCollection = lookupRepository.GetTrainingByCompanyId(companyIdSession);

            //send the details needed for trainingList to the trainingViewModelFactory to produce a view, by calling the CreateTrainingListView(int selectedCompanyId, 
            //string selectedTraining, IList<ITraining> trainingCollection, ICompanyDetail companyInfo, string processingMessage), from the trainingViewModelFactory
            var trainingList =
                this.trainingViewModelFactory.CreateTrainingListView(selectedCompanyId, selectedTraining, trainingCollection, companyInfo, processingMessage);

            //Return the information back to the controller
            return trainingList;
        }
        
        /// <summary>
        /// Gets the training registration view.
        /// </summary>
        /// <returns></returns>
        public ITrainingView GetTrainingRegistrationView()
        {

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            //Company ID of the Logged In User, HR/CompanyAdmin
            var companyId = (int) this.serviceProvider.GetSessionValue(SessionKey.CompanyId);
            

            var viewModel =
                this.trainingViewModelFactory.CreateTrainingView(companyId);

            return viewModel;
        }
        
        /// <summary>
        /// Creates the training updated view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public ITrainingView CreateTrainingUpdatedView(ITrainingView trainingInfo, string processingMessage)
        {

            var userName = (string)this.serviceProvider.GetSessionValue(SessionKey.UserName);

            var companyCollection = this.companyRepository.GetCompaniesForHR(userName);

            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }

            var returnViewModel =
                trainingViewModelFactory.CreateUpdatedTrainingView(trainingInfo, processingMessage);

            return returnViewModel;
        }
        
        /// <summary>
        /// Processes the training information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public string ProcessTrainingInfo(ITrainingView trainingInfo)
        {
            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }

            var processingMessage = string.Empty;

            var IsDateOaky = true;

            int trainingId = 0;

            var IsExist = (trainingRepository.GetTrainingByName(trainingInfo.TrainingName) == null) ? false : true;

            if(IsExist)
            {
                processingMessage = Messages.TrainingAlreadyExist;

                IsDateOaky = false;

                return processingMessage;
            }

            processingMessage = this.trainingRepository.SaveTrainingInfo(trainingInfo, out trainingId);

            return processingMessage;
        }

        /// <summary>
        /// Gets the training edit view.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public ITrainingView GetTrainingEditView(int trainingId) 
        {
            var trainingInfo = trainingRepository.GetTrainingById(trainingId);

            var userName = (string)this.serviceProvider.GetSessionValue(SessionKey.UserName);
            

            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }
            
            var viewModel = this.trainingViewModelFactory.CreateEditTrainingView(trainingInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit training information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public string ProcessEditTrainingInfo(ITrainingView trainingInfo)
        {
            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }

            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.trainingRepository.SaveEditTrainingInfo(trainingInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delete training information.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteTrainingInfo(int trainingId)
        {

            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.trainingRepository.SaveDeleteTrainingInfo(trainingId);


            return processingMessage;
        }

        #endregion

        #region //------------------------------------------Training Report Section-------------------------------------------//

        /// <summary>
        /// Gets the training report view.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loggedUserDetails
        /// or
        /// companyInfo
        /// </exception>
        public ITrainingReportViewModel GetTrainingReportView(int trainingId, string message)
        {
            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            var employeeId = (int)this.serviceProvider.GetSessionValue(SessionKey.EmployeeId);

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }
            

            var trainingEvaluations = lookupRepository.GetEvaluationratings();

            var companyInfo = this.companyRepository.GetCompanyById((int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId));

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUserDetails.Username);

            var trainingInfo = this.trainingRepository.GetTrainingById(trainingId);

            var employee = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var trainingCalendar = trainingRepository.GetTrainingCalendarByCompanyId(companyInfo.CompanyId);
            
            var viewModel = 
                this.trainingViewModelFactory.CreateTrainingReport(companyInfo, employee, employeeId, trainingInfo, trainingEvaluations, trainingCalendar);

            return viewModel;
        }
        
        /// <summary>
        /// Gets the training report view.
        /// </summary>
        /// <param name="trainingReportId">The training report identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loggedUserDetails
        /// or
        /// companyInfo
        /// </exception>
        public ITrainingReportViewModel GetTrainingReportView(int trainingReportId) 
        {
            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }
            
            var rating = lookupRepository.GetEvaluationratings();
            var trainingReport = this.trainingRepository.GetTrainingReportById(trainingReportId);

            var companyInfo = this.companyRepository.GetCompanyById(loggedUserDetails.CompanyId);

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUserDetails.Username);

            var trainingInfo = trainingRepository.GetTrainingById(trainingReport.TrainingId);

            var employee = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var trainingCalendar = trainingRepository.GetTrainingCalendarByCompanyId(companyInfo.CompanyId);

            return this.trainingViewModelFactory.CreateEditTrainingReport(trainingReport, trainingInfo, string.Empty);

        }
        
        /// <summary>
        /// Creates the training report updated view.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">userId</exception>
        /// <exception cref="ArgumentNullException">
        /// loggedUserDetails
        /// or
        /// companyInfo
        /// </exception>
        public ITrainingReportViewModel CreateTrainingReportUpdatedView(ITrainingReportViewModel trainingReportInfo, string processingMessage)
        {

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            int employeeId = (int)this.serviceProvider.GetSessionValue(SessionKey.EmployeeId);
            
            var trainingRating = lookupRepository.GetEvaluationratings();

            var companyInfo = this.companyRepository.GetCompanyById((int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId));

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }
            

            var trainingInfo = trainingRepository.GetTrainingById(trainingReportInfo.TrainingId);

            var employee = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var trainingCalendar = trainingRepository.GetTrainingCalendarByCompanyId(companyInfo.CompanyId);


            trainingReportInfo.Training = trainingInfo;
            

            var viewModel =
                this.trainingViewModelFactory.CreateUpdatedTrainingReportView(trainingReportInfo, trainingRating, trainingCalendar, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Processes the training report information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public string ProcessTrainingReportInfo(ITrainingReportViewModel trainingInfo)
        {
            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }

            var processingMessage = string.Empty;


            processingMessage = this.trainingRepository.SaveTrainingReportInfo(trainingInfo);

            return processingMessage;
        }

        /// <summary>
        /// Gets the training calender ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedTrainingName">Name of the selected training.</param>
        /// <param name="location">The location.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public ITrainingCalendarListView GetTrainingCalenderListView(int? selectedCompanyId, string selectedTrainingName, string location, string message)
        {

            var userInfo = this.usersRepository.GetUserById((int)this.serviceProvider.GetSessionValue(SessionKey.UserId));

            var companyInSession = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo.Username);

            var trainingCalendar = trainingRepository.GetAllTrainingCalendarByCompanyId(companyInSession);
            
            var returnViewModel = this.trainingViewModelFactory.CreateTrainingCalendarListView(selectedCompanyId, selectedTrainingName, location, trainingCalendar, companyCollection, message);

            return returnViewModel;
        }

        /// <summary>
        /// Gets the training calendar view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public ITraininingCalendarView GetTrainingCalendarView()
        {
            var userInfo = this.usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            var ccompanyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            var trainingCollection = this.trainingRepository.GetAllMyTrainings(companyId);

            var trainingStatus = this.lookupRepository.GetTrainingStatus();
            
            var returnModel = this.trainingViewModelFactory.CreateTrainingCalendarView(companyId, trainingCollection, trainingStatus);

            return returnModel;
        }

        /// <summary>
        /// Gets the training calendar view.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public ITraininingCalendarView GetTrainingCalendarView(ITraininingCalendarView traininingCalendarView, string message)
        {
            if (traininingCalendarView == null) throw new ArgumentNullException(nameof(traininingCalendarView));

            var userInfo = this.usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo.Username);

            var trainingCollection = trainingRepository.GetAllMyTrainings(companyId);

            var trainingStatus = this.lookupRepository.GetTrainingStatus();
            
            var returnModel = this.trainingViewModelFactory.CreateTrainingCalendarView(traininingCalendarView, companyCollection, trainingCollection, trainingStatus, message);

            return returnModel;
        }

        /// <summary>
        /// Processes the training calendar information.
        /// </summary>
        /// <param name="trainingCalendarView">The training calendar view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingCalendarView</exception>
        public string ProcessTrainingCalendarInfo(ITraininingCalendarView trainingCalendarView)
        {

            if (trainingCalendarView == null) throw new ArgumentNullException(nameof(trainingCalendarView));

            var result = string.Empty;

            var IsDataExits = false;

            var trainingCalendar = this.trainingRepository.GetTrainingCalendarByCompanyIdandTrainingId(trainingCalendarView.CompanyId, trainingCalendarView.TrainingId);

            if (trainingCalendar != null)
            {
                IsDataExits = ((trainingCalendarView.DeliveryStartDate != trainingCalendar.DeliveryStartDate) && (trainingCalendar.DeliveryEndDate != trainingCalendarView.DeliveryEndDate) && (trainingCalendar.Location != trainingCalendarView.Location)) ? false : true;

            }
            
            if (IsDataExits)
            {
                result = Messages.TrainingCalendarAlreadyExist;

                return result;
            }

            result = this.trainingRepository.SaveTrainingCalendarInfo(trainingCalendarView);

            return result;
        }
        
        /// <summary>
        /// Gets the edit training calendar edit view.
        /// </summary>
        /// <param name="trainingCalendarInfo">The training calendar information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public ITraininingCalendarView GetEditTrainingCalendarEditView(int trainingCalendarId)
        {

            if (trainingCalendarId <= 0) throw new ArgumentNullException(nameof(trainingCalendarId));

            var userInfo = this.usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo.Username);

            var trainingCalendar = this.trainingRepository.GetTrainingCalendarById(trainingCalendarId);

            var trainingCollection = trainingRepository.GetAllMyTrainings(companyId);

            var trainingStatus = this.lookupRepository.GetTrainingStatus();
            
            
            var returnModel = this.trainingViewModelFactory.CreateEditTrainingCalendarView(trainingCalendar, companyCollection, trainingCollection, trainingStatus);

            return returnModel;
        }

        /// <summary>
        /// Processes the edit calendar information.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">traininingCalendarView</exception>
        public string ProcessEditCalendarInfo(ITraininingCalendarView traininingCalendarView)
        {
            if (traininingCalendarView == null) throw new ArgumentNullException(nameof(traininingCalendarView));

            var result = string.Empty;

            result = this.trainingRepository.SaveEditTrainingCalendarInfo(traininingCalendarView);

            return result;
        }

        /// <summary>
        /// Processes the delete training calendar information.
        /// </summary>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingCalendarId</exception>
        public string ProcessDeleteTrainingCalendarInfo(int trainingCalendarId)
        {
            if (trainingCalendarId <= 0) throw new ArgumentNullException(nameof(trainingCalendarId));

            var result = string.Empty;

            result = this.trainingRepository.SaveDeleteTrainingCalendarInfo(trainingCalendarId);

            return result;
        }

        #endregion
        
        #region //--------------------------------------------------------------------------Training Calendar Section-----------------------------------------------------//

        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="selectedTrainingNeedAnalysisId"></param>
        /// <param name="selectedCompany"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">companyInfo</exception>
        public ITrainingNeedAnalysisListView GetTrainingNeedAnalysisList(int? selectedCompany, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));


            var companyInSession = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById(companyInSession);


            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo.Username);

            var trainingNeedAnalysisCollection = lookupRepository.GetTrainingNeedAnalysisByCompanyID(companyInSession);
            

            var trainingNeedAnalysisList =
                this.trainingViewModelFactory.CreateTrainingNeedAnalysisListView(selectedCompany, companyCollection, trainingNeedAnalysisCollection, processingMessage);

            return trainingNeedAnalysisList;
        }

        /// <summary>
        /// Gets the trainingNeedAnalysis registration view.
        /// </summary>
        /// <param name="loggedUserId"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">loggedUserId</exception>
        /// <exception cref="System.ArgumentNullException">loggedUserDetails</exception>
        public ITrainingNeedAnalysisView GetTrainingAnalysisView()
        {

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            var jobTitleCollection = lookupRepository.GetJobTitleCollectionByCompanyId(companyId);
            var trainingCollection = lookupRepository.GetTrainingByCompanyId(companyId);
            var frequencyCollection = this.lookupRepository.GetFrequencyOfDistribution();
            var currencyCollection = this.lookupRepository.GetCurrency();
            var methodOfDeliveryCollection = this.lookupRepository.GetMethodOfDelivery();
            
            var viewModel =
                this.trainingViewModelFactory.CreateTrainingNeedAnalysisView(companyId, trainingCollection, jobTitleCollection, frequencyCollection, currencyCollection, methodOfDeliveryCollection);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="trainingNeedAnalysisInfo"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">trainingNeedAnalysisInfo</exception>
        public string ProcessTrainingNeedAnalysisInfo(ITrainingNeedAnalysisView trainingNeedAnalysisInfo)
        {
            if(trainingNeedAnalysisInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingNeedAnalysisInfo));
            }

            var result = string.Empty;

            var trainingCalendar = this.trainingRepository.GetTrainingAnalysisByCompanyIdandTrainingIdandJobId(trainingNeedAnalysisInfo.CompanyID, trainingNeedAnalysisInfo.TrainingID, trainingNeedAnalysisInfo.JobID);

            var IsDataExits = (trainingCalendar == null) ? false : true;

            if (IsDataExits)
            {
                result = Messages.TrainingAnalysisAlreadyExist;

                return result;
            }
            
            result = this.trainingRepository.SaveTrainingNeedAnalysis(trainingNeedAnalysisInfo);

            return result;

        }

        /// <summary>
        /// Creates the training report list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="selectedTrainingReportId">The selected training report identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public ITrainingReportListView CreateTrainingReportList(int? selectedCompany, int? selectedTrainingReportId, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            var companyInSession = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById(companyInSession);

                if (companyInSession <= 0)
                {
                    throw new ArgumentNullException(nameof(companyInSession));
                }

                var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo.Username);

                var trainingReportCollection = lookupRepository.GetTrainingReportByCompanyID(companyInSession);
            

                var trainingReportList =
                    this.trainingViewModelFactory.CreateTrainingReportListView(selectedCompany, selectedTrainingReportId, trainingReportCollection, companyCollection, processingMessage);

                return trainingReportList;
        }
        /// <summary>
        /// Gets the training analysis view.
        /// </summary>
        /// <param name="trainingNeedAnalysis">The training need analysis.</param>
        /// <param name="loggedUserId"></param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">loggedUserId</exception>
        /// <exception cref="System.ArgumentNullException">
        /// trainingNeedAnalysis
        /// or
        /// loggedUserDetails
        /// </exception>
        public ITrainingNeedAnalysisView GetTrainingAnalysisView(ITrainingNeedAnalysisView trainingNeedAnalysis, string message)
        {

            if(trainingNeedAnalysis == null)
            {
                throw new ArgumentNullException(nameof(trainingNeedAnalysis));
            }

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int)this.serviceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);
            
            var jobTitleCollection = lookupRepository.GetJobTitleCollectionByCompanyId(companyId);
            var trainingCollection = lookupRepository.GetTrainingByCompanyId(companyId);
            var frequencyCollection = this.lookupRepository.GetFrequencyOfDistribution();
            var currencyCollection = this.lookupRepository.GetCurrency();
            var methodOfDeliveryCollection = this.lookupRepository.GetMethodOfDelivery();
            
            var viewModel =
                this.trainingViewModelFactory.CreateTrainingNeedAnalysisView(trainingNeedAnalysis, trainingCollection, jobTitleCollection, frequencyCollection, currencyCollection, methodOfDeliveryCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the edit training analysis edit view.
        /// </summary>
        /// <param name="trainingAnalysisid">The training analysisid.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">userId</exception>
        /// <exception cref="System.ArgumentNullException">
        /// trainingAnalysisid
        /// or
        /// loggedUserDetails
        /// </exception>
        public ITrainingNeedAnalysisView GetEditTrainingAnalysisView(int trainingAnalysisId, string message)
        {

            if (trainingAnalysisId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingAnalysisId));
            }

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }


            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);


            var jobTitleCollection = lookupRepository.GetJobTitleCollectionByCompanyId(companyId);
            var trainingCollection = lookupRepository.GetTrainingByCompanyId(companyId);
            var frequencyCollection = this.lookupRepository.GetFrequencyOfDistribution();
            var currencyCollection = this.lookupRepository.GetCurrency();
            var methodOfDeliveryCollection = this.lookupRepository.GetMethodOfDelivery();
            
            var trainingAnalysisInfo = this.trainingRepository.GetTrainingAnalysisById(trainingAnalysisId);

            var viewModel = this.trainingViewModelFactory.CreateEditTrainingAnalysisView(trainingAnalysisInfo, trainingCollection, jobTitleCollection, frequencyCollection, currencyCollection, methodOfDeliveryCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the delete training analysis information.
        /// </summary>
        /// <param name="trainingAnalysisId">The training analysis identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingAnalysisId</exception>
        public string ProcessDeleteTrainingAnalysisInfo(int trainingAnalysisId)
        {
            if (trainingAnalysisId <= 0) throw new ArgumentNullException(nameof(trainingAnalysisId));

            var result = string.Empty;

            result = this.trainingRepository.SaveDeleteTrainingAnalysisInfo(trainingAnalysisId);

            return result;
        }

        /// <summary>
        /// Gets the training history by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">userId</exception>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public ITrainingHistoryViewModel getTrainingHistoryById(int userId)
        {

            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById(userId);
            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            //Company ID of the Logged In User, HR/CompanyAdmin
            var companyId = loggedUserDetails.CompanyId;

            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUserDetails.Username);
            var trainingCollection = new List<ITraining>();
            var certificateCollection = new List<ICertificationModel>();
            var trainingReport = new List<ITrainingReport>();

            foreach (var item in companyCollection)
            {
                trainingCollection.AddRange(trainingRepository.GetAllMyTrainings(item.CompanyId));
                certificateCollection.AddRange(certificationRepository.GetCertificateById(item.CompanyId));
                trainingReport.AddRange(lookupRepository.GetTrainingReportByCompanyID(item.CompanyId));
            }

            var viewModel =
                this.trainingViewModelFactory.CreateTrainingHistoryView(certificateCollection, trainingCollection, trainingReport, userId);
            return viewModel;

        }

        /// <summary>
        /// Creates the trainig history view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public ITrainingHistoryListView CreateTrainigHistoryView(string message)
        {
            var loggedUserDetails = usersRepository.GetUserById((int) this.serviceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUserDetails.Username);

            var trainingHistoryColllection = this.trainingRepository.GetTrainingHistoryByHistoryId(loggedUserDetails.UserId);
            

            var viewModel = this.trainingViewModelFactory.CreateTrainingHistoryViewModel(trainingHistoryColllection, companyCollection, loggedUserDetails.UserId, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit training need analysis information.
        /// </summary>
        /// <param name="trainingNeedAnalysisInfo">The training need analysis information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingNeedAnalysisInfo</exception>
        public string ProcessEditTrainingNeedAnalysisInfo(ITrainingNeedAnalysisView trainingNeedAnalysisInfo)
        {
            if (trainingNeedAnalysisInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingNeedAnalysisInfo));
            }

            var result = string.Empty;

            result = this.trainingRepository.SaveEdtTrainingNeedAnalysis(trainingNeedAnalysisInfo);

            return result;
        }

        #endregion

        #region //-------------------------------------------------------Training History Section-------------------------------------------------------------//


        /// <summary>
        /// </summary>
        /// <param name="historyViewModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">historyViewModel</exception>
        public string processTrainingHistory(ITrainingHistoryViewModel historyViewModel)
        {

            if (historyViewModel == null)
            {
                throw new ArgumentNullException(nameof(historyViewModel));
            }
            var ViewModel = this.trainingRepository.SaveTrainingHistoryInfo(historyViewModel);
            return ViewModel;
        }

        /// <summary>
        /// Gets the training history edit view.
        /// </summary>
        /// <param name="TrainingHistoryId">The training history identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="Message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">TrainingHistoryId</exception>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public ITrainingHistoryViewModel getTrainingHistoryEditView (int TrainingHistoryId, int userId, string Message)
        {
            if (TrainingHistoryId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(TrainingHistoryId));
            }

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById(userId);
            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            //Company ID of the Logged In User, HR/CompanyAdmin
            var companyId = loggedUserDetails.CompanyId;

            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUserDetails.Username);
            var trainingCollection = new List<ITraining>();
            var certificateCollection = new List<ICertificationModel>();
            var trainingReport = new List<ITrainingReport>();

            var trainingHistoryCollection = this.trainingRepository.GetTrainingTariningHistoryById(TrainingHistoryId);

            foreach (var item in companyCollection)
            {
                trainingCollection.AddRange(trainingRepository.GetAllMyTrainings(item.CompanyId));
                certificateCollection.AddRange(certificationRepository.GetCertificateById(item.CompanyId));
                trainingReport.AddRange(lookupRepository.GetTrainingReportByCompanyID(item.CompanyId));
            }

            var viewModel = this.trainingViewModelFactory.CreateEditViewById(trainingCollection, trainingReport, certificateCollection, trainingHistoryCollection, Message);
            return viewModel;
        }

        /// <summary>
        /// Processes the training history edit.
        /// </summary>
        /// <param name="HistoryModel">The history model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">HistoryModel</exception>
        public string ProcessTrainingHistoryEdit (ITrainingHistoryViewModel HistoryModel)
        {
            if (HistoryModel == null) throw new ArgumentNullException(nameof(HistoryModel));
            var viewModel = this.trainingRepository.ProcessTrainingHistoryEdit(HistoryModel);
            return viewModel;
        }

        /// <summary>
        /// Processes the delete on training history.
        /// </summary>
        /// <param name="TrainingHistoryId">The training history identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteOnTrainingHistory (int TrainingHistoryId)
        {
            var viewModel = this.trainingRepository.DeleteTrainingHistory(TrainingHistoryId);
            return viewModel;
        }

        #endregion
    }
}

