using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class RewardListView : IRewardListView
    {

        /// <summary>
        /// Gets or sets the reward collection.
        /// </summary>
        /// <value>
        /// The reward collection.
        /// </value>
        public IList<IReward> RewardCollection { get; set; }
        

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected reward.
        /// </summary>
        /// <value>
        /// The selected reward.
        /// </value>
        public string SelectedReward { get; set; }
    }
}
