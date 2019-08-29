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
    public interface IAppraisalAction
    {
        /// <summary>
        /// Gets or sets the appraisal action identifier.
        /// </summary>
        /// <value>
        /// The appraisal action identifier.
        /// </value>
        int AppraisalActionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the appraisal action.
        /// </summary>
        /// <value>
        /// The name of the appraisal action.
        /// </value>
        string AppraisalActionName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the name of the comapny.
        /// </summary>
        /// <value>
        /// The name of the comapny.
        /// </value>
        string ComapnyName { get; set; }
    }
}
