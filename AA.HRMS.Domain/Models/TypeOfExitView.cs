using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ITypeOfExitView" />
    public class TypeOfExitView : ITypeOfExitView
    {
        public TypeOfExitView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
            this.EmployeeDropDown = new List<SelectListItem>();
            this.TypeOfExitDropDown = new List<SelectListItem>();
            this.InterViewerDropDown = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the type of exit identifier.
        /// </summary>
        /// <value>
        /// The type of exit identifier.
        /// </value>
        
        public int TypeOfExitId { get ; set ; }

        /// <summary>
        /// Gets or sets the name of the type of exit.
        /// </summary>
        /// <value>
        /// The name of the type of exit.
        /// </value>
        
        public string TypeOfExitName { get ; set ; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> EmployeeDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> CompanyDropDown { get;  set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> InterViewerDropDown { get;  set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> TypeOfExitDropDown { get; set; }
       /// <summary>
       /// 
       /// </summary>
        public int EmployeeId { get ; set ; }
    }
}
