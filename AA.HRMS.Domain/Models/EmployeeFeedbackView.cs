using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AA.HRMS.Domain.Models
{
    public class EmployeeFeedbackView : IEmployeeFeedbackView
    {
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public string ProcessingMessages  { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public IList<ICompanyDetail> CompanyCollection { get; set; }
        public IList<IEmployee> EmployeeCollection { get; set; }
        public IList<IEmployeeFeedbackModel> feedbackList { get; set; }
    }
}
