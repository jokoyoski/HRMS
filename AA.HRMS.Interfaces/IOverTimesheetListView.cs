using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
   public interface IOverTimesheetListView
    {
        /// <summary>
        /// 
        /// </summary>
        int selectedEmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int selectedCompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
         IList<SelectListItem> EmployeeDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<IOverTimesheet> OverTimesheetCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }
    }
}
