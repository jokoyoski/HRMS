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
    /// <seealso cref="AA.HRMS.Interfaces.ITrainingListView" />
    public class TrainingListView : ITrainingListView
    {
        public TrainingListView()
        {
            this.TrainingCollection = new List<ITraining>();
            this.CompanyDropDown = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the training collection.
        /// </summary>
        /// <value>
        /// The training collection.
        /// </value>
        public IList<ITraining> TrainingCollection { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company. 
        /// </value>
        public ICompanyDetail Company { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public int SelectedCompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SelectedTraining { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IList<SelectListItem> CompanyDropDown { get; set; }
    }
}

