using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IAnnualAssesingPerformance
    {
         int AnnualAssessingPerformanceId { get; set; }
        int YearId { get; set; }
         string Year { get; set; }
        int CompanyId { get; set; }
        string CompanyName { get; set; }
        bool IsOpen { get; set; }
        bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateModified { get; set; }
        string Status { get; set; }
    }
}
