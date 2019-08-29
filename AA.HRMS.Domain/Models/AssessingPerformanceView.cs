using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class AssessingPerformanceView : IAssessingPerformanceView
    {
        public int AssessingPerformanceId { get; set; }
        public string Things_I_Did_Well { get; set; }
        public string Things_I_Did_Not_Do_So_Well { get; set; }
        public string My_Development_Plan { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public int PeriodId { get; set; }
        public string ProcessingMessage { get; set; }
    }
}
