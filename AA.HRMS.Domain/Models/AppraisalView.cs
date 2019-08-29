using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using System.Web.Mvc;
using AA.Infrastructure.Extensions;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalView" />
    public class AppraisalView : IAppraisalView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppraisalView"/> class.
        /// </summary>
        public AppraisalView()
        {
            
            IsActive = true;
            DateInitiated = DateTime.UtcNow;
            this.AppraiserDropDown = new List<SelectListItem>();
            this.AppraisalRecommendedActionDropDown = new List<SelectListItem>();
            this.AppraisalRatingDropDown = new List<SelectListItem>();
            this.AppraisalApprovedActionDropDown = new List<SelectListItem>();
            this.AppraisalFinalRatingDropDown = new List<SelectListItem>();
            this.CompanyDropDownList = new List<SelectListItem>();
            this.AppraisalPeriodDropDownList = new List<SelectListItem>();
            this.YearDropDown = new List<SelectListItem>();
            this.AppraiserRatingDropDown = new List<SelectListItem>();
            this.AppraiseeRatingDropDown = new List<SelectListItem>();
            this.ResultDropDown = new List<SelectListItem>();
        }

        public int AppraisalId { get; set; }
        public DateTime DateInitiated { get; set; }
        public int AppraisalYearId { get; set; }
        public string AppraisalYearName { get; set; }
        public int AppraisalPeriodId { get; set; }
        public string AppraisalPeriodName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsOpened { get; set; }

        public string Target { get; set; }


        public IList<IAppraisalQualitativeMetric> AppraisalQualitativeMetric { get; set; }

        /// <summary>
        /// Gets or sets the appraisal quantitative metric.
        /// </summary>
        /// <value>
        /// The appraisal quantitative metric.
        /// </value>
        public IList<IAppraisalQuantitativeMetric> AppraisalQuantitativeMetric { get; set; }


        /// <summary>
        /// Gets or sets the appraisee rating drop down.
        /// </summary>
        /// <value>
        /// The appraisee rating drop down.
        /// </value>
        public IList<SelectListItem> AppraiseeRatingDropDown { get; set; }

        /// <summary>
        /// Gets or sets the result drop down.
        /// </summary>
        /// <value>
        /// The result drop down.
        /// </value>
        public IList<SelectListItem> ResultDropDown { get; set; }

        /// <summary>
        /// Gets or sets the appraisee rating collection.
        /// </summary>
        /// <value>
        /// The appraisee rating collection.
        /// </value>
        public IList<IAppraisalRating> AppraiseeRatingCollection { get; set; }

        /// <summary>
        /// Gets or sets the appraisal goal collection.
        /// </summary>
        /// <value>
        /// The appraisal goal collection.
        /// </value>
        public IList<IAppraisalGoal> AppraisalGoalCollection { get; set; }

        public IList<IResult> ResultCollection { get; set; }

        /// <summary>
        /// Gets or sets the appraiser rating drop down.
        /// </summary>
        /// <value>
        /// The appraiser rating drop down.
        /// </value>
        public IList<SelectListItem> AppraiserRatingDropDown { get; set; }

        /// <summary>
        /// Gets or sets the appraiser drop down.
        /// </summary>
        /// <value>
        /// The appraiser drop down.
        /// </value>
        public IList<SelectListItem> AppraiserDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal rating drop down.
        /// </summary>
        /// <value>
        /// The appraisal rating drop down.
        /// </value>
        public IList<SelectListItem> AppraisalRatingDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal recommended action drop down.
        /// </summary>
        /// <value>
        /// The appraisal recommended action drop down.
        /// </value>
        public IList<SelectListItem> AppraisalRecommendedActionDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal final rating drop down.
        /// </summary>
        /// <value>
        /// The appraisal final rating drop down.
        /// </value>
        public IList<SelectListItem> AppraisalFinalRatingDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal approved action drop down.
        /// </summary>
        /// <value>
        /// The appraisal approved action drop down.
        /// </value>
        public IList<SelectListItem> AppraisalApprovedActionDropDown { get; set; }
        /// <summary>
        /// Gets or sets the appraisal period drop down list.
        /// </summary>
        /// <value>
        /// The appraisal period drop down list.
        /// </value>
        public IList<SelectListItem> AppraisalPeriodDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the year drop down.
        /// </summary>
        /// <value>
        /// The year drop down.
        /// </value>
        public IList<SelectListItem> YearDropDown { get; set; }

        /// <summary>
        /// Gets the appraisee rating DDL.
        /// </summary>
        /// <param name="appraiseeRatingId">The appraisee rating identifier.</param>
        /// <returns></returns>
        public IList<SelectListItem> GetAppraiseeRatingDDL(int appraiseeRatingId)
        {
            this.AppraisalRatingDropDown.Each(x => x.Selected = false);

            this.AppraisalRatingDropDown.Where(x => x.Value == "-1").Each(y => y.Selected = true);

            var result = new List<SelectListItem>();

            if (appraiseeRatingId < 1)
            {
                return this.AppraisalRatingDropDown;
            }

            this.AppraisalRatingDropDown.Each(x => x.Selected = false);
            this.AppraisalRatingDropDown.Where(x => x.Value == appraiseeRatingId.ToString()).Each(y => y.Selected = true);

            return this.AppraisalRatingDropDown;
        }

        /// <summary>
        /// Gets the appraiser rating DDL.
        /// </summary>
        /// <param name="appraiserRatingId">The appraiser rating identifier.</param>
        /// <returns></returns>
        public IList<SelectListItem> GetAppraiserRatingDDL(int appraiserRatingId)
        {
            this.AppraisalRatingDropDown.Each(x => x.Selected = false);

            this.AppraisalRatingDropDown.Where(x => x.Value == "-1").Each(y => y.Selected = true);

            var result = new List<SelectListItem>();

            if (appraiserRatingId < 1)
            {
                return this.AppraisalRatingDropDown;
            }

            this.AppraisalRatingDropDown.Each(x => x.Selected = false);
            this.AppraisalRatingDropDown.Where(x => x.Value == appraiserRatingId.ToString()).Each(y => y.Selected = true);

            return this.AppraisalRatingDropDown;
        }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the employee appraisal collection.
        /// </summary>
        /// <value>
        /// The employee appraisal collection.
        /// </value>
        public IList<IEmployeeAppraisal> EmployeeAppraisalCollection { get; set; }

        /// <summary>
        /// Gets or sets the employee appraisal collection.
        /// </summary>
        /// <value>
        /// The employee appraisal collection.
        /// </value>
        public IList<IEmployeeQuestionRating> EmployeeQuestionAppraisalCollection { get; set; }

        /// <summary>
        /// Gets or sets the appraisal questions.
        /// </summary>
        /// <value>
        /// The appraisal questions.
        /// </value>
        public IList<IAppraisalQuestion> AppraisalQuestions { get; set; }

        /// <summary>
        /// Gets or sets the appraial collection.
        /// </summary>
        /// <value>
        /// The appraial collection.
        /// </value>
        public IList<IAppraisal> AppraialCollection { get; set; }

        /// <summary>
        /// Gets or sets the employee appraisal.
        /// </summary>
        /// <value>
        /// The employee appraisal.
        /// </value>
        public IEmployeeAppraisal EmployeeAppraisal { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Appraisee { get; set; }

        /// <summary>
        /// Gets or sets the supervisor.
        /// </summary>
        /// <value>
        /// The supervisor.
        /// </value>
        public IEmployee Appraiser { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUserDetail User { get; set; }
    }
}
