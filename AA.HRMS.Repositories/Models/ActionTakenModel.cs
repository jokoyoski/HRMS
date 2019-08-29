using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class ActionTakenModel : IActionTaken
    {
        /// <summary>
        /// Gets or sets the action taken identifier.
        /// </summary>
        /// <value>
        /// The action taken identifier.
        /// </value>
        public int ActionTakenId { get; set; }
        /// <summary>
        /// Gets or sets the name of the action taken.
        /// </summary>
        /// <value>
        /// The name of the action taken.
        /// </value>
        public string ActionTakenName { get; set; }
        /// <summary>
        /// Gets or sets the action taken description.
        /// </summary>
        /// <value>
        /// The action taken description.
        /// </value>
        public string ActionTakenDescription { get; set; }
    }
}
