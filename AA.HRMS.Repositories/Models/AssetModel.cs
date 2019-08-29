using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAsset" />
    
    public class AssetModel : IAsset

    {
        public int AssetId { get; set; }
        /// <summary>
        /// 
        /// 
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AssetDescription { get; set; }
        /// <summary>
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
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get; set; }
    }
}
