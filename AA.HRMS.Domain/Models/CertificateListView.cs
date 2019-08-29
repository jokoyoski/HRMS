using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ICertificateListView" />
    public class CertificateListView : ICertificateListView
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the certificate.
        /// </summary>
        /// <value>
        /// The name of the certificate.
        /// </value>
        public string CertificateName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the certification identifier.
        /// </summary>
        /// <value>
        /// The certification identifier.
        /// </value>
        public int CertificationId { get; set; }
        /// <summary>
        /// Gets or sets the certificate model.
        /// </summary>
        /// <value>
        /// The certificate model.
        /// </value>
        public IList<ICertificationModel> certificateModel { get; set; }
    }
    
}
