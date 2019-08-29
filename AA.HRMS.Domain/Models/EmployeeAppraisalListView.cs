using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class EmployeeAppraisalListView : IEmployeeAppraisalListView
    {
        /// <summary>
        /// Gets or sets the employee appraisal collection.
        /// </summary>
        /// <value>
        /// The employee appraisal collection.
        /// </value>
        public IList<IEmployeeAppraisal> EmployeeAppraisalCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public ICompanyDetail Company { get; set; }
    }
}
