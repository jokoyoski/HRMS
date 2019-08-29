using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    internal static class DeductionQueries
    {

        /// <summary>
        /// Gets the deduction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        internal static IDeduction getDeductionById(HRMSEntities db, int deductionId)
        {
            var result = (from s in db.Deductions
                          where s.DeductionId.Equals(deductionId)
                          select new Models.DeductionModel
                          {
                              DeductionId = s.DeductionId,
                              DeductionName = s.DeductionName,
                              DeductionAmount = s.DeductionAmount,
                              IsActive = s.IsActive,
                              CompanyId = s.CompanyId,
                              DateCreated = s.DateCreated

                          }).FirstOrDefault();

            return result;
        }

        internal static IEnumerable<IDeduction> getDeductionByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from s in db.Deductions
                          where s.EmployeeId.Equals(employeeId) && s.IsActive.Equals(true)
                          join v in db.Employees on s.EmployeeId equals v.EmployeeId
                          join b in db.Companies on s.CompanyId equals b.CompanyId
                          select new Models.DeductionModel
                          {
                              DeductionId = s.DeductionId,
                              DeductionName = s.DeductionName,
                              DeductionAmount = s.DeductionAmount,
                              IsActive = s.IsActive,
                              CompanyId = s.CompanyId,
                              DateCreated = s.DateCreated,
                              EmployeeId = s.EmployeeId,
                              EemployeeName = v.LastName + " " + v.FirstName,
                              DateStarted = s.DateStarted,
                              DateTerminated = s.DateTerminated,
                              CompanyName = b.CompanyName

                          }).OrderBy(p=>p.DeductionId);

            return result;
        }

        

        /// <summary>
        /// Gets the name of the deduction by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="deductionName">Name of the deduction.</param>
        /// <returns></returns>
        internal static IEnumerable<IDeduction> getDeduction(HRMSEntities db)
        {
            var result = (from a in db.Deductions
                          
                          select new Models.DeductionModel
                          {
                              DeductionId = a.DeductionId,
                              DeductionName = a.DeductionName,
                              DeductionAmount = a.DeductionAmount,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyId = a.CompanyId

                          }).ToList();
            return result;
        }

        /// <summary>
        /// Gets the name of the deduction by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="deductionName">Name of the deduction.</param>
        /// <returns></returns>
        internal static IDeduction getDeductionByName(HRMSEntities db, string deductionName)
        {
            var result = (from a in db.Deductions
                          where a.DeductionName.Equals(deductionName)
                          select new Models.DeductionModel
                          {
                              DeductionId = a.DeductionId,
                              DeductionName = a.DeductionName,
                              DeductionAmount = a.DeductionAmount,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyId = a.CompanyId

                          }).FirstOrDefault();
            return result;
        }
    }
}
