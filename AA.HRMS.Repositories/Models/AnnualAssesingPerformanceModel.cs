using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class AnnualAssesingPerformanceModel : IAnnualAssesingPerformance
    {
        public int AnnualAssessingPerformanceId { get; set; }
        public int YearId { get; set; }
        public string Year { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsOpen { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string Status { get; set; }
    }
}
