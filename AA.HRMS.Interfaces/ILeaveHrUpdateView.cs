using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveHrUpdateView
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
        /// Gets or sets the hr approver identifier.
        /// </summary>
        /// <value>
        /// The hr approver identifier.
        /// </value>
        string HRApproverID { get; set; }
        /// <summary>
        /// Gets or sets the hr approver comment.
        /// </summary>
        /// <value>
        /// The hr approver comment.
        /// </value>
        string HRApproverComment { get; set; }
        /// <summary>
        /// Gets or sets the date approved hr.
        /// </summary>
        /// <value>
        /// The date approved hr.
        /// </value>
        Nullable<System.DateTime> DateApprovedHR { get; set; }
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
