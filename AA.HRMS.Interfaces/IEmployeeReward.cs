using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeReward
    {
        /// <summary>
        /// Gets or sets the employee reward identifier.
        /// </summary>
        /// <value>
        /// The employee reward identifier.
        /// </value>
        int EmployeeRewardId { get; set; }

        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the reward identifier.
        /// </summary>
        /// <value>
        /// The reward identifier.
        /// </value>
        int RewardId { get; set; }
        /// <summary>
        /// Gets or sets the name of the reward.
        /// </summary>
        /// <value>
        /// The name of the reward.
        /// </value>
        string RewardName { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string companyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string employeeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string rewardName { get; set; }
    }
}
