using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IIndustryListView
    {
        /// <summary>
        /// Gets or sets the selected industry identifier.
        /// </summary>
        /// <value>
        /// The selected industry identifier.
        /// </value>
        string SelectedIndustryId { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected industry.
        /// </summary>
        /// <value>
        /// The name of the selected industry.
        /// </value>
        string SelectedIndustryName { get; set; }
        /// <summary>
        /// Gets or sets the industry collection.
        /// </summary>
        /// <value>
        /// The industry collection.
        /// </value>
        IList<IIndustry> IndustryCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
