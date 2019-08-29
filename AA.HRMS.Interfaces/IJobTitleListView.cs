using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJobTitleListView
    {
        /// <summary>
        /// Gets or sets the job titles collection.
        /// </summary>
        /// <value>
        /// The job titles collection.
        /// </value>
        IList<IJobTitle> JobTitlesCollection { get; set; }

        /// <summary>
        /// Gets or sets the company details.
        /// </summary>
        /// <value>
        /// The company details.
        /// </value>
        ICompanyDetail CompanyDetails { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected job title.
        /// </summary>
        /// <value>
        /// The selected job title.
        /// </value>
        string SelectedJobTitle { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }
    }
}