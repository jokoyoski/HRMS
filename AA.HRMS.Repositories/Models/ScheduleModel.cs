using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class ScheduleModel : ISchedule
    {
        /// <summary>
        /// Gets or sets the schedule identifier.
        /// </summary>
        /// <value>
        /// The schedule identifier.
        /// </value>
        public int ScheduleId { get; set; }
        /// <summary>
        /// Gets or sets the name of the schedule.
        /// </summary>
        /// <value>
        /// The name of the schedule.
        /// </value>
        public string ScheduleName { get; set; }
        /// <summary>
        /// Gets or sets the week identifier.
        /// </summary>
        /// <value>
        /// The week identifier.
        /// </value>
        public int WeekId { get; set; }
        /// <summary>
        /// Gets or sets the name of the week.
        /// </summary>
        /// <value>
        /// The name of the week.
        /// </value>
        public string WeekName { get; set; }
        /// <summary>
        /// Gets or sets the day identifier.
        /// </summary>
        /// <value>
        /// The day identifier.
        /// </value>
        public int DayId { get; set; }
        /// <summary>
        /// Gets or sets the name of the day.
        /// </summary>
        /// <value>
        /// The name of the day.
        /// </value>
        public string DayName { get; set; }
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
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
    }
}
