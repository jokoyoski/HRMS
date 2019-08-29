using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class DeductionRepository : IDeductionRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeductionRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public DeductionRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the deduction by identifier.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// deductionId
        /// or
        /// Get Reward By Id
        /// </exception>
        public IDeduction GetDeductionById(int deductionId)
        {
            if (deductionId <= 0)
            {
                throw new ArgumentNullException(nameof(deductionId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = DeductionQueries.getDeductionById(dbContext, deductionId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Deduction By Id", e);
            }
        }

        public IList<IDeduction> GetDeductionByEmployeeId(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = DeductionQueries.getDeductionByEmployeeId(dbContext, employeeId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Deduction By EmployeeId", e);
            }
        }

        /// <summary>
        /// Gets the name of the reward by.
        /// </summary>
        /// <param name="deductionName">Name of the deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Deduction By Name</exception>
        public IDeduction GetDeductionByName(string deductionName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var deductionInfo = DeductionQueries.getDeductionByName(dbContext, deductionName);
                    return deductionInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Deduction By Name", e);
            }
        }

        public IList<IDeduction> GetDeduction()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var deductionInfo = DeductionQueries.getDeduction(dbContext).ToList();
                    return deductionInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Deduction By Name", e);
            }
        }

        /// <summary>
        /// Saves the deduction information.
        /// </summary>
        /// <param name="deductionInfo">The deduction information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deductionInfo</exception>
        public string SaveDeductionInfo(IDeductionViewModel deductionInfo)
        {
            if (deductionInfo == null)
            {
                throw new ArgumentNullException(nameof(deductionInfo));
            }

            var result = string.Empty;

            var newRecord = new Deduction
            {
                DeductionName = deductionInfo.DeductionName,
                CompanyId = deductionInfo.CompanyId,
                DateCreated = DateTime.UtcNow,
                DeductionAmount = deductionInfo.DeductionAmount,
                DateStarted = deductionInfo.DateStarted,
                IsActive = true,
                DateTerminated = DateTime.Now,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Deductions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Deduction info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the edit deduction information.
        /// </summary>
        /// <param name="deductionInfo">The deduction information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deductionInfo</exception>
        public string SaveEditDeductionInfo(IDeductionViewModel deductionInfo)
        {
            if (deductionInfo == null)
            {
                throw new ArgumentNullException(nameof(deductionInfo));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelInfo = dbContext.Deductions.SingleOrDefault(p => p.DeductionId == deductionInfo.DeductionId);
                    
                    modelInfo.DeductionName = deductionInfo.DeductionName;
                    modelInfo.DeductionAmount = deductionInfo.DeductionAmount;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Deduction info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete deduction information.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deductionId</exception>
        public string SaveDeleteDeductionInfo(int deductionId)
        {
            if (deductionId <= 0)
            {
                throw new ArgumentNullException(nameof(deductionId));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelView = dbContext.Deductions.Find(deductionId);
                    
                    modelView.IsActive = false;
                    modelView.DateTerminated = DateTime.UtcNow;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Deduction info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

    }
}
