using AA.HRMS.Domain.Resources;
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
    public class DisciplineService : IDisciplineService
    {

        private readonly IUsersRepository usersRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly IDisciplineViewModelFactory disciplineViewModelFactory;
        private readonly IDisciplineRepository disciplineRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly ISessionStateService session;
        
        public DisciplineService(IUsersRepository usersRepository, ICompanyRepository companyRepository, ILookupRepository lookupRepository, IEmployeeOnBoardRepository employeeOnBoardRepository,
            IDisciplineViewModelFactory disciplineViewModelFactory, IDisciplineRepository disciplineRepository, IEmployeeRepository employeeRepository, ISessionStateService session)
        {
            this.disciplineRepository = disciplineRepository;
            this.lookupRepository = lookupRepository;
            this.companyRepository = companyRepository;
            this.usersRepository = usersRepository;
            this.disciplineViewModelFactory = disciplineViewModelFactory;
            this.employeeRepository = employeeRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.session = session;
        }

        /// <summary>
        /// Creates the training list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public IDisciplineListView CreateDisciplineList(int? selectedCompanyId, string message)
        {
            var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));
            
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var disciplineCollection = this.lookupRepository.GetDisciplineByCompanyId(companyInfo.CompanyId);
                

            var disciplineList =
                this.disciplineViewModelFactory.CreateDisciplineListView(selectedCompanyId, companyInfo, disciplineCollection, message);

            return disciplineList;
        }

        /// <summary>
        /// Gets the discipline edit view.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineInfo</exception>
        public IDisciplineView GetDisciplineEditView(int disciplineId)
        {

            if (disciplineId <= 0)
            {
                throw new ArgumentNullException(nameof(disciplineId));
            }

            var disciplineInfo = disciplineRepository.GetDisciplineById(disciplineId);

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));


            var companyInfo = this.companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));

            if (disciplineInfo == null)
            {
                throw new ArgumentNullException(nameof(disciplineInfo));
            }

            var employeeCollecction = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);
            

            var queryStatusCollection = this.lookupRepository.GetQueryStatus();

            var actionTakenCollection = this.lookupRepository.GetActionTaken();

            var viewModel = this.disciplineViewModelFactory.CreateEditDisciplingView(disciplineInfo, employeeCollecction, 
                queryStatusCollection, actionTakenCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the discipline view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">userId</exception>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public IDisciplineView GetDisciplineView(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(employeeId));
            }

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            var companyInfo = this.companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));

            var employeeCollecction = this.lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);
            

            var employeeInfo = this.employeeRepository.GetEmployeeById(employeeId);

            var queryStatusCollection = this.lookupRepository.GetQueryStatus();

            var actionTakenCollection = this.lookupRepository.GetActionTaken();

            var viewModel =
                this.disciplineViewModelFactory.CreateDisciplineView(employeeId, companyInfo.CompanyId, employeeCollecction, queryStatusCollection, actionTakenCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the discipline view.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">userId</exception>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public IDisciplineView GetDisciplineView(IDisciplineView disciplineView, string processingMessage)
        {
            if (disciplineView == null)
            {
                throw new ArgumentOutOfRangeException(nameof(disciplineView));
            }

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            var companyInfo = this.companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));

            var employeeCollecction = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var queryStatusCollection = this.lookupRepository.GetQueryStatus();

            var actionTakenCollection = this.lookupRepository.GetActionTaken();

            var viewModel =
                this.disciplineViewModelFactory.CreateDisciplineView(disciplineView, employeeCollecction, queryStatusCollection, actionTakenCollection, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Processes the discipline information.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineView</exception>
        public string ProcessDisciplineInfo(IDisciplineView disciplineView)
        {
            if (disciplineView == null) throw new ArgumentNullException(nameof(disciplineView));

            var result = string.Empty;

            result = this.disciplineRepository.SaveDisciplineInfo(disciplineView);

            return result;
        }

        /// <summary>
        /// Processes the edit discipline information.
        /// </summary>
        /// <param name="disciplineInfo">The discipline information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineInfo</exception>
        public string ProcessEditDisciplineInfo(IDisciplineView disciplineInfo)
        {
            if (disciplineInfo == null)
            {
                throw new ArgumentNullException(nameof(disciplineInfo));
            }

            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.disciplineRepository.SaveEditDisciplineInfo(disciplineInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delte discipline information.
        /// </summary>
        /// <param name="discipline">The discipline.</param>
        /// <returns></returns>
        public string ProcessDelteDisciplineInfo(int disciplineId)
        {
            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.disciplineRepository.SaveDeleteDisciplineInfo(disciplineId);


            return processingMessage;
        }

        /// <summary>
        /// Creates the employee discipline list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public IDisciplineListView CreateEmployeeDisciplineList(int? selectedCompanyId, string message)
        {
            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById((int)session.GetSessionValue(SessionKey.CompanyId));

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var disciplineCollection = lookupRepository.GetDisciplineByCompanyIdandEmployeeId(companyInfo.CompanyId);

            var disciplineList =
                this.disciplineViewModelFactory.CreateEmployeeDisciplineListView(selectedCompanyId, disciplineCollection, employeeInfo, companyInfo, message);

            return disciplineList;
        }

        /// <summary>
        /// Creates the employee discipline list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">companyInfo</exception>
        public IDisciplineListView CreateEmployeeDisciplineList(int employeeId, int? selectedCompanyId, string message)
        {
             var userInfo = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);
            
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var disciplineCollection = lookupRepository.GetDisciplineByCompanyIdandEmployeeId(companyInfo.CompanyId, employeeInfo.EmployeeId);
            

            var disciplineList =
                this.disciplineViewModelFactory.CreateEmployeeDisciplineListView(selectedCompanyId, disciplineCollection, employeeInfo, companyInfo, message);

            return disciplineList;
        }
    }
}
