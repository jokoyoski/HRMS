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
    /// <summary>
    /// 
    /// </summary>
    internal static class EmploymentHistoryQueries
    {
        /// <summary>
        /// Gets the employment histories by user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmploymentHistory> GetEmploymentHistoriesByUserId(HRMSEntities db, int userId)
        {
            var result = (from d in db.EmploymentHistories
                where d.EmployeeId.Equals(userId) && d.IsActive.Equals(true)
                select new EmploymentHistoryModel
                {
                    EmploymentHistoryId = d.EmploymentHistoryId,
                    UserId = d.EmployeeId,
                    CompanyName = d.CompanyName,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    ReasonExit = d.ReasonExit,
                    LevelOnExit = d.LevelOnExit,
                    JobFunction = d.JobFunction,
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive,
                }).OrderBy(x => x.EmploymentHistoryId).ToList();

            return result;
        }


        /// <summary>
        /// Gets the employment history by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeHistoryId">The employee history identifier.</param>
        /// <returns></returns>
        internal static IEmploymentHistory GetEmploymentHistoryById(HRMSEntities db, int employeeHistoryId)
        {
            var result = (from d in db.EmploymentHistories
                where d.EmploymentHistoryId.Equals(employeeHistoryId)
                select new EmploymentHistoryModel
                {
                    EmploymentHistoryId = d.EmploymentHistoryId,
                    UserId = d.EmployeeId,
                    CompanyName = d.CompanyName,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    ReasonExit = d.ReasonExit,
                    LevelOnExit = d.LevelOnExit,
                    JobFunction = d.JobFunction,
                    DateCreated = d.DateCreated
                }).FirstOrDefault();

            return result;
        }
    }
}