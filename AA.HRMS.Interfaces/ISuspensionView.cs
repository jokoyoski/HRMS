using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ISuspensionView
    {
        int SuspensionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int QueryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string QueryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        System.DateTime StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        System.DateTime EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        decimal Percentage { get; set; }
        /// <summary>
        /// /
        /// </summary>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsActive { get; set; }
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
        string ProcessingMessage { get; set; }
    }
}
