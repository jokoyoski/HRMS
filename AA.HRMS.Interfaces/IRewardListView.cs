using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IRewardListView
    {

        /// <summary>
        /// Gets or sets the reward collection.
        /// </summary>
        /// <value>
        /// The reward collection.
        /// </value>
        IList<IReward> RewardCollection { get; set; }
        

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected reward.
        /// </summary>
        /// <value>
        /// The selected reward.
        /// </value>
        string SelectedReward { get; set; }
    }
}
