using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IJobApplicationVacancyRepository" />
    public class JobApplicationVacancyRepository : IJobApplicationVacancyRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobApplicationVacancyRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public JobApplicationVacancyRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Saves the job application vacancy.
        /// </summary>
        /// <param name="jobApplicationVacancyInfo">The job application vacancy information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobApplicationVacancyInfo</exception>
        /// <exception cref="System.ArgumentNullException">jobApplicationVacancyInfo</exception>
        public string SaveJobApplicationVacancy(IJobApplicationVacancyView jobApplicationVacancyInfo)
        {
            if (jobApplicationVacancyInfo == null)
                throw new ArgumentNullException(nameof(jobApplicationVacancyInfo));

            var result = string.Empty;

            var newRecord = new JobApplicationVacancy
            {
                UserId = jobApplicationVacancyInfo.UserId,
                VacancyId = jobApplicationVacancyInfo.VacancyId,
                DateCreated = DateTime.UtcNow,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.JobApplicationVacancies.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveJobApplicationVacancy - {0} , {1}", e.Message,
                    e.InnerException != null
                        ? e.InnerException
                            .Message
                        : "");
            }

            return result;
        }
        
    }
}
