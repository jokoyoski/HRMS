using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class SuspensionListView : ISuspensionListView
    {
        public SuspensionListView()
        {
            this.SuspensionCollection = new List<ISuspension>();
            this.EmployeeCollection = new List<ISuspension>();
            this.QueryCollection = new List<ISuspension>();
            this.CompanyDropDown = new List<SelectListItem>();
            
        }

        public IList<ISuspension> SuspensionCollection { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<ISuspension> EmployeeCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<ISuspension> QueryCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICompanyDetail Company { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> CompanyDropDown { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> EmployeeDropDown { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> QueryDropDown { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedQueryId { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedEmployeeId { get ; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedCompanyId { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get ; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SelectedSuspension { get ; set ; }
    }
}
