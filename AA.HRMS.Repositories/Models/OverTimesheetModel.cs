using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IOverTimesheet" />
    /// 
    public class OverTimesheetModel : IOverTimesheet
    {
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
        public string EmployeeName { get; set; }
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
        public int CompanyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime DateCreated { get; set; }
    }
}
