using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IQueryView" />
    public class QueryView : IQueryView
    {


        public QueryView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
        }


        public int QueryId { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public string QueryName { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public string Consequences { get ; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> CompanyDropDown { get ; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreated { get;  set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get;  set; }
    }
}
