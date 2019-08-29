using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    
    public class SuspensionView : ISuspensionView
    {
       
        public SuspensionView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
            this.QueryDropDown = new List<SelectListItem>();
            this.EmployeeDropDown = new List<SelectListItem>();
        }

        public int SuspensionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int QueryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QueryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Percentage { get; set; }
        /// <summary>
        /// /
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> EmployeeDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> QueryDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }
       
    }
}
