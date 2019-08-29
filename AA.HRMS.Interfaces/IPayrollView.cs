using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollView
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
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the company collection.
        /// </summary>
        /// <value>
        /// The company collection.
        /// </value>
        IList<SelectListItem> CompanyCollection { get; set; }
        /// <summary>
        /// Gets or sets the employee reward.
        /// </summary>
        /// <value>
        /// The employee reward.
        /// </value>
        IList<IEmployeeReward> EmployeeReward { get; set; }
        /// <summary>
        /// Gets or sets the employee loans.
        /// </summary>
        /// <value>
        /// The employee loans.
        /// </value>
        IList<IEmployeeLoan> EmployeeLoans { get; set; }
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
        /// Gets or sets the month drop down.
        /// </summary>
        /// <value>
        /// The month drop down.
        /// </value>
        IList<SelectListItem> MonthDropDown { get; set; }
        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        string Month { get; set; }
        /// <summary>
        /// Gets or sets the year identifier.
        /// </summary>
        /// <value>
        /// The year identifier.
        /// </value>
        int YearId { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        string Year { get; set; }
        /// <summary>
        /// Gets or sets the year drop down.
        /// </summary>
        /// <value>
        /// The year drop down.
        /// </value>
        IList<SelectListItem> YearDropDown { get; set; }
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
        /// Gets or sets the employee reward identifier.
        /// </summary>
        /// <value>
        /// The employee reward identifier.
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
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the level grade.
        /// </summary>
        /// <value>
        /// The level grade.
        /// </value>
        IPayScale LevelGrade { get; set; }
    }
}
