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
    public interface IGradeView
    {

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// /
        /// </summary>
        IList<SelectListItem> BenefitDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        int GradeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the grade.
        /// </summary>
        /// <value>
        /// The name of the grade.
        /// </value>
        string GradeName { get; set; }

        /// <summary>
        /// Gets or sets the grade description.
        /// </summary>
        /// <value>
        /// The grade description.
        /// </value>
        string GradeDescription { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        DateTime? DateModified { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the duration of the annual leave.
        /// </summary>
        /// <value>
        /// The duration of the annual leave.
        /// </value>
        int AnnualLeaveDuration { get; set; }
    }
}