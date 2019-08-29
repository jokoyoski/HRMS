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
    internal static class ExitManagementQueries
    {
        /// <summary>
        /// Gets the employee exit by employee identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        internal static IEmployeeExit getEmployeeExitByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeExits
                          where d.EmployeeId.Equals(employeeId)
                          select new Models.EmployeeExitModel
                          {
                              CompanyId = d.CompanyId,
                              EmployeeExitId = d.EmployeeExitId,
                              EmployeeId = d.EmployeeId,
                              DateCreated = d.DateCreated,
                              DateRequested = d.DateRequested,
                              Reason = d.Reason,
                              TypeOfExitId = d.TypeOfExitId,
                              ExitInterViewSummary = d.ExitInterViewSummary,  //ExitInterViewSummary,
                              IsActive = d.IsActive,
                              InterviewDate = d.InterviewDate,
                              Interviewer = d.Interviewer//InterviewerId
                              
                          }).FirstOrDefault();

            return result;
        }
        /// <summary>
        /// Gets all my employee exit.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeExit> getAllMyEmployeeExit(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeExits
                          where d.CompanyId == companyId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.EmployeeExits on d.EmployeeExitId equals pdept.EmployeeExitId into gj
                          join s in db.TypeOfExits on d.TypeOfExitId equals s.TypeOFExitId
                          from f in gj.DefaultIfEmpty()

                          select new EmployeeExitModel
                          {
                              EmployeeExitId = d.EmployeeExitId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              Interviewer = d.Interviewer,
                              TypeOfExitId = d.TypeOfExitId,
                              Reason = d.Reason,
                              InterviewDate = d.InterviewDate,
                              DateRequested = d.DateRequested,
                              ExitInterViewSummary = d.ExitInterViewSummary,
                              IsActive = d.IsActive
                             

                          }).OrderBy(p => p.EmployeeExitId);

            return result;
        }
    }
}
