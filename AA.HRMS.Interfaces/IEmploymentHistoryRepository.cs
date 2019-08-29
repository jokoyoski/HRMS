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
    public interface IEmploymentHistoryRepository
    {
        /// <summary>
        /// Gets the employment histories by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<IEmploymentHistory> GetEmploymentHistoriesByUserId(int userId);

        /// <summary>
        /// Saves the employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        string SaveEmploymentHistoryInfo(IEmploymentHistoryView employmentHistoryInfo);

        /// <summary>
        /// Updates the employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        string UpdateEmploymentHistoryInfo(IEmploymentHistoryView employmentHistoryInfo);

        /// <summary>
        /// Deletes the employment history information.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        string DeleteEmploymentHistoryInfo(int employmentHistoryId);

        /// <summary>
        /// Gets the employement history by identifier.
        /// </summary>
        /// <param name="employmentHistory">The employment history.</param>
        /// <returns></returns>
        IEmploymentHistory GetEmployementHistoryById(int employmentHistory);
    }
}