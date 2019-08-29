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
    public class SuspensionService : ISuspensionService
    {
        private readonly ISuspensionViewModelFactory suspensionViewModelFactory;
        private readonly ISuspensionRepository suspensionRepository;
        private readonly IQueryRepository queryRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ISessionStateService serviceProvider;


        public SuspensionService(ISuspensionViewModelFactory suspensionViewModelFactory, ISuspensionRepository suspensionRepository, ILookupRepository lookupRepository, ISessionStateService serviceProvider,
           IQueryRepository queryRepository, ICompanyRepository companyRepository, IUsersRepository usersRepository, IEmployeeRepository employeeRepository)
        {
            this.suspensionViewModelFactory = suspensionViewModelFactory;
            this.suspensionRepository = suspensionRepository;
            this.queryRepository = queryRepository;
            this.lookupRepository = lookupRepository;
            this.companyRepository = companyRepository;
            this.usersRepository = usersRepository;
            this.employeeRepository = employeeRepository;
            this.serviceProvider = serviceProvider;
        }


        /// <summary>
        /// Creates the suspension list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="SelectedEmployeeId">The selected employee identifier.</param>
        /// <param name="selectedQueryId">The selected query identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public ISuspensionListView CreateSuspensionList(int? selectedCompanyId, int SelectedEmployeeId, int selectedQueryId, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int)serviceProvider.GetSessionValue(SessionKey.UserId));

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById((int)serviceProvider.GetSessionValue(SessionKey.CompanyId));

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }
            
            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId); 
            var queryCollection = lookupRepository.GetQueryByCompanyId(companyInfo.CompanyId);
            var suspensionCollection = lookupRepository.GetSuspensionByCompanyId(companyInfo.CompanyId); 
            
            var suspensionList =
                this.suspensionViewModelFactory.CreateSuspensionListView(selectedCompanyId, queryCollection, suspensionCollection, employeeCollection, companyInfo, processingMessage);
           

            return suspensionList;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="suspensionInfo"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionInfo</exception>
        public ISuspensionView CreateSuspensionUpdatedView(ISuspensionView suspensionInfo, string processingMessage)
        {
            if (suspensionInfo == null)
            {
                throw new ArgumentNullException(nameof(suspensionInfo));
            }

            var userName = (string)this.serviceProvider.GetSessionValue(SessionKey.UserName);

            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            var queryCollection = lookupRepository.GetQueryByCompanyId(companyId);
            var suspensionCollection = lookupRepository.GetSuspensionByCompanyId(companyId);
            

            var returnViewModel =
                suspensionViewModelFactory.CreateUpdatedSuspensionView(suspensionInfo, companyId, processingMessage);

            return returnViewModel;
        }

        /// <summary>
        /// Gets the suspension edit view.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        public ISuspensionView GetSuspensionEditView(int suspensionId)
        {

            var suspensionInfo = suspensionRepository.GetSuspensionById(suspensionId);

            var loggedUserInfo = this.usersRepository.GetUserById((int)serviceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)serviceProvider.GetSessionValue(SessionKey.CompanyId);

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            
            var queryCollection = lookupRepository.GetQueryByCompanyId(companyId);

            
            var viewModel = this.suspensionViewModelFactory.CreateEditSuspensionView(suspensionInfo, companyId, employeeCollection, queryCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the suspension registration view.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public ISuspensionView GetSuspensionRegistrationView()
        {

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int)serviceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            //Company ID of the Logged In User
            var companyId = (int)serviceProvider.GetSessionValue(SessionKey.CompanyId);
            
            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            var queryCollection = lookupRepository.GetQueryByCompanyId(companyId); 
            var suspensionCollection = lookupRepository.GetSuspensionByCompanyId(companyId); 
            
            var viewModel =
                this.suspensionViewModelFactory.CreateSuspensionView(suspensionCollection, companyId, employeeCollection, queryCollection);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="suspensionId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionId</exception>
        public string ProcessSuspensionInfo(ISuspensionView suspensionId)
        {
            if (suspensionId == null)
            {
                throw new ArgumentNullException(nameof(suspensionId));
            }

            var processingMessage = string.Empty;


            processingMessage = this.suspensionRepository.SaveSuspensionInfo(suspensionId);

            return processingMessage;
        }

        /// <summary>
        /// </summary>
        /// <param name="suspensionInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionInfo</exception>
        public string ProcessEditSuspensionInfo(ISuspensionView suspensionInfo)
        {
            if (suspensionInfo == null)
            {
                throw new ArgumentNullException(nameof(suspensionInfo));
            }

            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.suspensionRepository.SaveEditSuspensionInfo(suspensionInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delete suspension information.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteSuspensionInfo(int suspensionId)
        {
            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.suspensionRepository.SaveDeleteSuspensionInfo(suspensionId);


            return processingMessage;
        }
    }
}
