using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class MonthModel : IMonth
    {
        /// <summary>
        /// Gets or sets the month code.
        /// </summary>
        /// <value>
        /// The month code.
        /// </value>
        public string MonthCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the month.
        /// </summary>
        /// <value>
        /// The name of the month.
        /// </value>
        public string MonthName { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
