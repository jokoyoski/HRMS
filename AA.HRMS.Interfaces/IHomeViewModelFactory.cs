using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHomeViewModelFactory
    {

        /// <summary>
        /// Creates the home page jobs view.
        /// </summary>
        /// <param name="selectedVacancy">The selected vacancy.</param>
        /// <param name="vacancyDetail">The vacancy detail.</param>
        /// <returns></returns>
        IHomeView CreateHomePageJobsView(string selectedVacancy, IList<IVacancyDetail> vacancyDetail);
    }
}