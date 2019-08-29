using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class TrainingCalendarListView : ITrainingCalendarListView
    {

        public TrainingCalendarListView()
        {
            this.TrainingCalendarCollection = new List<ITrainingCalendar>();
            this.CompanyDropDown = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the training calendar collection.
        /// </summary>
        /// <value>
        /// The training calendar collection.
        /// </value>
        public IList<ITrainingCalendar> TrainingCalendarCollection { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        public int? SelectedCompanyId { get; set; }
        /// <summary>
        /// Gets or sets the selected location.
        /// </summary>
        /// <value>
        /// The selected location.
        /// </value>
        public string SelectedLocation { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected training.
        /// </summary>
        /// <value>
        /// The name of the selected training.
        /// </value>
        public string SelectedTrainingName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
