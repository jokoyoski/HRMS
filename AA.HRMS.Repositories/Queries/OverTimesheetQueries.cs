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
  public  class OverTimesheetQueries
  {
        /// <summary>
        /// Gets the over timesheet by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IOverTimesheet> GetOverTimesheetByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.OverTimesheets
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join f in db.Employees on d.EmployeeId equals f.EmployeeId
                          where d.CompanyId.Equals(companyId)
                          select new OverTimesheetModel
                          {
                              OverTimesheetId = d.OverTimesheetId,
                              EmployeeId = d.EmployeeId,
                              EmployeeName = f.FirstName + " " + f.LastName,
                              NumberofHours = d.NumberofHours,
                              DateCreated = d.DateCreated,
                              CompanyId = d.CompanyId,
                              CompanyName = e.CompanyName

                          }).OrderBy(p=>p.DateCreated);
            return result;
        }

        /// <summary>
        /// Gets the over timesheet by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="overTimeSheetId">The over time sheet identifier.</param>
        /// <returns></returns>
        internal static IOverTimesheet GetOverTimesheetById(HRMSEntities db, int overTimeSheetId)
        {
            var result = (from d in db.OverTimesheets
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join f in db.Employees on d.EmployeeId equals f.EmployeeId
                          where d.OverTimesheetId.Equals(overTimeSheetId)
                          select new OverTimesheetModel
                          {
                              OverTimesheetId = d.OverTimesheetId,
                              EmployeeId = d.EmployeeId,
                              EmployeeName = f.FirstName + " " + f.LastName,
                              NumberofHours = d.NumberofHours,
                              DateCreated = d.DateCreated,
                              CompanyId = d.CompanyId,
                              CompanyName = e.CompanyName

                          }).FirstOrDefault();
            return result;
        }
  }
}