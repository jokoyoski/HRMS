using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class QueryListView : IQueryListView
    {
        public QueryListView()
        {
            this.QueryCollection = new List<IQuery>();
            this.CompanyDropDown = new List<SelectListItem>();
        }

        public IList<IQuery> QueryCollection { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public ICompanyDetail Company { get; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> CompanyDropDown { get ; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SelectedQuery { get; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedCompanyId { get ; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get ; set ; }

        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public DateTime DateCreated { get; set; }
        
    }
}
