using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeExitListView" />
    public class EmployeeExitListView : IEmployeeExitListView
    {
        public EmployeeExitListView()
        {
            this.employeeExitCollection = new List<IEmployeeExit>();
        }
        /// <summary>
        /// 
        /// </summary>
        public IList<IEmployeeExit> employeeExitCollection { get; set ; }
        /// <summary>
        /// 
        /// </summary>

        public ICompanyDetail Company { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public string SelectedEmployeeExit { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedCompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedEmployeeExitId { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get ; set ; }
        
    }
}
