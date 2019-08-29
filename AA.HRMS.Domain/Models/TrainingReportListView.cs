using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class TrainingReportListView : ITrainingReportListView
    {
        public TrainingReportListView()
        {
            this.TrainingReportCollection = new List<ITrainingReport>();
        }

        public int SelectedTrainingCalendarID { get; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int? SelectedCompanyID { get; set ; }
        /// <summary>
        /// </summary>
        public string SelectedTrainingName { get ; set ; }
        /// <summary>
        /// Gets or sets the name of the selected employee.
        /// </summary>
        /// <value>
        /// The name of the selected employee.
        /// </value>
        public string SelectedEmployeeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TrainingEvaluationRating { get ; set ; }
        /// <summary>
        /// 
        /// </summary>
        public IList<ITrainingReport> TrainingReportCollection { get ; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set ; }
        /// <summary>
        /// 
        /// </summary>
        public int TrainingReportID { get ; set; }
    }
}
