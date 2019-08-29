

using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollViewModelFactory
    {

        /// <summary>
        /// Creates the payroll view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="payrollCollection">The payroll collection.</param>
        /// <param name="monthCollection">The month collection.</param>
        /// <param name="yearCollection">The year collection.</param>
        /// <returns></returns>
        IPayrollListView CreatePayrollView(int companyId, IList<IEmployee> employeeCollection, IList<IPayroll> payrollCollection,IList<IMonth> monthCollection, IList<IYear> yearCollection);

        /// <summary>
        /// Creates the pay slip view.
        /// </summary>
        /// <param name="payroll">The payroll.</param>
        /// <param name="companyDetail">The company detail.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="levelGrade">The level grade.</param>
        /// <param name="rewardCollection">The reward collection.</param>
        /// <param name="employeeDeductionCollection">The employee deduction collection.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        IPaySlipViewModel CreatePaySlipView(IPayroll payroll, IPayScale payScale, decimal taxRate, IList<IPayScaleBenefit> payScaleBenefits, ICompanyDetail companyDetail, 
            IDigitalFile companyLogo, IEmployee employee, ILevel level, IGrade grade, IList<IPayrollEmployeeReward> rewardCollection, IList<IPayrollEmployeeDeduction> employeeDeductionCollection, 
            IList<IPayrollEmployeeLoan> loanCollection, decimal PensionContribution, decimal spouseConsolidation,
            decimal childrenConsolidation, decimal consolidationTaxRelief, decimal taxableIncome);

        /// <summary>
        /// Creates the payroll list.
        /// </summary>
        /// <param name="payrollCollection">The payroll collection.</param>
        /// <param name="monthCollection">The month collection.</param>
        /// <param name="yearCollection">The year collection.</param>
        /// <returns></returns>
        IPayrollListView CreatePayrollList(string selectedMOnth, int? selectedYear, IList<IPayroll> payrollCollection, IList<IMonth> monthCollection, IList<IYear> yearCollection, string message);


        /// <summary>
        /// Creates the payroll history list.
        /// </summary>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="payrollHistoryCollection">The payroll history collection.</param>
        /// <param name="monthCollection">The month collection.</param>
        /// <param name="yearCollection">The year collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPayrollHistoryListView CreatePayrollHistoryList(string selectedMonth, int? selectedYear, IList<IPayrollHistory> payrollHistoryCollection, IList<IMonth> monthCollection, IList<IYear> yearCollection, string message);

        /// <summary>
        /// Creates the employee payroll list.
        /// </summary>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="payrollCollection">The payroll collection.</param>
        /// <param name="company">The company.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="monthCollection">The month collection.</param>
        /// <param name="yearCollection">The year collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPayrollListView CreateEmployeePayrollList(string selectedMonth, int? selectedYear, IList<IPayroll> payrollCollection, ICompanyDetail company, IEmployee employee, IList<IMonth> monthCollection, IList<IYear> yearCollection, string message);
    }
}
