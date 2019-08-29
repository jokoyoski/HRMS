using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IQueryView
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

        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        bool IsActive { get; set; }

        DateTime DateCreated { get; set; }

        string ProcessingMessage { get; set; }
    }
}
