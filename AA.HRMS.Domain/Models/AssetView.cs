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
    /// <seealso cref="AA.HRMS.Interfaces.IAssetView" />
    public class AssetView : IAssetView
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetView"/> class.
        /// </summary>
        public AssetView()
        {
            this.ProcessingMessage = string.Empty;
            this.CompanyDropDownList = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the asset identifier.
        /// <summary>
        /// Gets or sets the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        public int AssetId { get; set; }
        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>
        /// The name of the asset.
        /// </value>
        public string AssetName { get; set; }
        /// <summary>
        /// Gets or sets the asset description.
        /// </summary>
        /// <value>
        /// The asset description.
        /// </value>
        public string AssetDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
      
        public decimal AssetCost { get; set; }
        /// <summary>
        /// Gets or sets the life span.
        /// </summary>
        /// <value>
        /// The life span.
        /// </value>
        public int LifeSpan { get; set; }
        /// <summary>
        /// Gets or sets the asset serial number.
        /// </summary>
        /// <value>
        /// The asset serial number.
        /// </value>
        public string AssetSerialNumber { get; set; }
        /// <summary>
        /// Gets or sets the purchase date.
        /// </summary>
        /// <value>
        /// The purchase date.
        /// </value>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the asset identifier drop down.
        /// </summary>
        /// <value>
        /// The asset identifier drop down.
        /// </value>
      public  IList<SelectListItem> AssetIdDropDown { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

    }
}
