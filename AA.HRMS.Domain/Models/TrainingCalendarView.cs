using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class TrainingCalendarView : ITraininingCalendarView
    {
        public TrainingCalendarView()
        {
            this.TrainingDropDown = new List<SelectListItem>();
            this.CompanyDropDown = new List<SelectListItem>();
            this.TrainingStatusDropDown = new List<SelectListItem>();
        }
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
        /// Gets or sets the training drop down.
        /// </summary>
        /// <value>
        /// The training drop down.
        /// </value>
        public IList<SelectListItem> TrainingDropDown { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }
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
        /// Gets or sets the training status drop down.
        /// </summary>
        /// <value>
        /// The training status drop down.
        /// </value>
        public IList<SelectListItem> TrainingStatusDropDown { get; set; }
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
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
