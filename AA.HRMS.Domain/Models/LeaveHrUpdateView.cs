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
    /// <seealso cref="AA.HRMS.Interfaces.ILeaveHrUpdateView" />
    public class LeaveHrUpdateView : ILeaveHrUpdateView
    {
        /// <summary>
        /// Gets or sets the leave identifier.
        /// </summary>
        /// <value>
        /// The leave identifier.
        /// </value>
        public int LeaveID { get; set; }
        /// <summary>
        /// Gets or sets the leave status identifier.
        /// </summary>
        /// <value>
        /// The leave status identifier.
        /// </value>
        public int LeaveStatusID { get; set; }
        /// <summary>
        /// Gets or sets the hr approver identifier.
        /// </summary>
        /// <value>
        /// The hr approver identifier.
        /// </value>
        public string HRApproverID { get; set; }
        /// <summary>
        /// Gets or sets the hr approver comment.
        /// </summary>
        /// <value>
        /// The hr approver comment.
        /// </value>
        public string HRApproverComment { get; set; }
        /// <summary>
        /// Gets or sets the date approved hr.
        /// </summary>
        /// <value>
        /// The date approved hr.
        /// </value>
        public Nullable<System.DateTime> DateApprovedHR { get; set; }
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
