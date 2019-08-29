using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class EmployeeAnnualAssessingPerformanceModel : IEmployeeAnnualAssessingPerformance
    {
        public int EmployeeAnnualAssesssingPerformanceId { get; set; }
        public int AnnualAssessingPerformanceId { get; set; }
        public string Thing_I_Did_Well { get; set; }
        public string Things_I_Did_Not_Do_Well { get; set; }
        public string Driven_Exceptional_Client_Service { get; set; }
        public string Highest_Performing_Teams { get; set; }
        public string Examples_Of_Living_Our_Values { get; set; }
        public string Enhanced_Quality_And_Effective_Risk_Management { get; set; }
        public int? ReviewerRatingId { get; set; }
        public int? RevieweeRatingId { get; set; }
        public int? FinalRatingId { get; set; }
        public string ReviewerComment { get; set; }
        public string FinalRatingComment { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Year { get; set; }
        public int? RevieweeId { get; set; }
        public string Reviewee { get; set; }
        public int? ReviewerId { get; set; }
        public string Reviewer { get; set; }
        public int? FinalReviewerId { get; set; }
        public string FinalReviewer { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateOfReviewee { get; set; }
        public DateTime? DateOfReviewer { get; set; }
        public DateTime? DateOfFinalReview { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
    }
}
