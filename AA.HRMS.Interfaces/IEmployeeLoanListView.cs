using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeLoanListView
    {
        /// <summary>
        /// Gets or sets the employee collection.
        /// </summary>
        /// <value>
        /// The employee collection.
        /// </value>
        IList<IEmployeeLoan> EmployeeLoanCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected employee.
        /// </summary>
        /// <value>
        /// The name of the selected employee.
        /// </value>
        string SelectedEmployeeName { get; set; }
        /// <summary>+
        /// Gets or sets the name of the selected company.
        /// </summary>
        /// <value>
        /// The name of the selected company.
        /// </value>
        string SelectedCompanyName { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected employee loan.
        /// </summary>
        /// <value>
        /// The name of the selected employee loan.
        /// </value>
        string SelectedEmployeeLoanName { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyDetail Company { get; set; }

        string URL { get; set; }
    }
}
