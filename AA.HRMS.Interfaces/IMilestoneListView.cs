using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IMilestoneListView
    {
        /// <summary>
        /// Gets or sets the milestone collection.
        /// </summary>
        /// <value>
        /// The milestone collection.
        /// </value>
        IList<IMilestone> MilestoneCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
