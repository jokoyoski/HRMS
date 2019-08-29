using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJobTitleRepository
    {
        /// <summary>
        /// Deletes the job title.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <returns></returns>
        string DeleteJobTitle(int jobTitleId);

        /// <summary>
        /// Gets the job title by identifier.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <returns></returns>
        IJobTitle GetJobTitleById(int jobTitleId);

        /// <summary>
        /// Gets the job title by company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="jobTitleName">Name of the job title.</param>
        /// <returns></returns>
        IJobTitle GetJobTitleByCompany(int companyId, string jobTitleName);

        /// <summary>
        /// Saves the job title information.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <returns></returns>
        string SaveJobTitleInfo(IJobTitleView jobTitleInfo);

        /// <summary>
        /// Updates the job title information.
        /// </summary>
        /// <param name="jobTitleViewInfo">The job title view information.</param>
        /// <returns></returns>
        string UpdateJobTitleInfo(IJobTitleView jobTitleViewInfo);
    }
}