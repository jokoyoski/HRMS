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
    public interface IEducationHistoryService
    {
        /// <summary>
        /// Gets the education history view.
        /// </summary>
        /// <returns></returns>
        IEducationHistoryView GetEducationHistoryView(int employeeId, string URL);


        /// <summary>
        /// Gets the education history view.
        /// </summary>
        /// <param name="educationHistory">The education history.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEducationHistoryView GetEducationHistoryView(IEducationHistoryView educationHistory, string processingMessage);

        /// <summary>
        /// Processes the education history information.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        string ProcessEducationHistoryInfo(IEducationHistoryView educationHistoryInfo);

        /// <summary>
        /// Gets the educational edit view.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        IEducationHistoryView GetEducationalEditView(int educationHistoryId, string URL);

        /// <summary>
        /// Processes the education history edit view.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        string ProcessEducationHistoryEditView(IEducationHistoryView educationHistoryInfo);

        /// <summary>
        /// Gets the education history delete view.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        IEducationHistoryView GetEducationHistoryDeleteView(int educationHistoryId, string URL);

        /// <summary>
        /// Processes the education history delete view.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        string ProcessEducationHistoryDeleteView(int educationHistoryId);
    }
}