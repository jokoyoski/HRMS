using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ITrainingHistoryModel" />
    public class TrainingHistoryModel : ITrainingHistoryModel
    {
        public int TrainingHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the training name identifier.
        /// </summary>
        /// <value>
        /// The training name identifier.
        /// </value>
        public int TrainingNameId { get; set; }
        /// <summary>
        /// Gets or sets the training vendor identifier.
        /// </summary>
        /// <value>
        /// The training vendor identifier.
        /// </value>
        public int TrainingVendorId { get; set; }
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
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the tname.
        /// </summary>
        /// <value>
        /// The tname.
        /// </value>
        public string Tname { get; set; }
        /// <summary>
        /// Gets or sets the name of the vendor.
        /// </summary>
        /// <value>
        /// The name of the vendor.
        /// </value>
        public string VendorName { get; set; }
        /// <summary>
        /// Gets or sets the name of the certificate.
        /// </summary>
        /// <value>
        /// The name of the certificate.
        /// </value>
        public string CertificateName {get;set;}
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
