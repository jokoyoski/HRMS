using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalQuestionListView
    {
        IList<IAppraisalQuestion> appraisalquestion { get; set; }

        int AppraisalQuestionId { get; set; }

        string Question { get; set; }
        
        int CompanyId { get; set; }
        
        bool IsActive { get; set; }
        
        System.DateTime DateCreated { get; set; }
        
        Nullable<System.DateTime> DateModified { get; set; }

        string ProcessingMessage { get; set; }

    }
}
