using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ISuspensionRepository" />
    public class SuspensionRepository : ISuspensionRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public SuspensionRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        /// <summary>
        /// Gets the suspension by identifier.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// suspensionId
        /// or
        /// Get Suspension By Id
        /// </exception>
        public ISuspension GetSuspensionById(int suspensionId)
        {
            if (suspensionId <= 0)
            {
                throw new ArgumentNullException(nameof(suspensionId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = SuspensionQueries.getSuspensionById(dbContext, suspensionId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Suspension By Id", e);
            }
        }



        /// <summary>
        /// </summary>
        /// <param name="suspensionInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionInfo</exception>
        public string SaveSuspensionInfo(ISuspensionView suspensionInfo)
        {
            if (suspensionInfo == null)
            {
                throw new ArgumentNullException(nameof(suspensionInfo));
            }

            var result = string.Empty;

            var newRecord = new Suspension
            {
                EmployeeId = suspensionInfo.EmployeeId,
                QueryId = suspensionInfo.QueryId,
                StartDate = suspensionInfo.StartDate,
                EndDate = suspensionInfo.EndDate,
                Percentage = suspensionInfo.Percentage,
                CompanyId = suspensionInfo.CompanyId,
                IsActive = true,
                DateCreated = DateTime.Now


            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Suspensions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Suspension info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="suspensionInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionInfo</exception>
        public string SaveEditSuspensionInfo(ISuspensionView suspensionInfo)
        {
            if (suspensionInfo == null)
            {
                throw new ArgumentNullException(nameof(suspensionInfo));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelInfo = dbContext.Suspensions.SingleOrDefault(p => p.SuspensionId == suspensionInfo.SuspensionId);

                    modelInfo.SuspensionId = suspensionInfo.SuspensionId;
                    modelInfo.EmployeeId = suspensionInfo.EmployeeId;
                    modelInfo.QueryId = suspensionInfo.QueryId;
                    modelInfo.StartDate = suspensionInfo.StartDate;
                    modelInfo.EndDate = suspensionInfo.EndDate;
                    modelInfo.Percentage = suspensionInfo.Percentage;
                    modelInfo.IsActive = suspensionInfo.IsActive;
                    modelInfo.DateCreated = DateTime.Now;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Suspension info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete suspension information.
        /// </summary>
        /// <param name="SuspensionId">The suspension identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">SuspensionId</exception>
        public string SaveDeleteSuspensionInfo(int SuspensionId)
        {
            if (SuspensionId <= 0)
            {
                throw new ArgumentNullException(nameof(SuspensionId));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelView = dbContext.Suspensions.Find(SuspensionId);


                    modelView.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Delete Suspension info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllMySuspensions</exception>
        public IList<ISuspension> GetAllMySuspensions(int companyId)
        {
            try
            {
                using (
                      var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = SuspensionQueries.getAllMySuspensions(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllMySuspensions", e);
            }
        }
    }
}

