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
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalActionListView" />
    public class AppraisalActionListView : IAppraisalActionListView
    {
        /// <summary>
        /// Gets or sets the appraisal action identifier.
        /// </summary>
        /// <value>
        /// The appraisal action identifier.
        /// </value>
        public int AppraisalActionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the appraisal action.
        /// </summary>
        /// <value>
        /// The name of the appraisal action.
        /// </value>
        public string AppraisalActionName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the appraisal action.
        /// </summary>
        /// <value>
        /// The appraisal action.
        /// </value>
        public IList<IAppraisalActionView> appraisalAction { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
