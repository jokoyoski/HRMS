using System.Collections.Generic;
using System.Web.Mvc;



namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssetListView
    {
        /// <summary>
        /// 
        /// </summary>
        int SelectedCompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<IAsset> assetsCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int AssetId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string AssetName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string AssetDescription { get; set; }
        /// <summary>
        /// 
        /// 
        /// </summary>
        decimal AssetCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int LifeSpan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string AssetSerialNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
       
       bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
       int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>

        string ProcessingMessage { get; set; }
    }
}
    
