using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ICompanyListView
    {
        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        string SelectedCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected company.
        /// </summary>
        /// <value>
        /// The name of the selected company.
        /// </value>
        string SelectedCompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company collection.
        /// </summary>
        /// <value>
        /// The company collection.
        /// </value>
        IList<ICompanyDetail> CompanyCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}