using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public  interface IEmployeeDeductionListView
    {

        /// <summary>
        /// Gets or sets the employee deduction collection.
        /// </summary>
        /// <value>
        /// The employee deduction collection.
        /// </value>
        IList<IEmployeeDeduction> EmployeeDeductionCollection { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserDetail User { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the selected deduction.
        /// </summary>
        /// <value>
        /// The selected deduction.
        /// </value>
        string SelectedEmployeeDeduction { get; set; }
    }
}


