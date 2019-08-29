using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ILeaveSupervisorUpdateView" />
    public class LeaveSupervisorUpdateView : ILeaveSupervisorUpdateView
    {
        public int LeaveID { get; set; }
        /// <summary>
        /// Gets or sets the leave status identifier.
        /// </summary>
        /// <value>
        /// The leave status identifier.
        /// </value>
        public int LeaveStatusID { get; set; }
        /// <summary>
        /// Gets or sets the approving authority identifier.
        /// </summary>
        /// <value>
        /// The approving authority identifier.
        /// </value>
        public string ApprovingAuthorityID { get; set; }
        /// <summary>
        /// Gets or sets the approving authority comment.
        /// </summary>
        /// <value>
        /// The approving authority comment.
        /// </value>
        public string ApprovingAuthorityComment { get; set; }
        /// <summary>
        /// Gets or sets the date approved dept.
        /// </summary>
        /// <value>
        /// The date approved dept.
        /// </value>
        public Nullable<System.DateTime> DateApprovedDept { get; set; }
        /// <summary>
        /// Gets or sets the leave status list.
        /// </summary>
        /// <value>
        /// The leave status list.
        /// </value>
        public IList<SelectListItem> LeaveStatusList { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
