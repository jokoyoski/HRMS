using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class EmployeeQuestionRatingModel : IEmployeeQuestionRating
    {
        public int EmployeeQuestionRatingId { get; set; }
        public int EmployeeId { get; set; }
        public int AppraisalQuestionId { get; set; }
        public string Question { get; set; }
        public int EmployeeAppraisalId { get; set; }
        public int AppraisalId { get; set; }
        public int AppraiseeRatingId { get; set; }
        public int AppraiserRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string Status { get; set; }
    }
}
