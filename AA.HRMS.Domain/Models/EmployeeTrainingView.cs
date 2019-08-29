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
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeTrainingView" />
    public class EmployeeTrainingView : IEmployeeTrainingView
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeTrainingView"/> class.
        /// </summary>
        public EmployeeTrainingView()
        {
            this.CompanyDropDownList = new List<SelectListItem>();
            this.TrainingDropDownList = new List<SelectListItem>();
            this.EmployeeDropDownList = new List<SelectListItem>();
            this.CompanyDropDown = new List<SelectListItem>();

        }
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
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the supervisor identifier.
        /// </summary>
        /// <value>
        /// The supervisor identifier.
        /// </value>
        public int SupervisorId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproved { get; set; }
        /// <summary>
        /// Gets or sets the date approved.
        /// </summary>
        /// <value>
        /// The date approved.
        /// </value>
        public DateTime? DateApproved { get; set; }
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
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the training report identifier.
        /// </summary>
        /// <value>
        /// The training report identifier.
        /// </value>
        public int TrainingReportId { get; set; }



        /// <summary>
        /// Gets or sets the training drop down list.
        /// </summary>
        /// <value>
        /// The training drop down list.
        /// </value>
        public IList<SelectListItem> TrainingDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the employee drop down list.
        /// </summary>
        /// <value>
        /// The employee drop down list.
        /// </value>
        public IList<SelectListItem> EmployeeDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the employee training ListView.
        /// </summary>
        /// <value>
        /// The employee training ListView.
        /// </value>
        public IList<IEmployeeTrainingListView> employeeTrainingListView { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }

        public ITrainingView Training { get; set; }

        public string URL { get; set; }
    }
}
