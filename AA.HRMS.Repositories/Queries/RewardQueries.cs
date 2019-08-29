using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    internal static class RewardQueries
    {
        /// <summary>
        /// Gets the reward by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        internal static IReward getRewardById(HRMSEntities db, int rewardId)
        {
            var result = (from s in db.Rewards
                          where s.RewardId.Equals(rewardId)
                          select new Models.RewardModel
                          {
                              RewardId = s.RewardId,
                              RewardName = s.RewardName,
                              Amount = s.Amount,
                              IsActive_ = s.IsActive,
                              CompanyId = s.CompanyId,
                              DateCreated = s.DateCreated

                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the name of the reward by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="rewardName">Name of the reward.</param>
        /// <returns></returns>
        internal static IReward getRewardByName(HRMSEntities db, string rewardName)
        {
            var result = (from a in db.Rewards
                          where a.RewardName.Equals(rewardName)
                          select new Models.RewardModel
                          {
                              RewardId = a.RewardId,
                              RewardName = a.RewardName,
                              Amount = a.Amount,
                              DateCreated = a.DateCreated,
                              IsActive_ = a.IsActive,
                              CompanyId = a.CompanyId

                          }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the reward by reward identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IReward> getRewardByRewardId(HRMSEntities db)
        {
            var result = (from s in db.Rewards
                         select new Models.RewardModel
                          {
                              RewardId = s.RewardId,
                              RewardName = s.RewardName,
                              Amount = s.Amount,
                              IsActive_ = s.IsActive,
                              CompanyId = s.CompanyId,
                              DateCreated = s.DateCreated

                          }).ToList();

            return result;
        }
    }
}
