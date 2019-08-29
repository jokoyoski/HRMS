using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class TrainingNeedAnalysisListView : ITrainingNeedAnalysisListView
    {
        public TrainingNeedAnalysisListView()
        {
            this.TrainingNeedAnalysisCollection = new List<ITrainingNeedAnalysis>();
            this.CompanyDropDownList = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the trainingNeedAnalysis collection.
        /// </summary>
        /// <value>
        /// The trainingNeedAnalysis collection.
        /// </value>
        public IList<ITrainingNeedAnalysis> TrainingNeedAnalysisCollection { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public ICompanyDetail Company { get; set; }

        /// <summary>
        /// </summary>
        public int? SelectedTrainingNeedAnalysisId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? SelectedCompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SelectedTrainingNeedAnalysis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set ; }
    }
}
