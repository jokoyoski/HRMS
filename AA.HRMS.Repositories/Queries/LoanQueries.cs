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
    internal static class LoanQueries
    {
        /// <summary>
        /// Gets the loan by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        internal static ILoan GetLoanById(HRMSEntities db, int loanId)
        {
            var result = (from d in db.LoanTypes
                          where d.LoanTypeId.Equals(loanId)
                          select new LoanTypeModel
                          {
                             LoanTypeId = d.LoanTypeId,
                             LoanType = d.LoanType1,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                             
                          }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the employee loan by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeLoan> getEmployeeLoanByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeLoans
                          join e in db.LoanTypes on d.LoanTypeId equals e.LoanTypeId
                          join c in db.Companies on d.CompanyId equals c.CompanyId
                          join x in db.Employees on d.EmployeeId equals x.EmployeeId
                          where d.CompanyId.Equals(companyId)
                          select new EmployeeLoanModel
                          {
                              EmployeeLoanId = d.EmployeeLoanId,
                              EmployeeId = d.EmployeeId,
                              LoanTypeId = d.LoanTypeId,
                              Tenure = d.Tenure,
                              DateDisburst = d.DateDisburst,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              Amount = d.Amount,
                              AgreedDate = d.AgreedDate,
                              DateCreated = d.DateCreated,
                              CompanyName = c.CompanyName,
                              InterestRate = d.InterestRate,
                              PeriodRemain = d.PeriodRemain,
                              ExpectedDate = d.ExpectedDate,
                              EmployeeName = x.LastName + " " + x.FirstName,
                              IsApproved = d.IsApproved,
                              LoanName = e.LoanType1,
                          }).Where(x => x.IsActive == true).OrderBy(p=>p.CompanyName);
            return result;
        }


        internal static IEnumerable<IEmployeeLoan> getEmployeeLoanByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeLoans
                          join e in db.LoanTypes on d.LoanTypeId equals e.LoanTypeId
                          join c in db.Companies on d.CompanyId equals c.CompanyId
                          join x in db.Employees on d.EmployeeId equals x.EmployeeId
                          where d.EmployeeId.Equals(employeeId)
                          select new EmployeeLoanModel
                          {
                              EmployeeLoanId = d.EmployeeLoanId,
                              EmployeeId = d.EmployeeId,
                              LoanTypeId = d.LoanTypeId,
                              Tenure = d.Tenure,
                              DateDisburst = d.DateDisburst,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              Amount = d.Amount,
                              AgreedDate = d.AgreedDate,
                              DateCreated = d.DateCreated,
                              CompanyName = c.CompanyName,
                              InterestRate = d.InterestRate,
                              PeriodRemain = d.PeriodRemain,
                              ExpectedDate = d.ExpectedDate,
                              EmployeeName = x.LastName + " " + x.FirstName,
                              IsApproved = d.IsApproved,
                              LoanName = e.LoanType1,
                          }).Where(x => x.IsActive == true).OrderBy(p => p.CompanyName);
            return result;
        }



        

        internal static IEnumerable<IEmployeeLoan> getEmployeeLoanById(HRMSEntities db, int employeeLoanId)
        {
            var result = (from d in db.EmployeeLoans
                          join e in db.LoanTypes on d.LoanTypeId equals e.LoanTypeId
                          join c in db.Companies on d.CompanyId equals c.CompanyId
                          join x in db.Employees on d.EmployeeId equals x.EmployeeId
                          where d.EmployeeLoanId.Equals(employeeLoanId) 
                          select new EmployeeLoanModel
                          {
                              EmployeeLoanId = d.EmployeeLoanId,
                              EmployeeId = d.EmployeeId,
                              LoanTypeId = d.LoanTypeId,
                              Tenure = d.Tenure,
                              DateDisburst = d.DateDisburst,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              Amount = d.Amount,
                              AgreedDate = d.AgreedDate,
                              DateCreated = d.DateCreated,
                              CompanyName = c.CompanyName,
                              InterestRate = d.InterestRate,
                              PeriodRemain = d.PeriodRemain,
                              ExpectedDate = d.ExpectedDate,
                              EmployeeName = x.LastName + " " + x.FirstName,
                              IsApproved = d.IsApproved,
                              LoanName = e.LoanType1,
                          }).OrderBy(p => p.EmployeeLoanId);
            return result;
        }


        

        internal static IEnumerable<IEmployeeLoan> getPendingLoanRequestByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeLoans
                          join e in db.LoanTypes on d.LoanTypeId equals e.LoanTypeId
                          join c in db.Companies on d.CompanyId equals c.CompanyId
                          join x in db.Employees on d.EmployeeId equals x.EmployeeId
                          where d.CompanyId.Equals(companyId) && d.IsApproved.Equals(null)
                          select new EmployeeLoanModel
                          {
                              EmployeeLoanId = d.EmployeeLoanId,
                              EmployeeId = d.EmployeeId,
                              LoanTypeId = d.LoanTypeId,
                              Tenure = d.Tenure,
                              DateDisburst = d.DateDisburst,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              Amount = d.Amount,
                              AgreedDate = d.AgreedDate,
                              DateCreated = d.DateCreated,
                              CompanyName = c.CompanyName,
                              EmployeeName = x.LastName + " " + x.FirstName,
                              IsApproved = d.IsApproved,
                              InterestRate = d.InterestRate,
                              PeriodRemain = d.PeriodRemain,
                              ExpectedDate = d.ExpectedDate,
                              LoanName = e.LoanType1
                          }).Where(x => x.IsActive == true).OrderBy(p => p.CompanyName);
            return result;
        }


        

        /// <summary>
        /// Gets the list of loan by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ILoan> GetListOfLoanById(HRMSEntities db, int loanId)
        {
            var result = (from d in db.LoanTypes
                          where d.LoanTypeId.Equals(loanId)
                          select new LoanTypeModel
                          {
                              LoanTypeId = d.LoanTypeId,
                              LoanType = d.LoanType1,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                          }).ToList();
            return result;
        }



    }
}
