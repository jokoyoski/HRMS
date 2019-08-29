using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class DayModel : IDay
    {
        /// <summary>
        /// Gets or sets the day identifier.
        /// </summary>
        /// <value>
        /// The day identifier.
        /// </value>
        public int DayId { get; set; }
        /// <summary>
        /// Gets or sets the name of the day.
        /// </summary>
        /// <value>
        /// The name of the day.
        /// </value>
        public string DayName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
