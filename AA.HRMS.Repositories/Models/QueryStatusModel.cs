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
    /// <seealso cref="AA.HRMS.Interfaces.IQueryStatus" />
    public class QueryStatusModel : IQueryStatus
    {
        /// <summary>
        /// Gets or sets the query status identifier.
        /// </summary>
        /// <value>
        /// The query status identifier.
        /// </value>
        public int QueryStatusId { get; set; }
        /// <summary>
        /// Gets or sets the name of the query status.
        /// </summary>
        /// <value>
        /// The name of the query status.
        /// </value>
        public string QueryStatusName { get; set; }
        /// <summary>
        /// Gets or sets the query status description.
        /// </summary>
        /// <value>
        /// The query status description.
        /// </value>
        public string QueryStatusDescription { get; set; }
    }
}
