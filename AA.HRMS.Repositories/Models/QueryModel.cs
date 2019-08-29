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
    /// <seealso cref="AA.HRMS.Interfaces.IQuery" />
    public class QueryModel  : IQuery
    {
        /// <summary>
        /// Gets or sets the query identifier.
        /// </summary>
        /// <value>
        /// The query identifier.
        /// </value>
        public int QueryId { get; set; }
        /// <summary>
        /// </summary>
        public string QueryName { get; set; }
        /// <summary>
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// </summary>
        public string Consequences { get; set; }
        /// <summary>
        /// </summary>
        public bool IsActive { get;  set; }
        /// <summary>
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
