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
    /// <seealso cref="AA.HRMS.Interfaces.IAwardRepository" />
    public class AwardRepository :IAwardRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AwardRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public AwardRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Saves the award information.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        public string SaveAwardInfo(IAwardView awardInfo)
        {
            if (awardInfo == null) throw new ArgumentNullException(nameof(awardInfo));

            var result = string.Empty;

            var newRecord = new Award
            {
                UserId = awardInfo.UserId,
                AwardName = awardInfo.AwardName,
                AwardYear = awardInfo.AwardYear,
                IsActive = true,
                DateCreated = awardInfo.DateCreated
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Awards.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAwardInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the award information.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo
        /// or
        /// awardData</exception>
        public string UpdateAwardInfo(IAwardView awardInfo)
        {
            if (awardInfo == null) throw new ArgumentNullException(nameof(awardInfo));

            var result = string.Empty;

             
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var awardData =
                        dbContext.Awards.SingleOrDefault(m => m.AwardId.Equals(awardInfo.AwardId));
                    if (awardData == null) throw new ArgumentNullException(nameof(awardData));

                    awardData.AwardName = awardInfo.AwardName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Award Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the award by identifier.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAwardById</exception>
        public IAward GetAwardById(int awardId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        AwardQueries.GetAwardById(dbContext, awardId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAwardById", e);
            }
        }

        /// <summary>
        /// Deletes the award information.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">awardId</exception>
        /// <exception cref="ArgumentNullException">awardId</exception>
        public string DeleteAwardInfo(int awardId)
        {
            if (awardId < 1)

            {
                throw new ArgumentOutOfRangeException("awardId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var awardData =
                        dbContext.Awards.SingleOrDefault(m => m.AwardId.Equals(awardId));
                    if (awardData == null) throw new ArgumentNullException("awardId");

                    awardData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Award Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}
