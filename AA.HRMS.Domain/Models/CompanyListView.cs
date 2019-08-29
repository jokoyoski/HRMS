using AA.HRMS.Interfaces;
using System.Collections.Generic;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ICompanyListView" />
    public class CompanyListView : ICompanyListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyListView"/> class.
        /// </summary>
        public CompanyListView()
        {
            this.CompanyCollection = new List<ICompanyDetail>();
            this.ProcessingMessage = string.Empty;
            this.SelectedCompanyId = string.Empty;
            this.SelectedCompanyName = string.Empty;
        }

        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        public string SelectedCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected company.
        /// </summary>
        /// <value>
        /// The name of the selected company.
        /// </value>
        public string SelectedCompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company collection.
        /// </summary>
        /// <value>
        /// The company collection.
        /// </value>
        public IList<ICompanyDetail> CompanyCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
