using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingNeedAnalysisListView
    {
        /// <summary>
        /// Gets or sets the trainingNeedAnalysis collection.
        /// </summary>
        /// <value>
        /// The trainingNeedAnalysis collection.
        /// </value>
        IList<ITrainingNeedAnalysis> TrainingNeedAnalysisCollection { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyDetail Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string SelectedTrainingNeedAnalysis { get; set; }
        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        int? SelectedCompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int? SelectedTrainingNeedAnalysisId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }
    }
}

