using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IBenefitListView
    {
        /// <summary>
        /// Gets or sets the benefits.
        /// </summary>
        /// <value>
        /// The benefits.
        /// </value>
        IList<IBenefit> Benefits { get; set; }
        /// <summary>
        /// Gets or sets the selected benefit.
        /// </summary>
        /// <value>
        /// The selected benefit.
        /// </value>
        string SelectedBenefit { get; set; }
        /// <summary>
        /// Gets or sets the selected company.
        /// </summary>
        /// <value>
        /// The selected company.
        /// </value>
        string SelectedCompany { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
