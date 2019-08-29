using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class TrainingNeedAnalysisView : ITrainingNeedAnalysisView
    {
        public TrainingNeedAnalysisView()
        {
            this.CompanyDropdownList = new List<SelectListItem>();
            this.TrainingDropDownList = new List<SelectListItem>();
            this.JobDropDownList = new List<SelectListItem>();
            this.FrequencyOfDeliveryDropDownList = new List<SelectListItem>();
            this.CurrencyDropDownList = new List<SelectListItem>();
            this.MethodOfDeliveryDropDown = new List<SelectListItem>();
            this.ApprovedBudgetCurrencyDropDownList = new List<SelectListItem>();
        }
        public int TrainingNeedAnalysisID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int JobID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TrainingID { get; set; }
        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        /// The name of the training.
        /// </value>
        public string TrainingName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MethodOfDelivery { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsProviderApproved { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal ApprovedBudget { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ApprovedBudgetCurrency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FrequencyOfDeliveryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal TrainingDuration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CertificateIssued { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the company dropdown list.
        /// </summary>
        /// <value>
        /// The company dropdown list.
        /// </value>
        public IList<SelectListItem> CompanyDropdownList { get; set; }
        /// <summary>
        /// Gets or sets the training drop down list.
        /// </summary>
        /// <value>
        /// The training drop down list.
        /// </value>
        public IList<SelectListItem> TrainingDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the job drop down list.
        /// </summary>
        /// <value>
        /// The job drop down list.
        /// </value>
        public IList<SelectListItem> JobDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the currency drop down.
        /// </summary>
        /// <value>
        /// The currency drop down.
        /// </value>
        public IList<SelectListItem> CurrencyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the approved budget currency drop down list.
        /// </summary>
        /// <value>
        /// The approved budget currency drop down list.
        /// </value>
        public IList<SelectListItem> ApprovedBudgetCurrencyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the frequency of delivery drop down.
        /// </summary>
        /// <value>
        /// The frequency of delivery drop down.
        /// </value>
        public IList<SelectListItem> FrequencyOfDeliveryDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the method of delivery drop down.
        /// </summary>
        /// <value>
        /// The method of delivery drop down.
        /// </value>
        public IList<SelectListItem> MethodOfDeliveryDropDown { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
