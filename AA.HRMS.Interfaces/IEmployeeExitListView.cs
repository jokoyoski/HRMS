using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeExitListView
    {
        IList<IEmployeeExit> employeeExitCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ICompanyDetail Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string SelectedEmployeeExit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int SelectedCompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int SelectedEmployeeExitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }
        
    }
}
