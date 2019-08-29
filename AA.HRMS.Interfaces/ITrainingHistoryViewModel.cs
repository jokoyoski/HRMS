using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
  public   interface ITrainingHistoryViewModel
    {
        /// <summary>
        /// Gets or sets the training history identifier.
        /// </summary>
        /// <value>
        /// The training history identifier.
        /// </value>
        int TrainingHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        int TrainingId { get; set; }
        /// <summary>
        /// Gets or sets the certification identifier.
        /// </summary>
        /// <value>
        /// The certification identifier.
        /// </value>
        int CertificationId { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        DateTime Year { get; set; }
        /// <summary>
        /// Gets or sets the training vendor identifier.
        /// </summary>
        /// <value>
        /// The training vendor identifier.
        /// </value>
        int TrainingVendorId { get; set; }
        /// <summary>
        /// Gets or sets the processingmessage.
        /// </summary>
        /// <value>
        /// The processingmessage.
        /// </value>
        string processingmessage { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the training collection.
        /// </summary>
        /// <value>
        /// The training collection.
        /// </value>
        IList<ITraining> trainingCollection { get; set; }
        /// <summary>
        /// Gets or sets the training report collection.
        /// </summary>
        /// <value>
        /// The training report collection.
        /// </value>
        IList<ITrainingReport> trainingReportCollection { get; set; }
        /// <summary>
        /// Gets or sets the training history ListView.
        /// </summary>
        /// <value>
        /// The training history ListView.
        /// </value>
        IList<ITrainingHistoryListView> TrainingHistoryListView { get; set; }

        /// <summary>
        /// Gets or sets the training drop down list.
        /// </summary>
        /// <value>
        /// The training drop down list.
        /// </value>
        IList<SelectListItem> TrainingDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the certificate drop down list.
        /// </summary>
        /// <value>
        /// The certificate drop down list.
        /// </value>
        IList<SelectListItem> CertificateDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the training vendor drop list.
        /// </summary>
        /// <value>
        /// The training vendor drop list.
        /// </value>
        IList<SelectListItem> TrainingVendorDropList { get; set; }

    }
}
