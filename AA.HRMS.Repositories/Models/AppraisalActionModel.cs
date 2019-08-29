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
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalAction" />
    public class AppraisalActionModel : IAppraisalAction
    {
        public int AppraisalActionId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the name of the comapny.
        /// </summary>
        /// <value>
        /// The name of the comapny.
        /// </value>
        public string ComapnyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the appraisal action.
        /// </summary>
        /// <value>
        /// The name of the appraisal action.
        /// </value>
        public string AppraisalActionName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
