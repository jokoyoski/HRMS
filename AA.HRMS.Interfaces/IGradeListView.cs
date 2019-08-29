using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGradeListView
    {
        /// <summary>
        /// Gets or sets the grades collection.
        /// </summary>
        /// <value>
        /// The grades collection.
        /// </value>
        IEnumerable<IGrade> GradesCollection { get; set; }

        /// <summary>
        /// Gets or sets the company details.
        /// </summary>
        /// <value>
        /// The company details.
        /// </value>
        ICompanyDetail CompanyDetails { get; set; }

        IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected grade.
        /// </summary>
        /// <value>
        /// The name of the selected grade.
        /// </value>
        string SelectedGradeName { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}