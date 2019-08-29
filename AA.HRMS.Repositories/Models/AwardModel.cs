using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAward" />
    public class AwardModel : IAward
    {
        /// <summary>
        /// Gets or sets the award identifier.
        /// </summary>
        /// <value>
        /// The award identifier.
        /// </value>
        public int AwardId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the award.
        /// </summary>
        /// <value>
        /// The name of the award.
        /// </value>
        public string AwardName { get; set; }
        /// <summary>
        /// Gets or sets the award year.
        /// </summary>
        /// <value>
        /// The award year.
        /// </value>
        public int AwardYear { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
