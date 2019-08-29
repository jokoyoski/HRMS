using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeAppraisal
    {
         int EmployeeAppraisalId { get; set; }
         int? SupervisorId { get; set; }
        string SupervisorName { get; set; }
        int AppraisalId { get; set; }
         int EmployeeId { get; set; }
        string EmployeeName { get; set; }
        int HRId { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateModified { get; set; }
         bool IsActive { get; set; }
         int CompanyId { get; set; }
        string CompanyName { get; set; }
        string AppraisalPeriod { get; set; }
        string AppraisalYear { get; set; }
        DateTime DateInitiated { get; set; }
         string Status { get; set; }
        bool IsOpened { get; set; }
        string Things_I_Did_Well { get; set; }
        string Things_I_Did_Not_Do_So_Well { get; set; }
        string My_Development_Plan { get; set; }

    }
}
