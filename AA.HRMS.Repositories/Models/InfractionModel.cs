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
    public class InfractionModel : IInfraction
    {
        /// <summary>
        /// Gets or sets the infraction identifier.
        /// </summary>
        /// <value>
        /// The infraction identifier.
        /// </value>
        public string InfractionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the infraction.
        /// </summary>
        /// <value>
        /// The name of the infraction.
        /// </value>
        public string InfractionName { get; set; }

        /// <summary>
        /// Gets or sets the infraction consequence.
        /// </summary>
        /// <value>
        /// The infraction consequence.
        /// </value>
        public string InfractionConsequence { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive_ { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
    }
}
