using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IMilestone
    {
        /// <summary>
        /// Gets or sets the milestone identifier.
        /// </summary>
        /// <value>
        /// The milestone identifier.
        /// </value>
        int MilestoneId { get; set; }

        /// <summary>
        /// Gets or sets the name of the milestone.
        /// </summary>
        /// <value>
        /// The name of the milestone.
        /// </value>
        string MilestoneName { get; set; }

        /// <summary>
        /// Gets or sets the milestone description.
        /// </summary>
        /// <value>
        /// The milestone description.
        /// </value>
        string MilestoneDescription { get; set; }

        /// <summary>
        /// Gets or sets the has started.
        /// </summary>
        /// <value>
        /// The has started.
        /// </value>
        bool? hasStarted { get; set; }

        /// <summary>
        /// Gets or sets the date started.
        /// </summary>
        /// <value>
        /// The date started.
        /// </value>
        DateTime? DateStarted { get; set; }

        /// <summary>
        /// Gets or sets the has completed.
        /// </summary>
        /// <value>
        /// The has completed.
        /// </value>
        bool? hasCompleted { get; set; }
        
        /// <summary>
        /// Gets or sets the date completed.
        /// </summary>
        /// <value>
        /// The date completed.
        /// </value>
        DateTime? DateCompleted { get; set; }

        /// <summary>
        /// Gets or sets the is approved.
        /// </summary>
        /// <value>
        /// The is approved.
        /// </value>
        bool? IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the date approved.
        /// </summary>
        /// <value>
        /// The date approved.
        /// </value>
        DateTime? DateApproved { get; set; }

        /// <summary>
        /// Gets or sets the approval comment.
        /// </summary>
        /// <value>
        /// The approval comment.
        /// </value>
        string ApprovalComment { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        string TaskName { get; set; }
    }
}
