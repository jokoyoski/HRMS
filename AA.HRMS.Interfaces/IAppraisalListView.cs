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
    public interface IAppraisalListView
    {

        /// <summary>
        /// Gets or sets the appraisal identifier.
        /// </summary>
        /// <value>
        /// The appraisal identifier.
        /// </value>
        int AppraisalId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal year.
        /// </summary>
        /// <value>
        /// The appraisal year.
        /// </value>
        System.DateTime AppraisalYear { get; set; }
        /// <summary>
        /// Gets or sets the appraisal period.
        /// </summary>
        /// <value>
        /// The appraisal period.
        /// </value>
        string AppraisalPeriod { get; set; }
        /// <summary>
        /// Gets or sets the initiation date.
        /// </summary>
        /// <value>
        /// The initiation date.
        /// </value>
        System.DateTime InitiationDate { get; set; }

        /// <summary>
        /// Gets or sets the appraisal summary.
        /// </summary>
        /// <value>
        /// The appraisal summary.
        /// </value>
        string AppraisalSummary { get; set; }
        /// <summary>
        /// Gets or sets the key strength.
        /// </summary>
        /// <value>
        /// The key strength.
        /// </value>
        string KeyStrength { get; set; }
        /// <summary>
        /// Gets or sets the areas of improvement.
        /// </summary>
        /// <value>
        /// The areas of improvement.
        /// </value>
        string AreasOfImprovement { get; set; }

        /// <summary>
        /// Gets or sets the appraisal agreed date.
        /// </summary>
        /// <value>
        /// The appraisal agreed date.
        /// </value>
        System.DateTime AppraisalAgreedDate { get; set; }
        /// <summary>
        /// Gets or sets the date approved.
        /// </summary>
        /// <value>
        /// The date approved.
        /// </value>
        System.DateTime DateApproved { get; set; }
        /// <summary>
        /// Gets or sets the approved action effective date.
        /// </summary>
        /// <value>
        /// The approved action effective date.
        /// </value>
        System.DateTime ApprovedActionEffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the appraiser identifier.
        /// </summary>
        /// <value>
        /// The appraiser identifier.
        /// </value>
        int AppraiserId { get; set; }
        /// <summary>
        /// Gets or sets the appraiser rating identifier.
        /// </summary>
        /// <value>
        /// The appraiser rating identifier.
        /// </value>
        int AppraiserRatingId { get; set; }
        /// <summary>
        /// Gets or sets the recommended action identifier.
        /// </summary>
        /// <value>
        /// The recommended action identifier.
        /// </value>
        int RecommendedActionId { get; set; }
        /// <summary>
        /// Gets or sets the final rating identifier.
        /// </summary>
        /// <value>
        /// The final rating identifier.
        /// </value>
        int FinalRatingId { get; set; }
        /// <summary>
        /// Gets or sets the approved action identifier.
        /// </summary>
        /// <value>
        /// The approved action identifier.
        /// </value>
        int ApprovedActionId { get; set; }
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
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the employee drop down list.
        /// </summary>
        /// <value>
        /// The employee drop down list.
        /// </value>
        IList<SelectListItem> EmployeeDropDownList { get; set; }


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
        /// Gets or sets the appraisal view.
        /// </summary>
        /// <value>
        /// The appraisal view.
        /// </value>
        IList<IAppraisalView> appraisalView { get; set; }
        /// <summary>
        /// Gets or sets the appraisal.
        /// </summary>
        /// <value>
        /// The appraisal.
        /// </value>
        IList<IAppraisal> appraisal { get; set; }

        IList<IEmployeeAppraisal> EmployeeAppraisalCollection { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyDetail Company { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the supervisor.
        /// </summary>
        /// <value>
        /// The supervisor.
        /// </value>
        IEmployee Supervisor { get; set; }
    }
}
