using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models

{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ITrainingView" />

    public class TrainingView : ITrainingView
    {


        public TrainingView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        public int TrainingID { get; set; }
        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        ///The training identifier.
        /// </value>
        public string TrainingName { get; set; }
        /// <summary>
        /// Gets or sets the name of the training..
        /// </summary>
        /// <value>
        /// The training name.
        /// </value>
        public int CompanyID { get; set; }
        /// <summary>
        /// Gets or sets the company  created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>

        public string TrainingDescription { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training description.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

    }
}
