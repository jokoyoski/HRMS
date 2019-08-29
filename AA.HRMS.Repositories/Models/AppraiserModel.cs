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
    /// <seealso cref="AA.HRMS.Interfaces.IAppraiser" />
    public class AppraiserModel : IAppraiser
    {
        /// <summary>
        /// Gets or sets the appraiser identifier.
        /// </summary>
        /// <value>
        /// The appraiser identifier.
        /// </value>
        public int AppraiserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the appraiser.
        /// </summary>
        /// <value>
        /// The name of the appraiser.
        /// </value>
        public string AppraiserName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
