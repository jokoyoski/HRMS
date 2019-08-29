using System.Collections.Generic;
using System.Web.Mvc;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IDepartmentListView" />
    public class DepartmentListView : IDepartmentListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentListView"/> class.
        /// </summary>
        public DepartmentListView()
        {
            this.DepartmentCollection = new List<IDepartment>();
            this.CompanyDropDownList = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the selected department identifier.
        /// </summary>
        /// <value>
        /// The selected department identifier.
        /// </value>
        public int SelectedDepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        public int SelectedCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the selected department.
        /// </summary>
        /// <value>
        /// The selected department.
        /// </value>
        public string SelectedDepartment { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        public IList<IDepartment> DepartmentCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}