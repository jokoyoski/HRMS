using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    public class PayrollQueries
    {
        /// <summary>
        /// Gets all payroll.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IPayroll> getAllPayroll(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Payrolls
                          where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                          join v in db.Employees on a.EmployeeId equals v.EmployeeId
                          join b in db.PayrollHistories on a.PayrollHistoryId equals b.PayrollHistoryId
                          join n in db.Months on b.MonthCode equals n.MonthCode
                          join y in db.Years on b.Year equals y.YearId
                          select new PayrollModel
                          {
                              PayrollId = a.PayrollId,
                              BasicSalary = a.BasicSalary,
                              EmployeeId = a.EmployeeId,
                              CompanyId = a.CompanyId,
                              NetSalary = a.NetSalary,
                              DateCreated = a.DateCreated,
                              Year = y.Year1,
                              Month = n.MonthName,
                              IsActive = a.IsActive,
                              CompanyName = x.CompanyName,
                              EmployeeName = v.LastName + " " + v.FirstName
                              
                              
                          }).OrderBy(x=>x.DateCreated);

            return result;
        }

        internal static IEnumerable<IPayrollEmployeeDeduction> getPayrollEmployeeDeductionByPayrollId(HRMSEntities db, int payrollId)
        {
            var result = (from a in db.PayrollEmployeeDeductions
                          where a.PayrollId.Equals(payrollId) && a.IsActive.Equals(true)
                          join c in db.Deductions on a.EmployeeDeductionId equals c.DeductionId
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                          select new PayrollEmployeeDeductionModel
                          {
                              EmployeeDeductionId = a.EmployeeDeductionId,
                              PayrollEmployeeDeductionId = a.PayrollEmployeeDeductionId,
                              PayrollId = a.PayrollId,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyName = x.CompanyName,
                              Amount = c.DeductionAmount,
                              DeductionName = c.DeductionName,


                          }).OrderBy(x => x.DateCreated);

            return result;
        }

        internal static IEnumerable<IPayrollEmployeeLoan> getPayrollEmployeeLoanByPayrollId(HRMSEntities db, int payrollId)
        {
            var result = (from a in db.PayrollEmployeeLoans
                          where a.PayrollId.Equals(payrollId) && a.IsActive.Equals(true)
                          join c in db.EmployeeLoans on a.EmployeeLoanId equals c.EmployeeLoanId
                          join v in db.LoanTypes on c.LoanTypeId equals v.LoanTypeId
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                          select new PayrollEmployeeLoanModel
                          {
                              EmployeeLoanId = a.EmployeeLoanId,
                              PayrollEmployeeLoanId = a.PayrollEmployeeLoanId,
                              PayrollId = a.PayrollId,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreate,
                              IsActive = a.IsActive,
                              CompanyName = x.CompanyName,
                              Amount = c.Amount,
                              LoanTypeName = v.LoanType1,
                              InterestRate = c.InterestRate ?? 0,
                              Tenure = c.Tenure,
                          }).OrderBy(x => x.DateCreated);

            return result;
        }


        internal static IEnumerable<IPayrollEmployeeReward> getPayrollEmployeeRewardByPayrollId(HRMSEntities db, int payrollId)
        {
            var result = (from a in db.PayrollEmployeeRewards
                          where a.PayrollId.Equals(payrollId) && a.IsActive.Equals(true)
                          join c in db.EmployeeRewards on a.EmployeeRewardId equals c.EmployeeRewardId
                          join v in db.Rewards on c.RewardId equals v.RewardId
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                          select new PayrollEmployeeRewardModel
                          {
                              EmployeeRewardId = a.EmployeeRewardId,
                              PayrollEmployeeRewardId = a.PayrollEmployeeRewardId,
                              PayrollId = a.PayrollId,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyName = x.CompanyName,
                              Amount = v.Amount,
                              RewardName = v.RewardName,
                              
                          }).OrderBy(x => x.DateCreated);

            return result;
        }




        /// <summary>
        /// Gets the payroll history list.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IPayrollHistory> getPayrollHistoryList(HRMSEntities db, int companyId)
        {
            var result = (from a in db.PayrollHistories
                          where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                          join n in db.Months on a.MonthCode equals n.MonthCode
                          join y in db.Years on a.Year equals y.YearId
                          select new PayrollHistoryModel
                          {
                              PayrollHistoryId = a.PayrollHistoryId,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              YearName = y.Year1,
                              MonthName = n.MonthName,
                              IsActive = a.IsActive,
                              CompanyName = x.CompanyName,


                          }).OrderBy(x => x.DateCreated);

            return result;
        }
        

        /// <summary>
        /// Gets all employee payroll.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IPayroll> getAllEmployeePayroll(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.Payrolls
                          where a.EmployeeId.Equals(employeeId) && a.IsActive.Equals(true)
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                          join v in db.Employees on a.EmployeeId equals v.EmployeeId
                          select new PayrollModel
                          {
                              PayrollId = a.PayrollId,
                              BasicSalary = a.BasicSalary,
                              EmployeeId = a.EmployeeId,
                              CompanyId = a.CompanyId,
                              NetSalary = a.NetSalary,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyName = x.CompanyName,
                              EmployeeName = v.LastName + " " + v.FirstName


                          }).OrderBy(x => x.PayrollId);

            return result;
        }

        /// <summary>
        /// Gets the payroll by payroll history identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="payrollHistoryId">The payroll history identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IPayroll> getPayrollByPayrollHistoryId(HRMSEntities db, int payrollHistoryId)
        {
            var result = (from a in db.Payrolls
                          where a.PayrollHistoryId.Equals(payrollHistoryId) && a.IsActive.Equals(true)
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                          join v in db.Employees on a.EmployeeId equals v.EmployeeId
                          select new PayrollModel
                          {
                              PayrollId = a.PayrollId,
                              BasicSalary = a.BasicSalary,
                              EmployeeId = a.EmployeeId,
                              CompanyId = a.CompanyId,
                              NetSalary = a.NetSalary,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyName = x.CompanyName,
                              EmployeeName = v.LastName + " " + v.FirstName,
                              PayrollHistoryId = a.PayrollHistoryId


                          }).OrderBy(x => x.EmployeeId);

            return result;
        }
        
        /// <summary>
        /// Gets the payrll by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        internal static IPayroll getPayrllById(HRMSEntities db, int payrollId)
        {
            var result = (from a in db.Payrolls
                          where a.PayrollId.Equals(payrollId) && a.IsActive.Equals(true)
                          join x in db.PayrollHistories on a.PayrollHistoryId equals x.PayrollHistoryId
                          join v in db.Months on x.MonthCode equals v.MonthCode
                          join b in db.Years on x.Year equals b.YearId
                          select new PayrollModel
                          {
                              PayrollId = a.PayrollId,
                              PayrollHistoryId = a.PayrollHistoryId,
                              BasicSalary = a.BasicSalary,
                              NetSalary = a.NetSalary,
                              EmployeeId = a.EmployeeId,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              Month = v.MonthName, 
                              Year = b.Year1,
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the payrll by company mont year.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="monthCode">The month code.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        internal static IPayrollHistory getPayrllHistoryByCompanyMontYear(HRMSEntities db, int companyId, string monthCode, int yearId)
        {
            var result = (from a in db.PayrollHistories
                          where a.CompanyId.Equals(companyId) && a.Year.Equals(yearId) && a.MonthCode.Equals(monthCode) && a.IsActive.Equals(true) 
                          join n in db.Companies on a.CompanyId equals n.CompanyId
                          join b in db.Months on a.MonthCode equals b.MonthCode
                          join c in db.Years on a.Year equals c.YearId
                          select new PayrollHistoryModel
                          {
                              PayrollHistoryId = a.PayrollHistoryId,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              CompanyId = a.CompanyId,
                              CompanyName = n.CompanyName,
                              MonthCode = a.MonthCode,
                              MonthName = b.MonthName,
                              YearName = c.Year1,
                              Year = a.Year
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the payrll history by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="payrollHistoryId">The payroll history identifier.</param>
        /// <returns></returns>
        internal static IPayrollHistory getPayrllHistoryById(HRMSEntities db, int payrollHistoryId)
        {
            var result = (from a in db.PayrollHistories
                          where a.PayrollHistoryId.Equals(payrollHistoryId) && a.IsActive.Equals(true)
                          join n in db.Companies on a.CompanyId equals n.CompanyId
                          join b in db.Months on a.MonthCode equals b.MonthCode
                          join c in db.Years on a.Year equals c.YearId
                          select new PayrollHistoryModel
                          {
                              PayrollHistoryId = a.PayrollHistoryId,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              CompanyId = a.CompanyId,
                              CompanyName = n.CompanyName,
                              MonthCode = a.MonthCode,
                              MonthName = b.MonthName,
                              YearName = c.Year1,
                              Year = a.Year
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the payrll history by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IPayrollHistory> getPayrllHistoryByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.PayrollHistories
                          where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                          join n in db.Companies on a.CompanyId equals n.CompanyId
                          join b in db.Months on a.MonthCode equals b.MonthCode
                          join c in db.Years on a.Year equals c.YearId
                          select new PayrollHistoryModel
                          {
                              PayrollHistoryId = a.PayrollHistoryId,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              CompanyId = a.CompanyId,
                              CompanyName = n.CompanyName,
                              MonthCode = a.MonthCode,
                              MonthName = b.MonthName,
                              YearName = c.Year1,
                              Year = a.Year
                          }).OrderBy(p => p.PayrollHistoryId);

            return result;
        }

    }
}
