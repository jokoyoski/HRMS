using System.Collections.Generic;
using AA.HRMS.Interfaces;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IGradeListView" />
    public class GradeListView : IGradeListView
    {
        /// <summary>
        /// Gets or sets the grades collection.
        /// </summary>
        /// <value>
        /// The grades collection.
        /// </value>
        public IEnumerable<IGrade> GradesCollection { get; set; }

        /// <summary>
        /// Gets or sets the company details.
        /// </summary>
        /// <value>
        /// The company details.
        /// </value>
        public ICompanyDetail CompanyDetails { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected grade.
        /// </summary>
        /// <value>
        /// The name of the selected grade.
        /// </value>
        public string SelectedGradeName { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}