using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingStatus
    {
        /// <summary>
        /// Gets or sets the training status identifier.
        /// </summary>
        /// <value>
        /// The training status identifier.
        /// </value>
        int TrainingStatusId { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        string Status { get; set; }
    }
}
