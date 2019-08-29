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
    internal static class GradeQueries
    {
        /// <summary>
        /// Gets the name of the grade by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="gradeName">Name of the grade.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IGrade getGradeByName(HRMSEntities db, string gradeName, int companyId)
        {
            var result = (from d in db.Grades
                where d.GradeName.Equals(gradeName) && d.IsActive.Equals(true)
                where d.CompanyId == companyId
                select new GradeModel
                {
                    GradeId = d.GradeId,
                    GradeName = d.GradeName,
                    CompanyId = d.CompanyId,
                    DateCreated = d.DateCreated,
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the grade by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        internal static IGrade getGradeById(HRMSEntities db, int gradeId)
        {
            var result = (from d in db.Grades
                where d.GradeId.Equals(gradeId) && d.IsActive.Equals(true)
                select new GradeModel
                {
                    GradeId = d.GradeId,
                    GradeName = d.GradeName,
                    GradeDescription = d.GradeDescription,
                    CompanyId = d.CompanyId,
                    DateCreated = d.DateCreated,
                    DateModified = d.DateModified,
                    AnnualLeaveDuration = d.AnnualLeaveDuration,
                    IsActive = d.IsActive,
                }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the grade list by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IGrade> getGradeListById(HRMSEntities db, int gradeId)
        {
            var result = (from d in db.Grades
                          where d.GradeId.Equals(gradeId) && d.IsActive.Equals(true)
                          select new GradeModel
                          {
                              GradeId = d.GradeId,
                              GradeName = d.GradeName,
                              GradeDescription = d.GradeDescription,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              AnnualLeaveDuration = d.AnnualLeaveDuration,
                              IsActive = d.IsActive,
                          }).OrderBy(p=>p.GradeId);
            return result;
        }

        

        /// <summary>
        /// Gets the grade by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IGrade> getGradeByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Grades
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                          select new GradeModel
                          {
                              GradeId = d.GradeId,
                              GradeName = d.GradeName,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                          }).OrderBy(p=>p.GradeName);
            return result;
        }
        
    }
}