using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyService
    {
        /// <summary>
        /// Gets the vacancy view.
        /// </summary>
        /// <returns></returns>
        IVacancyView GetVacancyView();

        /// <summary>
        /// Gets the vacancy view.
        /// </summary>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IVacancyView GetVacancyView(IVacancyView vacancyInfo, string message);

        /// <summary>
        /// Processes the vacancy information.
        /// </summary>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <returns></returns>
        string ProcessVacancyInformation(IVacancyView vacancyInfo);

        /// <summary>
        /// Gets the vacancy edit view.
        /// </summary>
        /// <param name="vacancyId">The vacancy identifier.</param>
        /// <returns></returns>
        IVacancyView GetVacancyEditView(int vacancyId);

        /// <summary>
        /// Processes the delete vacancy information.
        /// </summary>
        /// <param name="vacancyId">The vacancy identifier.</param>
        /// <returns></returns>
        string ProcessDeleteVacancyInfo(int vacancyId);

        /// <summary>
        /// Processes the edit vacancy information.
        /// </summary>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <returns></returns>
        string ProcessEditVacancyInformation(IVacancyView vacancyInfo);

        /// <summary>
        /// Gets the vacancy ListView.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IVacancyListAdminView GetAdminVacancyListView(IVacancyListFilter searchCriteria, string message);


        /// <summary>
        /// Gets all vacancies.
        /// </summary>
        /// <returns></returns>
        IVacancyListView GetAllVacancies();

        /// <summary>
        /// Gets the vacancy details.
        /// </summary>
        /// <param name="vacancyId">The vacancy identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IVacancyDetail GetVacancyDetails(int vacancyId, int userId);

        /// <summary>
        /// Processes the job application.
        /// </summary>
        /// <param name="jobApplicationVacancyInfo">The job application vacancy information.</param>
        /// <returns></returns>
        string ProcessJobApplication(IJobApplicationVacancyView jobApplicationVacancyInfo);

        /// <summary>
        /// Gets the applications view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IApplicationsListView GetApplicationsView(int userId, string message);

        /// <summary>
        /// Gets the open vacancies.
        /// </summary>
        /// <param name="selectedVacancy">The selected vacancy.</param>
        /// <returns></returns>
        IHomeView GetOpenVacancies(string selectedVacancy);

        /// <summary>
        /// Gets the applications view.
        /// </summary>
        /// <param name="selectedVacancyId">The selected vacancy identifier.</param>
        /// <param name="selectedcompanyId">The selectedcompany identifier.</param>
        /// <param name="selectedJobName">Name of the selected job.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IVacancyListView GetApplicationsView(int selectedVacancyId, int selectedcompanyId, string selectedJobName,
            string processingMessage);
    }
}