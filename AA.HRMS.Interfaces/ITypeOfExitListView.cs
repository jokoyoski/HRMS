using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITypeOfExitListView
    {
        /// <summary>
        /// 
        /// </summary>
        IList<ITypeOfExit> TypeOfExitCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ICompanyDetail Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string SelectedTypeOfExit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int SelectedCompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int SelectedTypeOfExitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }
    }
}
