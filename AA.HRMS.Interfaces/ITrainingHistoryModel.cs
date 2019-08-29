using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingHistoryModel
    {
        /// <summary>
        /// Gets or sets the training history identifier.
        /// </summary>
        /// <value>
        /// The training history identifier.
        /// </value>
        int TrainingHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the training name identifier.
        /// </summary>
        /// <value>
        /// The training name identifier.
        /// </value>
        int TrainingNameId { get; set; }
        /// <summary>
        /// Gets or sets the training vendor identifier.
        /// </summary>
        /// <value>
        /// The training vendor identifier.
        /// </value>
        int TrainingVendorId { get; set; }
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
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the tname.
        /// </summary>
        /// <value>
        /// The tname.
        /// </value>
        string Tname { get; set; }
        /// <summary>
        /// Gets or sets the name of the vendor.
        /// </summary>
        /// <value>
        /// The name of the vendor.
        /// </value>
        string VendorName { get; set; }
        /// <summary>
        /// Gets or sets the name of the certificate.
        /// </summary>
        /// <value>
        /// The name of the certificate.
        /// </value>
        string CertificateName { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}

