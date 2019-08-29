using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class LeaveRequestModelView : ILeaveRequestModelView
    {
        public int LeaveID { get; set; }
        public string EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
        public System.DateTime DateLeaveStart { get; set; }
        public System.DateTime DateLeaveEnds { get; set; }
        public string Comment { get; set; }
        public int LeaveStatusID { get; set; }
        public System.DateTime DateRequested { get; set; }
        public string ApprovingAuthorityID { get; set; }
        public string HRApproverID { get; set; }
        public string ApprovingAuthorityComment { get; set; }
        public string HRApproverComment { get; set; }
        public Nullable<System.DateTime> DateApprovedDept { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string ProcessingMessage { get; set; }
        public IList<SelectListItem> LeaveTypeList { get; set; }

    }
}
