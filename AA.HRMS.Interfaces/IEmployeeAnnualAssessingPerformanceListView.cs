using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeAnnualAssessingPerformanceListView
    {
        IList<IEmployeeAnnualAssessingPerformance> EmployeeAnnualAssessingPerformance { get; set; }
        string ProcessingMessage { get; set; }
        string URL { get; set; }
    }
}
