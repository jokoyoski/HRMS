using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollHistoryListView
    {
        IList<IPayrollHistory> PayrollHistoryCollection { get; set; }

        string ProcessingMessage { get; set; }
    }
}
