using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAdvertisement" />
    public class AdvertisementModel : IAdvertisement
    {
        /// <summary>
        /// Gets or sets the advertisement identifier.
        /// </summary>
        /// <value>
        /// The advertisement identifier.
        /// </value>
        public int AdvertisementId { get; set; }

        /// <summary>
        /// Gets or sets the media.
        /// </summary>
        /// <value>
        /// The media.
        /// </value>
        public string Media { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the is status.
        /// </summary>
        /// <value>
        /// The is status.
        /// </value>
        public int IsStatus { get; set; }

        /// <summary>
        /// Gets or sets the digital field identifier.
        /// </summary>
        /// <value>
        /// The digital field identifier.
        /// </value>
        public int DigitalFieldId { get; set; }
    }
}