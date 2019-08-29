using System.Collections.Generic;
using System.Web.Mvc;
using AA.HRMS.Interfaces;


namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IOverTimesheetListView" />

    public class OverTimesheetListView : IOverTimesheetListView
    {
        public OverTimesheetListView()
        {
            this.CompanyDropDownList = new List<SelectListItem>();
            this.EmployeeDropDownList = new List<SelectListItem>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int selectedEmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int selectedCompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> EmployeeDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  IList<IOverTimesheet> OverTimesheetCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }


    }
}
