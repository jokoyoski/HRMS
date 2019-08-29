using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAppraisalView
    {

         int AppraisalId { get; set; }
         DateTime DateInitiated { get; set; }
         int AppraisalYearId { get; set; }
         string AppraisalYearName { get; set; }
         int AppraisalPeriodId { get; set; }
         string AppraisalPeriodName { get; set; }
         int CompanyId { get; set; }
         string CompanyName { get; set; }
         bool IsActive { get; set; }
         DateTime? DateModified { get; set; }
         bool IsOpened { get; set; }

        IList<IAppraisalQualitativeMetric> AppraisalQualitativeMetric { get; set; }

       
        IList<IAppraisalQuantitativeMetric> AppraisalQuantitativeMetric { get; set; }

        IList<IEmployeeQuestionRating> EmployeeQuestionAppraisalCollection { get; set; }

        IList<SelectListItem> GetAppraiserRatingDDL(int appraiserRatingId);

        IList<IAppraisalRating> AppraiseeRatingCollection { get; set; }

        IList<IAppraisalGoal> AppraisalGoalCollection { get; set; }

        IList<IResult> ResultCollection { get; set; }

        IList<SelectListItem> GetAppraiseeRatingDDL(int appraiseeRatingId);

        IList<SelectListItem> ResultDropDown { get; set; }

        string Target { get; set; }

        /// <summary>
        /// Gets or sets the appraiser rating drop down.
        /// </summary>
        /// <value>
        /// The appraiser rating drop down.
        /// </value>
        IList<SelectListItem> AppraiserRatingDropDown { get; set; }

        /// <summary>
        /// Gets or sets the appraisee rating drop down.
        /// </summary>
        /// <value>
        /// The appraisee rating drop down.
        /// </value>
        IList<SelectListItem> AppraiseeRatingDropDown { get; set; }

        /// <summary>
        /// Gets or sets the appraiser drop down.
        /// </summary>
        /// <value>
        /// The appraiser drop down.
        /// </value>
        IList<SelectListItem> AppraiserDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal rating drop down.
        /// </summary>
        /// <value>
        /// The appraisal rating drop down.
        /// </value>
         IList<SelectListItem> AppraisalRatingDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal recommended action drop down.
        /// </summary>
        /// <value>
        /// The appraisal recommended action drop down.
        /// </value>
         IList<SelectListItem> AppraisalRecommendedActionDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal final rating drop down.
        /// </summary>
        /// <value>
        /// The appraisal final rating drop down.
        /// </value>
         IList<SelectListItem> AppraisalFinalRatingDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal approved action drop down.
        /// </summary>
        /// <value>
        /// The appraisal approved action drop down.
        /// </value>
         IList<SelectListItem> AppraisalApprovedActionDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal period drop down list.
        /// </summary>
        /// <value>
        /// The appraisal period drop down list.
        /// </value>
         IList<SelectListItem> AppraisalPeriodDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
         IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the year drop down.
        /// </summary>
        /// <value>
        /// The year drop down.
        /// </value>
         IList<SelectListItem> YearDropDown { get; set; }
        
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
         string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string URL { get; set; }

        /// <summary>
        /// Gets or sets the employee appraisal collection.
        /// </summary>
        /// <value>
        /// The employee appraisal collection.
        /// </value>
        IList<IEmployeeAppraisal> EmployeeAppraisalCollection { get; set; }

        IList<IAppraisal> AppraialCollection { get; set; }

        /// <summary>
        /// Gets or sets the employee appraisal.
        /// </summary>
        /// <value>
        /// The employee appraisal.
        /// </value>
        IEmployeeAppraisal EmployeeAppraisal { get; set; }

        /// <summary>
        /// Gets or sets the appraisal questions.
        /// </summary>
        /// <value>
        /// The appraisal questions.
        /// </value>
        IList<IAppraisalQuestion> AppraisalQuestions { get; set; }
        
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Appraisee { get; set; }

        /// <summary>
        /// Gets or sets the supervisor.
        /// </summary>
        /// <value>
        /// The supervisor.
        /// </value>
        IEmployee Appraiser { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserDetail User { get; set; }
    }
}
