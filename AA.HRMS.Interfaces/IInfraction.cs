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
    public interface IInfraction
    {
        /// <summary>
        /// Gets or sets the infraction identifier.
        /// </summary>
        /// <value>
        /// The infraction identifier.
        /// </value>
        string InfractionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the infraction.
        /// </summary>
        /// <value>
        /// The name of the infraction.
        /// </value>
        string InfractionName { get; set; }

        /// <summary>
        /// Gets or sets the infraction consequence.
        /// </summary>
        /// <value>
        /// The infraction consequence.
        /// </value>
        string InfractionConsequence { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive_ { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
    }
}
