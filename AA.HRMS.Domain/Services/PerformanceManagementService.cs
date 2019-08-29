using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
using AA.Infrastructure.Extensions;
using AA.Infrastructure.Interfaces;

namespace AA.HRMS.Domain.Services
{
    public class PerformanceManagementService : IPerformanceManagementService
    {
        private readonly IPerformanceManagementRepository appraisal;
        private readonly IPerformanceManagementViewModelFactory performanceManagementViewModelFactory;
        private readonly IPerformanceManagementRepository performanceManagementRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly ISessionStateService session;
        private readonly IEmployeeRepository employeeRepository;

        
        public PerformanceManagementService(IPerformanceManagementViewModelFactory performanceManagementViewModelFactory, IPerformanceManagementRepository performanceManagementRepository,
            IUsersRepository usersRepository, IEmployeeOnBoardRepository employeeOnBoardRepository, ICompanyRepository companyRepository, ILookupRepository lookupRepository, ISessionStateService session, IEmployeeRepository employeeRepository)
        {
            this.performanceManagementViewModelFactory = performanceManagementViewModelFactory;
            this.performanceManagementRepository = performanceManagementRepository;
            this.usersRepository = usersRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.companyRepository = companyRepository;
            this.lookupRepository = lookupRepository;
            this.session = session;
            this. employeeRepository = employeeRepository;


        }

        #region //=========================================APPRAISAL ACTION==================================================//    
        
        /// <summary>
        /// Gets the appraisal action ListView by company identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalActionView GetAppraisalActionListViewByCompanyId(string processingMessage) 
        {
            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var model = this.performanceManagementRepository.GetAppraisalActionList((int) this.session.GetSessionValue(SessionKey.CompanyId));
                
            return this.performanceManagementViewModelFactory.GetAppraisalActionListView(model, processingMessage);
        }

        /// <summary>
        /// Gets the appraisal action registration view.
        /// </summary>
        /// <param name="loggedUserId">The logged user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">loggedUserId</exception>
        /// <exception cref="ArgumentNullException">loggedDetails</exception>
        public IAppraisalActionView GetAppraisalActionRegistrationView()
        {

            var loggedDetails = usersRepository.GetUserById((int) this.session.GetSessionValue(SessionKey.UserId));

            if (loggedDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedDetails));
            }

            var companyId = (int) this.session.GetSessionValue(SessionKey.CompanyId);

            var viewModel = this.performanceManagementViewModelFactory.CreateAppraisalActionView(companyId);

            return viewModel;
        }

        /// <summary>
        /// Processes the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public string ProcessAppraisalActionInfo(IAppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalActionInfo));
            }

            var processingMessage = string.Empty;


            processingMessage = this.performanceManagementRepository.SaveAppraisalActionInfo(appraisalActionInfo);

            return processingMessage;
        }

        /// <summary>
        /// Gets the appraisal action edit view.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public IAppraisalActionView GetAppraisalActionEditView(int appraisalActionId)
        {
            var appraisalActionInfo = performanceManagementRepository.GetAppraisalActionById(appraisalActionId);

            if (appraisalActionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalActionInfo));
            }


            var viewModel = this.performanceManagementViewModelFactory.CreateEditAppraisalActionView(appraisalActionInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public string ProcessEditAppraisalActionInfo(IAppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalActionInfo));
            }

            string processingMessage = string.Empty;


            //Store information
            processingMessage = this.performanceManagementRepository.UpdateAppraisalActionInfo(appraisalActionInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delete appraisal action information.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionId</exception>
        public string ProcessDeleteAppraisalActionInfo(int appraisalActionId)
        {
            if (appraisalActionId < 1)
            {
                throw new ArgumentNullException(nameof(appraisalActionId));
            }


           // string processingMessage = string.Empty;


            var processingMessage = this.performanceManagementRepository.DeleteAppraisalActionInfo(appraisalActionId);


            return processingMessage;
        }

        /// <summary>
        /// Creates the appraisal action update view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public IAppraisalActionView CreateAppraisalActionUpdateView(IAppraisalActionView appraisalActionInfo, string processingMessage) 
        {
             if (appraisalActionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalActionInfo));
            }

            var Appraisaldata =
                this.usersRepository.GetUserById(appraisalActionInfo.CompanyId);

            var returnViewModel =
                performanceManagementViewModelFactory.CreateUpdatedAppraisalActionView(appraisalActionInfo, processingMessage);
            
            return returnViewModel;
        }

        #endregion

        #region //========================APPRAISAL RATING=================//

        /// <summary>
        /// Gets the appraisal rating ListView.
        /// </summary>
        /// <returns></returns>
        public IList<IAppraisalRating> GetAppraisalRatingListView()
        {
            var model = this.performanceManagementRepository.GetAppraisalRatingList();
            return model;
        }

        /// <summary>
        /// Gets the appraisal rating registration view.
        /// </summary>
        /// <returns></returns>
        public IAppraisalRatingView GetAppraisalRatingRegistrationView()
        {
            var viewModel = this.performanceManagementViewModelFactory.CreateAppraisalRatingView();

            return viewModel;
        }

        /// <summary>
        /// Processes the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public string ProcessAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalRatingInfo));
            }

            var processingMessage = string.Empty;


            processingMessage = this.performanceManagementRepository.SaveAppraisalRatingInfo(appraisalRatingInfo);

            return processingMessage;
        }

        /// <summary>
        /// Gets the appraisal rating edit view.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public IAppraisalRatingView GetAppraisalRatingEditView(int appraisalRatingId)
        {
            var appraisalRatingInfo = performanceManagementRepository.GetAppraisalRatingById(appraisalRatingId);

            if (appraisalRatingInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalRatingInfo));
            }
            
            var viewModel = this.performanceManagementViewModelFactory.CreateEditAppraisalRatingView(appraisalRatingInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public string ProcessEditAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalRatingInfo));
            }

            string processingMessage = string.Empty;


            //Store Company Information
            processingMessage = this.performanceManagementRepository.UpdateAppraisalRatingInfo(appraisalRatingInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delete appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingId</exception>
        public string ProcessDeleteAppraisalRatingInfo(int appraisalRatingId)
        {
            if (appraisalRatingId < 1)
            {
                throw new ArgumentNullException(nameof(appraisalRatingId));
            }


            string processingMessage = string.Empty;


            processingMessage = this.performanceManagementRepository.DeleteAppraisalRatingInfo(appraisalRatingId);


            return processingMessage;
        }

        /// <summary>
        /// Creates the appraisal rating update view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public IAppraisalRatingView CreateAppraisalRatingUpdateView(IAppraisalRatingView appraisalRatingInfo, string processingMessage)
        {
            if (appraisalRatingInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalRatingInfo));
            }

            var returnViewModel =
                performanceManagementViewModelFactory.CreateUpdatedAppraisalRatingView(appraisalRatingInfo, processingMessage);

            return returnViewModel;
        }

        #endregion
        
        #region //========================EMPLOYEE TASK=================//

        /// <summary>
        /// Gets the employee task details view.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskInfo</exception>
        public IEmployeeTaskView GetEmployeeTaskDetailsView(int employeeTaskId)
        {
            var employeeTaskInfo = performanceManagementRepository.GetEmployeeTaskById(employeeTaskId);

            if (employeeTaskInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeTaskInfo));
            }

            var viewModel = this.performanceManagementViewModelFactory.CreateEditEmployeeTaskView(employeeTaskInfo);

            return viewModel;
        }
        
        /// <summary>
        /// Gets the employee task ListView.
        /// </summary>
        /// <returns></returns>
        public IEmployeeTaskListView GetTaskListView(string processingMessage)
        {

            int companyId = (int)session.GetSessionValue(SessionKey.CompanyId);

            var model = this.performanceManagementRepository.GetTaskListByCompanyId(companyId);
            
            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeTaskListView(model, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee task ListView.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeTaskListView GetEmployeeTaskListView(int employeeId, string processingMessage)
        {
            var model = this.performanceManagementRepository.GetEmployeeTaskList(employeeId);

            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeTaskListView(model, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee task registration view.
        /// </summary>
        /// <returns></returns>
        public IEmployeeTaskView GetEmployeeTaskRegistrationView(int appraisalGoalId)
        {
            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeTaskView(appraisalGoalId);

            return viewModel;
        }

        /// <summary>
        /// Proceses the employee task information.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskInfo</exception>
        public string ProcessEmployeeTaskInfo(IEmployeeTaskView employeeTaskInfo)
        {
            if (employeeTaskInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeTaskInfo));
            }

            var processingMessage = string.Empty;

            int companyId = (int)session.GetSessionValue(SessionKey.CompanyId);

            employeeTaskInfo.CompanyId = companyId;


            processingMessage = this.performanceManagementRepository.SaveEmployeeTaskInfo(employeeTaskInfo);

            return processingMessage;
        }

        /// <summary>
        /// Getemployees the task edit view.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskInfo</exception>
        public IEmployeeTaskView GetEmployeeTaskEditView(int employeeTaskId)
        {
            var employeeTaskInfo = performanceManagementRepository.GetEmployeeTaskById(employeeTaskId);

            if (employeeTaskInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeTaskInfo));
            }

            var viewModel = this.performanceManagementViewModelFactory.CreateEditEmployeeTaskView(employeeTaskInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the editemplotyee task information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public string ProcessEditEmployeeTaskInfo(IEmployeeTaskView employeeTaskInfo)
        {
            if (employeeTaskInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeTaskInfo));
            }

            string processingMessage = string.Empty;


            //Store Company Information
            processingMessage = this.performanceManagementRepository.UpdateEmployeeTaskInfo(employeeTaskInfo);


            return processingMessage;
        }

        /// <summary>
        /// Gets the employee task delete view.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskInfo</exception>
        public IEmployeeTaskView GetEmployeeTaskDeleteView(int employeeTaskId)
        {
            var employeeTaskInfo = performanceManagementRepository.GetEmployeeTaskById(employeeTaskId);

            if (employeeTaskInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeTaskInfo));
            }

            var viewModel = this.performanceManagementViewModelFactory.CreateEditEmployeeTaskView(employeeTaskInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the delete employee task information.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskId</exception>
        public string ProcessDeleteEmployeeTaskInfo(int employeeTaskId)
        {
            if (employeeTaskId < 1)
            {
                throw new ArgumentNullException(nameof(employeeTaskId));
            }


            string processingMessage = string.Empty;


            processingMessage = this.performanceManagementRepository.DeleteEmployeeTaskInfo(employeeTaskId);


            return processingMessage;
        }

        /// <summary>
        /// Creates the employee task update view.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskInfo</exception>
        public IEmployeeTaskView CreateEmployeeTaskUpdateView(IEmployeeTaskView employeeTaskInfo, string processingMessage)
        {
            if (employeeTaskInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeTaskInfo));
            }

            var returnViewModel =
                performanceManagementViewModelFactory.CreateUpdatedEmployeeTaskView(employeeTaskInfo, processingMessage);

            return returnViewModel;
        }

        #endregion

        #region //===========================APPRAISER====================//

        /// <summary>
        /// Gets the appraiser ListView.
        /// </summary>
        /// <returns></returns>
        public IList<IAppraiser> GetAppraiserListView()
        {
            var model = this.performanceManagementRepository.GetAppraiserList();
            return model;
        }

        /// <summary>
        /// Gets the appraiser registration view.
        /// </summary>
        /// <returns></returns>
        public IAppraiserView GetAppraiserRegistrationView()
        {
            var viewModel = this.performanceManagementViewModelFactory.CreateAppraiserView();

            return viewModel;
        }

        /// <summary>
        /// Processes the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public string ProcessAppraiserInfo(IAppraiserView appraiserInfo)
        {
            if (appraiserInfo == null)
            {
                throw new ArgumentNullException(nameof(appraiserInfo));
            }

            var processingMessage = string.Empty;


            processingMessage = this.performanceManagementRepository.SaveAppraiserInfo(appraiserInfo);

            return processingMessage;
        }

        /// <summary>
        /// Gets the appraiser edit view.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public IAppraiserView GetAppraiserEditView(int appraiserId)
        {
            var appraiserInfo = performanceManagementRepository.GetAppraiserById(appraiserId);

            if (appraiserInfo == null)
            {
                throw new ArgumentNullException(nameof(appraiserInfo));
            }


            var viewModel = this.performanceManagementViewModelFactory.CreateEditAppraiserView(appraiserInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public string ProcessEditAppraiserInfo(IAppraiserView appraiserInfo)
        {
            if (appraiserInfo == null)
            {
                throw new ArgumentNullException(nameof(appraiserInfo));
            }

            string processingMessage = string.Empty;


            //Store Company Information
            processingMessage = this.performanceManagementRepository.UpdateAppraiserInfo(appraiserInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delete appraiser information.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserId</exception>
        public string ProcessDeleteAppraiserInfo(int appraiserId)
        {
            if (appraiserId < 1)
            {
                throw new ArgumentNullException(nameof(appraiserId));
            }


            string processingMessage = string.Empty;


            processingMessage = this.performanceManagementRepository.DeleteAppraiserInfo(appraiserId);


            return processingMessage;
        }

        /// <summary>
        /// Creates the appraiser update view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public IAppraiserView CreateAppraiserUpdateView(IAppraiserView appraiserInfo, string processingMessage)
        {
            if (appraiserInfo == null)
            {
                throw new ArgumentNullException(nameof(appraiserInfo));
            }

            var returnViewModel =
                performanceManagementViewModelFactory.CreateUpdatedAppraiserView(appraiserInfo, processingMessage);

            return returnViewModel;
        }

        #endregion

        #region //=========================APPRAISAL GOAL=====================//

        /// <summary>
        /// Gets the appraisal goal ListView.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalGoalListView GetAppraisalGoalListView(int employeeAppraisalId, string processingMessage)
        {
            
            var model = this.performanceManagementRepository.GetAppraisalGoalList(employeeAppraisalId);

            var employeeAppraisal = this.performanceManagementRepository.GetEmployeeAppraisalById(employeeAppraisalId);

            var viewModel = this.performanceManagementViewModelFactory.CreateAppraisalGoalListView(model, employeeAppraisal, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the appraisal goal registration view.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        public IAppraisalGoalView GetAppraisalGoalRegistrationView(int employeeAppraisalId)
        {
            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var employeeAppraisal = this.performanceManagementRepository.GetEmployeeAppraisalById(employeeAppraisalId);

            var appraisal = this.performanceManagementRepository.GetAppraisalById(employeeAppraisal.AppraisalId);

            var appraisee = this.employeeOnBoardRepository.GetOnBoarderById(employeeAppraisal.EmployeeId);
             
            var appraiser = this.employeeOnBoardRepository.GetOnBoarderById(employeeAppraisal.SupervisorId ?? 0);

            var viewModel = this.performanceManagementViewModelFactory.CreateAppraisalGoalView(appraisal, employeeAppraisal, appraisee, appraiser);

            return viewModel;
        }

        /// <summary>
        /// Processes the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalGoalInfo</exception>
        public string ProcessAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo)
        {
            if (appraisalGoalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalGoalInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;


            if (!isDataOkay)
            {
                return processingMessage;
            }


            //Everything is Okay, Proceed to store
            var savedDataMessage = this.performanceManagementRepository.SaveAppraisalGoalInfo(appraisalGoalInfo);

            return savedDataMessage;
        }

        /// <summary>
        /// Gets the appraisal goal edit view.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">appraisalGoalInfo</exception>
        public IAppraisalGoalView GetAppraisalGoalEditView(int appraisalGoalId, string processingMessage)
        {
            var appraisalGoalInfo = performanceManagementRepository.GetAppraisalGoalById(appraisalGoalId);

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            if (appraisalGoalInfo == null)
            {
                throw new ApplicationException(nameof(appraisalGoalInfo));
            }

            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var employeeCollections = this.lookupRepository.GetEmployeeByCompanyId(companyId).ToList();

            var appraisersList = this.performanceManagementRepository.GetAppraiserList().ToList();

            var viewModel =
                this.performanceManagementViewModelFactory.CreateEditAppraisalGoalView(appraisersList, appraisalGoalInfo, employeeCollections, "");

            return viewModel;
        }

        /// <summary>
        /// Processes the edit appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalGoalInfo</exception>
        public string ProcessEditAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo)
        {
            if (appraisalGoalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalGoalInfo));
            }

            string processingMessage = string.Empty;
            bool isDataOkay = true;


            if (!isDataOkay)
            {
                return processingMessage;
            }

            //Store Information
            processingMessage = this.performanceManagementRepository.UpdateAppraisalGoalInfo(appraisalGoalInfo);

            return processingMessage;
        }

        /// <summary>
        /// Processes the delete appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalGoalId</exception>
        public string ProcessDeleteAppraisalGoalInfo(int appraisalGoalId)
        {
            if (appraisalGoalId < 1)
            {
                throw new ArgumentOutOfRangeException("appraisalGoalId");
            }

            var deleteMessage = this.performanceManagementRepository.DeleteAppraisalGoalInfo(appraisalGoalId);

            return deleteMessage;
        }

        /// <summary>
        /// Creates the appraisal goal update view.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalGoalView CreateAppraisalGoalUpdateView(IAppraisalGoalView appraisalGoalInfo, string processingMessage)
        {
            var appraisersList = this.performanceManagementRepository.GetAppraiserList().ToList();

            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var employeeCollections = this.lookupRepository.GetEmployeeByCompanyId(userInfo.CompanyId).ToList();

            var viewModel =
                this.performanceManagementViewModelFactory.CreateUpdatedAppraisalGoalView(appraisersList, appraisalGoalInfo, employeeCollections, processingMessage);

            return viewModel;
        }

        #endregion
        
        #region //==============================APPRAISAL======================================//

        /// <summary>
        /// Gets the appraisal ListView.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IAppraisalListView GetAppraisalListView(string processingMessage)
        {
           var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            int companyId =(int) this.session.GetSessionValue(SessionKey.CompanyId);

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }
           
            var companyCollection = this.companyRepository.GetMyCompanies(loggedUser.CompanyId);

            var model = performanceManagementRepository.GetAppraisalList(companyId);
            


            return this.performanceManagementViewModelFactory.GetAppraisalListView(model, processingMessage);
        }

        /// <summary>
        /// Gets the appraisal question ListView.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IAppraisalQuestionListView GetAppraisalQuestionListView(string processingMessage)
        {
            var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }

            var companyCollection = this.companyRepository.GetMyCompanies(loggedUser.CompanyId);

            var model = new List<IAppraisalQuestion>();

            foreach (var item in companyCollection)
            {
                model.AddRange(performanceManagementRepository.GetAppraisalQuestionList(item.CompanyId));
            }


            return this.performanceManagementViewModelFactory.GetAppraisalQuestionListView(model, processingMessage);
        }

        /// <summary>
        /// Gets the appraisal list employee view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeInfo
        /// or
        /// loggedUser
        /// </exception>
        public IAppraisalView GetAppraisalListEmployeeView(string processingMessage)
        {
            var loggedUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var employeeInfo = employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);

            if(employeeInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeInfo));
            }

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var model = this.performanceManagementRepository.GetAppraisalListEmployee(companyId, employeeInfo.EmployeeId);
            
            return this.performanceManagementViewModelFactory.GetEmployeeAppraisalListView(model, processingMessage);
        }

        /// <summary>
        /// Gets the appraisee ListView.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeInfo
        /// or
        /// loggedUser
        /// </exception>
        public IAppraisalView GetAppraiseeListView(int appraisalId, string message)
        {

            var loggedUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            if (loggedUser == null) throw new ArgumentNullException(nameof(loggedUser));

            var companyCollection = this.companyRepository.GetMyCompanies(loggedUser.CompanyId);

            var model = this.performanceManagementRepository.GetEmployeeAppraisalByAppraisalId(companyId, appraisalId);
            
            return this.performanceManagementViewModelFactory.GetEmployeeAppraisalListView(model, message);
        }

        /// <summary>
        /// Gets the employee appraisal ListView.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IAppraisalListView GetEmployeeAppraisalListView(int employee, string processingMessage)
        {
            var loggedUser = usersRepository.GetUserById(employee);

            if (employee <= 0)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }
            

            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUser.Username);

            var model = new List<IAppraisal>();

            foreach (var item in companyCollection)
            {
                model.AddRange(performanceManagementRepository.GetAppraisalList(item.CompanyId));
            }


            return this.performanceManagementViewModelFactory.GetAppraisalListView(model, processingMessage);
        }

        /// <summary>
        /// Gets the appraisal registration view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IAppraisalView GetAppraisalRegistrationView()
        {

            var userInfo = this.usersRepository.GetUserById((int) this.session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var appraisersList = this.performanceManagementRepository.GetAppraiserList().ToList();

            var appraisalRatingsList = this.performanceManagementRepository.GetAppraisalRatingList().ToList();

            var appraisalActionsList = performanceManagementRepository.GetAppraisalActionList(companyId);

            var appraisalPeriod = this.lookupRepository.GetAppraisalPeriod();

            var yearCollection = this.lookupRepository.GetAllYears();

            var employeeCollections = this.lookupRepository.GetEmployeeByCompanyId(companyId);
            
            var viewModel = this.performanceManagementViewModelFactory.CreateAppraisalView(appraisersList, appraisalRatingsList, appraisalActionsList, appraisalPeriod, employeeCollections, yearCollection, companyId);

            return viewModel;
        }

        /// <summary>
        /// Gets the appraisal question registration view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public IAppraisalQuestionView GetAppraisalQuestionRegistrationView()
        {

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var viewModel = this.performanceManagementViewModelFactory.CreateAppraisalQuestionView(companyId);

            return viewModel;
        }
        
        //Edit Appraisal view        
        /// <summary>
        /// Gets the appraisal edit view.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        /// <exception cref="ApplicationException">appraisalInfo</exception>
        public IAppraisalView GetAppraisalEditView(int appraisalId, string processingMessage)
        {

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }
            
            var appraisalInfo = performanceManagementRepository.GetAppraisalById(appraisalId);
            
            if (appraisalInfo == null)
            {
                throw new ApplicationException(nameof(appraisalInfo));
            }
            
            
            var viewModel =
                this.performanceManagementViewModelFactory.CreateDeleteAppraisalView(appraisalInfo, companyInfo);

            return viewModel;
        }

        /// <summary>
        /// Getemployees the appraisal edit view.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        /// <exception cref="ApplicationException">appraisalInfo</exception>
        public IAppraisalView GetemployeeAppraisalEditView(int employeeAppraisalId)
        {

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));
            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            var employeeAppraisal = performanceManagementRepository.GetEmployeeAppraisalById(employeeAppraisalId);

            var appraiserInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeAppraisal.SupervisorId ?? -1);

            var appraiseeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeAppraisal.EmployeeId);


            var appraisalQuantitativeMetric = this.performanceManagementRepository.GetAppraisalQuantitativeMetricByEmployeeAppraisalId(employeeAppraisalId);

            var appraisalQualitativeMetric = this.performanceManagementRepository.GetAppraisalQualitativeMetricByEmployeeAppraisalId(employeeAppraisalId);




            var appraisalInfo = performanceManagementRepository.GetAppraisalById(employeeAppraisal.AppraisalId);

            var employeeAppraisalQuestionRating = this.performanceManagementRepository.GetEmployeeAppraisalQuestionRating(appraiseeInfo.EmployeeId, employeeAppraisal.AppraisalId);

            if (appraisalInfo == null)
            {
                throw new ApplicationException(nameof(appraisalInfo));
            }
            
            var userInfo = this.lookupRepository.GetEmployeeByCompanyId(loggedUserDetails.CompanyId);

            var appraisersList = this.lookupRepository.GetEmployeeByCompanyId(loggedUserDetails.CompanyId);
            var appraisalActionsList = this.performanceManagementRepository.GetAppraisalActionList();
            var appraisalRatingsList = this.performanceManagementRepository.GetAppraisalRatingList().ToList();
            var appraisals = this.performanceManagementRepository.GetAppraisalList(loggedUserDetails.CompanyId);

            var appraisalQuestion = this.performanceManagementRepository.GetAppraisalQuestion(appraiseeInfo.CompanyId);
            var employeeAppraisalCollection = this.performanceManagementRepository.GetAppraisalByEmployeeId(appraiseeInfo.EmployeeId, companyId, appraisalInfo.AppraisalId);

            var appraisalGoalCollection = this.performanceManagementRepository.GetAppraisalGoalList(employeeAppraisalId);

            var resultCollection = this.lookupRepository.GetResult();
            
            var viewModel =
                this.performanceManagementViewModelFactory.CreateEditAppraisalView(appraisalInfo, employeeAppraisal, appraisalQualitativeMetric, appraisalQuantitativeMetric, employeeAppraisalCollection, appraisalQuestion,
                appraiseeInfo, appraiserInfo, loggedUserDetails, appraisalRatingsList, employeeAppraisalQuestionRating, appraisalGoalCollection, resultCollection);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="employeeAppraisals">The employee appraisals.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        public string ProcessEditAppraisalInfo(IAppraisal appraisalInfo, IEmployeeAppraisal employeeAppraisal, IEnumerable<IAppraisalQualitativeMetric> appraisalQualitativeMetric, IEnumerable<IAppraisalQuantitativeMetric> appraisalQuantitativeMetric)
        {

            //Get The Curretly Logged In User Information


            if (appraisalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalInfo));
            }

            string processingMessage = string.Empty;
            bool isDataOkay = true;

            employeeAppraisal.Status = "Appraised";

            if (!isDataOkay)
            {
                return processingMessage;
            }

            foreach (var patch in appraisalQualitativeMetric)
            {

                var updateAppraisalQualitative = new AppraisalQualitativeMetricModel();


                updateAppraisalQualitative.Target = patch.Target;
                updateAppraisalQualitative.ResultId = patch.ResultId;
                updateAppraisalQualitative.EmployeeAppraisalId = patch.EmployeeAppraisalId;
                updateAppraisalQualitative.CompanyId = patch.CompanyId;

                processingMessage = this.performanceManagementRepository.SaveApraisalQualitativeInfo(updateAppraisalQualitative);

            }

            foreach (var cell in appraisalQuantitativeMetric)
            {

                var updateAppraisalQualitative = new AppraisalQuantitativeMetricModel();


                updateAppraisalQualitative.PrimaryActual = cell.PrimaryActual;
                updateAppraisalQualitative.PrimaryTarget = cell.PrimaryTarget;

                updateAppraisalQualitative.SecondaryActual = cell.SecondaryActual;
                updateAppraisalQualitative.SecondaryTarget = cell.SecondaryTarget;

                updateAppraisalQualitative.ResultId = cell.ResultId;
                updateAppraisalQualitative.EmployeeAppraisalId = cell.EmployeeAppraisalId;
                updateAppraisalQualitative.CompanyId = cell.CompanyId;

                processingMessage = this.performanceManagementRepository.SaveApraisalQuantitativeInfo(updateAppraisalQualitative);


            }
            



            processingMessage = this.performanceManagementRepository.SaveUpdateEmployeeAppraisal(employeeAppraisal);

            return processingMessage;
        }

        /// <summary>
        /// Processes the delete appraisal information.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalId</exception>
        public string ProcessDeleteAppraisalInfo(int appraisalId)
        {
            if (appraisalId < 1)
            {
                throw new ArgumentOutOfRangeException("appraisalId");
            }

            var deleteMessage = this.performanceManagementRepository.DeleteAppraisalInfo(appraisalId);

            return deleteMessage;
        }

        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="employeeApprasial"></param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalView CreateAppraisalUpdateView(IAppraisal appraisalInfo, IEmployeeAppraisal employeeAppraisal, IEnumerable<IAppraisalQualitativeMetric> appraisalQualitativeMetric, IEnumerable<IAppraisalQuantitativeMetric> appraisalQuantitativeMetric, string processingMessage)
        {
            var userId = (int)this.session.GetSessionValue(SessionKey.UserId);

            var companyId = (int)session.GetSessionValue(SessionKey.CompanyId);

            var companyInfo = this.companyRepository.GetCompanyById(companyId);

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail((usersRepository.GetUserById(userId).Email));

            var superviser = this.employeeOnBoardRepository.GetOnBoarderById(employeeInfo.SupervisorId ?? -1);

            var appraisersList = this.performanceManagementRepository.GetAppraiserList();

            var appraisalRatingsList = this.performanceManagementRepository.GetAppraisalRatingList();

            var appraisalQuestion = this.performanceManagementRepository.GetAppraisalQuestion(companyInfo.CompanyId);

            var viewModel =
                this.performanceManagementViewModelFactory.CreateUpdatedAppraisalView(appraisalInfo, employeeAppraisal, appraisalQualitativeMetric, appraisalQuantitativeMetric, appraisalQuestion, appraisalRatingsList, employeeInfo, companyInfo, processingMessage);

            return viewModel;
        }
        
        /// <summary>
        /// Processes the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        public string ProcessAppraisalInfo(IAppraisalView appraisalInfo)
        {
            if (appraisalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalInfo));
            }

            var processingMessage = string.Empty;

            var isDataOkay = true;

            int appraisalId = 0;

            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var hrPersonnel = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);

            isDataOkay = (this.performanceManagementRepository.GetAppraisalByCompanyYearPeriod(appraisalInfo.CompanyId, appraisalInfo.AppraisalYearId, appraisalInfo.AppraisalPeriodId) == null) ? true : false;
            
            if (!isDataOkay)
            {

                processingMessage = Messages.AppraisalAlreadyExist;

                return processingMessage;
            }

            var employeeCollection = this.lookupRepository.GetEmployeeByCompanyId(companyId);


                

                appraisalInfo.CompanyId = companyId;


                if (employeeCollection == null || employeeCollection.Count == 0)
                {
                    processingMessage = Messages.NoEmployeeRecord;

                    return processingMessage;
                }

                processingMessage = this.performanceManagementRepository.SaveAppraisalInfo(appraisalInfo, out appraisalId);


                if (string.IsNullOrEmpty(processingMessage))
                {

                    foreach (var packet in employeeCollection)
                    {

                        var appraisalQuestion = this.performanceManagementRepository.GetAppraisalQuestion(companyId);

                        var employeeAppraisal = new EmployeeAppraisalViewModel();

                        employeeAppraisal.EmployeeId = packet.EmployeeId;
                        employeeAppraisal.SupervisorId = packet.SupervisorId;
                        if(hrPersonnel != null)
                        {
                            employeeAppraisal.HRId = hrPersonnel.EmployeeId;
                        }
                        else
                        {
                            employeeAppraisal.HRId = userInfo.UserId;
                        }
                        employeeAppraisal.AppraisalId = appraisalId;
                        employeeAppraisal.CompanyId = companyId;
                        employeeAppraisal.Status = "Appraisee";

                        processingMessage = performanceManagementRepository.SaveEmployeeAppraisalInfo(employeeAppraisal);
                    }

                }

           
            

            return processingMessage;
        }

        /// <summary>
        /// Processes the appraisal question information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        public string ProcessAppraisalQuestionInfo(IAppraisalQuestionView appraisalInfo)
        {
            if (appraisalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            var userInfo = this.usersRepository.GetUserById((int) this.session.GetSessionValue(SessionKey.UserId));

            var companyId = (int) this.session.GetSessionValue(SessionKey.CompanyId);

            if (!isDataOkay)
            {
                return processingMessage;
            }
            
                appraisalInfo.CompanyId = companyId;

                //Everything is Okay, Proceed to store
                processingMessage = this.performanceManagementRepository.SaveAppraisalQuestionInfo(appraisalInfo);

            
            return processingMessage;
        }
        
        /// <summary>
        /// Creates the appraisal question update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalQuestionView CreateAppraisalQuestionUpdateView(IAppraisalQuestion appraisalInfo, string processingMessage)
        {
            var userId = (int)this.session.GetSessionValue(SessionKey.UserId);

            var companyInfo = this.companyRepository.GetCompanyById(usersRepository.GetUserById(userId).CompanyId);


            //    var viewModel =
            //   this.performanceManagementViewModelFactory.CreateUpdatedAppraisalView(appraisalInfo, employeeApprasial, appraisalQuestion, appraisalRatingsList, employeeInfo, companyInfo, processingMessage);

            return null;
        }

        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAppraisalQuestionView CreateAppraisalQuestionDeleteView(IAppraisalQuestion appraisalInfo, string processingMessage)
        {
            var userId = (int)this.session.GetSessionValue(SessionKey.UserId);

            var companyInfo = this.companyRepository.GetCompanyById(usersRepository.GetUserById(userId).CompanyId);


            //    var viewModel =
            //   this.performanceManagementViewModelFactory.CreateUpdatedAppraisalView(appraisalInfo, employeeApprasial, appraisalQuestion, appraisalRatingsList, employeeInfo, companyInfo, processingMessage);

            return null;
        }

        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        public IAppraisalView CreateAppraisalUpdateView(IAppraisalView appraisalInfo, string processingMessage)
        {
            if (appraisalInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalInfo));
            }

            var appraisalPeriodCollection = this.lookupRepository.GetAppraisalPeriod();

            var yearCollection = this.lookupRepository.GetAllYears();

            var viewModel = this.performanceManagementViewModelFactory.CreateAppraisalUpdateView(appraisalInfo, appraisalPeriodCollection, yearCollection, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Creates the appraisal question update view.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="CompanyId">The company identifier.</param>
        /// <returns></returns>
        public IAppraisalQuestionView CreateAppraisalQuestionUpdateView(IAppraisalQuestionView appraisalQuestionInfo, string processingMessage)
        {
            var Company = this.lookupRepository.GetCompanyCollection();
            var viewModel =
                this.performanceManagementViewModelFactory.CreateUpdatedAppraisalQuestionView(Company, appraisalQuestionInfo, "");

            return viewModel;
        }

        /// <summary>
        /// Gets the employee every appraisal.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loggedUser
        /// or
        /// employeeInfo
        /// </exception>
        public IAppraisalListView GetEmployeeEveryAppraisal(string processingMessage)
        {
            var loggedUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }

            var companyInfo = this.companyRepository.GetCompanyById((int) this.session.GetSessionValue(SessionKey.CompanyId));

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);

            IEmployee supervisorInfo;

            var appraisalInfo = this.performanceManagementRepository.GetAllMyAppraisals(companyInfo.CompanyId);

            var employeeAppraisalCollection = new List<IEmployeeAppraisal>();

            if (employeeInfo != null)
            {
                supervisorInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeInfo.SupervisorId ?? 0);

                appraisalInfo = this.performanceManagementRepository.GetAllMyAppraisals(employeeInfo.CompanyId);

                foreach (var item in appraisalInfo)
                {
                    employeeAppraisalCollection.AddRange(this.performanceManagementRepository.GetAppraisalByEmployeeId(employeeInfo.EmployeeId, employeeInfo.CompanyId, item.AppraisalId));
                }

                companyInfo = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);

                return this.performanceManagementViewModelFactory.CreateSpecificEmployeeAppraisalView(employeeAppraisalCollection, employeeInfo, supervisorInfo, companyInfo, employeeInfo.EmployeeId, processingMessage);

            }

            foreach (var item in appraisalInfo)
            {
                employeeAppraisalCollection.AddRange(this.performanceManagementRepository.GetAppraisalByEmployeeId(loggedUser.UserId, loggedUser.CompanyId, item.AppraisalId));
            }

            return this.performanceManagementViewModelFactory.CreateSpecificEmployeeAppraisalView(employeeAppraisalCollection, employeeInfo, null, companyInfo, 0, processingMessage);

        }

        /// <summary>
        /// Gets the employee appraisee list.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loggedUser
        /// or
        /// employeeInfo
        /// </exception>
        public IAppraisalListView GetEmployeeAppraiseeList(string processingMessage)
        {
            var loggedUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }


            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);

            var supervisorInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeInfo.SupervisorId ?? -1);

            var appraisalInfo = this.performanceManagementRepository.GetAllMyAppraisals(companyId);

            if (employeeInfo == null) throw new ArgumentNullException(nameof(employeeInfo));

            var employeeAppraisalCollection = new List<IEmployeeAppraisal>();

            foreach (var item in appraisalInfo)
            {
                employeeAppraisalCollection.AddRange(this.performanceManagementRepository.GetAppraisalBySupervisorId(employeeInfo.EmployeeId, employeeInfo.CompanyId, item.AppraisalId));
            }


            var companyInfo = this.companyRepository.GetCompanyById(companyId);

            return this.performanceManagementViewModelFactory.CreateSpecificEmployeeAppraisalView(employeeAppraisalCollection, employeeInfo, supervisorInfo, companyInfo, employeeInfo.EmployeeId, processingMessage);


        }


        /// <summary>
        /// Gets the employee every appraisal.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loggedUser
        /// or
        /// employeeId
        /// </exception>
        public IAppraisalListView GetEmployeeEveryAppraisal(string processingMessage, int employeeId)
        {
            var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }

            if (employeeId <= 0) throw new ArgumentNullException(nameof(employeeId));


            var appraisalInfo = this.performanceManagementRepository.GetAllMyAppraisals(loggedUser.CompanyId);

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            var supervisorInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeInfo.SupervisorId ?? -1);

            var companyInfo = this.companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));

            var appraisalCollection = new List<IEmployeeAppraisal>();

            foreach (var item in appraisalInfo)
            {
                appraisalCollection.AddRange(this.performanceManagementRepository.GetAppraisalByEmployeeId(employeeInfo.EmployeeId, employeeInfo.CompanyId, item.AppraisalId));
            }



            return this.performanceManagementViewModelFactory.CreateSpecificEmployeeAppraisalView(appraisalCollection, employeeInfo, supervisorInfo, companyInfo, employeeInfo.EmployeeId, processingMessage);


        }

        /// <summary>
        /// Gets the employee appraisal view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IAppraisalView GetEmployeeAppraisalView(int employeeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the employee appraisal update view.
        /// </summary>
        /// <param name="appraisal">The appraisal.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IAppraisalView GetEmployeeAppraisalUpdateView(IAppraisalView appraisal, string message)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the employee appraisal.
        /// </summary>
        /// <param name="SaveEmployeeAppraisal">The save employee appraisal.</param>
        /// <returns></returns>
        public string SaveEmployeeAppraisal(IAppraisalView SaveEmployeeAppraisal)
        {

            var save = this.appraisal.saveEmployeeAppraisal(SaveEmployeeAppraisal);
            return save;
        }

        /// <summary>
        /// Gets the create employee appraisal.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IAppraisalView GetCreateEmployeeAppraisal(int employeeId)
        {

            var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }
            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUser.Username);


            var model = new List<IEmployee>();
            var appraisal = new List<IAppraisal>();


            var appraisalCollection = this.performanceManagementRepository.GetAllMyAppraisalsByEmployeeId(employeeId);

            var employee = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);



            var saveTrainees =
                 this.performanceManagementViewModelFactory.CreateEmployeeAppraisalRequestView(appraisalCollection, companyCollection, model, employee);

            return saveTrainees;

        }

        /// <summary>
        /// Gets the create employee appraisal.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalInfo
        /// or
        /// userId
        /// </exception>
        public IAppraisalView GetCreateEmployeeAppraisal(IAppraisalView appraisalInfo, string processingMessage)
        {
            if (appraisalInfo == null) throw new ArgumentNullException(nameof(appraisalInfo));

            var userInfo = this.usersRepository.GetUserById((int) this.session.GetSessionValue(SessionKey.UserId));

            var companyId = (int) this.session.GetSessionValue(SessionKey.CompanyId);

            var employeeCollection = this.lookupRepository.GetEmployeeByCompanyId(companyId);

            var appraisalList = performanceManagementRepository.GetAllMyAppraisals(companyId);
            
            var returnModel = this.performanceManagementViewModelFactory.CreateEmployeeAppraisalView(appraisalInfo, companyId, appraisalList, employeeCollection, processingMessage);

            return returnModel;

        }

        /// <summary>
        /// Creates the employee appraisal update view.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IAppraisalView CreateEmployeeAppraisalUpdateView(IEmployeeAppraisal employeeAppraisal, string message)
        {
            var userId = (int)this.session.GetSessionValue(SessionKey.UserId);
            var appraisalInfo = this.performanceManagementRepository.GetAppraisalById(employeeAppraisal.AppraisalId);
            var companyInfo = this.companyRepository.GetCompanyById(usersRepository.GetUserById(userId).CompanyId);
            var appraisee = this.employeeOnBoardRepository.GetOnBoarderById(employeeAppraisal.EmployeeId);
            var appraiser = this.employeeOnBoardRepository.GetOnBoarderById(appraisee.SupervisorId ?? -1);
            var employeeQuestionlRating = this.performanceManagementRepository.GetEmployeeAppraisalQuestionRating(employeeAppraisal.EmployeeId, employeeAppraisal.AppraisalId);
            var appraisalRatingsList = this.performanceManagementRepository.GetAppraisalRatingList();



            var viewModel =
                this.performanceManagementViewModelFactory.CreateUpdatedEmployeeAppraisalView(employeeAppraisal, appraisalInfo, employeeQuestionlRating, appraisalRatingsList, appraisee, appraiser, companyInfo, message);

            return viewModel;

        }

        /// <summary>
        /// Processes the edit employee appraisal information.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <returns></returns>
        public string ProcessEditEmployeeAppraisalInfo(IEmployeeAppraisal employeeAppraisal)
        {

            if (!string.IsNullOrEmpty(employeeAppraisal.Status))
            {
                employeeAppraisal.Status = "Appraised";
            }

            var processingMessage = this.performanceManagementRepository.SaveUpdateEmployeeAppraisal(employeeAppraisal);

            return processingMessage;
        }

        /// <summary>
        /// Processes the edit appraisal question information.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQuestionInfo</exception>
        public string ProcessEditAppraisalQuestionInfo(IAppraisalQuestion appraisalQuestionInfo)
        {
            if (appraisalQuestionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestionInfo));
            }

            string processingMessage = string.Empty;
            bool isDataOkay = true;


            if (!isDataOkay)
            {
                return processingMessage;
            }


            //Store Information
            processingMessage = this.performanceManagementRepository.SaveUpdateAppraisalQuestion(appraisalQuestionInfo);

            return processingMessage;
        }

        /// <summary>
        /// Processes the delete appraisal question information.
        /// </summary>
        /// <param name="appraisalQuestionInfo">The appraisal question information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQuestionInfo</exception>
        public string ProcessDeleteAppraisalQuestionInfo(IAppraisalQuestion appraisalQuestionInfo)
        {
            if (appraisalQuestionInfo == null)
            {
                throw new ArgumentNullException(nameof(appraisalQuestionInfo));
            }

            string processingMessage = string.Empty;
            bool isDataOkay = true;


            if (!isDataOkay)
            {
                return processingMessage;
            }


            //Store Information
            processingMessage = this.performanceManagementRepository.SaveDeleteAppraisalQuestion(appraisalQuestionInfo);

            return processingMessage;
        }

        /// <summary>
        /// Gets the appraisal question edit view.
        /// </summary>
        /// <param name="appraisalQuestionId">The appraisal question identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQuestionId</exception>
        /// <exception cref="ApplicationException">appraisalQuestionInfo</exception>
        public IAppraisalQuestionView GetAppraisalQuestionEditView(int appraisalQuestionId, string processingMessage)
        {

            if (appraisalQuestionId <= 0) throw new ArgumentNullException(nameof(appraisalQuestionId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var appraisalQuestionInfo = performanceManagementRepository.GetAppraisalQuestionById(appraisalQuestionId);

            if (appraisalQuestionInfo == null)
            {
                throw new ApplicationException(nameof(appraisalQuestionInfo));
            }

            var viewModel =
                this.performanceManagementViewModelFactory.CreateEditAppraisalQuestionView(appraisalQuestionInfo, companyId, "");

            return viewModel;
        }

        /// <summary>
        /// Gets the appraisal question delete view.
        /// </summary>
        /// <param name="appraisalQuestionId">The appraisal question identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQuestionId</exception>
        /// <exception cref="ApplicationException">appraisalQuestionInfo</exception>
        public IAppraisalQuestionView GetAppraisalQuestionDeleteView(int appraisalQuestionId, string processingMessage)
        {

            if (appraisalQuestionId <= 0) throw new ArgumentNullException(nameof(appraisalQuestionId));

            var appraisalQuestionInfo = performanceManagementRepository.GetAppraisalQuestionById(appraisalQuestionId);

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            if (appraisalQuestionInfo == null)
            {
                throw new ApplicationException(nameof(appraisalQuestionInfo));
            }

            var viewModel =
                this.performanceManagementViewModelFactory.CreateDeleteAppraisalQuestionView(appraisalQuestionInfo, companyId, "");

            return viewModel;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IEmployeeFeedbackView GetEmployeeFeedbackListView(string message)
        {
            var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var EmployeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            //Get companies by Company Id
            var companyCollection = this.companyRepository.GetMyCompanies(loggedUser.CompanyId);

            var employeeCollection = this.lookupRepository.GetEmployeeByCompanyId(companyId);

            var feedbackCollection = (performanceManagementRepository.GetEmployeeFeedbackByCompanyId(EmployeeInfo.EmployeeId));

            return this.performanceManagementViewModelFactory.GetEmployeeFeedbackListView(employeeCollection,
                feedbackCollection, EmployeeInfo.EmployeeId, message);
        }

        /// <summary>
        /// Gets the employee feedback view by identifier.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">feedbackId</exception>
        public IEmployeeFeedbackViewModel GetEmployeeFeedbackViewByID(int feedbackId)
        {
            if (feedbackId == 0)
            {
                throw new ArgumentNullException(nameof(feedbackId));
            }

            var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);

            var employeeFeedback = this.performanceManagementRepository.GetEmployeeFeedbackByemployeeFeedbackId(feedbackId);

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);

            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeFeedbackViewByID(feedbackId, employeeCollection, employeeInfo);

            return viewModel;

        }

        /// <summary>
        /// Gets the view employee feedback.
        /// </summary>
        /// <param name="employeeFeedbackId">The employee feedback identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeFeedbackId</exception>
        public IEmployeeFeedbackViewModel GetViewEmployeeFeedback(int employeeFeedbackId)
        {

            if (employeeFeedbackId == 0)
            {
                throw new ArgumentNullException(nameof(employeeFeedbackId));
            }

            var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);

            var employeeFeedback = this.performanceManagementRepository.GetEmployeeFeedbackByemployeeFeedbackId(employeeFeedbackId);

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);

            var viewModel = this.performanceManagementViewModelFactory.CreateViewEmployeeFeedback(employeeFeedback, employeeCollection, employeeInfo);

            return viewModel;

        }

        /// <summary>
        /// Gets the employee feedback view.
        /// </summary>
        /// <param name="employeeFeedback">The employee feedback.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeFeedback</exception>
        public IEmployeeFeedbackViewModel GetEmployeeFeedbackView(IEmployeeFeedbackViewModel employeeFeedback, string processingMessage)
        {

            if (employeeFeedback == null)
            {
                throw new ArgumentNullException(nameof(employeeFeedback));
            }
            else
            {
                var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));


                var employeeCollection = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);


                var employeeList = lookupRepository.GetEmployeeByCompanyId(loggedUser.CompanyId);

                var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeFeedbackViewByID(employeeFeedback, employeeList, processingMessage);

                return viewModel;
            }
        }

        /// <summary>
        /// Gets the feedback employee ListView.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeFeedbackView GetFeedbackEmployeeListView(int feedbackId, string message)
        {
            var loggedUser = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var employeeCollection = this.lookupRepository.GetEmployeeByCompanyId(loggedUser.CompanyId);

            var feedbackCollection = (performanceManagementRepository.GetEmployeeFeedbackByFeedbackId(feedbackId));

            return this.performanceManagementViewModelFactory.GetEmployeeFeedbackListView(employeeCollection,
                feedbackCollection, 0, message);
        }

        /// <summary>
        /// Processes the employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeView</exception>
        public string ProcessEmployeeFeedback(IEmployeeFeedbackViewModel employeeView)
        {
            if (employeeView == null)
            {
                throw new ArgumentNullException(nameof(employeeView));
            }

            var processing = string.Empty;

            var IsDataOkay = (this.performanceManagementRepository.GetEmployeeFeedbackByFeedbackIdEmployeeIdFeedbackOnEmployeeId(employeeView.EmployeeId ?? 0, employeeView.FeedbackId, employeeView.FeedbackOnEmployeeId ?? 0) == null) ? true : false;

            if (!IsDataOkay)
            {
                processing = Messages.EmployeeFeedBackAlreadyExist;

                return processing;
            }

            var viewModel = this.performanceManagementRepository.SaveEmployeeFeedback(employeeView);

            var feedback = new FeedbackViewModel();

            feedback.FeedbackId = employeeView.FeedbackId;


            var feedbackupdate = this.performanceManagementRepository.ProcessEditFeedback(feedback);

            return viewModel;


        }

        /// <summary>
        /// Processes the updated employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeView</exception>
        public string ProcessUpdatedEmployeeFeedback(IEmployeeFeedbackViewModel employeeView)
        {
            if (employeeView == null)
            {
                throw new ArgumentNullException(nameof(employeeView));
            }

            var viewModel = this.performanceManagementRepository.SaveEditedEmployeeFeedback(employeeView);

            return viewModel;
        }

        /// <summary>
        /// Gets all feed by company and year.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IFeedbackListview GetAllFeedByCompanyAndYear(string processingMessage)
        {
            var loggedUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null) throw new ArgumentNullException(nameof(loggedUser));

            var companyCollection = this.companyRepository.GetMyCompanies(loggedUser.CompanyId);

            var companyIdInSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var feedbackCollection = performanceManagementRepository.GetFeedBackById(companyIdInSession);


            return this.performanceManagementViewModelFactory.CreateFeedBackView(feedbackCollection, companyCollection, processingMessage);
        }

        /// <summary>
        /// Creates the feedback view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IFeedbackViewModel CreateFeedbackView(string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var yearCollection = this.lookupRepository.GetAllYears();

            var companyInfo = this.companyRepository.GetCompanyById(companyId);

            var viewModel = this.performanceManagementViewModelFactory.CreateFeedbackView(yearCollection, companyInfo, processingMessage);
            return viewModel;
        }

        /// <summary>
        /// Creates the feedback view.
        /// </summary>
        /// <param name="feedback">The feedback.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">feedback</exception>
        public IFeedbackViewModel CreateFeedbackView(IFeedbackModel feedback, string processingMessage)
        {
            if (feedback == null) throw new ArgumentNullException(nameof(feedback));

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var yearCollection = this.lookupRepository.GetAllYears();

            var companyInfo = this.companyRepository.GetCompanyById(companyId);

            var viewModel = this.performanceManagementViewModelFactory.CreateFeedbackView(feedback, yearCollection, companyInfo, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Processes the feedback information.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">viewModel</exception>
        public string ProcessFeedbackInfo(IFeedbackModel viewModel)
        {
            if (viewModel == null)
            {
                throw new System.ArgumentNullException(nameof(viewModel));
            }

            var isDataOkay = true;

            var processingMessage = string.Empty;

            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            var hrPersonnel = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);

            int feedbackId = 0;

            isDataOkay = (this.performanceManagementRepository.GetFeedbackByCompanyYearId(viewModel.CompanyId, viewModel.YearId) == null) ? true : false;

            if (!isDataOkay)
            {
                processingMessage = Messages.FeedBackAlreadyExist;

                return processingMessage;
            }

            processingMessage = this.performanceManagementRepository.SaveFeedbackInfo(viewModel, out feedbackId);

            return processingMessage;
        }

        #endregion

        #region //=====================================================Annual Performance Section Start======================================//

        /// <summary>
        /// Gets the annual performance.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IAnnualAssessingPerformanceListView GetAnnualPerformance(string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById((int)session.GetSessionValue(SessionKey.CompanyId));

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);
            
            var annualPerformance = this.performanceManagementRepository.GetAnnualAssessingPerformanceByCompanyId(companyInfo.CompanyId);

            var viewModel = this.performanceManagementViewModelFactory.CreateAnnualPerformanceListView(annualPerformance, processingMessage);

            return viewModel;
        }
       
        /// <summary>
        /// Gets the annual performance view.
        /// </summary>
        /// <returns></returns>
        public IAnnualAssessingPerformanceView GetAnnualPerformanceView()
        {

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var yearCollection = this.lookupRepository.GetAllYears();

            var viewModel = this.performanceManagementViewModelFactory.CreateAnnualPerformanceView(userInfo, yearCollection);
            
            return viewModel;
        }

        /// <summary>
        /// Gets the annual performance view.
        /// </summary>
        /// <param name="annualAssessingPerformance">The annual assessing performance.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">annualAssessingPerformance</exception>
        public IAnnualAssessingPerformanceView GetAnnualPerformanceView(IAnnualAssessingPerformanceView annualAssessingPerformance, string processingMessage)
        {

            if (annualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(annualAssessingPerformance));
            }

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var yearCollection = this.lookupRepository.GetAllYears();

            var viewModel = this.performanceManagementViewModelFactory.CreateAnnualPerformanceView(annualAssessingPerformance, userInfo, yearCollection, processingMessage);


            return viewModel;
        }
        
        /// <summary>
        /// Processes the annual performance information.
        /// </summary>
        /// <param name="annualAssessingPerformance">The annual assessing performance.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">annualAssessingPerformance</exception>
        public string ProcessAnnualPerformanceInfo(IAnnualAssessingPerformanceView annualAssessingPerformance)
        {

            if (annualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(annualAssessingPerformance));
            }

            var processingMessage = string.Empty;

            int annualAssessingPerformanceId = 0;
            

            bool isDataOaky = (this.performanceManagementRepository.GetAnnualAssessingPerformanceByCompanyIdYearId(annualAssessingPerformance.CompanyId, annualAssessingPerformance.YearId) == null) ? true : false;

            if (!isDataOaky)
            {
                processingMessage = Messages.AnnualAssessingPerformanceAlreadyExist;

                return processingMessage;
            }

            processingMessage = performanceManagementRepository.SaveAnnualPerformanceInfo(annualAssessingPerformance, out annualAssessingPerformanceId);

            var employeeCollection = this.lookupRepository.GetEmployeeByCompanyId(annualAssessingPerformance.CompanyId);

            if (string.IsNullOrEmpty(processingMessage))
            {
                foreach (var item in employeeCollection)
                {
                    var employeeAnnualAssessing = new EmployeeAnnualAssessingPerformanceView();

                    employeeAnnualAssessing.CompanyId = annualAssessingPerformance.CompanyId;
                    employeeAnnualAssessing.AnnualAssessingPerformanceId = annualAssessingPerformanceId;
                    employeeAnnualAssessing.RevieweeId = item.EmployeeId;

                    if (item.SupervisorId > 0)
                    {
                        employeeAnnualAssessing.ReviewerId = item.SupervisorId;
                    }

                    employeeAnnualAssessing.Status = "Reviewee";

                    performanceManagementRepository.SaveEmployeeAnnualPerformanceInfo(employeeAnnualAssessing);
                }
            }

            
            
            return processingMessage;
        }

        #endregion
        
        #region  //=========================================================Employee Annual Performance Scetion Start===========================================//

      
        /// <summary>
        /// Gets the employee annual performance view list.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">annualAssessingPerformanceId</exception>
        public IEmployeeAnnualAssessingPerformanceListView GetEmployeeAnnualPerformanceViewList(int annualAssessingPerformanceId, string message)
        {

            if (annualAssessingPerformanceId <= 0)
            {
                throw new ArgumentNullException(nameof(annualAssessingPerformanceId));
            }


            var employeeAnnualAssessingPerformanceCollection = this.performanceManagementRepository.GetEmployeeAnnualAssessingPerformanceListByAnnualAssessingPerformanceId(annualAssessingPerformanceId);

            

            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeAnnualAssessingPerformanceListView(employeeAnnualAssessingPerformanceCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee annual performance view list employee.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeAnnualAssessingPerformanceListView GetEmployeeAnnualPerformanceViewListEmployee(string message)
        {

            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);

            var employeeAnnualAssessingPerformanceCollection = this.performanceManagementRepository.GetEmployeeAnnualAssessingPerformanceListByEmployeeId(employeeInfo.EmployeeId);
            
            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeAnnualAssessingPerformanceListView(employeeAnnualAssessingPerformanceCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee annual performance view list reviewer.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeAnnualAssessingPerformanceListView GetEmployeeAnnualPerformanceViewListReviewer(string message)
        {

            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);

            var employeeAnnualAssessingPerformanceCollection = this.performanceManagementRepository.GetEmployeeAnnualAssessingPerformanceListBySupervisorId(employeeInfo.EmployeeId);

            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeAnnualAssessingPerformanceListView(employeeAnnualAssessingPerformanceCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee annual performance view.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">annualAssessingPerformanceId</exception>
        public IEmployeeAnnualAssessingPerformanceView GetEmployeeAnnualPerformanceView(int employeeAnnualAssessingPerformanceId)
        {

            if (employeeAnnualAssessingPerformanceId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeAnnualAssessingPerformanceId));
            }

            var loggedInUser = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var employeeAnnualPerformanceAssessmentInfo = this.performanceManagementRepository.GetEmployeeAnnualAssessingPerformanceById(employeeAnnualAssessingPerformanceId);

            var annualPerformanceAssessmentInfo= this.performanceManagementRepository.GetAnnualAssessingPerformanceById(employeeAnnualPerformanceAssessmentInfo.AnnualAssessingPerformanceId);

            var companyInfo = this.companyRepository.GetCompanyById(loggedInUser.CompanyId);
            
            var revieweeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedInUser.Email);

            var reviewerInfo = this.employeeOnBoardRepository.GetOnBoarderById(revieweeInfo.SupervisorId ?? 0);

            var ratingCollection = this.performanceManagementRepository.GetAppraisalRatingList();

            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeAnnualPerformanceView(annualPerformanceAssessmentInfo, revieweeInfo, reviewerInfo, ratingCollection, companyInfo);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee annual performance view.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <param name="processinMessage">The processin message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">employeeAnnualAssessingPerformance</exception>
        public IEmployeeAnnualAssessingPerformanceView GetEmployeeAnnualPerformanceView(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance, string processinMessage)
        {

            if (employeeAnnualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(employeeAnnualAssessingPerformance));
            }

            var loggedInUser = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var annualPerformanceAssessmentInfo = this.performanceManagementRepository.GetAnnualAssessingPerformanceById(employeeAnnualAssessingPerformance.AnnualAssessingPerformanceId);

            var companyInfo = this.companyRepository.GetCompanyById(loggedInUser.CompanyId);

            var revieweeInfo = this.employeeOnBoardRepository.GetOnBoarderById((int)this.session.GetSessionValue(SessionKey.EmployeeId));

            var reviewerInfo = this.employeeOnBoardRepository.GetOnBoarderById(revieweeInfo.SupervisorId ?? 0);

            var ratingCollection = this.performanceManagementRepository.GetAppraisalRatingList();

            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeAnnualPerformanceView(employeeAnnualAssessingPerformance, annualPerformanceAssessmentInfo, revieweeInfo, reviewerInfo, ratingCollection, companyInfo);

            return viewModel;
        }

        /// <summary>
        /// Processings the employee annual assessing performance information.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">employeeAnnualAssessingPerformance</exception>
        public string ProcessingEmployeeAnnualAssessingPerformanceInfo(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance)
        {
            if (employeeAnnualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(employeeAnnualAssessingPerformance));
            }

            var processingMessage = string.Empty;
            
                employeeAnnualAssessingPerformance.Status = "Reviewer";

            processingMessage = this.performanceManagementRepository.SaveEmployeeAnnualPerformanceInfo(employeeAnnualAssessingPerformance);

            return processingMessage;
        }

        /// <summary>
        /// Gets the edit employee annual performance view.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">annualAssessingPerformanceId</exception>
        public IEmployeeAnnualAssessingPerformanceView GetEditEmployeeAnnualPerformanceView(int employeeAppraisalAssessingPerformanceId)
        {

            if (employeeAppraisalAssessingPerformanceId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeAppraisalAssessingPerformanceId));
            }

            var loggedInUser = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById(loggedInUser.CompanyId);

            var employeeAnnualPerformanceAssessmentInfo = this.performanceManagementRepository.GetEmployeeAnnualAssessingPerformanceById(employeeAppraisalAssessingPerformanceId);

            var annualPerformanceAssessmentInfo = this.performanceManagementRepository.GetAnnualAssessingPerformanceById(employeeAnnualPerformanceAssessmentInfo.AnnualAssessingPerformanceId);

            var revieweeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeAnnualPerformanceAssessmentInfo.RevieweeId ?? 0);

            var reviewerInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeAnnualPerformanceAssessmentInfo.ReviewerId ?? 0);

            var ratingCollection = this.performanceManagementRepository.GetAppraisalRatingList();

            var viewModel = this.performanceManagementViewModelFactory.CreateEmployeeAnnualPerformanceView(employeeAnnualPerformanceAssessmentInfo, annualPerformanceAssessmentInfo, revieweeInfo, reviewerInfo, ratingCollection, companyInfo);

            return viewModel;
        }

        /// <summary>
        /// Processings the edit employee annual assessing performance information.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">employeeAnnualAssessingPerformance</exception>
        public string ProcessingEditEmployeeAnnualAssessingPerformanceInfo(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance)
        {
            if (employeeAnnualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(employeeAnnualAssessingPerformance));
            }

            var processingMessage = string.Empty;

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById((int)this.session.GetSessionValue(SessionKey.EmployeeId));

            if (employeeInfo.SupervisorEmployeeId < 0)
            {
                employeeAnnualAssessingPerformance.Status = "FinalReviewer";

            }

            if (employeeAnnualAssessingPerformance.RevieweeRatingId > 0)
            {
                employeeAnnualAssessingPerformance.Status = "Reviewer";
            }

            if (!string.IsNullOrEmpty(employeeAnnualAssessingPerformance.ReviewerComment) || employeeAnnualAssessingPerformance.FinalReviewerId > 0)
            {
                employeeAnnualAssessingPerformance.Status = "FinalReviewer";
            }

            if (!string.IsNullOrEmpty(employeeAnnualAssessingPerformance.FinalRatingComment) || employeeAnnualAssessingPerformance.FinalRatingId > 0)
            {
                employeeAnnualAssessingPerformance.Status = "Reviewed";
                employeeAnnualAssessingPerformance.FinalReviewerId = (int)this.session.GetSessionValue(SessionKey.UserId);

            }

            processingMessage = this.performanceManagementRepository.EditEmployeeAnnualPerformanceInfo(employeeAnnualAssessingPerformance);

            return processingMessage;
        }

        #endregion

        #region //===============================================Milestone Section=====================================//

        /// <summary>
        /// Gets the milestone view.
        /// </summary>
        /// <param name="milestoneId">The milestone identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IMilestoneView GetMilestoneView(int milestoneId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the employee milestone list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IMilestoneListView GetMilestoneListByEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the milestone list by task.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">taskId</exception>
        public IMilestoneListView GetMilestoneListByTask(int taskId, string processingMessage)
        {
            if (taskId <= 0) throw new ArgumentNullException(nameof(taskId));

            var milestoneCollection = this.performanceManagementRepository.GetMilestoneListByTaskId(taskId);

            return this.performanceManagementViewModelFactory.CreateTaskMileStoneList(milestoneCollection, processingMessage);
        }

        #endregion

    }
}
