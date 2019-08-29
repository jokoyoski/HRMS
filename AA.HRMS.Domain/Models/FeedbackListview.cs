using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class FeedbackListview : IFeedbackListview
    {
        public FeedbackListview()
        {
            feedbackModel = new List<IFeedbackModel>();
        }

        public IList<IFeedbackModel> feedbackModel { get; set; }
        public IList<ICompanyDetail> companyDetail { get; set; }
        public IList<IYear> yearCollection { get; set; }
        //public IList<IEmployeeFeedbackModel> employeeFeedback { get; set; }
        public int FeedbackId { get; set; }
        public int YearId { get; set; }
        public int CompanyId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsLock { get; set; }
        public string ProcessingMessage { get; set; }
    }
}
