using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingCalendar
    {
        /// <summary>
        /// Gets or sets the training calender identifier.
        /// </summary>
        /// <value>
        /// The training calender identifier.
        /// </value>
        int TrainingCalenderId { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        int TrainingId { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the delivery start date.
        /// </summary>
        /// <value>
        /// The delivery start date.
        /// </value>
        DateTime DeliveryStartDate { get; set; }
        /// <summary>
        /// Gets or sets the delivery end date.
        /// </summary>
        /// <value>
        /// The delivery end date.
        /// </value>
        DateTime DeliveryEndDate { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        string Location { get; set; }
        /// <summary>
        /// Gets or sets the training status identifier.
        /// </summary>
        /// <value>
        /// The training status identifier.
        /// </value>
        int TrainingStatusId { get; set; }
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
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        /// The name of the training.
        /// </value>
        string TrainingName { get; set; }
        /// <summary>
        /// Gets or sets the name of the training status.
        /// </summary>
        /// <value>
        /// The name of the training status.
        /// </value>
        string TrainingStatusName { get; set; }
    
    }
}
