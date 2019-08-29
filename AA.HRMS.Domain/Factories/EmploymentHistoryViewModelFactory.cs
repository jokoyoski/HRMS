using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System;

namespace AA.HRMS.Domain.Factories
{

    public class EmploymentHistoryViewModelFactory : IEmploymentHistoryViewModelFactory
    {

        /// <summary>
        /// Creates the employment history view.
        /// </summary>
        /// <returns></returns>
        public IEmploymentHistoryView CreateEmploymentHistoryView(int employeeId, string URL)
        {
            var viewModel = new EmploymentHistoryView
            {
                URL = URL,
                EmployeeId = employeeId,
                ProcessingMessage = string.Empty
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the edit employment history view.
        /// </summary>
        /// <param name="employmentHistoryId"></param>
        /// <returns></returns>
        public IEmploymentHistoryView CreateEditEmploymentHistoryView(IEmploymentHistory employmentHistory, string URL)
        {

            var returnEmploymentHistory = new EmploymentHistoryView
            {
                EmploymentHistoryId = employmentHistory.EmploymentHistoryId,
                EmployeeId = employmentHistory.UserId,
                CompanyName = employmentHistory.CompanyName,
                StartDate = employmentHistory.StartDate,
                EndDate = employmentHistory.EndDate,
                ReasonExit = employmentHistory.ReasonExit,
                LevelOnExit = employmentHistory.LevelOnExit,
                JobFunction = employmentHistory.JobFunction,
                DateCreated = employmentHistory.DateCreated,
                IsActive = employmentHistory.IsActive,
                URL = URL,
            };

            return returnEmploymentHistory;
        }

        /// <summary>
        /// Creates the updated employment history view.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <param name="processMessage">The process message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryInfo</exception>
        public IEmploymentHistoryView CreateUpdatedEmploymentHistoryView(IEmploymentHistoryView employmentHistoryInfo, string processMessage)
        {
            if (employmentHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(employmentHistoryInfo));
            }

            employmentHistoryInfo.ProcessingMessage = processMessage;

            return employmentHistoryInfo;
        }
    }
}
