using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class AnnualAssessingPerformanceListView : IAnnualAssessingPerformanceListView
    {
        public IList<IAnnualAssesingPerformance> AnnualAssesingPerformanceCollection { get; set; }
        
        public string ProcessingMessage { get; set; }
        
    }
}
