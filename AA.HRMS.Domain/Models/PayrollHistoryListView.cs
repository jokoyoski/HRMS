using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class PayrollHistoryListView : IPayrollHistoryListView
    {
        public IList<IPayrollHistory> PayrollHistoryCollection { get; set; }

        public string ProcessingMessage { get; set; }
    }
}
