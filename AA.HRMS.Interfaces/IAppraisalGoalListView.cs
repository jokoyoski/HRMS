using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalGoalListView
    {
        IList<IAppraisalGoal> AppraisalCollection { get; set; }
        IEmployeeAppraisal EmployeeAppraisal { get; set; }
        string ProcessingMessage { get; set; }
        string URL { get; set; }
    }
}
