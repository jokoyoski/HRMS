using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeDeduction
    {
        /// <summary>
        /// Gets or sets the employee deduction identifier.
        /// </summary>
        /// <value>
        /// The employee deduction identifier.
        /// </value>
        int EmployeeDeductionId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
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
        /// 
        /// </summary>
        int CompanyDeductionId { get; set; }
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
    }
}
