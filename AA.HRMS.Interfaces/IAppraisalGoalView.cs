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
    public interface IAppraisalGoalView
    {
        /// <summary>
        /// Gets or sets the appraisal goal identifier.
        /// </summary>
        /// <value>
        /// The appraisal goal identifier.
        /// </value>
        int AppraisalGoalId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal identifier.
        /// </summary>
        /// <value>
        /// The appraisal identifier.
        /// </value>
        IEmployeeAppraisal EmployeeAppraisal { get; set; }
        /// <summary>
        /// Gets or sets the appraisal.
        /// </summary>
        /// <value>
        /// The appraisal.
        /// </value>
        IAppraisal Appraisal { get; set; }
        /// <summary>
        /// Gets or sets the employee appraisal identifier.
        /// </summary>
        /// <value>
        /// The employee appraisal identifier.
        /// </value>
        int EmployeeAppraisalId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal identifier.
        /// </summary>
        /// <value>
        /// The appraisal identifier.
        /// </value>
        int AppraisalId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal drop down list.
        /// </summary>
        /// <value>
        /// The appraisal drop down list.
        /// </value>
        IList<SelectListItem> AppraisalDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the appraiser identifier.
        /// </summary>
        /// <value>
        /// The appraiser identifier.
        /// </value>
        int AppraiserId { get; set; }
        /// <summary>
        /// Gets or sets the appraiser.
        /// </summary>
        /// <value>
        /// The appraiser.
        /// </value>
        IEmployee Appraiser { get; set; }
        /// <summary>
        /// Gets or sets the appraisee identifier.
        /// </summary>
        /// <value>
        /// The appraisee identifier.
        /// </value>
        int AppraiseeId { get; set; }
        /// <summary>
        /// Gets or sets the name of the appraisee.
        /// </summary>
        /// <value>
        /// The name of the appraisee.
        /// </value>
        IEmployee Appraisee { get; set; }
        /// <summary>
        /// Gets or sets the goal.
        /// </summary>
        /// <value>
        /// The goal.
        /// </value>
        string Goal { get; set; }
        /// <summary>
        /// Gets or sets the measurements.
        /// </summary>
        /// <value>
        /// The measurements.
        /// </value>
        string Measurements { get; set; }
        /// <summary>
        /// Gets or sets the outcome.
        /// </summary>
        /// <value>
        /// The outcome.
        /// </value>
        string Outcome { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
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
    }
}
