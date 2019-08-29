using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalLog
    {
        /// <summary>
        /// Gets or sets the appraisal log identifier.
        /// </summary>
        /// <value>
        /// The appraisal log identifier.
        /// </value>
        int AppraisalLogId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal identifier.
        /// </summary>
        /// <value>
        /// The appraisal identifier.
        /// </value>
        int AppraisalId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the supervisor identifier.
        /// </summary>
        /// <value>
        /// The supervisor identifier.
        /// </value>
        int SupervisorId { get; set; }
        /// <summary>
        /// Gets or sets the hr identifier.
        /// </summary>
        /// <value>
        /// The hr identifier.
        /// </value>
        int HRId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        DateTime? DateModified { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        string Status { get; set; }
    }
}
