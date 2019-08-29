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
   public interface IAssetRepository
   {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AssetName"></param>
        /// <returns></returns>
       IAsset GetCompanyAssetByName(string AssetName, int companyId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
       IAsset GetCompanyAssetById(int AssetId, int companyId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<IAsset> GetAllAsset(int companyId);
   }
}
