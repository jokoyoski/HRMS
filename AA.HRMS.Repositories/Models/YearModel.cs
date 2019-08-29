using AA.HRMS.Interfaces;
using System;

namespace AA.HRMS.Repositories.Models
{
    public class YearModel : IYear
    {
        /// <summary>
        /// Gets or sets the year identifier.
        /// </summary>
        /// <value>
        /// The year identifier.
        /// </value>
        public int YearId { get; set; }
        /// <summary>
        /// Gets or sets the year1.
        /// </summary>
        /// <value>
        /// The year1.
        /// </value>
        public string Year { get; set; }
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
