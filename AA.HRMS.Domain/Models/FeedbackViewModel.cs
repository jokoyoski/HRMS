using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class FeedbackViewModel : IFeedbackViewModel
    {
        public FeedbackViewModel()
        {
            YearDropDownList = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the feedback identifier.
        /// </summary>
        /// <value>
        /// The feedback identifier.
        /// </value>
        public int FeedbackId { get; set; }

        /// <summary>
        /// Gets or sets the year identifier.
        /// </summary>
        /// <value>
        /// The year identifier.
        /// </value>
        public int YearId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

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
        /// Gets or sets a value indicating whether this instance is lock.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is lock; otherwise, <c>false</c>.
        /// </value>
        public bool IsLock { get; set; }

        /// <summary>
        /// Gets or sets the year drop down list.
        /// </summary>
        /// <value>
        /// The year drop down list.
        /// </value>
        public IList<SelectListItem> YearDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string  ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the no of feedback.
        /// </summary>
        /// <value>
        /// The no of feedback.
        /// </value>
        public int NoOfFeedback { get; set; }
    }
}
