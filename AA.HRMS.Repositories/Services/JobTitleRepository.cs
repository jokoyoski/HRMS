using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Models;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IJobTitleRepository" />
    public class JobTitleRepository : IJobTitleRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobTitleRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public JobTitleRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Gets the job title by company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="jobTitleName">Name of the job title.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get JobTitle by Company</exception>
        public IJobTitle GetJobTitleByCompany(int companyId, string jobTitleName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = JobTitleQueries.getJobTitleByCompany(dbContext, companyId, jobTitleName);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get JobTitle by Company", e);
            }
        }

        /// <summary>
        /// Saves the job title information.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleInfo</exception>
        public string SaveJobTitleInfo(IJobTitleView jobTitleInfo)
        {
            if (jobTitleInfo == null)
            {
                throw new ArgumentNullException(nameof(jobTitleInfo));
            }

            var result = string.Empty;

            var newRecord = new JobTitle
            {
                CompanyId = jobTitleInfo.CompanyId,
                JobTitleName = jobTitleInfo.JobTitleName,
                JobDefinition = jobTitleInfo.JobDefinition,
                JobFunction = jobTitleInfo.JobFunction,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.JobTitles.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save JobTitle Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Gets the job title by identifier.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetJobTitleById</exception>
        public IJobTitle GetJobTitleById(int jobTitleId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        JobTitleQueries.getJobTitleById(dbContext, jobTitleId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetJobTitleById", e);
            }
        }

        /// <summary>
        /// Updates the job title information.
        /// </summary>
        /// <param name="jobTitleViewInfo">The job title view information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleViewInfo</exception>
        public string UpdateJobTitleInfo(IJobTitleView jobTitleViewInfo)
        {
            if (jobTitleViewInfo == null)
                throw new ArgumentNullException(nameof(jobTitleViewInfo));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newJobTitle = dbContext.JobTitles.Find(jobTitleViewInfo.JobTitleId);

                    newJobTitle.JobTitleName = jobTitleViewInfo.JobTitleName;
                    newJobTitle.JobDefinition = jobTitleViewInfo.JobDefinition;
                    newJobTitle.JobFunction = jobTitleViewInfo.JobFunction;
                    newJobTitle.CompanyId = jobTitleViewInfo.CompanyId;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the job title.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// jobTitleId
        /// or
        /// jobTitleId
        /// </exception>
        public string DeleteJobTitle(int jobTitleId)
        {
            if (jobTitleId < 1)
                throw new ArgumentNullException("jobTitleId");

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var jobTitleData =
                        dbContext.JobTitles.SingleOrDefault(p => p.JobTitleId.Equals(jobTitleId));
                    if (jobTitleData == null) throw new ArgumentNullException("jobTitleId");


                    jobTitleData.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete JobTitle Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}