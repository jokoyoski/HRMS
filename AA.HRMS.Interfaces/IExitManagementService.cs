using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IExitManagementService
    {
        /// <summary>
        /// Gets the employee exit view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmployeeExitView GetEmployeeExitView(int employeeId);

        /// <summary>
        /// Creates the employee exit updated view.
        /// </summary>
        /// <param name="employeeExitView">The employee exit view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeExitView CreateEmployeeExitUpdatedView(IEmployeeExitView employeeExitView, string message);

        /// <summary>
        /// Processes the employee exit information.
        /// </summary>
        /// <param name="EmployeeExitInfo">The employee exit information.</param>
        /// <returns></returns>
        string ProcessEmployeeExitInfo(IEmployeeExitView EmployeeExitInfo);

        /// <summary>
        /// Creates the employee exit list.
        /// </summary>
        /// <param name="selectedEmployeeExitId">The selected employee exit identifier.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeExitListView CreateEmployeeExitList(int? selectedEmployeeExitId, string selectedCompany, string processingMessage);
    }
}
