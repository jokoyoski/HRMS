using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ILeaveRequestModel" />
    public class LeaveRequestModel : ILeaveRequestModel
    {
        //public int LeaveId { get; set; }
        //public int EmployeeId { get; set; }
        //public int LeaveTypeId { get; set; }
        //public System.DateTime DateLeaveStart { get; set; }
        //public System.DateTime DateLeaveEnds { get; set; }
        //public string Comment { get; set; }
        //public int LeaveStatusId { get; set; }
        //public System.DateTime DateRequested { get; set; }
        //public Nullable<int> ApprovingAuthorityId { get; set; }
        //public Nullable<int> HRApproverId { get; set; }
        //public string ApprovingAuthorityComment { get; set; }
        //public string HRApproverComment { get; set; }
        //public Nullable<System.DateTime> DateApprovedDept { get; set; }
        //public Nullable<System.DateTime> DateApprovedHR { get; set; }
        //public System.DateTime DateCreated { get; set; }



        public int LeaveId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the leave type identifier.
        /// </summary>
        /// <value>
        /// The leave type identifier.
        /// </value>
        public int LeaveTypeId { get; set; }
        /// <summary>
        /// Gets or sets the name of the leave type.
        /// </summary>
        /// <value>
        /// The name of the leave type.
        /// </value>
        public string LeaveTypeName { get; set; }

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
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the leave status identifier.
        /// </summary>
        /// <value>
        /// The leave status identifier.
        /// </value>
        public int LeaveStatusId { get; set; }
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
        public Nullable<int> ApprovingAuthorityId { get; set; }
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
        public Nullable<int> HRApproverId { get; set; }
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
    }
}
