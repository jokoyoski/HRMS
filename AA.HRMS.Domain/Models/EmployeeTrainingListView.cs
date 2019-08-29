using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{

    public class EmployeeTrainingListView : IEmployeeTrainingListView
    {
        public EmployeeTrainingListView()
        {
            this.employeeTrainingView = new List<IEmployeeTrainingModel>();
            this.employeeTraining = new List<IEmployeeTrainingView>();
            this.CompanyDropDownList = new List<SelectListItem>();
            this.EmployeeDropDownList = new List<SelectListItem>();
            this.TrainingDropDownList = new List<SelectListItem>();
        }

        public int EmployeeTrainingId { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        public int TrainingId { get; set; }

        public string URL { get; set; }
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
        public DateTime DateApproved { get; set; }
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
        /// Gets or sets the selected employee identifier.
        /// </summary>
        /// <value>
        /// The selected employee identifier.
        /// </value>
        public int SelectedEmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the selected training identifier.
        /// </summary>
        /// <value>
        /// The selected training identifier.
        /// </value>
        public int SelectedTrainingId { get; set; }
        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        public int SelectedCompanyId { get; set; }

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
        /// <summary>
        /// Gets or sets the training.
        /// </summary>
        /// <value>
        /// The training.
        /// </value>
        public ITraining Training { get; set; }
        /// <summary>
        /// Gets or sets the employee training view.
        /// </summary>
        /// <value>
        /// The employee training view.
        /// </value>
        public IList<IEmployeeTrainingModel> employeeTrainingView { get; set; }
        /// <summary>
        /// Gets or sets the employee training.
        /// </summary>
        /// <value>
        /// The employee training.
        /// </value>
        public IList<IEmployeeTrainingView> employeeTraining{ get; set; }
    }
}
