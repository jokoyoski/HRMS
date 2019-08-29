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
    public class AppraisalRatingRepository : IAppraisalRatingRepository
    {
        private readonly IDbContextFactory dbContextFactory;


        public AppraisalRatingRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        /// <summary>
        /// Gets the appraisal rating list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal rating list {0}</exception>
        public IList<IAppraisalRating> GetAppraisalRatingList()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalRatingList =
                        PerformanceManagementQueries.GetAppraisalRatingList(dbContext).ToList();

                    return appraisalRatingList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal rating list {0}", e);
            }

        }

        /// <summary>
        /// Saves the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public string SaveAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            var result = string.Empty;

            var newRecord = new AppraisalRating
            {
                AppraisalRatingName = appraisalRatingInfo.AppraisalRatingName
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.AppraisalRatings.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalRatingInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Updates the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalRatingInfo
        /// or
        /// appraisalRatingData
        /// </exception>
        public string UpdateAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalRatingData =
                        dbContext.AppraisalRatings.SingleOrDefault(m => m.AppraisalRatingId.Equals(appraisalRatingInfo.AppraisalRatingId));
                    if (appraisalRatingData == null) throw new ArgumentNullException(nameof(appraisalRatingData));

                    appraisalRatingData.AppraisalRatingName = appraisalRatingInfo.AppraisalRatingName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Appraisal Rating Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Gets the appraisal rating by identifier.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalRatingById</exception>
        public IAppraisalRating GetAppraisalRatingById(int appraisalRatingId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraisalRatingById(dbContext, appraisalRatingId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalRatingById", e);
            }
        }
        /// <summary>
        /// Deletes the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalRatingId</exception>
        /// <exception cref="ArgumentNullException">appraisalRatingId</exception>
        public string DeleteAppraisalRatingInfo(int appraisalRatingId)
        {
            if (appraisalRatingId < 1)

            {
                throw new ArgumentOutOfRangeException("appraisalRatingId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalRatingData =
                        dbContext.AppraisalRatings.SingleOrDefault(m => m.AppraisalRatingId.Equals(appraisalRatingId));
                    if (appraisalRatingData == null) throw new ArgumentNullException("appraisalRatingId");

                    appraisalRatingData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Appraisal Rating Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}