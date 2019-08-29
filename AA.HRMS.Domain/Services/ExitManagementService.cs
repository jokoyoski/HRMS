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
    public class ExitManagementService : IExitManagementService
    {

        private readonly IExitManagementRepository exitManagementRepository;
        private readonly IUsersRepository usersRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly IExitManagementViewModelFactory exitManagementViewModelFactory;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly ITypeOfExitRepository typeOfExitRepository;
        private readonly ISessionStateService session;

        public ExitManagementService(IExitManagementRepository exitManagementRepository, IExitManagementViewModelFactory exitManagementViewModelFactory, 
            IUsersRepository usersRepository,ICompanyRepository companyRepository, ILookupRepository lookupRepository, IEmployeeOnBoardRepository employeeOnBoardRepository,
            ITypeOfExitRepository typeOfExitRepository, ISessionStateService session)
        {
            this.exitManagementRepository = exitManagementRepository;
            this.exitManagementViewModelFactory = exitManagementViewModelFactory;
            this.usersRepository = usersRepository;
            this.companyRepository = companyRepository;
            this.lookupRepository = lookupRepository;
            this.typeOfExitRepository = typeOfExitRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.session = session;
        }

        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="selectedEmployeeExitId"></param>
        /// <param name="selectedCompany"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public IEmployeeExitListView CreateEmployeeExitList(int? selectedEmployeeExitId, string selectedCompany, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int) session.GetSessionValue(SessionKey.UserId));


            var companyIdInSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById(companyIdInSession);


            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }
            
            var employeeExitCollection = lookupRepository.GetEmployeeExitByCompanyID(companyIdInSession);
            
            var employeeExitList =
                this.exitManagementViewModelFactory.CreateEmployeeExitListView(userInfo.CompanyId, selectedEmployeeExitId, employeeExitCollection, companyInfo, processingMessage);

            return employeeExitList;
        }


        /// <summary>
        /// Processes the employee exit information.
        /// </summary>
        /// <param name="employeeExitInfo">The employee exit information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeExitInfo</exception>
        public string ProcessEmployeeExitInfo(IEmployeeExitView employeeExitInfo)
        {
           
                if (employeeExitInfo == null)
                {
                    throw new ArgumentNullException(nameof(employeeExitInfo));
                }

                var processingMessage = string.Empty;


                processingMessage = this.exitManagementRepository.SaveEmployeeExitInfo(employeeExitInfo);

                return processingMessage;
            
        }

        /// <summary>
        /// Gets the employee exit view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        public IEmployeeExitView GetEmployeeExitView(int employeeId)
        {

            if (employeeId <= 0) throw new ArgumentNullException(nameof(employeeId));

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            var companyInfo = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var typeOfExistCollection = this.typeOfExitRepository.GetAllMyTypeOfExit(employeeInfo.CompanyId);

            return this.exitManagementViewModelFactory.CreateExitManagementView(employeeInfo, companyInfo, typeOfExistCollection);
        }


        /// <summary>
        /// Creates the employee exit updated view.
        /// </summary>
        /// <param name="employeeExitView">The employee exit view.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userId
        /// or
        /// employeeExitView
        /// </exception>
        public IEmployeeExitView CreateEmployeeExitUpdatedView(IEmployeeExitView employeeExitView, string message)
        {

            if (employeeExitView == null) throw new ArgumentNullException(nameof(employeeExitView));

            var companyInfo = companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));

            employeeExitView.Company = companyInfo;

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeExitView.EmployeeId);

            employeeExitView.Employee = employeeInfo;

            var typeOfExistCollection = this.typeOfExitRepository.GetAllMyTypeOfExit(employeeExitView.CompanyId);

            return this.exitManagementViewModelFactory.CreateExitManagementUpdateView(employeeExitView, typeOfExistCollection, message);
        }
    }
}
