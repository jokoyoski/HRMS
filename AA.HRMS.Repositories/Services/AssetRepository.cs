using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAssetRepository" />
    public class AssetRepository : IAssetRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        
        public AssetRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>


        public IAsset GetCompanyAssetByName(string assetName, int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = AssetQueries.getAssetByName(dbContext, assetName, companyId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAssetByName", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public IAsset GetCompanyAssetById(int AssetId, int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = AssetQueries.getAssetById(dbContext, AssetId, companyId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAssetByName", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>

        public IList<IAsset> GetAllAsset(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = AssetQueries.getAllAssetByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllAsset", e);
            }
        }

    }
}

