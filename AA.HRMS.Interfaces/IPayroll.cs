using System;

namespace AA.HRMS.Interfaces
{
    public interface IPayroll
    {
        /// <summary>
        /// Gets or sets the payroll identifier.
        /// </summary>
        /// <value>
        /// The payroll identifier.
        /// </value>
        int PayrollId { get; set; }
        /// <summary>
        /// Gets or sets the payroll history identifier.
        /// </summary>
        /// <value>
        /// The payroll history identifier.
        /// </value>
        int PayrollHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the month code.
        /// </summary>
        /// <value>
        /// The month code.
        /// </value>
        string MonthCode { get; set; }
        /// <summary>
        /// Gets or sets the year identifier.
        /// </summary>
        /// <value>
        /// The year identifier.
        /// </value>
        int YearId { get; set; }
        /// <summary>
        /// Gets or sets the basic salary.
        /// </summary>
        /// <value>
        /// The basic salary.
        /// </value>
        decimal BasicSalary { get; set; }
        /// <summary>
        /// Gets or sets the net salary.
        /// </summary>
        /// <value>
        /// The net salary.
        /// </value>
        decimal NetSalary { get; set; }
        /// <summary>
        /// Gets or sets the employee infraction identifier.
        /// </summary>
        /// <value>
        /// The employee infraction identifier.
        /// </value>
        int? EmployeeRewardId { get; set; }
        /// <summary>
        /// Gets or sets the employee deduction identifier.
        /// </summary>
        /// <value>
        /// The employee deduction identifier.
        /// </value>
        int? EmployeeDeductionId { get; set; }
        /// <summary>
        /// Gets or sets the employee loan identifier.
        /// </summary>
        /// <value>
        /// The employee loan identifier.
        /// </value>
        int? EmployeeLoanId { get; set; }
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
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        string Month { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        string Year { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        string EmployeeName { get; set; }
    }
}
