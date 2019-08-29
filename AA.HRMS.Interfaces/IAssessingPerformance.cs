using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IAssessingPerformance
    {
         int AssessingPerformanceId { get; set; }
         string Things_I_Did_Well { get; set; }
         string Things_I_Did_Not_Do_So_Well { get; set; }
         string My_Development_Plan { get; set; }
         int CompanyId { get; set; }
         int EmployeeId { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
         int PeriodId { get; set; }
    }
}
