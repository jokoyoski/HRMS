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
    public interface IEmploymentHistoryViewModelFactory
    {
        /// <summary>
        /// Creates the employment history view.
        /// </summary>
        /// <returns></returns>
        IEmploymentHistoryView CreateEmploymentHistoryView(int employeeId, string URL);

        /// <summary>
        /// Creates the updated employment history view.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <param name="processMessage">The process message.</param>
        /// <returns></returns>
        IEmploymentHistoryView CreateUpdatedEmploymentHistoryView(IEmploymentHistoryView employmentHistoryInfo, string processMessage);

        /// <summary>
        /// Creates the edit employment history view.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        IEmploymentHistoryView CreateEditEmploymentHistoryView(IEmploymentHistory employmentHistory, string URL);
    }
}
