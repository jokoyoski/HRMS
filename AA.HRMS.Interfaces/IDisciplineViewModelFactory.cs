using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IDisciplineViewModelFactory
    {
        /// <summary>
        /// Creates the discipline ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="disciplineCollection">The discipline collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDisciplineListView CreateDisciplineListView(int? selectedCompanyId, ICompanyDetail company, IList<IDiscipline> disciplineCollection, string message);

        /// <summary>
        /// Creates the discipline ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="disciplineCollection">The discipline collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDisciplineListView CreateEmployeeDisciplineListView(int? selectedCompanyId, IList<IDiscipline> disciplineCollection, IEmployee employee, ICompanyDetail company, string message);

        /// <summary>
        /// Creates the discipline view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="queryStatus">The query status.</param>
        /// <param name="actionTaken">The action taken.</param>
        /// <returns></returns>
        IDisciplineView CreateDisciplineView(int employeeId, int companyId, IList<IEmployee> employeeCollecction,IList<IQueryStatus> queryStatus, IList<IActionTaken> actionTaken);

        /// <summary>
        /// Creates the discipline view.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="queryStatus">The query status.</param>
        /// <param name="actionTaken">The action taken.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDisciplineView CreateDisciplineView(IDisciplineView disciplineView, IList<IEmployee> employeeCollecction, IList<IQueryStatus> queryStatus, IList<IActionTaken> actionTaken, string processingMessage);

        /// <summary>
        /// Creates the edit discipling view.
        /// </summary>
        /// <param name="discipline">The discipline.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IDisciplineView CreateEditDisciplingView(IDiscipline discipline, IList<IEmployee> employeeCollecction, IList<IQueryStatus> queryStatusCollecction, IList<IActionTaken> actionTaken);
    }
}
