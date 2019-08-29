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
    public class SkillSetQueries
    {
        /// <summary>
        /// Gets the skill set by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        internal static ISkillSetModel getSkillSetById(HRMSEntities db, int skillSetId)
        {
            var result = (from d in db.SkillSets
                join b in db.Experiences on d.ExperienceId equals b.ExperienceId
                          where d.SkillId.Equals(skillSetId)
                          select new SkillSetModel
                          {
                              SkillId = d.SkillId,
                              SkillName = d.SkillName,
                              SkillDescription = d.SkillDescription,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              EmployeeId = d.EmployeeId,
                              ExperienceName = b.ExperienceName,
                              Experience = d.ExperienceId
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the skill set by user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ISkillSetModel> getSkillSetByUserId(HRMSEntities db, int userId)
        {
            var result = (from d in db.SkillSets
                    join b in db.Experiences on d.ExperienceId equals b.ExperienceId
                          select new SkillSetModel
                          {
                              SkillId = d.SkillId,
                              SkillName = d.SkillName,
                              SkillDescription = d.SkillDescription,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              EmployeeId = d.EmployeeId,
                              ExperienceName = b.ExperienceName
                          }).Where(x=>x.EmployeeId == userId && x.IsActive== true)
                          .OrderBy(x=>x.SkillName);
            return result;
        }


    }
}