using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IQuery
    {
         int QueryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
         string QueryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
         int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
         string Consequences { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>

        DateTime DateCreated { get; set; }
    }
}
