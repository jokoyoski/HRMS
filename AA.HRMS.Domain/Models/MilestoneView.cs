using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class MilestoneView : IMilestoneView
    {
        /// <summary>
        /// Gets or sets the milestone identifier.
        /// </summary>
        /// <value>
        /// The milestone identifier.
        /// </value>
        public int MilestoneId { get; set; }

        /// <summary>
        /// Gets or sets the name of the milestone.
        /// </summary>
        /// <value>
        /// The name of the milestone.
        /// </value>
        public string MilestoneName { get; set; }

        /// <summary>
        /// Gets or sets the milestone description.
        /// </summary>
        /// <value>
        /// The milestone description.
        /// </value>
        public string MilestoneDescription { get; set; }

        /// <summary>
        /// Gets or sets the has started.
        /// </summary>
        /// <value>
        /// The has started.
        /// </value>
        public bool? hasStarted { get; set; }

        /// <summary>
        /// Gets or sets the date started.
        /// </summary>
        /// <value>
        /// The date started.
        /// </value>
        public DateTime? DateStarted { get; set; }

        /// <summary>
        /// Gets or sets the has completed.
        /// </summary>
        /// <value>
        /// The has completed.
        /// </value>
        public bool? hasCompleted { get; set; }

        /// <summary>
        /// Gets or sets the date completed.
        /// </summary>
        /// <value>
        /// The date completed.
        /// </value>
        public DateTime? DateCompleted { get; set; }

        /// <summary>
        /// Gets or sets the is approved.
        /// </summary>
        /// <value>
        /// The is approved.
        /// </value>
        public bool? IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the date approved.
        /// </summary>
        /// <value>
        /// The date approved.
        /// </value>
        public DateTime? DateApproved { get; set; }

        /// <summary>
        /// Gets or sets the approval comment.
        /// </summary>
        /// <value>
        /// The approval comment.
        /// </value>
        public string ApprovalComment { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
