using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDepartmentListView
    {
        /// <summary>
        /// Gets or sets the selected department identifier.
        /// </summary>
        /// <value>
        /// The selected department identifier.
        /// </value>
        int SelectedDepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        int SelectedCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the selected department.
        /// </summary>
        /// <value>
        /// The selected department.
        /// </value>
        string SelectedDepartment { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        IList<IDepartment> DepartmentCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}