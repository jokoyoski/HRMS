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
    public class QueryService : IQueryService
    {
        private readonly IQueryViewModelFactory queryViewModelFactory;
        private readonly IQueryRepository queryRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ISessionStateService serviceProvider;

        public QueryService(IQueryViewModelFactory queryViewModelFactory, ILookupRepository lookupRepository, ISessionStateService serviceProvider,
           IQueryRepository queryRepository, ICompanyRepository companyRepository, IUsersRepository usersRepository, IEmployeeRepository employeeRepository)
        {
            this.queryViewModelFactory = queryViewModelFactory;
            this.queryRepository = queryRepository;
            this.lookupRepository = lookupRepository;
            this.companyRepository = companyRepository;
            this.usersRepository = usersRepository;
            this.employeeRepository = employeeRepository;
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets the query registration view.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public IQueryView GetQueryRegistrationView()
        {
            

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById((int)this.serviceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }

            //Company ID of the Logged In User, HR/CompanyAdmin
            var companyId = (int)this.serviceProvider.GetSessionValue(SessionKey.CompanyId);
            
            var viewModel =
                this.queryViewModelFactory.CreateQueryView(companyId);

            return viewModel;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="selectedCompanyId"></param>
        /// <param name="selectedQuery"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public IQueryListView CreateQueryList(int? selectedCompanyId, string selectedQuery, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int) serviceProvider.GetSessionValue(SessionKey.UserId));

            //Get The Selected Company Information
            var companyInfo = this.companyRepository.GetCompanyById((int)serviceProvider.GetSessionValue(SessionKey.CompanyId));

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var queryCollection = lookupRepository.GetQueryByCompanyId(companyInfo.CompanyId);
            
            var queryList =
                this.queryViewModelFactory.CreateQueryListView(selectedCompanyId, selectedQuery, queryCollection, companyInfo, processingMessage);

            return queryList;
        }

        /// <summary>
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public IQueryView CreateQueryUpdatedView(IQueryView queryInfo, string processingMessage)
        {
            if (queryInfo == null)
            {
                throw new ArgumentNullException(nameof(queryInfo));
            }

            var returnViewModel =
                queryViewModelFactory.CreateUpdatedQueryView(queryInfo, processingMessage);

            return returnViewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="queryId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public IQueryView GetQueryEditView(int queryId)
        {
            var queryInfo = queryRepository.GetQueryById(queryId);

            if (queryInfo == null)
            {
                throw new ArgumentNullException(nameof(queryInfo));
            }
            

            var viewModel = this.queryViewModelFactory.CreateEditQueryView(queryInfo);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public string ProcessQueryInfo(IQueryView queryInfo)
        {
            if (queryInfo == null)
            {
                throw new ArgumentNullException(nameof(queryInfo));
            }

            var processingMessage = string.Empty;


            processingMessage = this.queryRepository.SaveQueryInfo(queryInfo);

            return processingMessage;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public string ProcessEditQueryInfo(IQueryView queryInfo)
        {
            if (queryInfo == null)
            {
                throw new ArgumentNullException(nameof(queryInfo));
            }

            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.queryRepository.SaveEditQueryInfo(queryInfo);


            return processingMessage;
        }

        /// <summary>
        /// </summary>
        /// <param name="queryId"></param>
        /// <returns></returns>
        public string ProcessDeleteQueryInfo(int queryId)
        {

            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.queryRepository.SaveDeleteQueryInfo(queryId);


            return processingMessage;
        }

    }
}
