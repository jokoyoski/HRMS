using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEducationHistoryViewModelFactory
    {
        /// <summary>
        /// Creates the education history view.
        /// </summary>
        /// <returns></returns>
        IEducationHistoryView CreateEducationHistoryView(int employeeId, string URL);

        /// <summary>
        /// Creates the updated education history view.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEducationHistoryView CreateUpdatedEducationHistoryView(IEducationHistoryView educationHistoryInfo, string processingMessage);

        /// <summary>
        /// Edits the education history view.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        IEducationHistoryView EditEducationHistoryView(IEducationHistory educationHistoryInfo, string URL);

        /// <summary>
        /// Edits the updated education history view.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEducationHistoryView EditUpdatedEducationHistoryView(IEducationHistoryView educationHistoryInfo, string processingMessage);

        /// <summary>
        /// Deletes the education history.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        IEducationHistoryView DeleteEducationHistory(IEducationHistory educationHistoryInfo, string URL);
    }
}
