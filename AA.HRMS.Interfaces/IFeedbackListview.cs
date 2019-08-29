using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IFeedbackListview
    {

          IList<IFeedbackModel> feedbackModel { get; set; }
        IList<ICompanyDetail> companyDetail { get; set; }
        IList<IYear> yearCollection { get; set; }
        //IList<IEmployeeFeedbackModel> employeeFeedback { get; set; }
        int FeedbackId { get; set; }
          int YearId { get; set; }
          int CompanyId { get; set; }
          DateTime DateCreated { get; set; }
          bool IsActive { get; set; }
          bool IsLock { get; set; }
          string ProcessingMessage { get; set; }
    }
}
