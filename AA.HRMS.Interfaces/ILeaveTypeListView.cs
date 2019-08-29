using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveTypeListView
    {
        /// <summary>
        /// Gets or sets the leave types.
        /// </summary>
        /// <value>
        /// The leave types.
        /// </value>
        IList<AA.HRMS.Interfaces.ILeaveType> LeaveTypes { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
