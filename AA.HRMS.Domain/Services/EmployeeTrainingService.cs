using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Services
{
   public class EmployeeTrainingService : IEmployeeTrainingService
    {
        private readonly IEmployeeTrainingRepository employeeTraining;
        private readonly IEmployeeTrainingFactory employeeTrainingFactory;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly ITrainingRepository trainingRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly IUsersRepository usersRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly ISessionStateService session;
        
        public EmployeeTrainingService (IEmployeeTrainingRepository employeeTraining,
            IEmployeeOnBoardRepository employeeOnBoardRepository, ITrainingRepository trainingRepository,
            IEmployeeTrainingFactory employeeTrainingFactory, ILookupRepository lookupRepository,
            IUsersRepository usersRepository, ISessionStateService session,
            ICompanyRepository companyRepository)
        {
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.employeeTraining = employeeTraining;
            this.trainingRepository = trainingRepository;
            this.employeeTrainingFactory = employeeTrainingFactory;
            this.lookupRepository = lookupRepository;
            this.usersRepository = usersRepository;
            this.companyRepository = companyRepository;
            this.session = session;
        }


        /// <summary>
        /// Gets the create employee training by user identifier.
        /// </summary>
        /// <param name="reportId">The report identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IEmployeeTrainingView GetCreateEmployeeTrainingByUserId(int reportId)
        {
            //var Employee = this.lookupRepository.GetEmployeeByCompanyId(EmployeeId);
            var loggedUser = usersRepository.GetUserById((int) session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }


            var companyInfo = this.companyRepository.GetCompanyById((int) session.GetSessionValue(SessionKey.CompanyId));

            var model = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);
            var training = lookupRepository.GetTrainingByCompanyId(companyInfo.CompanyId);
            var EmployeeTraining = employeeTraining.GetEmployeeTraining(companyInfo.CompanyId);

            var trainingReport = lookupRepository.GetTrainingReportByReportID(reportId);
            

            var saveTrainees =
                 this.employeeTrainingFactory.CreateEmployeeTrainingView(EmployeeTraining, companyInfo, training, model, trainingReport);

            return saveTrainees;
        }

        /// <summary>
        /// Gets the create employee training.
        /// </summary>
        /// <param name="employeeTrainingInfo">The employee training information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTrainingInfo</exception>
        public IEmployeeTrainingView GetCreateEmployeeTraining(IEmployeeTrainingView employeeTrainingInfo, string processingMessage)
        {
            if (employeeTrainingInfo == null) throw new ArgumentNullException(nameof(employeeTrainingInfo));
            

            var userInfo = this.usersRepository.GetUserById((int) session.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById((int) session.GetSessionValue(SessionKey.UserId));

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var trainingList = trainingRepository.GetAllMyTrainings(companyInfo.CompanyId);

            var trainingReport = lookupRepository.GetTrainingReportByReportID(companyInfo.CompanyId);
            
            var returnModel = this.employeeTrainingFactory.CreateEmployeeTrainingView(employeeTrainingInfo, trainingList, employeeCollection, processingMessage, trainingReport);

            return returnModel;

        }

        /// <summary>
        /// Saves the employee training.
        /// </summary>
        /// <param name="SaveEmployeeTraining">The save employee training.</param>
        /// <param name="training">The training.</param>
        /// <returns></returns>
        public string SaveEmployeeTraining(IEmployeeTrainingView SaveEmployeeTraining, ITrainingView training)
        {
            

            if (!string.IsNullOrEmpty(training.TrainingName))
            {
                int trainingId = 0;

                var trainingInfo = this.trainingRepository.SaveTrainingInfo(training, out trainingId);

                SaveEmployeeTraining.TrainingId = trainingId;
            }

            

            var save = this.employeeTraining.saveEmployeeTraining(SaveEmployeeTraining);

            return save;
        }

        /// <summary>
        /// Gets the employee training.
        /// </summary>
        /// <param name="selectedCompanyid">The selected companyid.</param>
        /// <param name="selectedTraining">The selected training.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="trainingReportId">The training report identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IEmployeeTrainingListView GetEmployeeTraining(int? selectedCompanyid, int? selectedTraining, string processingMessage, int trainingReportId)
        {
            var loggedUser = usersRepository.GetUserById((int) session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }
            

            var companyInfo = this.companyRepository.GetCompanyById((int) session.GetSessionValue(SessionKey.CompanyId));


            var returnModel = employeeTraining.GetEmployeeTraining(companyInfo.CompanyId);
            var trainingCollection = trainingRepository.GetAllMyTrainings(companyInfo.CompanyId);
            var trainingReport = this.lookupRepository.GetTrainingReportByReportID(trainingReportId);
            

            return this.employeeTrainingFactory.GetTraineeListView(selectedCompanyid, selectedTraining, returnModel, companyInfo, trainingCollection, processingMessage, trainingReport);

        }

        /// <summary>
        /// Gets the employee training view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">EmployeeTrainingInfo</exception>
        public IEmployeeTrainingView GetEmployeeTrainingView (int Id)
        {
            var EmployeeTrainingInfo = employeeTraining.GetEmployeeTrainingById(Id);


            if (EmployeeTrainingInfo == null)
            {
                throw new ArgumentNullException(nameof(EmployeeTrainingInfo));
            }

            var userInfo = this.usersRepository.GetUserById((int) session.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById((int) session.GetSessionValue(SessionKey.CompanyId));

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var trainingList = trainingRepository.GetAllMyTrainings(companyInfo.CompanyId);
            

            var ViewModel = this.employeeTrainingFactory.CreateEditEmployeeTrainingView(EmployeeTrainingInfo, companyInfo, employeeCollection, trainingList);

            return ViewModel;
        }

        /// <summary>
        /// Processes the edit employee training.
        /// </summary>
        /// <param name="employeeTrainingView">The employee training view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTrainingView</exception>
        public string ProcessEditEmployeeTraining(IEmployeeTrainingView employeeTrainingView)
        {
            if (employeeTrainingView == null)
            {
                throw new ArgumentNullException(nameof(employeeTrainingView));
            }

            string processingMessage = string.Empty;

            processingMessage = this.employeeTraining.UpdateEmployeeTraining(employeeTrainingView);

            return processingMessage;
        }

        /// <summary>
        /// Processes the delete employee training information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">id</exception>
        public string ProcessDeleteEmployeeTrainingInfo(int employeeTrainingId)
        {
            if (employeeTrainingId < 1)
            {
                throw new ArgumentNullException(nameof(employeeTrainingId));
            }

            var ProcessingMessage = this.employeeTraining.DeletEmployeeTrainingInfo(employeeTrainingId);
            return ProcessingMessage;
        }

        /// <summary>
        /// Gets all requested training by company.
        /// </summary>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IEmployeeTrainingListView GetAllRequestedTrainingByCompany(int? selectedEmployeeId, string processingMessage)
        {
            var loggedUser = usersRepository.GetUserById((int) session.GetSessionValue(SessionKey.UserId));

            var companuInSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var companyInfo = this.companyRepository.GetCompanyById(companuInSession);
            
            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }

            var trainingCollection = trainingRepository.GetTrainingRequestByCompanyId(companuInSession);
            
            var companyCollection = this.companyRepository.GetMyCompanies(loggedUser.CompanyId);
            

            return this.employeeTrainingFactory.CreateSpecificEmployeeTrainingView(selectedEmployeeId, employeeInfo, companyInfo, trainingCollection, companyCollection, processingMessage);
            
        }

        /// <summary>
        /// Gets the employee every training.
        /// </summary>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loggedUser
        /// or
        /// employeeInfo
        /// </exception>
        public IEmployeeTrainingListView GetEmployeeEveryTraining(int? selectedEmployeeId, string processingMessage)
        {


            var loggedUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }


            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUser.Email);


            if (employeeInfo == null) throw new ArgumentNullException(nameof(employeeInfo));

            var companyCollection = this.companyRepository.GetMyCompanies(loggedUser.UserId);


            var trainingCollection = this.trainingRepository.GetAllMyTrainingsByEmployeeId(employeeInfo.EmployeeId);


            var companyInfo = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);

            return this.employeeTrainingFactory.CreateSpecificEmployeeTrainingView(selectedEmployeeId, employeeInfo, companyInfo, trainingCollection, companyCollection, processingMessage);


        }

        /// <summary>
        /// Gets the employee every training.
        /// </summary>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loggedUser
        /// or
        /// employeeId
        /// </exception>
        public IEmployeeTrainingListView GetEmployeeEveryTraining(int? selectedEmployeeId, string processingMessage, int employeeId)
        {


            var loggedUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }

            if (employeeId <= 0) throw new ArgumentNullException(nameof(employeeId));

            var companyCollection = this.companyRepository.GetMyCompanies(loggedUser.UserId);


            var trainingCollection = this.trainingRepository.GetAllMyTrainingsByEmployeeId(employeeId);

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            var companyInfo = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);

            return this.employeeTrainingFactory.CreateSpecificEmployeeTrainingView(selectedEmployeeId, employeeInfo, companyInfo, trainingCollection, companyCollection, processingMessage);


        }

        /// <summary>
        /// Gets the create employee training by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUser</exception>
        public IEmployeeTrainingView GetCreateEmployeeTrainingById (int employeeId)
        {

            var loggedUser = usersRepository.GetUserById((int) session.GetSessionValue(SessionKey.UserId));
            
            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }

            var companyInfo = this.companyRepository.GetCompanyById((int)session.GetSessionValue(SessionKey.CompanyId));


            var model = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var training = lookupRepository.GetTrainingInCalendarByCompanyId(companyInfo.CompanyId);

            var trainingCollection = this.trainingRepository.GetAllMyTrainingsByEmployeeId(employeeId);

            var employee = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);
            

            var saveTrainees =
                 this.employeeTrainingFactory.CreateEmployeeTrainingRequestView(trainingCollection, companyInfo, training, model, employee);

            return saveTrainees;

        }
   }
}
