using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IIndustryListView" />
    public class IndustryListView : IIndustryListView
    {

        public IndustryListView()
        {
            this.IndustryCollection = new List<IIndustry>();
            this.ProcessingMessage = string.Empty;
            this.SelectedIndustryId = string.Empty;
            this.SelectedIndustryName = string.Empty;
        }

        public string SelectedIndustryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected industry.
        /// </summary>
        /// <value>
        /// The name of the selected industry.
        /// </value>
        public string SelectedIndustryName { get; set; }

        /// <summary>
        /// Gets or sets the industry collection.
        /// </summary>
        /// <value>
        /// The industry collection.
        /// </value>
        public IList<IIndustry> IndustryCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
