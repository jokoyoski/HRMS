using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssetView
    {
        /// <summary>
        /// Gets or sets the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
      
        string AssetName { get; set; }
        /// <summary>
        /// Gets or sets the asset description.
        /// </summary>
        /// <value>
        /// The asset description.
        /// </value>
        string AssetDescription { get; set; }
        /// <summary>
        /// Gets or sets the asset cost.
        /// </summary>
        /// <value>
        /// The asset cost.
        /// </value>
        decimal AssetCost { get; set; }
        /// <summary>
        /// Gets or sets the life span.
        /// </summary>
        /// <value>
        /// The life span.
        /// </value>
        int LifeSpan { get; set; }
        /// <summary>
        /// Gets or sets the asset serial number.
        /// </summary>
        /// <value>
        /// The asset serial number.
        /// </value>
        string AssetSerialNumber { get; set; }
        /// <summary>
        /// Gets or sets the purchase date.
        /// </summary>
        /// <value>
        /// The purchase date.
        /// </value>
        DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the asset identifier drop down.
        /// </summary>
        /// <value>
        /// The asset identifier drop down.
        /// </value>
        IList<SelectListItem> AssetIdDropDown { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
   
}

