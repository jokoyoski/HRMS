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
    /// <seealso cref="AA.HRMS.Interfaces.ISuspension" />
    public class SuspensionModel : ISuspension
    {
        /// <summary>
        /// Gets or sets the suspension identifier.
        /// </summary>
        /// <value>
        /// The suspension identifier.
        /// </value>
        public int SuspensionId { get; set; }
        /// <summary>
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// </summary>
        public int QueryId { get; set; }
        /// <summary>
        /// </summary>
        public string QueryName { get; set; }
        /// <summary>
        /// </summary>
        public System.DateTime StartDate { get; set; }
        /// <summary>
        /// </summary>
        public System.DateTime EndDate { get; set; }
        /// <summary>
        /// </summary>
        public decimal Percentage { get; set; }
        /// <summary>
        /// /
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// </summary>
        public bool IsActive { get; set; }
    }
}
