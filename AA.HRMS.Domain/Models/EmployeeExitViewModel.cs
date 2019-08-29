using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeExitView" />
    public class EmployeeExitViewModel : IEmployeeExitView
    {
        /// <summary>
        /// Gets or sets the employee exit identifier.
        /// </summary>
        /// <value>
        /// The employee exit identifier.
        /// </value>
        public int EmployeeExitId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the date requested.
        /// </summary>
        /// <value>
        /// The date requested.
        /// </value>
        public DateTime DateRequested { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public string Reason { get; set; }
        /// <summary>
        /// Gets or sets the type of exit identifier.
        /// </summary>
        /// <value>
        /// The type of exit identifier.
        /// </value>
        public int TypeOfExitId { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public ICompanyDetail Company { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the exit inter view summary.
        /// </summary>
        /// <value>
        /// The exit inter view summary.
        /// </value>
        public string ExitInterViewSummary { get; set; }
        /// <summary>
        /// Gets or sets the interviewer identifier.
        /// </summary>
        /// <value>
        /// The interviewer identifier.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Interviewer Required")]
        [MinLength(2, ErrorMessage = "Minimum two characters required")]
        public string Interviewer { get; set; }
        /// <summary>
        /// Gets or sets the interview date.
        /// </summary>
        /// <value>
        /// The interview date.
        /// </value>
        public DateTime InterviewDate { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> EmployeeDropDown { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> TypeOfExitDropDown { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> InterViewerDropDown { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> CompanyDropDown { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set ; }
    }
}
