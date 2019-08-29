using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingNeedAnalysis
    {
        /// <summary>
        /// Gets or sets the training need anaylsis identifier.
        /// </summary>
        /// <value>
        /// The training need anaylsis identifier.
        /// </value>
        int TrainingNeedAnaylsisId { get; set; }
        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>
        /// The job identifier.
        /// </value>
        int JobId { get; set; }
        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        string JobTitle { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        int TrainingId { get; set; }
        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        /// The name of the training.
        /// </value>
        string TrainingName { get; set; }
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
        int MethodOfDelivery { get; set; }
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
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        int CurrencyId { get; set; }
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
        /// Gets or sets the approved budget currency.
        /// </summary>
        /// <value>
        /// The approved budget currency.
        /// </value>
        int ApprovedBudgetCurrency { get; set; }
        /// <summary>
        /// Gets or sets the frequecy of delivery identifier.
        /// </summary>
        /// <value>
        /// The frequecy of delivery identifier.
        /// </value>
        int FrequecyOfDeliveryId { get; set; }
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
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the frequency of delivery.
        /// </summary>
        /// <value>
        /// The frequency of delivery.
        /// </value>
        string FrequencyOfDelivery { get; set; }
    }
}
