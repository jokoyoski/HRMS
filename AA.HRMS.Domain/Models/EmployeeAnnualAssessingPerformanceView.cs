using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class EmployeeAnnualAssessingPerformanceView : IEmployeeAnnualAssessingPerformanceView
    {

        public EmployeeAnnualAssessingPerformanceView()
        {
            this.RevieweeRatingDropDown = new List<SelectListItem>();
            this.ReviewerRatingDropDown = new List<SelectListItem>();
            this.FinalRatingDropDown = new List<SelectListItem>();

        }
        public int EmployeeAnnualAssesssingPerformanceId { get; set; }
        public int AnnualAssessingPerformanceId { get; set; }
        public string Thing_I_Did_Well { get; set; }
        public string Things_I_Did_Not_Do_Well { get; set; }
        public string Driven_Exceptional_Client_Service { get; set; }
        public string Highest_Performing_Teams { get; set; }
        public string Examples_Of_Living_Our_Values { get; set; }
        public string Enhanced_Quality_And_Effective_Risk_Management { get; set; }
        public int? ReviewerRatingId { get; set; }
        public IList<SelectListItem> ReviewerRatingDropDown { get; set; }
        public int? RevieweeRatingId { get; set; }
        public IList<SelectListItem> RevieweeRatingDropDown { get; set; }
        public int? FinalRatingId { get; set; }
        public IList<SelectListItem> FinalRatingDropDown { get; set; }
        public string ReviewerComment { get; set; }
        public string FinalRatingComment { get; set; }
        public int CompanyId { get; set; }
        public int? RevieweeId { get; set; }
        public int? ReviewerId { get; set; }
        public int? FinalReviewerId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateOfReviewee { get; set; }
        public DateTime? DateOfReviewer { get; set; }
        public DateTime? DateOfFinalReview { get; set; }
        public bool IsActive { get; set; }
        public string ProcessingMessage { get; set; }
        public string Status { get; set; }
        public ICompanyDetail Company { get; set; }
        public IEmployee Reviewee { get; set; }
        public IEmployee Reviewer { get; set; }
        public IAnnualAssesingPerformance AnnualAssesingPerformance { get; set; }
        public IList<IAppraisalRating> RatingColletion { get; set; }

        public string URL { get; set; }
    }
}
