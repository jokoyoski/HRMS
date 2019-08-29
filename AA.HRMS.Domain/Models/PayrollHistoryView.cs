using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class PayrollHistoryView : IPayrollHistoryView
    {
        public int PayrollHistoryId { get; set; }
        public int Year { get; set; }
        public string YearName { get; set; }
        public string MonthCode { get; set; }
        public string MonthName { get; set; }
        public DateTime DateCreated { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public string ProcessingMessage { get; set; }
    }
}
