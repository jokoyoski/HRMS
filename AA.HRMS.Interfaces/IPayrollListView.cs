using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollListView
    {
        /// <summary>
        /// Gets or sets the selected year.
        /// </summary>
        /// <value>
        /// The selected year.
        /// </value>
        string SelectedYear { get; set; }
        /// <summary>
        /// Gets or sets the selected month.
        /// </summary>
        /// <value>
        /// The selected month.
        /// </value>
        string SelectedMonth { get; set; }
        /// <summary>
        /// Gets or sets the month drop down.
        /// </summary>
        /// <value>
        /// The month drop down.
        /// </value>
        IList<SelectListItem> MonthDropDown { get; set; }
        /// <summary>
        /// Gets or sets the year drop down.
        /// </summary>
        /// <value>
        /// The year drop down.
        /// </value>
        IList<SelectListItem> YearDropDown { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the payroll list.
        /// </summary>
        /// <value>
        /// The payroll list.
        /// </value>
        IList<IPayroll> PayrollList { get; set; }
        /// <summary>
        /// Gets or sets the employee list.
        /// </summary>
        /// <value>
        /// The employee list.
        /// </value>
        IList<IEmployee> EmployeeList { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyDetail Company { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
