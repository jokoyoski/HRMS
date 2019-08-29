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
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeDeductionView" />
    public class EmployeeDeductionView : IEmployeeDeductionView
    {
        public EmployeeDeductionView()
        {
           
            this.DeductionDropDown = new List<SelectListItem>();
            this.CompanyDropDown = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the employee deduction identifier.
        /// </summary>
        /// <value>
        /// The employee deduction identifier.
        /// </value>
        public int EmployeeDeductionId { get; set; }
        /// <summary>
        /// Gets or sets the deduction identifier.
        /// </summary>
        /// <value>
        /// The deduction identifier.
        /// </value>
        public int DeductionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the deduction.
        /// </summary>
        /// <value>
        /// The name of the deduction.
        /// </value>
        public string DeductionName { get; set; }

        /// <summary>
        /// Gets or sets the deduction amount.
        /// </summary>
        /// <value>
        /// The deduction amount.
        /// </value>
        public decimal DeductionAmount { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; }
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
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the deduction drop down.
        /// </summary>
        /// <value>
        /// The deduction drop down.
        /// </value>
        public IList<SelectListItem> DeductionDropDown { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get;  set; }
    }
}
