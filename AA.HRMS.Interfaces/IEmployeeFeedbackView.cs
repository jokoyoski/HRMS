using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeFeedbackView
    {
         int CompanyId { get; set; }
         int EmployeeId { get; set; }
         string ProcessingMessages { get; set; }
         Nullable<bool> IsActive { get; set; }
         IList<ICompanyDetail> CompanyCollection { get; set; }
         IList<IEmployee> EmployeeCollection { get; set; }
        IList<IEmployeeFeedbackModel> feedbackList { get; set; }
    }
}
