using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IQueryViewModelFactory
    {

        /// <summary>
        /// Creates the query view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IQueryView CreateQueryView(int companyId);

        /// <summary>
        /// Creates the updated query view.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IQueryView CreateUpdatedQueryView(IQueryView queryInfo, string processingMessage);

        /// <summary>
        /// Creates the query update view.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        IQueryView CreateQueryUpdateView(IQuery queryInfo);

        /// <summary>
        /// Creates the edit query view.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        IQueryView CreateEditQueryView(IQuery queryInfo);
        
        /// <summary>
        /// Creates the query ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedQuery">The selected query.</param>
        /// <param name="QueryCollection">The query collection.</param>
        /// <param name="company">The company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IQueryListView CreateQueryListView(int? selectedCompanyId, string selectedQuery, IList<IQuery> QueryCollection, ICompanyDetail company, string processingMessage);
    }
}
