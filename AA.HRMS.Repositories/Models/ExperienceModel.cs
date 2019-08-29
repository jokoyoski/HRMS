using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IExperience" />
    public class ExperienceModel : IExperience
    {
        /// <summary>
        /// Gets or sets the experience identifier.
        /// </summary>
        /// <value>
        /// The experience identifier.
        /// </value>
        public int ExperienceId { get; set; }
        /// <summary>
        /// Gets or sets the experience1.
        /// </summary>
        /// <value>
        /// The experience1.
        /// </value>
        public string Experience { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
