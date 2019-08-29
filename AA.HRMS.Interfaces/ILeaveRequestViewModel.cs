using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveRequestViewModel
    {
        /// <summary>
        /// Gets or sets the leave identifier.
        /// </summary>
        /// <value>
        /// The leave identifier.
        /// </value>
        int LeaveID { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeID { get; set; }
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        string EmployeeName { get; set; }

        string URL { get; set; }
        /// <summary>
        /// Gets or sets the leave type identifier.
        /// </summary>
        /// <value>
        /// The leave type identifier.
        /// </value>
        int LeaveTypeID { get; set; }
        /// <summary>
        /// Gets or sets the name of the leave type.
        /// </summary>
        /// <value>
        /// The name of the leave type.
        /// </value>
        string LeaveTypeName { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        int Duration { get; set; }
        /// <summary>
        /// Gets or sets the date leave start.
        /// </summary>
        /// <value>
        /// The date leave start.
        /// </value>
        System.DateTime DateLeaveStart { get; set; }
        /// <summary>
        /// Gets or sets the date leave ends.
        /// </summary>
        /// <value>
        /// The date leave ends.
        /// </value>
        System.DateTime DateLeaveEnds { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }
        /// <summary>
        /// Gets or sets the leave status identifier.
        /// </summary>
        /// <value>
        /// The leave status identifier.
        /// </value>
        int LeaveStatusID { get; set; }
        /// <summary>
        /// Gets or sets the name of the leave status.
        /// </summary>
        /// <value>
        /// The name of the leave status.
        /// </value>
        string LeaveStatusName { get; set; }
        /// <summary>
        /// Gets or sets the date requested.
        /// </summary>
        /// <value>
        /// The date requested.
        /// </value>
        System.DateTime DateRequested { get; set; }
        /// <summary>
        /// Gets or sets the approving authority identifier.
        /// </summary>
        /// <value>
        /// The approving authority identifier.
        /// </value>
        Nullable<int> ApprovingAuthorityID { get; set; }
        /// <summary>
        /// Gets or sets the name of the approving authority.
        /// </summary>
        /// <value>
        /// The name of the approving authority.
        /// </value>
        string ApprovingAuthorityName { get; set; }
        /// <summary>
        /// Gets or sets the hr approver identifier.
        /// </summary>
        /// <value>
        /// The hr approver identifier.
        /// </value>
        Nullable<int> HRApproverID { get; set; }
        /// <summary>
        /// Gets or sets the name of the hr approver.
        /// </summary>
        /// <value>
        /// The name of the hr approver.
        /// </value>
        string HRApproverName { get; set; }
        /// <summary>
        /// Gets or sets the approving authority comment.
        /// </summary>
        /// <value>
        /// The approving authority comment.
        /// </value>
        string ApprovingAuthorityComment { get; set; }
        /// <summary>
        /// Gets or sets the hr approver comment.
        /// </summary>
        /// <value>
        /// The hr approver comment.
        /// </value>
        string HRApproverComment { get; set; }
        /// <summary>
        /// Gets or sets the date approved dept.
        /// </summary>
        /// <value>
        /// The date approved dept.
        /// </value>
        Nullable<System.DateTime> DateApprovedDept { get; set; }
        /// <summary>
        /// Gets or sets the date approved hr.
        /// </summary>
        /// <value>
        /// The date approved hr.
        /// </value>
        Nullable<System.DateTime> DateApprovedHR { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

        int AnnualLeaveDuration { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the leave type drop down.
        /// </summary>
        /// <value>
        /// The leave type drop down.
        /// </value>
        IList<SelectListItem> LeaveTypeDropDown { get; set; }
        /// <summary>
        /// Gets or sets the leave status drop down.
        /// </summary>
        /// <value>
        /// The leave status drop down.
        /// </value>
        IList<SelectListItem> LeaveStatusDropDown { get; set; }

        /// <summary>
        /// Gets or sets the type of the leave.
        /// </summary>
        /// <value>
        /// The type of the leave.
        /// </value>
        ILeaveType LeaveType { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }

        IGrade Grade { get; set; }

    }
}
