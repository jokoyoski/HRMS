using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyRepository
    {
        /// <summary>
        /// Saves the vacancy information.
        /// </summary>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <returns></returns>
        string SaveVacancyInfo(IVacancyView vacancyInfo);

        /// <summary>
        /// Deletes the vacancy information.
        /// </summary>
        /// <param name="vacancyId">The vacancy identifier.</param>
        /// <returns></returns>
        string DeleteVacancyInfo(int vacancyId);

        /// <summary>
        /// Gets all vacancy.
        /// </summary>
        /// <returns></returns>
        IList<IVacancyDetail> GetAllVacancy();

        /// <summary>
        /// Gets the vacancy by identifier.
        /// </summary>
        /// <param name="vacancy">The vacancy.</param>
        /// <returns></returns>
        IVacancyDetail GetVacancyById(int vacancy);

        /// <summary>
        /// Gets the vacancy detail collection.
        /// </summary>
        /// <returns></returns>
        IList<IVacancyDetail> GetVacancyDetailCollection();

        /// <summary>
        /// Gets the applicants by vacancy identifier.
        /// </summary>
        /// <param name="vacancyId">The vacancy identifier.</param>
        /// <returns></returns>
        IList<IApplicationModel> GetApplicantsByVacancyId(int vacancyId);

        /// <summary>
        /// Gets the vacancy by company.
        /// </summary>
        /// <param name="vacancyId">The vacancy identifier.</param>
        /// <returns></returns>
        IVacancyDetail GetVacancyByCompany(int vacancyId);

        /// <summary>
        /// Updates the vacancy information.
        /// </summary>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <returns></returns>
        string UpdateVacancyInfo(IVacancyView vacancyInfo);

        /// <summary>
        /// Gets the vacancy by vacancy identifier.
        /// </summary>
        /// <param name="vacancyId">The vacancy identifier.</param>
        /// <returns></returns>
        IVacancyDetail GetVacancyByVacancyId(int vacancyId);

        /// <summary>
        /// Gets the applications.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<IApplicationModel> GetApplications(int userId);

        /// <summary>
        /// Gets the open jobs.
        /// </summary>
        /// <returns></returns>
        IList<IVacancyDetail> GetOpenJobs();


        /// <summary>
        /// Gets the user application status.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="vacancyId">The vacancy identifier.</param>
        /// <returns></returns>
        IApplicationModel GetUserApplicationStatus(int userId, int vacancyId);


        /// <summary>
        /// Gets all applications.
        /// </summary>
        /// <returns></returns>
        IList<IApplicationModel> GetAllApplications();
    }
}