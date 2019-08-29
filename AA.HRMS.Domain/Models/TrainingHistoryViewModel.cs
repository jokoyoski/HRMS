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
    /// <seealso cref="AA.HRMS.Interfaces.ITrainingHistoryViewModel" />
    public class TrainingHistoryViewModel : ITrainingHistoryViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingHistoryViewModel"/> class.
        /// </summary>
        public TrainingHistoryViewModel()
        {
            this.TrainingDropDownList = new List<SelectListItem>();

            this.TrainingDropDownList = new List<SelectListItem>();
        }
        public int TrainingHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        public int TrainingId { get; set; }
        /// <summary>
        /// Gets or sets the certification identifier.
        /// </summary>
        /// <value>
        /// The certification identifier.
        /// </value>
        public int CertificationId { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public DateTime Year { get; set; }
        /// <summary>
        /// Gets or sets the processingmessage.
        /// </summary>
        /// <value>
        /// The processingmessage.
        /// </value>
        public string processingmessage { get; set; }
        /// <summary>
        /// Gets or sets the training vendor identifier.
        /// </summary>
        /// <value>
        /// The training vendor identifier.
        /// </value>
        public int TrainingVendorId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool  IsActive { get; set; }

        public IList<ITraining> trainingCollection { get; set; }
        /// <summary>
        /// Gets or sets the training report collection.
        /// </summary>
        /// <value>
        /// The training report collection.
        /// </value>
        public IList<ITrainingReport> trainingReportCollection { get; set; }
        /// <summary>
        /// Gets or sets the training history ListView.
        /// </summary>
        /// <value>
        /// The training history ListView.
        /// </value>
        public IList<ITrainingHistoryListView> TrainingHistoryListView { get; set; }

        /// <summary>
        /// Gets or sets the training drop down list.
        /// </summary>
        /// <value>
        /// The training drop down list.
        /// </value>
        public IList<SelectListItem> TrainingDropDownList { get; set;}

        /// <summary>
        /// Gets or sets the certificate drop down list.
        /// </summary>
        /// <value>
        /// The certificate drop down list.
        /// </value>
        public IList<SelectListItem> CertificateDropDownList { get; set;}

        /// <summary>
        /// Gets or sets the training vendor drop list.
        /// </summary>
        /// <value>
        /// The training vendor drop list.
        /// </value>
        public IList<SelectListItem> TrainingVendorDropList { get; set;}

    }
}
