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
    public interface IExperience
    {
        /// <summary>
        /// Gets or sets the experience identifier.
        /// </summary>
        /// <value>
        /// The experience identifier.
        /// </value>
        int ExperienceId { get; set; }
        /// <summary>
        /// Gets or sets the experience1.
        /// </summary>
        /// <value>
        /// The experience1.
        /// </value>
        string Experience { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}
