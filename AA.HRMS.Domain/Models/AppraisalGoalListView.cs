using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class AppraisalGoalListView : IAppraisalGoalListView
    {
        /// <summary>
        /// Gets or sets the appraisal collection.
        /// </summary>
        /// <value>
        /// The appraisal collection.
        /// </value>
        public IList<IAppraisalGoal> AppraisalCollection { get; set; }
        /// <summary>
        /// Gets or sets the employee appraisal.
        /// </summary>
        /// <value>
        /// The employee appraisal.
        /// </value>
        public IEmployeeAppraisal EmployeeAppraisal { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }
    }
}
