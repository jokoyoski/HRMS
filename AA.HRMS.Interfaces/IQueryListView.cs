using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IQueryListView
    {
       
        IList<IQuery> QueryCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ICompanyDetail Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string SelectedQuery { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int SelectedCompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }
    }
}
