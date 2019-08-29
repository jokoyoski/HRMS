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
    public interface IJobApplicationVacancyRepository
    {
        /// <summary>
        /// Saves the job application vacancy.
        /// </summary>
        /// <param name="jobApplicationVacancyInfo">The job application vacancy information.</param>
        /// <returns></returns>
        string SaveJobApplicationVacancy(IJobApplicationVacancyView jobApplicationVacancyInfo);
    }
}
