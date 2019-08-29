using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IActionTaken
    {
        /// <summary>
        /// Gets or sets the action taken identifier.
        /// </summary>
        /// <value>
        /// The action taken identifier.
        /// </value>
        int ActionTakenId { get; set; }
        /// <summary>
        /// Gets or sets the name of the action taken.
        /// </summary>
        /// <value>
        /// The name of the action taken.
        /// </value>
        string ActionTakenName { get; set; }
        /// <summary>
        /// Gets or sets the action taken description.
        /// </summary>
        /// <value>
        /// The action taken description.
        /// </value>
        string ActionTakenDescription { get; set; }
    }
}
