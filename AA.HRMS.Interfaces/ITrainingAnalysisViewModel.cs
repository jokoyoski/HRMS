﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
   public interface ITrainingAnalysisViewModel
    {
        /// <summary>
        /// Gets or sets the training need analysis identifier.
        /// </summary>
        /// <value>
        /// The training need analysis identifier.
        /// </value>
        int TrainingNeedAnalysisID { get; set; }
        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>
        /// The job identifier.
        /// </value>
        int JobID { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        int TrainingID { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyID { get; set; }
        /// <summary>
        /// Gets or sets the training description.
        /// </summary>
        /// <value>
        /// The training description.
        /// </value>
        string TrainingDescription { get; set; }
        /// <summary>
        /// Gets or sets the method of delivery.
        /// </summary>
        /// <value>
        /// The method of delivery.
        /// </value>
        string MethodOfDelivery { get; set; }
        /// <summary>
        /// Gets or sets the training provider.
        /// </summary>
        /// <value>
        /// The training provider.
        /// </value>
        string TrainingProvider { get; set; }
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        decimal Cost { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        string Location { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is provider approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is provider approved; otherwise, <c>false</c>.
        /// </value>
        bool IsProviderApproved { get; set; }
        /// <summary>
        /// Gets or sets the approved budget.
        /// </summary>
        /// <value>
        /// The approved budget.
        /// </value>
        decimal ApprovedBudget { get; set; }
        /// <summary>
        /// Gets or sets the frequency of delivery identifier.
        /// </summary>
        /// <value>
        /// The frequency of delivery identifier.
        /// </value>
        int FrequencyOfDeliveryID { get; set; }
        /// <summary>
        /// Gets or sets the duration of the training.
        /// </summary>
        /// <value>
        /// The duration of the training.
        /// </value>
        decimal TrainingDuration { get; set; }
        /// <summary>
        /// Gets or sets the certificate issued.
        /// </summary>
        /// <value>
        /// The certificate issued.
        /// </value>
        string CertificateIssued { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        string Currency { get; set; }
        /// <summary>
        /// Gets or sets the approved budget currency.
        /// </summary>
        /// <value>
        /// The approved budget currency.
        /// </value>
        string ApprovedBudgetCurrency { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }


        IList<SelectListItem> CompanyDropdownList { get; set; }
        /// <summary>
        /// Gets or sets the training drop down list.
        /// </summary>
        /// <value>
        /// The training drop down list.
        /// </value>
        IList<SelectListItem> TrainingDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the frequency of delivery drop down list.
        /// </summary>
        /// <value>
        /// The frequency of delivery drop down list.
        /// </value>
        IList<SelectListItem> FrequencyOfDeliveryDropDownList { set; get; }
        /// <summary>
        /// Gets or sets the job drop down list.
        /// </summary>
        /// <value>
        /// The job drop down list.
        /// </value>
        IList<SelectListItem> JobDropDownList { get; set; }
    }
}
