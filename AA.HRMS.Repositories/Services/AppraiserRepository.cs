using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAppraiserRepository" />
    public class AppraiserRepository : IAppraiserRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public AppraiserRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory; 
        }

        public IList<IAppraiser> GetAppraiserList()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraiserList =
                        PerformanceManagementQueries.GetAppraiserList(dbContext).ToList();

                    return appraiserList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraiser list {0}", e);
            }
        }

        /// <summary>
        /// Saves the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public string SaveAppraiserInfo(IAppraiserView appraiserInfo)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            var result = string.Empty;

            var newRecord = new Appraiser
            {
                AppraiserName = appraiserInfo.AppraiserName
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Appraisers.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraiserInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Updates the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraiserInfo
        /// or
        /// appraiserData
        /// </exception>
        public string UpdateAppraiserInfo(IAppraiserView appraiserInfo)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            var result = string.Empty;



            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraiserData =
                        dbContext.Appraisers.SingleOrDefault(m => m.AppraiserId.Equals(appraiserInfo.AppraiserId));
                    if (appraiserData == null) throw new ArgumentNullException(nameof(appraiserData));

                    appraiserData.AppraiserName = appraiserInfo.AppraiserName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Appraiser Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the appraiser by identifier.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalActionById</exception>
        public IAppraiser GetAppraiserById(int appraiserId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraiserById(dbContext, appraiserId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalActionById", e);
            }
        }
        /// <summary>
        /// Deletes the appraiser information.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraiserId</exception>
        /// <exception cref="ArgumentNullException">appraiserId</exception>
        public string DeleteAppraiserInfo(int appraiserId)
        {
            if (appraiserId < 1)

            {
                throw new ArgumentOutOfRangeException("appraiserId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraiserData =
                        dbContext.Appraisers.SingleOrDefault(m => m.AppraiserId.Equals(appraiserId));
                    if (appraiserData == null) throw new ArgumentNullException("appraiserId");

                    appraiserData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Appraiser Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        
    }
}
