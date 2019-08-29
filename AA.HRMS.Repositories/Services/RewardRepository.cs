using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class RewardRepository : IRewardRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="RewardRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public RewardRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the reward by identifier.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// rewardId
        /// or
        /// Get Reward By Id
        /// </exception>
        public IReward GetRewardById(int rewardId)
        {
            if (rewardId <= 0)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = RewardQueries.getRewardById(dbContext, rewardId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Reward By Id", e);
            }
        }

        /// <summary>
        /// Gets the name of the reward by.
        /// </summary>
        /// <param name="rewardName">Name of the reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Reward By Name</exception>
        public IReward GetRewardByName(string rewardName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var rewardInfo = RewardQueries.getRewardByName(dbContext, rewardName);
                    return rewardInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Reward By Name", e);
            }
        }

        /// <summary>
        /// Saves the reward information.
        /// </summary>
        /// <param name="rewardInfo">The reward information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardInfo</exception>
        public string SaveRewardInfo(IRewardView rewardInfo)
        {
            if (rewardInfo == null)
            {
                throw new ArgumentNullException(nameof(rewardInfo));
            }

            var result = string.Empty;

            var newRecord = new Reward
            {
                RewardName = rewardInfo.RewardName,
                CompanyId = rewardInfo.CompanyId,
                DateCreated = DateTime.UtcNow,
                Amount = rewardInfo.Amount,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Rewards.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Reward info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the edit reward information.
        /// </summary>
        /// <param name="rewardInfo">The reward information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardInfo</exception>
        public string SaveEditRewardInfo(IRewardView rewardInfo)
        {
            if (rewardInfo == null)
            {
                throw new ArgumentNullException(nameof(rewardInfo));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelInfo = dbContext.Rewards.SingleOrDefault(p => p.RewardId == rewardInfo.RewardId);

                    modelInfo.RewardName = rewardInfo.RewardName;
                    modelInfo.Amount = rewardInfo.Amount;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Reward info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete reward information.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardId</exception>
        public string SaveDeleteRewardInfo(int rewardId)
        {
            if (rewardId <= 0)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelView = dbContext.Rewards.Find(rewardId);

                    modelView.IsActive = false;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Reward info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// get Reward By RewardId
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Reward</exception>
        public IList<IReward> GetRewardByRewardId()
        {
            
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = RewardQueries.getRewardByRewardId(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Reward", e);
            }
        }
    }
}
