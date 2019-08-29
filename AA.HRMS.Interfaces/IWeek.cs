using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IWeek
    {
        /// <summary>
        /// Gets or sets the week identifier.
        /// </summary>
        /// <value>
        /// The week identifier.
        /// </value>
        int WeekId { get; set; }
        /// <summary>
        /// Gets or sets the name of the week.
        /// </summary>
        /// <value>
        /// The name of the week.
        /// </value>
        string WeekName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}
