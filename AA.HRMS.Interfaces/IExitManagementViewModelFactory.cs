using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IExitManagementViewModelFactory
    {
        /// <summary>
        /// Creates the exit management view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="typeOfExitCollection">The type of exit collection.</param>
        /// <returns></returns>
        IEmployeeExitView CreateExitManagementView(IEmployee employee, ICompanyDetail company, IList<ITypeOfExit> typeOfExitCollection);
        /// <summary>
        /// Creates the exit management update view.
        /// </summary>
        /// <param name="employeeExitView">The employee exit view.</param>
        /// <param name="typeOfExitCollection">The type of exit collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeExitView CreateExitManagementUpdateView(IEmployeeExitView employeeExitView, IList<ITypeOfExit> typeOfExitCollection, string message);
        /// <summary>
        /// Creates the exit management view.
        /// </summary>
        /// <param name="employeeExitView">The employee exit view.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="typeOfExitCollection">The type of exit collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeExitView CreateExitManagementView(IEmployeeExitView employeeExitView, IList<ICompanyDetail> companyCollection, IList<IEmployee> employeeCollection, IList<ITypeOfExit> typeOfExitCollection, string processingMessage);
        /// <summary>
        /// Creates the employee exit ListView.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedEmployeeExitID">The selected employee exit identifier.</param>
        /// <param name="employeeExitCollection">The employee exit collection.</param>
        /// <param name="company">The company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeExitListView CreateEmployeeExitListView(int companyId, int? selectedEmployeeExitID, IList<IEmployeeExit> employeeExitCollection, ICompanyDetail company, string processingMessage);       
    }
}
