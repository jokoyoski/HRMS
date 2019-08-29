using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalListView" />
    public class AppraisalListView : IAppraisalListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppraisalListView"/> class.
        /// </summary>
        public AppraisalListView()
        {
            this.appraisalView = new List<IAppraisalView>();
            this.appraisal = new List<IAppraisal>();
        }
        /// <summary>
        /// Gets or sets the appraisal identifier.
        /// </summary>
        /// <value>
        /// The appraisal identifier.
        /// </value>
        public int AppraisalId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal year.
        /// </summary>
        /// <value>
        /// The appraisal year.
        /// </value>
        public System.DateTime AppraisalYear { get; set; }
        /// <summary>
        /// Gets or sets the appraisal period.
        /// </summary>
        /// <value>
        /// The appraisal period.
        /// </value>
        public string AppraisalPeriod { get; set; }
        /// <summary>
        /// Gets or sets the initiation date.
        /// </summary>
        /// <value>
        /// The initiation date.
        /// </value>
        public System.DateTime InitiationDate { get; set; }

        /// <summary>
        /// Gets or sets the appraisal summary.
        /// </summary>
        /// <value>
        /// The appraisal summary.
        /// </value>
        public string AppraisalSummary { get; set; }
        /// <summary>
        /// Gets or sets the key strength.
        /// </summary>
        /// <value>
        /// The key strength.
        /// </value>
        public string KeyStrength { get; set; }
        /// <summary>
        /// Gets or sets the areas of improvement.
        /// </summary>
        /// <value>
        /// The areas of improvement.
        /// </value>
        public string AreasOfImprovement { get; set; }

        /// <summary>
        /// Gets or sets the appraisal agreed date.
        /// </summary>
        /// <value>
        /// The appraisal agreed date.
        /// </value>
        public System.DateTime AppraisalAgreedDate { get; set; }
        /// <summary>
        /// Gets or sets the date approved.
        /// </summary>
        /// <value>
        /// The date approved.
        /// </value>
        public System.DateTime DateApproved { get; set; }
        /// <summary>
        /// Gets or sets the approved action effective date.
        /// </summary>
        /// <value>
        /// The approved action effective date.
        /// </value>
        public System.DateTime ApprovedActionEffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the appraiser identifier.
        /// </summary>
        /// <value>
        /// The appraiser identifier.
        /// </value>
        public int AppraiserId { get; set; }
        /// <summary>
        /// Gets or sets the appraiser rating identifier.
        /// </summary>
        /// <value>
        /// The appraiser rating identifier.
        /// </value>
        public int AppraiserRatingId { get; set; }
        /// <summary>
        /// Gets or sets the recommended action identifier.
        /// </summary>
        /// <value>
        /// The recommended action identifier.
        /// </value>
        public int RecommendedActionId { get; set; }
        /// <summary>
        /// Gets or sets the final rating identifier.
        /// </summary>
        /// <value>
        /// The final rating identifier.
        /// </value>
        public int FinalRatingId { get; set; }
        /// <summary>
        /// Gets or sets the approved action identifier.
        /// </summary>
        /// <value>
        /// The approved action identifier.
        /// </value>
        public int ApprovedActionId { get; set; }

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
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the employee drop down list.
        /// </summary>
        /// <value>
        /// The employee drop down list.
        /// </value>
        public IList<SelectListItem> EmployeeDropDownList { get; set; }



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
        /// Gets or sets the appraisal.
        /// </summary>
        /// <value>
        /// The appraisal.
        /// </value>
        public IList<IAppraisal> appraisal { get; set; }

        /// <summary>
        /// Gets or sets the employee appraisal collection.
        /// </summary>
        /// <value>
        /// The employee appraisal collection.
        /// </value>
        public IList<IEmployeeAppraisal> EmployeeAppraisalCollection { get; set; }

        /// <summary>
        /// Gets or sets the appraisal view.
        /// </summary>
        /// <value>
        /// The appraisal view.
        /// </value>
        public IList<IAppraisalView> appraisalView { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public ICompanyDetail Company { get;  set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the supervisor.
        /// </summary>
        /// <value>
        /// The supervisor.
        /// </value>
        public IEmployee Supervisor { get; set; }
    }
}
