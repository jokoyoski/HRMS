using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollServices
    {
        /// <summary>
        /// Gets the payroll view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IPayrollListView GetPayrollView();

        /// <summary>
        /// Gets the pay slip view.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        IPaySlipViewModel GetPaySlipView(int payrollId);

        /// <summary>
        /// Gets the payroll list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <returns></returns>
        IPayrollListView GetPayrollList(int payrollHistoryId, string selectedMonth, int? selectedYear, string message);

        /// <summary>
        /// Gets the payroll history list.
        /// </summary>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPayrollHistoryListView GetPayrollHistoryList(string selectedMonth, int? selectedYear, string message);

        /// <summary>
        /// Gets the payroll employee list.
        /// </summary>
        /// <param name="loggedUserId">The logged user identifier.</param>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPayrollListView GetPayrollEmployeeList(string selectedMonth, int? selectedYear, string message);

        /// <summary>
        /// Gets the employee payroll list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPayrollListView GetEmployeePayrollList(int employeeId, string selectedMonth, int? selectedYear, string message);

        /// <summary>
        /// Generates the pay.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="Year">The year.</param>
        /// <returns></returns>
        Task<string> GeneratePay(string monthCode, int yearId);
    }
}
