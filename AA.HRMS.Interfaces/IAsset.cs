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
   public interface IAsset
    {
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
        DateTime PurchaseDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int CompanyId { get; set; }
    }
}
