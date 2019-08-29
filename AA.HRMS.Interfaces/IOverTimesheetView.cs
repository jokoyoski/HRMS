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
   public interface IOverTimesheetView
    {
        /// <summary>
        /// 
        /// </summary>

         int OverTimesheetId { get; set; }
        /// <summary>
        /// 
        /// </summary>
         int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime OverTimeDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
       int NumberofHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
         IList<SelectListItem> EmployeeDropDownList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }
    }
}
