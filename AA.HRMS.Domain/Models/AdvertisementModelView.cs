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
    /// <seealso cref="AA.HRMS.Interfaces.IAdvertisementModelView" />
public class AdvertisementModelView : IAdvertisementModelView

{
    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the advertisement identifier.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}The advertisement identifier.
    /// </value>
    public int AdvertisementId { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the media.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}The media.
    /// </value>
    public string Media { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the comment.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}The comment.
    /// </value>
    public string Comment { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the is status.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}The is status.
    /// </value>
    public int IsStatus { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the digital field identifier.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}The digital field identifier.
    /// </value>
    public int DigitalFieldId { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the processing message.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}The processing message.
    /// </value>
    public string ProcessingMessage { get; set; }
}
}
