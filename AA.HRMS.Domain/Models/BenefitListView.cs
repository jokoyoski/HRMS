using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class BenefitListView : IBenefitListView
    {
        /// <summary>
        /// Gets or sets the benefits.
        /// </summary>
        /// <value>
        /// The benefits.
        /// </value>
        public IList<IBenefit> Benefits { get; set; }
        /// <summary>
        /// Gets or sets the selected benefit.
        /// </summary>
        /// <value>
        /// The selected benefit.
        /// </value>
        public string SelectedBenefit { get; set; }
        /// <summary>
        /// Gets or sets the selected company.
        /// </summary>
        /// <value>
        /// The selected company.
        /// </value>
        public string SelectedCompany { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
