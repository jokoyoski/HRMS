using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdvertisementModelView
    {
        /// <summary>
        /// Gets or sets the advertisement identifier.
        /// </summary>
        /// <value>
        /// The advertisement identifier.
        /// </value>
        int AdvertisementId { get; set; }

        /// <summary>
        /// Gets or sets the media.
        /// </summary>
        /// <value>
        /// The media.
        /// </value>
        string Media { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }

        /// <summary>
        /// Gets or sets the is status.
        /// </summary>
        /// <value>
        /// The is status.
        /// </value>
        int IsStatus { get; set; }

        /// <summary>
        /// Gets or sets the digital field identifier.
        /// </summary>
        /// <value>
        /// The digital field identifier.
        /// </value>
        int DigitalFieldId { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
