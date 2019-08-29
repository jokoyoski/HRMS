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
    internal static class LevelQueries
    {

        /// <summary>
        /// Gets the level by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        internal static ILevel getLevelById(HRMSEntities db, int levelId)
        {
            var result = (from d in db.Levels
                          where d.LevelId.Equals(levelId) && d.IsActive.Equals(true)
                          select new LevelModel
                          {
                              LevelId = d.LevelId,
                              LevelName = d.LevelName,
                              LevelDescription = d.LevelDescription,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,

                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the level list by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ILevel> getLevelListById(HRMSEntities db, int levelId)
        {
            var result = (from d in db.Levels
                          where d.LevelId.Equals(levelId) && d.IsActive.Equals(true)
                          select new LevelModel
                          {
                              LevelId = d.LevelId,
                              LevelName = d.LevelName,
                              LevelDescription = d.LevelDescription,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,

                          }).OrderBy(p=>p.LevelId);
            return result;
        }

        

        /// <summary>
        /// Gets the level by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ILevel> getLevelByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Levels
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                          select new LevelModel
                          {
                              LevelId = d.LevelId,
                              LevelName = d.LevelName,
                              LevelDescription = d.LevelDescription,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                          }).OrderBy(p=>p.LevelName);
            return result;
        }

        /// <summary>
        /// Gets the level by name company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static ILevel getLevelByNameCompanyId(HRMSEntities db, int companyId, string name)
        {
            var result = (from d in db.Levels
                          where d.CompanyId.Equals(companyId) && d.LevelName.Equals(name) && d.IsActive.Equals(true)
                          select new LevelModel
                          {
                              LevelId = d.LevelId,
                              LevelName = d.LevelName,
                              LevelDescription = d.LevelDescription,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                          }).FirstOrDefault();
            return result;
        }

    }
}
