using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollRepository
    {
        /// <summary>
        /// Saves the payroll history information.
        /// </summary>
        /// <param name="payrollHistoryInfo">The payroll history information.</param>
        /// <returns></returns>
        Task<int> SavePayrollHistoryInfo(IPayrollHistoryView payrollHistoryInfo);

        /// <summary>
        /// Gets the payroll by identifier.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        IPayroll GetPayrollById(int payrollId);

        /// <summary>
        /// Gets the payroll list.
        /// </summary>
        /// <returns></returns>
        IList<IPayroll> GetPayrollList(int companyId);

        /// <summary>
        /// Gets the payroll history list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IPayrollHistory> GetPayrollHistoryList(int companyId);

        /// <summary>
        /// Gets the employee payroll list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IPayroll> GetEmployeePayrollList(int employeeId);

        /// <summary>
        /// Gets the payroll list by payroll history identifier.
        /// </summary>
        /// <param name="payrollHistoryId">The payroll history identifier.</param>
        /// <returns></returns>
        IList<IPayroll> GetPayrollListByPayrollHistoryId(int payrollHistoryId);

        /// <summary>
        /// Saves the payroll.
        /// </summary>
        /// <param name="payrollInfo">The payroll information.</param>
        /// <returns></returns>
        Task<int> SavePayroll(IPayrollView payrollInfo);

        /// <summary>
        /// Gets the payrll by company mont year.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="monthCode">The month code.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        IPayrollHistory GetPayrllHistoryByCompanyMonthYear(int companyId, string monthCode, int yearId);

        /// <summary>
        /// Gets the payrll history by company month year.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IPayrollHistory> GetPayrllHistoryByCompanyMonthYear(int companyId);

        /// <summary>
        /// Saves the payroll history.
        /// </summary>
        /// <param name="payrollInfo">The payroll information.</param>
        /// <returns></returns>
        string SavePayrollHistory(IPayrollHistory payrollInfo);

        /// <summary>
        /// Saves the payroll employee deduction.
        /// </summary>
        /// <param name="payrollEmployeeDeduction">The payroll employee deduction.</param>
        /// <returns></returns>
        string SavePayrollEmployeeDeduction(IPayrollEmployeeDeduction payrollEmployeeDeduction);

        /// <summary>
        /// Gets the payroll employee deduction by payroll identifier.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        IList<IPayrollEmployeeDeduction> GetPayrollEmployeeDeductionByPayrollId(int payrollId);

        /// <summary>
        /// Gets the payroll employee loan by payroll identifier.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        IList<IPayrollEmployeeLoan> GetPayrollEmployeeLoanByPayrollId(int payrollId);

        /// <summary>
        /// Gets the payroll employee reward by payroll identifier.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        IList<IPayrollEmployeeReward> GetPayrollEmployeeRewardByPayrollId(int payrollId);

        /// <summary>
        /// Saves the payroll employee loan.
        /// </summary>
        /// <param name="payrollEmployeeLoan">The payroll employee loan.</param>
        /// <returns></returns>
        string SavePayrollEmployeeLoan(IPayrollEmployeeLoan payrollEmployeeLoan);

        /// <summary>
        /// Saves the payroll employee reward.
        /// </summary>
        /// <param name="payrollEmployeeReward">The payroll employee reward.</param>
        /// <returns></returns>
        string SavePayrollEmployeeReward(IPayrollEmployeeReward payrollEmployeeReward);
    }
}
