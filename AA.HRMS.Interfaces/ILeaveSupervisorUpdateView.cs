using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveSupervisorUpdateView
    {
        /// <summary>
        /// Gets or sets the leave identifier.
        /// </summary>
        /// <value>
        /// The leave identifier.
        /// </value>
        int LeaveID { get; set; }
        /// <summary>
        /// Gets or sets the leave status identifier.
        /// </summary>
        /// <value>
        /// The leave status identifier.
        /// </value>
        int LeaveStatusID { get; set; }
        /// <summary>
        /// Gets or sets the approving authority identifier.
        /// </summary>
        /// <value>
        /// The approving authority identifier.
        /// </value>
        string ApprovingAuthorityID { get; set; }
        /// <summary>
        /// Gets or sets the approving authority comment.
        /// </summary>
        /// <value>
        /// The approving authority comment.
        /// </value>
        string ApprovingAuthorityComment { get; set; }
        /// <summary>
        /// Gets or sets the date approved dept.
        /// </summary>
        /// <value>
        /// The date approved dept.
        /// </value>
        Nullable<System.DateTime> DateApprovedDept { get; set; }
        /// <summary>
        /// Gets or sets the leave status list.
        /// </summary>
        /// <value>
        /// The leave status list.
        /// </value>
        IList<SelectListItem> LeaveStatusList { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
