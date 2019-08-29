using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeTrainingModel" />
    public class EmployeeTrainingModel : IEmployeeTrainingModel
   {
        /// <summary>
        /// Gets or sets the employee training identifier.
        /// </summary>
        /// <value>
        /// The employee training identifier.
        /// </value>
        public int EmployeeTrainingId { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        public int TrainingId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the supervisor identifier.
        /// </summary>
        /// <value>
        /// The supervisor identifier.
        /// </value>
        public int SupervisorId { get; set; }
        /// <summary>
        /// Gets or sets the name of the supervisor.
        /// </summary>
        /// <value>
        /// The name of the supervisor.
        /// </value>
        public string SupervisorName { get; set; }
        /// <summary>
        /// Gets or sets the is approved.
        /// </summary>
        /// <value>
        /// The is approved.
        /// </value>
        public bool? IsApproved { get; set; }
        /// <summary>
        /// Gets or sets the date approved.
        /// </summary>
        /// <value>
        /// The date approved.
        /// </value>
        public System.DateTime? DateApproved { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        /// The name of the training.
        /// </value>
        public string TrainingName { get; set; }
        /// <summary>
        /// Gets or sets the training report identifier.
        /// </summary>
        /// <value>
        /// The training report identifier.
        /// </value>
        public int TrainingReportId { get; set; }

   }
}
