using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using System.Linq;
using AA.HRMS.Repositories.Models;
using System.Collections.Generic;

namespace AA.HRMS.Repositories.Queries
{
    public class JobTitleQueries
    {
        /// <summary>
        /// Gets the job title by company.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="jobTitleName">Name of the job title.</param>
        /// <returns></returns>
        internal static IJobTitle getJobTitleByCompany(HRMSEntities db, int companyId,string jobTitleName)
        {
            var result = (from d in db.JobTitles
                          join b in db.Companies on d.CompanyId equals b.CompanyId
                          where d.CompanyId == companyId
                          where d.JobTitleName.Equals(jobTitleName)
                          select new JobTitleModel
                          {
                              CompanyId = d.CompanyId,
                              JobTitleName = d.JobTitleName,
                              JobDefinition = d.JobDefinition,
                              JobTitleId = d.JobTitleId,
                              JobFunction = d.JobFunction,
                              DateCreated = d.DateCreated
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the job title by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <returns></returns>
        internal static IJobTitle getJobTitleById(HRMSEntities db, int jobTitleId)
        {
            var result = (from d in db.JobTitles
                          where d.JobTitleId.Equals(jobTitleId)
                          select new JobTitleModel
                          {
                              JobTitleId = d.JobTitleId,
                               CompanyId = d.CompanyId,
                              JobTitleName = d.JobTitleName,
                              JobDefinition = d.JobDefinition,
                              JobFunction = d.JobFunction,
                              DateCreated = d.DateCreated
                          }).Where(a=>a.JobTitleId == jobTitleId).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the job list.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IJobTitle> getJobList(HRMSEntities db)
        {
            var result = (from d in db.JobTitles
                          select new Models.JobTitleModel
                          {
                              CompanyId = d.CompanyId,
                              JobTitleName = d.JobTitleName,
                              JobDefinition = d.JobDefinition,
                              JobFunction = d.JobFunction,
                              DateCreated = d.DateCreated,
                              
                          }).OrderBy(x => x.JobTitleName);

            return result;
        }
    }
}
