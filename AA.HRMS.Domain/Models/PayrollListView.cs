using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public  class PayrollListView : IPayrollListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayrollListView"/> class.
        /// </summary>
        public PayrollListView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
            this.MonthDropDown = new List<SelectListItem>();
            this.YearDropDown = new List<SelectListItem>();
            this.ProcessingMessage = string.Empty;
            this.SelectedMonth = string.Empty;
            this.SelectedYear = string.Empty;
        }
        /// <summary>
        /// Gets or sets the selected year.
        /// </summary>
        /// <value>
        /// The selected year.
        /// </value>
        public string SelectedYear { get; set; }
        /// <summary>
        /// Gets or sets the selected month.
        /// </summary>
        /// <value>
        /// The selected month.
        /// </value>
        public string SelectedMonth { get; set; }
        /// <summary>
        /// Gets or sets the month drop down.
        /// </summary>
        /// <value>
        /// The month drop down.
        /// </value>
        public IList<SelectListItem> MonthDropDown { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the year drop down.
        /// </summary>
        /// <value>
        /// The year drop down.
        /// </value>
        public IList<SelectListItem> YearDropDown { get; set; }
        /// <summary>
        /// Gets or sets the payroll list.
        /// </summary>
        /// <value>
        /// The payroll list.
        /// </value>
        public IList<IPayroll> PayrollList { get; set; }
        /// <summary>
        /// Gets or sets the employee list.
        /// </summary>
        /// <value>
        /// The employee list.
        /// </value>
        public IList<IEmployee> EmployeeList { get; set; }
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
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
