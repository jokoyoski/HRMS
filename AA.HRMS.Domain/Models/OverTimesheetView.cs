using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IOverTimesheetView" />
    
    public class OverTimesheetView : IOverTimesheetView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OverTimesheetView"/> class.
        /// </summary>

        public OverTimesheetView()
        {
            this.ProcessingMessage = string.Empty;
            this.EmployeeDropDownList = new List<SelectListItem>();
            this.CompanyDropDownList = new List<SelectListItem>();
        }
        /// <summary>
        /// 
        /// </summary>

        public int OverTimesheetId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime OverTimeDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NumberofHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> EmployeeDropDownList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }

    }
}
