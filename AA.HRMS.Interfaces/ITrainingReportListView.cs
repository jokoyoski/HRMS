using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingReportListView
    {
        
        int SelectedTrainingCalendarID { get; set; }
        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        int? SelectedCompanyID { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string SelectedTrainingName { get; set; }
        /// <summary>
        /// Gets or sets the name of the selected employee.
        /// </summary>
        /// <value>
        /// The name of the selected employee.
        /// </value>
        string SelectedEmployeeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int TrainingEvaluationRating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// 
        IList<ITrainingReport> TrainingReportCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int  TrainingReportID { get; set; }

    }
}
