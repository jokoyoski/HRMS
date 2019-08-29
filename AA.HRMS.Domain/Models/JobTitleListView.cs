using System.Collections.Generic;
using System.Web.Mvc;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IJobTitleListView" />
    public class JobTitleListView : IJobTitleListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobTitleListView"/> class.
        /// </summary>
        public JobTitleListView()
        {
            this.JobTitlesCollection = new List<IJobTitle>();
        }

        /// <summary>
        /// Gets or sets the job titles collection.
        /// </summary>
        /// <value>
        /// The job titles collection.
        /// </value>
        public IList<IJobTitle> JobTitlesCollection { get; set; }

        /// <summary>
        /// Gets or sets the company details.
        /// </summary>
        /// <value>
        /// The company details.
        /// </value>
        public ICompanyDetail CompanyDetails { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected job title.
        /// </summary>
        /// <value>
        /// The selected job title.
        /// </value>
        public string SelectedJobTitle { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
    }
}