using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeDeductionListView" />
    public class EmployeeDeductionListView: IEmployeeDeductionListView
    {

        public EmployeeDeductionListView()
        {
            this.CompanyDropDownList = new List<SelectListItem>();
           
        }
        /// <summary>
        /// 
        /// </summary>
      public  IList<IEmployeeDeduction> EmployeeDeductionCollection { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Employee { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUserDetail User { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
       public string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
      public  IList<SelectListItem> CompanyDropDownList { get; set; }
  

        /// <summary>
        /// Gets or sets the selected deduction.
        /// </summary>
        /// <value>
        /// The selected deduction.
        /// </value>
      public  string SelectedEmployeeDeduction { get; set; }
    }
}

