using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories
{
    
    public class QueryViewModelFactory : IQueryViewModelFactory
    {

        /// <summary>
        /// Creates the query view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public IQueryView CreateQueryView(int companyId)
        {

            var viewModel = new QueryView
            {
                CompanyId = companyId,
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the query ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedQuery">The selected query.</param>
        /// <param name="QueryCollection">The query collection.</param>
        /// <param name="company">The company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IQueryListView CreateQueryListView(int? selectedCompanyId, string selectedQuery, IList<IQuery> QueryCollection, ICompanyDetail company, string processingMessage)
        {

            var filteredList = QueryCollection
                .Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();


            filteredList = filteredList
                .Where(x => x.QueryName.Contains(string.IsNullOrEmpty(selectedQuery)
                ? x.QueryName
                : selectedQuery))
                .ToList();

            var viewModel = new QueryListView
            {
                QueryCollection = filteredList,
                Company = company,
                ProcessingMessage = processingMessage
            };

            return viewModel;

        }

        /// <summary>
        /// Creates the updated query view.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public IQueryView CreateUpdatedQueryView(IQueryView queryInfo, string processingMessage)
        {
            if (queryInfo == null) throw new ArgumentNullException(nameof(queryInfo));
            
            queryInfo.ProcessingMessage = processingMessage;

            return queryInfo;
        }

        /// <summary>
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public IQueryView CreateQueryUpdateView(IQuery queryInfo)
        {
            if (queryInfo == null) throw new ArgumentNullException(nameof(queryInfo));

            var queryView = new QueryView
            {
                QueryId = queryInfo.QueryId,
                QueryName = queryInfo.QueryName,
                CompanyId = queryInfo.CompanyId,
                IsActive = queryInfo.IsActive,
                DateCreated = queryInfo.DateCreated,
                Consequences = queryInfo.Consequences

            };

            return queryView;
        }

        /// <summary>
        /// Creates the edit query view.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public IQueryView CreateEditQueryView(IQuery queryInfo)
        {
            if (queryInfo == null) throw new ArgumentNullException(nameof(queryInfo));

            var returnQuery = new QueryView
            {
                QueryId = queryInfo.QueryId,
                QueryName = queryInfo.QueryName,
                CompanyId = queryInfo.CompanyId,
                IsActive = queryInfo.IsActive,
                DateCreated = queryInfo.DateCreated,
                Consequences = queryInfo.Consequences,
                
            };

            return returnQuery;
        }
    }
}
