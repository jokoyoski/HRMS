using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeTaskListView
    {
        IList<IEmployeeTask> EmployeeTaskCollection { get; set; }


        string ProcessingMessage { get; set; }
    }
}
