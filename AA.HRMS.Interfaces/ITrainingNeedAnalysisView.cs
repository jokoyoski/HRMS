using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingNeedAnalysisView
    {
        /// <summary>
        /// 
        /// </summary>
        int TrainingNeedAnalysisID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int JobID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int TrainingID { get; set; }
        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        /// The name of the training.
        /// </value>
        string TrainingName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int CompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string TrainingDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int MethodOfDelivery { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string TrainingProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        decimal Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int Currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsProviderApproved { get; set; }
        /// <summary>
        /// Gets or sets the approved budget.
        /// </summary>
        /// <value>
        /// The approved budget.
        /// </value>
        decimal ApprovedBudget { get; set; }
        /// <summary>
        /// Gets or sets the approved budget currency.
        /// </summary>
        /// <value>
        /// The approved budget currency.
        /// </value>
        int ApprovedBudgetCurrency { get; set; }
        /// <summary>
        /// Gets or sets the approved budget currency drop down list.
        /// </summary>
        /// <value>
        /// The approved budget currency drop down list.
        /// </value>
        IList<SelectListItem> ApprovedBudgetCurrencyDropDownList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int FrequencyOfDeliveryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        decimal TrainingDuration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string CertificateIssued { get; set; }
        /// <summary>
        /// 
        /// </summary>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the company dropdown list.
        /// </summary>
        /// <value>
        /// The company dropdown list.
        /// </value>
        IList<SelectListItem> CompanyDropdownList { get; set; }
        /// <summary>
        /// Gets or sets the training drop down list.
        /// </summary>
        /// <value>
        /// The training drop down list.
        /// </value>
        IList<SelectListItem> TrainingDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the job drop down list.
        /// </summary>
        /// <value>
        /// The job drop down list.
        /// </value>
        IList<SelectListItem> JobDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the currency drop down.
        /// </summary>
        /// <value>
        /// The currency drop down.
        /// </value>
        IList<SelectListItem> CurrencyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the frequency of delivery drop down.
        /// </summary>
        /// <value>
        /// The frequency of delivery drop down.
        /// </value>
        IList<SelectListItem> FrequencyOfDeliveryDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the method of delivery drop down.
        /// </summary>
        /// <value>
        /// The method of delivery drop down.
        /// </value>
        IList<SelectListItem> MethodOfDeliveryDropDown { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
