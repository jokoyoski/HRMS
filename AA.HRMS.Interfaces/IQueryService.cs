using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IQueryService
    {

        /// <summary>
        /// Gets the query registration view.
        /// </summary>
        /// <returns></returns>
        IQueryView GetQueryRegistrationView();

        /// <summary>
        /// Processes the query information.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        string ProcessQueryInfo(IQueryView queryInfo);

        /// <summary>
        /// Gets the query edit view.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <returns></returns>
        IQueryView GetQueryEditView(int queryId);

        /// <summary>
        /// Processes the edit query information.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        string ProcessEditQueryInfo(IQueryView queryInfo);

        /// <summary>
        /// Processes the delete query information.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <returns></returns>
        string ProcessDeleteQueryInfo(int queryId);

        /// <summary>
        /// Creates the query updated view.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IQueryView CreateQueryUpdatedView(IQueryView queryInfo, string processingMessage);

        /// <summary>
        /// Creates the query list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedQuery">The selected query.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IQueryListView CreateQueryList(int? selectedCompanyId, string selectedQuery, string processingMessage);
    }
}
