using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ISuspensionListView
    {
        IList<ISuspension> SuspensionCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<ISuspension> EmployeeCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<ISuspension> QueryCollection { get; set; }

        ICompanyDetail Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> EmployeeDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> QueryDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string SelectedSuspension { get; set; }

        int SelectedQueryId { get; set; }

        int SelectedEmployeeId { get; set; }
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
