using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;
using AA.HRMS.Repositories.Models;
using System.Data.Entity;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmploymentHistoryRepository" />
    public class EmploymentHistoryRepository : IEmploymentHistoryRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmploymentHistoryRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public EmploymentHistoryRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }


        /// <summary>
        /// Gets the employment history by company.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByEmail</exception>
        public IList<IEmploymentHistory> GetEmploymentHistoriesByUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        EmploymentHistoryQueries.GetEmploymentHistoriesByUserId(dbContext, userId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetEmploymentHistoryByUserId", e);
            }
        }

        /// <summary>
        /// Saves the employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryInfo</exception>
        public string SaveEmploymentHistoryInfo(IEmploymentHistoryView employmentHistoryInfo)
        {
            if (employmentHistoryInfo == null) throw new ArgumentNullException(nameof(employmentHistoryInfo));

            var result = string.Empty;

            var newRecord = new EmploymentHistory
            {
                EmployeeId = employmentHistoryInfo.EmployeeId,
                CompanyName = employmentHistoryInfo.CompanyName,
                StartDate = employmentHistoryInfo.StartDate,
                EndDate = employmentHistoryInfo.EndDate,
                ReasonExit = employmentHistoryInfo.ReasonExit,
                LevelOnExit = employmentHistoryInfo.LevelOnExit,
                JobFunction = employmentHistoryInfo.JobFunction,
                DateCreated = employmentHistoryInfo.DateCreated,
                IsActive = true
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmploymentHistories.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEmploymentHistoryInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryInfo</exception>
        public string UpdateEmploymentHistoryInfo(IEmploymentHistoryView employmentHistoryInfo)
        {
            if (employmentHistoryInfo == null) throw new ArgumentNullException(nameof(employmentHistoryInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var data = dbContext.EmploymentHistories.SingleOrDefault(x =>
                        x.EmploymentHistoryId == employmentHistoryInfo.EmploymentHistoryId);

                    data.CompanyName = employmentHistoryInfo.CompanyName;
                    data.StartDate = employmentHistoryInfo.StartDate;
                    data.EndDate = employmentHistoryInfo.EndDate;
                    data.ReasonExit = employmentHistoryInfo.ReasonExit;
                    data.LevelOnExit = employmentHistoryInfo.LevelOnExit;
                    data.JobFunction = employmentHistoryInfo.JobFunction;
                    

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEmploymentHistoryInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the employment history information.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryId</exception>
        public string DeleteEmploymentHistoryInfo(int employmentHistoryId)
        {
            if (employmentHistoryId <= 0)
            {
                throw new ArgumentNullException(nameof(employmentHistoryId));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employmentHistoryInfo =
                        dbContext.EmploymentHistories.SingleOrDefault(x =>
                            x.EmploymentHistoryId == employmentHistoryId);
                    employmentHistoryInfo.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Employment History Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        /// <summary>
        /// Gets the employement history by identifier.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetEmploymentHistoryById</exception>
        public IEmploymentHistory GetEmployementHistoryById(int employmentHistoryId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        EmploymentHistoryQueries.GetEmploymentHistoryById(dbContext, employmentHistoryId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetEmploymentHistoryById", e);
            }
        }
    }
}