using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    internal static class AssetQueries
    {
      
        /// <summary>S
        /// Gets the name of the asset by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>

        internal static IAsset getAssetByName(HRMSEntities db, string assetName, int companyId)
        {
            var result = (from d in db.Assets
                         where d.AssetName.Equals(assetName) && d.CompanyId == companyId
                          select new AssetModel
                          {
                              AssetId = d.AssetId,
                              AssetName = d.AssetName,
                              AssetDescription = d.AssetDescription,
                              AssetCost = d.AssetCost,
                              LifeSpan = d.LifeSpan,
                              AssetSerialNumber = d.AssetSerialNumber,
                              PurchaseDate = d.PurchaseDate,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              CompanyId = d.CompanyId,
                          }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the asset by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>

        internal static IAsset getAssetById(HRMSEntities db, int assetId, int companyId)
        {
                var result = (from d in db.Assets
                              where d.AssetId.Equals(assetId) && d.CompanyId == companyId
                              select new AssetModel
                              {
                                  AssetId = d.AssetId,
                                  AssetName = d.AssetName,
                                  AssetDescription = d.AssetDescription,
                                  AssetCost = d.AssetCost,
                                  LifeSpan = d.LifeSpan,
                                  AssetSerialNumber = d.AssetSerialNumber,
                                  PurchaseDate = d.PurchaseDate,
                                  IsActive = d.IsActive,
                                  DateCreated = d.DateCreated,
                                  CompanyId = d.CompanyId,
                              }).FirstOrDefault();
                return result;
        }

        internal static IEnumerable<IAsset> getAllAssetByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Assets
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          where d.CompanyId.Equals(companyId)
                          select new AssetModel
                          {
                              AssetId = d.AssetId,
                              AssetName = d.AssetName,
                              AssetDescription = d.AssetDescription,
                              AssetCost = d.AssetCost,
                              LifeSpan = d.LifeSpan,
                              AssetSerialNumber = d.AssetSerialNumber,
                              PurchaseDate = d.PurchaseDate,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              CompanyId = d.CompanyId,
                             
                          }).OrderBy(p=>p.AssetName);
            return result;
        }

        /// <summary>
        /// Gets all asset.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="AssetId">The asset identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IAsset> getAllAsset(HRMSEntities db, int companyId, int AssetId)
        {
            var result = (from d in db.Assets
                          where d.CompanyId == companyId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join passet in db.Assets on d.AssetId equals passet.AssetId into gj
                          from f in gj.DefaultIfEmpty()
                          select new AssetModel
                          {
                              AssetId = d.AssetId,
                              AssetName = d.AssetName,
                              AssetDescription = d.AssetDescription,
                              AssetCost = d.AssetCost,
                              LifeSpan = d.LifeSpan,
                              AssetSerialNumber = d.AssetSerialNumber,
                              PurchaseDate = d.PurchaseDate,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              CompanyId = d.CompanyId,
                          }).ToList();

            return result;
        }

    }
}
