using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    internal static class EducationHistoryQueries
    {
        /// <summary>
        /// Gets the education history by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        internal static IEducationHistory GetEducationHistoryById(HRMSEntities db, int educationHistoryId)
        {
            var result = (from d in db.EducationHistories
                where d.EducationHistoryId.Equals(educationHistoryId)
                select new EducationHistoryModel
                {
                    SchoolName = d.SchoolName,
                    Note = d.Note,
                    Degree = d.Degree,
                    DateCreated = d.DateCreated,
                    EducationHistoryId = d.EducationHistoryId,
                    GraduationYear = d.GraduationYear,
                    EmployeeId = d.EmployeeId
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the education history by user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEducationHistory> GetEducationHistoryByUserId(HRMSEntities db, int userId)
        {
            var result = (from d in db.EducationHistories
                where d.EmployeeId.Equals(userId) && d.IsActive.Equals(true)
                select new EducationHistoryModel
                {
                    SchoolName = d.SchoolName,
                    Note = d.Note,
                    Degree = d.Degree,
                    DateCreated = d.DateCreated,
                    EducationHistoryId = d.EducationHistoryId,
                    GraduationYear = d.GraduationYear,
                    EmployeeId = d.EmployeeId,
                    IsActive = d.IsActive
                }).ToList();
            return result;
        }
    }
}