using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IDeductionViewModel
    {

        string EmployeeName { get; set; }
        /// <summary>
        /// Gets or sets the deduction identifier.
        /// </summary>
        /// <value>
        /// The deduction identifier.
        /// </value>
        int DeductionId { get; set; }
        /// <summary>
        /// Gets or sets the name of the deduction.
        /// </summary>
        /// <value>
        /// The name of the deduction.
        /// </value>
        string DeductionName { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the deduction amount.
        /// </summary>
        /// <value>
        /// The deduction amount.
        /// </value>
        decimal DeductionAmount { get; set; }
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
        /// 
        DateTime DateStarted { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the date terminated.
        /// </summary>
        /// <value>
        /// The date terminated.
        /// </value>
        DateTime? DateTerminated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is terminated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is terminated; otherwise, <c>false</c>.
        /// </value>
        bool IsTerminated { get; set; }

        string URL { get; set; }
    }
}
