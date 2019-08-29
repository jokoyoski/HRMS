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
    /// <seealso cref="AA.HRMS.Interfaces.ILeaveRequestViewModel" />
    public class LeaveRequestViewModel : ILeaveRequestViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaveRequestViewModel"/> class.
        /// </summary>
        public LeaveRequestViewModel()
        {
            ProcessingMessage = String.Empty;
            LeaveTypeDropDown = new List<SelectListItem>();
            LeaveStatusDropDown = new List<SelectListItem>();
        }

        public int LeaveID { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeID { get; set; }
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }
        /// <summary>
        /// Gets or sets the leave type identifier.
        /// </summary>
        /// <value>
        /// The leave type identifier.
        /// </value>
        public int LeaveTypeID { get; set; }
        /// <summary>
        /// Gets or sets the name of the leave type.
        /// </summary>
        /// <value>
        /// The name of the leave type.
        /// </value>
        public string LeaveTypeName { get; set; }

        public int Duration { get; set; }

        public int AnnualLeaveDuration { get; set; }

        /// <summary>
        /// Gets or sets the date leave start.
        /// </summary>
        /// <value>
        /// The date leave start.
        /// </value>
        public System.DateTime DateLeaveStart { get; set; }
        /// <summary>
        /// Gets or sets the date leave ends.
        /// </summary>
        /// <value>
        /// The date leave ends.
        /// </value>
        public System.DateTime DateLeaveEnds { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the leave status identifier.
        /// </summary>
        /// <value>
        /// The leave status identifier.
        /// </value>
        public int LeaveStatusID { get; set; }
        /// <summary>
        /// Gets or sets the name of the leave status.
        /// </summary>
        /// <value>
        /// The name of the leave status.
        /// </value>
        public string LeaveStatusName { get; set; }

        /// <summary>
        /// Gets or sets the date requested.
        /// </summary>
        /// <value>
        /// The date requested.
        /// </value>
        public System.DateTime DateRequested { get; set; }

        /// <summary>
        /// Gets or sets the approving authority identifier.
        /// </summary>
        /// <value>
        /// The approving authority identifier.
        /// </value>
        public Nullable<int> ApprovingAuthorityID { get; set; }
        /// <summary>
        /// Gets or sets the name of the approving authority.
        /// </summary>
        /// <value>
        /// The name of the approving authority.
        /// </value>
        public string ApprovingAuthorityName { get; set; }

        /// <summary>
        /// Gets or sets the hr approver identifier.
        /// </summary>
        /// <value>
        /// The hr approver identifier.
        /// </value>
        public Nullable<int> HRApproverID { get; set; }
        /// <summary>
        /// Gets or sets the name of the hr approver.
        /// </summary>
        /// <value>
        /// The name of the hr approver.
        /// </value>
        public string HRApproverName { get; set; }

        /// <summary>
        /// Gets or sets the approving authority comment.
        /// </summary>
        /// <value>
        /// The approving authority comment.
        /// </value>
        public string ApprovingAuthorityComment { get; set; }
        /// <summary>
        /// Gets or sets the hr approver comment.
        /// </summary>
        /// <value>
        /// The hr approver comment.
        /// </value>
        public string HRApproverComment { get; set; }
        /// <summary>
        /// Gets or sets the date approved dept.
        /// </summary>
        /// <value>
        /// The date approved dept.
        /// </value>
        public Nullable<System.DateTime> DateApprovedDept { get; set; }
        /// <summary>
        /// Gets or sets the date approved hr.
        /// </summary>
        /// <value>
        /// The date approved hr.
        /// </value>
        public Nullable<System.DateTime> DateApprovedHR { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the leave type drop down.
        /// </summary>
        /// <value>
        /// The leave type drop down.
        /// </value>
        public IList<SelectListItem> LeaveTypeDropDown { get; set; }
        /// <summary>
        /// Gets or sets the leave status drop down.
        /// </summary>
        /// <value>
        /// The leave status drop down.
        /// </value>
        public IList<SelectListItem> LeaveStatusDropDown { get; set; }

        /// <summary>
        /// Gets or sets the type of the leave.
        /// </summary>
        /// <value>
        /// The type of the leave.
        /// </value>
        public ILeaveType LeaveType { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        public IGrade Grade { get; set; }

    }
}
