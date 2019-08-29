using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class EmployeeRewardModel : IEmployeeReward
    {
        /// <summary>
        /// Gets or sets the employee reward identifier.
        /// </summary>
        /// <value>
        /// The employee reward identifier.
        /// </value>
        public int EmployeeRewardId { get; set; }

        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the reward identifier.
        /// </summary>
        /// <value>
        /// The reward identifier.
        /// </value>
        public int RewardId { get; set; }
        /// <summary>
        /// Gets or sets the name of the reward.
        /// </summary>
        /// <value>
        /// The name of the reward.
        /// </value>
        public string RewardName { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        public string companyName { get; set; }
        public string employeeName { get; set; }
        public string rewardName { get; set; }
    }
}
