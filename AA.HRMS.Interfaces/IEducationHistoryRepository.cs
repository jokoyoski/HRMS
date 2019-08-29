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
    public interface IEducationHistoryRepository
    {
        /// <summary>
        /// Gets the education history by identifier.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        IEducationHistory GetEducationHistoryById(int educationHistoryId);

        /// <summary>
        /// Gets the education histories by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<IEducationHistory> GetEducationHistoriesByUserId(int userId);

        /// <summary>
        /// Saves the education history information.
        /// </summary>
        /// <param name="applicationInfo">The application information.</param>
        /// <returns></returns>
        string SaveEducationHistoryInfo(IEducationHistoryView applicationInfo);

        /// <summary>
        /// Updates the education history information.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        string UpdateEducationHistoryInfo(IEducationHistoryView educationHistoryInfo);

        /// <summary>
        /// Deletes the education history information.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        string DeleteEducationHistoryInfo(int educationHistoryId);
    }
}