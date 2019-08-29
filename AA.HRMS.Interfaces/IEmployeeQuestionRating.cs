using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeQuestionRating
    {
         int EmployeeQuestionRatingId { get; set; }
         int EmployeeId { get; set; }
         int AppraisalQuestionId { get; set; }
        string Question { get; set; }
        int EmployeeAppraisalId { get; set; }
         int AppraisalId { get; set; }
         int AppraiseeRatingId { get; set; }
         int AppraiserRatingId { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateModified { get; set; }
         string Status { get; set; }
    }
}
