using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AA.HRMS.Domain.Factories
{
    public class PayrollViewModelFactory : IPayrollViewModelFactory
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
        /// <exception cref="ArgumentNullException">
        /// employeeCollection
        /// or
        /// payrollCollection
        /// or
        /// monthCollection
        /// or
        /// yearCollection
        /// </exception>
        public IPayrollListView CreatePayrollView(int companyId, IList<IEmployee> employeeCollection, IList<IPayroll> payrollCollection,
            IList<IMonth> monthCollection, IList<IYear> yearCollection)
        {

            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }

            if (payrollCollection == null)
            {
                throw new ArgumentNullException(nameof(payrollCollection));
            }

            if (monthCollection == null)
            {
                throw new ArgumentNullException(nameof(monthCollection));
            }

            if (yearCollection == null)

            {
                throw new ArgumentNullException(nameof(yearCollection));
            }
            
            var monthDDL = GetDropDownList.Month(monthCollection, "");
            var yearDDL = GetDropDownList.Year(yearCollection, -1);

            var viewwModel = new PayrollListView
            {
                MonthDropDown = monthDDL,
                YearDropDown = yearDDL,
                EmployeeList = employeeCollection,
                PayrollList = payrollCollection,
                CompanyId = companyId
            };

            return viewwModel;
        }

        /// <summary>
        /// Creates the pay slip view.
        /// </summary>
        /// <param name="payroll">The payroll.</param>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payroll</exception>
        public IPaySlipViewModel CreatePaySlipView(IPayroll payroll, IPayScale payScale, decimal taxRate, IList<IPayScaleBenefit> payScaleBenefits, 
            ICompanyDetail companyDetail, IDigitalFile companyLogo, IEmployee employee, ILevel level, IGrade grade, IList<IPayrollEmployeeReward> rewardCollection, 
            IList<IPayrollEmployeeDeduction> employeeDeductionCollection, IList<IPayrollEmployeeLoan> loanCollection, decimal pensionContribution, decimal spouseConsolidation,
            decimal childrenConsolidation, decimal consolidationTaxRelief, decimal taxableIncome)
        {
            if (payroll == null)
            {
                throw new ArgumentNullException(nameof(payroll));
            }

            var viewModel = new PaySlipViewModel
            {
                CompanyDetail = companyDetail,
                Payroll = payroll,
                Employee = employee,
                Loan = loanCollection,
                Reward = rewardCollection,
                EmployeeDeduction = employeeDeductionCollection,
                Level = level,
                Grade = grade,
                PayScale = payScale,
                PayScaleCollection = payScaleBenefits,
                CompanyLogo = companyLogo,
                TaxRate = taxRate,
                PensionContribution = pensionContribution,
                Dependant = spouseConsolidation,
                Children = childrenConsolidation,
                TaxCollation = consolidationTaxRelief,
                TaxationAmount = taxableIncome,
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the payroll list.
        /// </summary>
        /// <param name="payrollCollection">The payroll collection.</param>
        /// <param name="monthCollection">The month collection.</param>
        /// <param name="yearCollection">The year collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// monthCollection
        /// or
        /// yearCollection
        /// </exception>
        public IPayrollListView CreatePayrollList(string selectedMonth, int? selectedYear, IList<IPayroll> payrollCollection, IList<IMonth> monthCollection, 
            IList<IYear> yearCollection, string message)
        {
            if (monthCollection == null)
            {
                throw new ArgumentNullException(nameof(monthCollection));
            }

            if (yearCollection == null)
            {
                throw new ArgumentNullException(nameof(yearCollection));
            }

            if (payrollCollection == null)
            {
                throw new ArgumentNullException(nameof(payrollCollection));
            }

            var monthDDL = GetDropDownList.Month(monthCollection, "");
            var yearDDL = GetDropDownList.Year(yearCollection, -1);

            var filteredList = payrollCollection.Where(x => x.YearId.Equals(selectedYear < 1 ? x.YearId : selectedYear)).ToList();

            //filteredList = filteredList.Where(x =>
            //    x.MonthCode.Contains(string.IsNullOrEmpty(selectedMonth)
            //        ? x.MonthCode
            //        : selectedMonth)).ToList();

            var viewwModel = new PayrollListView
            {
                MonthDropDown = monthDDL,
                YearDropDown = yearDDL,
                PayrollList = filteredList,
                ProcessingMessage = message
            };

            return viewwModel;
        }

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
        /// <exception cref="System.ArgumentNullException">
        /// monthCollection
        /// or
        /// yearCollection
        /// or
        /// payrollHistoryCollection
        /// </exception>
        public IPayrollHistoryListView CreatePayrollHistoryList(string selectedMonth, int? selectedYear, IList<IPayrollHistory> payrollHistoryCollection, 
            IList<IMonth> monthCollection, IList<IYear> yearCollection, string message)
        {
            if (monthCollection == null)
            {
                throw new ArgumentNullException(nameof(monthCollection));
            }

            if (yearCollection == null)
            {
                throw new ArgumentNullException(nameof(yearCollection));
            }

            if (payrollHistoryCollection == null)
            {
                throw new ArgumentNullException(nameof(payrollHistoryCollection));
            }
            
            var viewwModel = new PayrollHistoryListView
            {
                PayrollHistoryCollection = payrollHistoryCollection,
                ProcessingMessage = message
            };

            return viewwModel;
        }
        
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
        /// <exception cref="ArgumentNullException">
        /// monthCollection
        /// or
        /// yearCollection
        /// or
        /// payrollCollection
        /// </exception>
        public IPayrollListView CreateEmployeePayrollList(string selectedMonth, int? selectedYear, IList<IPayroll> payrollCollection, ICompanyDetail company, 
            IEmployee employee, IList<IMonth> monthCollection, IList<IYear> yearCollection, string message)
        {
            if (monthCollection == null)
            {
                throw new ArgumentNullException(nameof(monthCollection));
            }

            if (yearCollection == null)
            {
                throw new ArgumentNullException(nameof(yearCollection));
            }

            if (payrollCollection == null)
            {
                throw new ArgumentNullException(nameof(payrollCollection));
            }

            var monthDDL = GetDropDownList.Month(monthCollection, "");
            var yearDDL = GetDropDownList.Year(yearCollection, -1);
            

            var viewwModel = new PayrollListView
            {
                MonthDropDown = monthDDL,
                YearDropDown = yearDDL,
                PayrollList = payrollCollection,
                ProcessingMessage = message,
                Company = company,
                Employee = employee,
            };

            return viewwModel;
        }
    }
}
