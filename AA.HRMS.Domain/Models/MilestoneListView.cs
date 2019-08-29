using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class MilestoneListView : IMilestoneListView
    {

        /// <summary>
        /// Gets or sets the milestone collection.
        /// </summary>
        /// <value>
        /// The milestone collection.
        /// </value>
        public IList<IMilestone> MilestoneCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
