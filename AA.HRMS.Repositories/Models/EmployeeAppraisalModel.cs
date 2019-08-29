using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class EmployeeAppraisalModel : IEmployeeAppraisal
    {
        public int EmployeeAppraisalId { get; set; }
        public int? SupervisorId { get; set; }
        public string SupervisorName { get; set; }
        public int AppraisalId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int HRId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public string AppraisalPeriod { get; set; }
        public string AppraisalYear { get; set; }
        public DateTime DateInitiated { get; set; }
        public string Status { get; set; }
        public bool IsOpened { get; set; }
        public string Things_I_Did_Well { get; set; }
        public string Things_I_Did_Not_Do_So_Well { get; set; }
        public string My_Development_Plan { get; set; }
        public string CompanyName { get; set; }
    }
}
