using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class EmployeeAnnualAssessingPerformanceListView : IEmployeeAnnualAssessingPerformanceListView
    {
        public IList<IEmployeeAnnualAssessingPerformance> EmployeeAnnualAssessingPerformance { get; set; }
        public string ProcessingMessage { get; set; }
        public string URL { get; set; }
    }
}
