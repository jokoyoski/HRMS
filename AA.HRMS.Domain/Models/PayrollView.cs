using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class PayrollView : IPayrollView
    {
        /// <summary>
        /// Gets or sets the payroll identifier.
        /// </summary>
        /// <value>
        /// The payroll identifier.
        /// </value>
        public int PayrollId { get; set; }
        /// <summary>
        /// Gets or sets the payroll history identifier.
        /// </summary>
        /// <value>
        /// The payroll history identifier.
        /// </value>
        public int PayrollHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the month code.
        /// </summary>
        /// <value>
        /// The month code.
        /// </value>
        public string MonthCode { get; set; }
        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public string Month { get; set; }
        /// <summary>
        /// Gets or sets the month drop down.
        /// </summary>
        /// <value>
        /// The month drop down.
        /// </value>
        public IList<SelectListItem> MonthDropDown { get; set; }
        /// <summary>
        /// Gets or sets the year drop down.
        /// </summary>
        /// <value>
        /// The year drop down.
        /// </value>
        public IList<SelectListItem> YearDropDown { get; set; }
        /// <summary>
        /// Gets or sets the company collection.
        /// </summary>
        /// <value>
        /// The company collection.
        /// </value>
        public IList<SelectListItem> CompanyCollection { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public string Year { get; set; }
        /// <summary>
        /// Gets or sets the year identifier.
        /// </summary>
        /// <value>
        /// The year identifier.
        /// </value>
        public int YearId { get; set; }
        /// <summary>
        /// Gets or sets the basic salary.
        /// </summary>
        /// <value>
        /// The basic salary.
        /// </value>
        public decimal BasicSalary { get; set; }
        /// <summary>
        /// Gets or sets the net salary.
        /// </summary>
        /// <value>
        /// The net salary.
        /// </value>
        public decimal NetSalary { get; set; }
        /// <summary>
        /// Gets or sets the employee infraction identifier.
        /// </summary>
        /// <value>
        /// The employee infraction identifier.
        /// </value>
        public int? EmployeeRewardId { get; set; }
        /// <summary>
        /// Gets or sets the employee deduction.
        /// </summary>
        /// <value>
        /// The employee deduction.
        /// </value>
        public int? EmployeeDeductionId { get; set; }
        /// <summary>
        /// Gets or sets the employee loan identifier.
        /// </summary>
        /// <value>
        /// The employee loan identifier.
        /// </value>
        public int? EmployeeLoanId { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the employee reward.
        /// </summary>
        /// <value>
        /// The employee reward.
        /// </value>
        public IList<IEmployeeReward> EmployeeReward { get; set; }
        /// <summary>
        /// Gets or sets the employee loans.
        /// </summary>
        /// <value>
        /// The employee loans.
        /// </value>
        public IList<IEmployeeLoan> EmployeeLoans { get; set; }
        /// <summary>
        /// Gets or sets the level grade.
        /// </summary>
        /// <value>
        /// The level grade.
        /// </value>
        public IPayScale LevelGrade { get; set; }
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
    }
}
