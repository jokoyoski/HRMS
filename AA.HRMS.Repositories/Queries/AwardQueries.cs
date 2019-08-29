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
    internal static class AwardQueries
    {
        /// <summary>
        /// Gets the award by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        internal static IAward GetAwardById(HRMSEntities db, int awardId)
        {
            var result = (from d in db.Awards
                          where d.AwardId.Equals(awardId)
                          select new AwardModel
                          {
                              AwardId = d.AwardId,
                              UserId = d.UserId,
                              AwardName = d.AwardName,
                              AwardYear = d.AwardYear,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                          }).FirstOrDefault();
            return result;
        }
    }
}
