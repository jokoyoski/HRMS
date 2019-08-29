using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAward
    {
        /// <summary>
        /// Gets or sets the award identifier.
        /// </summary>
        /// <value>
        /// The award identifier.
        /// </value>
        int AwardId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the award.
        /// </summary>
        /// <value>
        /// The name of the award.
        /// </value>
        string AwardName { get; set; }

        /// <summary>
        /// Gets or sets the award year.
        /// </summary>
        /// <value>
        /// The award year.
        /// </value>
        int AwardYear { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}
