using System.Collections.Generic;
using System.Web.Mvc;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAssetListView" />
    
    public class AssetListView : IAssetListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetListView"/> class.
        /// </summary>
        public AssetListView()
        {
          
            this.CompanyDropDownList = new List<SelectListItem>();
        }

        public int AssetId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AssetDescription { get; set; }
        /// <summary>
        /// 
        /// 
        /// </summary>
        public decimal AssetCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LifeSpan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AssetSerialNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime PurchaseDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// 
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
       public IList<IAsset> assetsCollection { get; set; }    
        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
       public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// 
        /// </summary>
       public int SelectedCompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }
    }
}
