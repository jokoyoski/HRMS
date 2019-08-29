using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeAnnualAssessingPerformanceView
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
         int? RevieweeId { get; set; }
         int? ReviewerId { get; set; }
         int? FinalReviewerId { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateOfReviewee { get; set; }
         DateTime? DateOfReviewer { get; set; }
         DateTime? DateOfFinalReview { get; set; }
         bool IsActive { get; set; }
         string ProcessingMessage { get; set; }
        string Status { get; set; }
        IList<SelectListItem> ReviewerRatingDropDown { get; set; }
        IList<SelectListItem> RevieweeRatingDropDown { get; set; }
        IList<SelectListItem> FinalRatingDropDown { get; set; }
        ICompanyDetail Company { get; set; }
        IEmployee Reviewee { get; set; }
        IEmployee Reviewer { get; set; }
        IAnnualAssesingPerformance AnnualAssesingPerformance { get; set; }
        IList<IAppraisalRating> RatingColletion { get; set; }
        string URL { get; set; }
    }
}
