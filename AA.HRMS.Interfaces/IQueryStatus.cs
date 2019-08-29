using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IQueryStatus
    {
        /// <summary>
        /// Gets or sets the query status identifier.
        /// </summary>
        /// <value>
        /// The query status identifier.
        /// </value>
        int QueryStatusId { get; set; }
        /// <summary>
        /// Gets or sets the name of the query status.
        /// </summary>
        /// <value>
        /// The name of the query status.
        /// </value>
        string QueryStatusName { get; set; }
        /// <summary>
        /// Gets or sets the query status description.
        /// </summary>
        /// <value>
        /// The query status description.
        /// </value>
        string QueryStatusDescription { get; set; }
    }
}
