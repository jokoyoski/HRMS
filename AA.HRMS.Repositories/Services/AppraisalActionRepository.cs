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
    public class AppraisalActionRepository
    {

        private readonly IDbContextFactory dbContextFactory;

        public AppraisalActionRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory; 
        }

        public IList<IAppraisalAction> GetAppraisalActionList()
        {
             try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalActionList =
                        PerformanceManagementQueries.GetAppraisalActionList(dbContext).ToList();

                    return appraisalActionList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal action list {0}", e);
            }
        }
        /// <summary>
        /// Saves the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public string SaveAppraisalActionInfo(IAppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var result = string.Empty;

            var newRecord = new AppraisalAction
            {
                AppraisalActionName = appraisalActionInfo.AppraisalActionName
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.AppraisalActions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalActionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalActionInfo
        /// or
        /// appraisalActionData
        /// </exception>
        public string UpdateAppraisalActionInfo(IAppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalActionData =
                        dbContext.AppraisalActions.SingleOrDefault(m => m.AppraisalActionId.Equals(appraisalActionInfo.AppraisalActionId));
                    if (appraisalActionData == null) throw new ArgumentNullException(nameof(appraisalActionData));

                    appraisalActionData.AppraisalActionName = appraisalActionInfo.AppraisalActionName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Appraisal Action Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the appraisal action by identifier.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalActionById</exception>
        public IAppraisalAction GetAppraisalActionById(int appraisalActionId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraisalActionById(dbContext, appraisalActionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalActionById", e);
            }
        }
        /// <summary>
        /// Deletes the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalActionId</exception>
        /// <exception cref="ArgumentNullException">appraisalActionId</exception>
        public string DeleteAppraisalActionInfo(int appraisalActionId)
        {
            if (appraisalActionId < 1)

            {
                throw new ArgumentOutOfRangeException("appraisalActionId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalActionData =
                        dbContext.AppraisalActions.SingleOrDefault(m => m.AppraisalActionId.Equals(appraisalActionId));
                    if (appraisalActionData == null) throw new ArgumentNullException("appraisalActionId");

                    appraisalActionData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Appraisal Action Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

    }
}
