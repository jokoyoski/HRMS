using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollHistoryView
    {
         int PayrollHistoryId { get; set; }
         int Year { get; set; }
        string YearName { get; set; }
        string MonthCode { get; set; }
        string MonthName { get; set; }
        DateTime DateCreated { get; set; }
         int CompanyId { get; set; }
         bool IsActive { get; set; }
         string ProcessingMessage { get; set; }
    }
}
