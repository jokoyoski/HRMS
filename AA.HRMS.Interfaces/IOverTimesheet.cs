using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
   public interface IOverTimesheet
    {
         int OverTimesheetId { get; set; }
        /// <summary>
        /// 
        /// </summary>
         int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string EmployeeName { get; set; }
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
        int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string CompanyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime DateCreated { get; set; }
    }
}
