using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeLoanListView" />
    public class EmployeeLoanListView : IEmployeeLoanListView
    {
        /// <summary>
        /// Gets or sets the employee collection.
        /// </summary>
        /// <value>
        /// The employee collection.
        /// </value>
        public IList<IEmployeeLoan> EmployeeLoanCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected employee.
        /// </summary>
        /// <value>
        /// The name of the selected employee.
        /// </value>
        public string SelectedEmployeeName { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected company.
        /// </summary>
        /// <value>
        /// The name of the selected company.
        /// </value>
        public string SelectedCompanyName { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected employee loan.
        /// </summary>
        /// <value>
        /// The name of the selected employee loan.
        /// </value>
        public string SelectedEmployeeLoanName { get; set; }

        public string URL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEmployee Employee { get;  set; }
        /// <summary>
        /// 
        /// </summary>
        public IUserDetail User { get; set; }

        public ICompanyDetail Company { get; set; }

        public IList<SelectListItem> CompanyDropDownList { get;  set; }

        
    }
}