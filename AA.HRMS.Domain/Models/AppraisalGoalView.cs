using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalGoalView" />
    public class AppraisalGoalView : IAppraisalGoalView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppraisalGoalView"/> class.
        /// </summary>
        
        public AppraisalGoalView()
        {
            IsActive = true;
            DateCreated = DateTime.UtcNow;
            this.AppraisalDropDownList = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the appraisal goal identifier.
        /// </summary>
        /// <value>
        /// The appraisal goal identifier.
        /// </value>
        public int AppraisalGoalId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal identifier.
        /// </summary>
        /// <value>
        /// The appraisal identifier.
        /// </value>
        public IEmployeeAppraisal EmployeeAppraisal { get; set; }

        public IAppraisal Appraisal { get; set; }

        /// <summary>
        /// Gets or sets the employee appraisal identifier.
        /// </summary>
        /// <value>
        /// The employee appraisal identifier.
        /// </value>
        public int EmployeeAppraisalId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal identifier.
        /// </summary>
        /// <value>
        /// The appraisal identifier.
        /// </value>
        public int AppraisalId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the appraisal drop down list.
        /// </summary>
        /// <value>
        /// The appraisal drop down list.
        /// </value>
        public IList<SelectListItem> AppraisalDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the appraiser identifier.
        /// </summary>
        /// <value>
        /// The appraiser identifier.
        /// </value>
        public int AppraiserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the appraiser.
        /// </summary>
        /// <value>
        /// The name of the appraiser.
        /// </value>
        public IEmployee Appraiser { get; set; }
        /// <summary>
        /// Gets or sets the appraisee identifier.
        /// </summary>
        /// <value>
        /// The appraisee identifier.
        /// </value>
        public int AppraiseeId { get; set; }
        /// <summary>
        /// Gets or sets the name of the appraisee.
        /// </summary>
        /// <value>
        /// The name of the appraisee.
        /// </value>
        public IEmployee Appraisee { get; set; }
        /// <summary>
        /// Gets or sets the goal.
        /// </summary>
        /// <value>
        /// The goal.
        /// </value>
        public string Goal { get; set; }
        /// <summary>
        /// Gets or sets the measurements.
        /// </summary>
        /// <value>
        /// The measurements.
        /// </value>
        public string Measurements { get; set; }
        /// <summary>
        /// Gets or sets the outcome.
        /// </summary>
        /// <value>
        /// The outcome.
        /// </value>
        public string Outcome { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
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
    }
}
