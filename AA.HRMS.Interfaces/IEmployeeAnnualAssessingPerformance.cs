using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeAnnualAssessingPerformance
    {
         int EmployeeAnnualAssesssingPerformanceId { get; set; }
         int AnnualAssessingPerformanceId { get; set; }
         string Thing_I_Did_Well { get; set; }
         string Things_I_Did_Not_Do_Well { get; set; }
         string Driven_Exceptional_Client_Service { get; set; }
         string Highest_Performing_Teams { get; set; }
         string Examples_Of_Living_Our_Values { get; set; }
         string Enhanced_Quality_And_Effective_Risk_Management { get; set; }
         int? ReviewerRatingId { get; set; }
         int? RevieweeRatingId { get; set; }
         int? FinalRatingId { get; set; }
         string ReviewerComment { get; set; }
         string FinalRatingComment { get; set; }
         int CompanyId { get; set; }
        string CompanyName { get; set; }
        string Year { get; set; }
        int? RevieweeId { get; set; }
        string Reviewee { get; set; }
         int? ReviewerId { get; set; }
        string Reviewer { get; set; }
         int? FinalReviewerId { get; set; }
        string FinalReviewer { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateOfReviewee { get; set; }
         DateTime? DateOfReviewer { get; set; }
         DateTime? DateOfFinalReview { get; set; }
         bool IsActive { get; set; }
        string Status { get; set; }
    }
}
