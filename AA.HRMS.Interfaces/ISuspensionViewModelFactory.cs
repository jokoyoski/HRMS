using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ISuspensionViewModelFactory
    {
        /// <summary>
        /// Creates the suspension view.
        /// </summary>
        /// <param name="suspensionView">The suspension view.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="QueryCollection">The query collection.</param>
        /// <returns></returns>
        ISuspensionView CreateSuspensionView(IList<ISuspension> suspensionView, int companyId, IList<IEmployee> employeeCollection, IList<IQuery> QueryCollection);

        /// <summary>
        /// Creates the updated suspension view.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ISuspensionView CreateUpdatedSuspensionView(ISuspensionView suspensionInfo, int companyId, string processingMessage);

        /// <summary>
        /// Creates the suspension update view.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="queryCollection">The query collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ISuspensionView CreateSuspensionUpdateView(ISuspensionView suspensionInfo, IList<IEmployee> employeeCollection, IList<IQuery> queryCollection, string processingMessage);

        /// <summary>
        /// Creates the edit suspension view.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="queryCollection">The query collection.</param>
        /// <returns></returns>
        ISuspensionView CreateEditSuspensionView(ISuspension suspensionInfo, int companyId, IList<IEmployee> employeeCollection, IList<IQuery> queryCollection);

        /// <summary>
        /// Creates the suspension ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="queryCollection">The query collection.</param>
        /// <param name="suspensionCollection">The suspension collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="company">The company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ISuspensionListView CreateSuspensionListView(int? selectedCompanyId, IList<IQuery> queryCollection, IList<ISuspension> suspensionCollection, IList<IEmployee> employeeCollection, ICompanyDetail company, string processingMessage);
       


    }
}
