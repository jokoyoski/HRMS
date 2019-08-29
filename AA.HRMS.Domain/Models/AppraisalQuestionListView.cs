using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    class AppraisalQuestionListView: IAppraisalQuestionListView
    {
        public AppraisalQuestionListView()
        {
            this.appraisalquestion = new List<IAppraisalQuestion>();
        }
        public int AppraisalQuestionId { get; set; }
        public string Question { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public IList<IAppraisalQuestion> appraisalquestion { get; set; }
        public string ProcessingMessage { get; set; }

    }
}
