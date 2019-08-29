using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveRequestModelView
    {
        int LeaveID { get; set; }
        string EmployeeID { get; set; }
        int LeaveTypeID { get; set; }
        System.DateTime DateLeaveStart { get; set; }
        System.DateTime DateLeaveEnds { get; set; }
        string Comment { get; set; }
        int LeaveStatusID { get; set; }
        System.DateTime DateRequested { get; set; }
        string ApprovingAuthorityID { get; set; }
        string HRApproverID { get; set; }
        string ApprovingAuthorityComment { get; set; }
        string HRApproverComment { get; set; }
        Nullable<System.DateTime> DateApprovedDept { get; set; }
        System.DateTime DateCreated { get; set; }
        string ProcessingMessage { get; set; }
        IList<SelectListItem> LeaveTypeList { get; set; }
    }
}
