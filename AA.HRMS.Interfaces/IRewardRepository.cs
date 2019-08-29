using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IRewardRepository
    {
        /// <summary>
        /// Gets the reward by identifier.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        IReward GetRewardById(int rewardId);

        /// <summary>
        /// Gets the name of the reward by.
        /// </summary>
        /// <param name="rewardName">Name of the reward.</param>
        /// <returns></returns>
        IReward GetRewardByName(string rewardName);

        /// <summary>
        /// Saves the reward information.
        /// </summary>
        /// <param name="rewardInfo">The reward information.</param>
        /// <returns></returns>
        string SaveRewardInfo(IRewardView rewardInfo);

        /// <summary>
        /// Saves the edit reward information.
        /// </summary>
        /// <param name="rewardInfo">The reward information.</param>
        /// <returns></returns>
        string SaveEditRewardInfo(IRewardView rewardInfo);

        /// <summary>
        /// Saves the delete reward information.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        string SaveDeleteRewardInfo(int rewardId);

        /// <summary>
        /// get Reward By RewardId
        /// </summary>
        /// <param name="rewardId"></param>
        /// <returns></returns>
        IList<IReward> GetRewardByRewardId();
    }
}
