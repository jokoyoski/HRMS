using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingCalendarListView
    {
        /// <summary>
        /// Gets or sets the training calendar collection.
        /// </summary>
        /// <value>
        /// The training calendar collection.
        /// </value>
        IList<ITrainingCalendar> TrainingCalendarCollection { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        int? SelectedCompanyId { get; set; }
        /// <summary>
        /// Gets or sets the selected location.
        /// </summary>
        /// <value>
        /// The selected location.
        /// </value>
        string SelectedLocation { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected training.
        /// </summary>
        /// <value>
        /// The name of the selected training.
        /// </value>
        string SelectedTrainingName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
