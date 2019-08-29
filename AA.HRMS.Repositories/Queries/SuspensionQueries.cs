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
    internal static class SuspensionQueries
    {
        /// <summary>
        /// Gets the suspension by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        internal static ISuspension getSuspensionById(HRMSEntities db, int suspensionId)
        {
            var result = (from s in db.Suspensions
                          where s.SuspensionId.Equals(suspensionId)
                          select new Models.SuspensionModel
                          {
                              SuspensionId = s.SuspensionId,
                              EmployeeId = s.EmployeeId,
                              QueryId = s.QueryId,
                              StartDate = s.StartDate,
                              EndDate = s.EndDate,
                              Percentage = s.Percentage,
                              IsActive = true,
                              DateCreated = DateTime.Now

                          }).FirstOrDefault();

            return result;
        }
        /// <summary>
        /// Gets all my suspensions.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ISuspension> getAllMySuspensions(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Suspensions
                          where d.CompanyId == companyId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join a in db.Employees on d.EmployeeId equals a.EmployeeId
                          join c in db.Queries on d.QueryId equals c.QueryId 
                          join pdept in db.Suspensions on d.SuspensionId equals pdept.SuspensionId into gj
                          from f in gj.DefaultIfEmpty()
                          select new SuspensionModel
                          {
                              SuspensionId = d.SuspensionId,
                              EmployeeId = d.EmployeeId,
                              QueryId = d.QueryId,
                              StartDate = d.StartDate,
                              EndDate = d.EndDate,
                              Percentage = d.Percentage,
                              IsActive = true,
                              DateCreated = DateTime.Now
                          }).ToList();

            return result;
        }
    }
}
