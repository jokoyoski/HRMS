using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Factories
{
    public class EducationHistoryViewModelFactory : IEducationHistoryViewModelFactory
    {

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEducationHistoryView CreateEducationHistoryView(int employeeId, string URL)
        {

            var viewModel = new EducationHistoryView
            {
               EmployeeId = employeeId,
               URL = URL,
            };

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="educationHistoryInfo"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryInfo</exception>
        public IEducationHistoryView CreateUpdatedEducationHistoryView(IEducationHistoryView educationHistoryInfo, string processingMessage)
        {
            if (educationHistoryInfo == null) throw new ArgumentNullException(nameof(educationHistoryInfo));

            educationHistoryInfo.ProcessingMessage = processingMessage;

            return educationHistoryInfo;
        }

        /// <summary>
        /// </summary>
        /// <param name="educationHistoryInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryInfo</exception>
        public IEducationHistoryView EditEducationHistoryView(IEducationHistory educationHistoryInfo, string URL)
        {
            if (educationHistoryInfo == null)
                throw new ArgumentNullException(nameof(educationHistoryInfo));

            var educationHistoryView = new EducationHistoryView
            {
                EducationHistoryId = educationHistoryInfo.EducationHistoryId,
                SchoolName = educationHistoryInfo.SchoolName,
                GraduationYear = educationHistoryInfo.GraduationYear,
                Degree = educationHistoryInfo.Degree,
                Note = educationHistoryInfo.Note,
                URL = URL,
            };

            return educationHistoryView;
        }
        
        /// <summary>
        /// Delete the education history
        /// </summary>
        /// <param name="educationHistoryInfo"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryInfo</exception>
        public IEducationHistoryView EditUpdatedEducationHistoryView(IEducationHistoryView educationHistoryInfo, string processingMessage)
        {
            if (educationHistoryInfo == null)
                throw new ArgumentNullException(nameof(educationHistoryInfo));

            educationHistoryInfo.ProcessingMessage = processingMessage;

            return educationHistoryInfo;
        }

        /// <summary>
        /// Deletes the education history.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryInfo</exception>
        public IEducationHistoryView DeleteEducationHistory(IEducationHistory educationHistoryInfo, string URL)
        {
            if (educationHistoryInfo == null)
                throw new ArgumentNullException(nameof(educationHistoryInfo));

            var educationHistory = new EducationHistoryView
            {
                EducationHistoryId = educationHistoryInfo.EducationHistoryId,
                SchoolName = educationHistoryInfo.SchoolName,
                GraduationYear = educationHistoryInfo.GraduationYear,
                Degree = educationHistoryInfo.Degree,
                Note = educationHistoryInfo.Note,
                IsActive = educationHistoryInfo.IsActive,
                EmployeeId = educationHistoryInfo.EmployeeId,
                URL = URL,
            };

            return educationHistory;
        }
    }
}
