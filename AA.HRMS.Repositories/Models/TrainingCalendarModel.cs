using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ITrainingCalendar" />
    public class TrainingCalendarModel : ITrainingCalendar
    {

        /// <summary>
        /// Gets or sets the training calender identifier.
        /// </summary>
        /// <value>
        /// The training calender identifier.
        /// </value>
        public int TrainingCalenderId { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        public int TrainingId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the delivery start date.
        /// </summary>
        /// <value>
        /// The delivery start date.
        /// </value>
        public DateTime DeliveryStartDate { get; set; }
        /// <summary>
        /// Gets or sets the delivery end date.
        /// </summary>
        /// <value>
        /// The delivery end date.
        /// </value>
        public DateTime DeliveryEndDate { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the training status identifier.
        /// </summary>
        /// <value>
        /// The training status identifier.
        /// </value>
        public int TrainingStatusId { get; set; }
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
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        /// The name of the training.
        /// </value>
        public string TrainingName { get; set; }
        /// <summary>
        /// Gets or sets the name of the training status.
        /// </summary>
        /// <value>
        /// The name of the training status.
        /// </value>
        public string TrainingStatusName { get; set; }
    }
}
