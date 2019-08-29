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
    public interface IEmploymentHistoryService
    {

        /// <summary>
        /// Gets the employment history view.
        /// </summary>
        /// <returns></returns>
        IEmploymentHistoryView GetEmploymentHistoryView(int employeeId, string URL);


        /// <summary>
        /// Gets the employment history view.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmploymentHistoryView GetEmploymentHistoryView(IEmploymentHistoryView employmentHistoryInfo,
            string processingMessage);


        /// <summary>
        /// Gets the employment history edit view.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        IEmploymentHistoryView GetEmploymentHistoryEditView(int employmentHistoryId, string URL);

        /// <summary>
        /// Processes the employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        string ProcessEmploymentHistoryInfo(IEmploymentHistoryView employmentHistoryInfo);

        /// <summary>
        /// Processes the edit employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        string ProcessEditEmploymentHistoryInfo(IEmploymentHistoryView employmentHistoryInfo);

        /// <summary>
        /// Deletes the employment history information.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        string DeleteEmploymentHistoryInfo(int employmentHistoryId);
    }
}