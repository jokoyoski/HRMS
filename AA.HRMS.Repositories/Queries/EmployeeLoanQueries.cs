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
   internal static  class EmployeeLoanQueries
   {
        
        internal static IEmployeeLoan getEmployeeLoanByEmployeeLoanId(HRMSEntities db, int employeeLoanId)
        {
            var result = (from a in db.EmployeeLoans
                          where a.EmployeeLoanId.Equals(employeeLoanId)
                          select new EmployeeLoanModel
                          {
                              EmployeeLoanId = a.EmployeeLoanId,
                              LoanTypeId = a.LoanTypeId,
                              CompanyId = a.CompanyId,
                              Reason = a.Reason,
                              Tenure = a.Tenure,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              EmployeeId = a.EmployeeId,
                              Amount = a.Amount,
                              AgreedDate = a.AgreedDate,
                              DateDisburst = a.DateDisburst,
                              HRComment = a.HRComment,
                              IsApproved = a.IsApproved,
                              InterestRate = a.InterestRate,
                              PeriodRemain = a.PeriodRemain,
                              ExpectedDate = a.ExpectedDate
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEmployeeLoan getEmployeeLoanByEmployeeandCompanyId(HRMSEntities db, int employeeId, int loanId)
        {
            var result = (from a in db.EmployeeLoans
                          where a.EmployeeId.Equals(employeeId) && a.LoanTypeId.Equals(loanId)
                          select new EmployeeLoanModel
                          {
                              EmployeeLoanId = a.EmployeeLoanId,
                              LoanTypeId = a.LoanTypeId,
                              CompanyId = a.CompanyId,
                              Reason = a.Reason,
                              Tenure= a.Tenure,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              EmployeeId = a.EmployeeId,
                              Amount= a.Amount,
                              AgreedDate = a.AgreedDate,
                              DateDisburst = a.DateDisburst,
                              HRComment = a.HRComment,
                              InterestRate = a.InterestRate,
                              PeriodRemain = a.PeriodRemain,
                              IsApproved = a.IsApproved
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IEmployeeLoan> getEmployeeLoanByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.EmployeeLoans
                          where a.EmployeeId.Equals(employeeId) && a.IsActive.Equals(true)
                          join c in db.LoanTypes on a.LoanTypeId equals c.LoanTypeId
                          join b in db.Companies on a.CompanyId equals b.CompanyId
                          select new EmployeeLoanModel
                          {
                              EmployeeLoanId = a.EmployeeLoanId,
                              LoanTypeId = a.LoanTypeId,
                              CompanyId = a.CompanyId,
                              Reason = a.Reason,
                              Tenure = a.Tenure,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              EmployeeId = a.EmployeeId,
                              Amount = a.Amount,
                              AgreedDate = a.AgreedDate,
                              DateDisburst = a.DateDisburst,
                              HRComment = a.HRComment,
                              IsApproved = a.IsApproved,
                              InterestRate = a.InterestRate,
                              PeriodRemain = a.PeriodRemain,
                              LoanName = c.LoanType1,
                              CompanyName = b.CompanyName
                          }).OrderBy(p=>p.DateCreated);

            return result;
        }

   }
}
