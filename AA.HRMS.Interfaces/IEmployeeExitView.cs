using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeExitView
    {
        /// <summary>
        /// Gets or sets the employee exit identifier.
        /// </summary>
        /// <value>
        /// The employee exit identifier.
        /// </value>
        int EmployeeExitId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the employee drop down.
        /// </summary>
        /// <value>
        /// The employee drop down.
        /// </value>
        IList<SelectListItem> EmployeeDropDown { get; set; }
        /// <summary>
        /// Gets or sets the date requested.
        /// </summary>
        /// <value>
        /// The date requested.
        /// </value>
        DateTime DateRequested { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        string Reason { get; set; }
        /// <summary>
        /// Gets or sets the type of exit identifier.
        /// </summary>
        /// <value>
        /// The type of exit identifier.
        /// </value>
        int TypeOfExitId { get; set; }
        /// <summary>
        /// Gets or sets the type of exit drop down.
        /// </summary>
        /// <value>
        /// The type of exit drop down.
        /// </value>
        IList<SelectListItem> TypeOfExitDropDown { get; set; }
        /// <summary>
        /// Gets or sets the exit inter view summary.
        /// </summary>
        /// <value>
        /// The exit inter view summary.
        /// </value>
        string ExitInterViewSummary { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyDetail Company { get; set; }
        /// <summary>
        /// Gets or sets the interviewer identifier.
        /// </summary>
        /// <value>
        /// The interviewer identifier.
        /// </value>
        string Interviewer { get; set; }
        /// <summary>
        /// Gets or sets the inter view drop down.
        /// </summary>
        /// <value>
        /// The inter view drop down.
        /// </value>
        IList<SelectListItem> InterViewerDropDown { get; set; }
        /// <summary>
        /// Gets or sets the interview date.
        /// </summary>
        /// <value>
        /// The interview date.
        /// </value>
        DateTime InterviewDate { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }
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
    }
}
