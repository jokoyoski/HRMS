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
    /// <seealso cref="AA.HRMS.Interfaces.ITypeOfExitListView" />
    class TypeOfExitListView : ITypeOfExitListView
    {
        public IList<ITypeOfExit> TypeOfExitCollection { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public ICompanyDetail Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SelectedTypeOfExit { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedCompanyID { get; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedTypeOfExitId { get; set ; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get ; set ; }
    }
}
