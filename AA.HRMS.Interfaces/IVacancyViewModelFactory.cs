using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyViewModelFactory
    {
        /// <summary>
        /// Creates the vacancy view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IVacancyView CreateVacancyView(IList<ICompanyDetail> companyCollection);


        /// <summary>
        /// Creates the vacancy view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="departmetnCollection">The departmetn collection.</param>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="gradesCollection">The grades collection.</param>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IVacancyView CreateVacancyView(IList<ICompanyDetail> companyCollection, IList<IDepartment> departmetnCollection,
            IList<IJobTitle> jobTitleCollection,
            IList<IGrade> gradesCollection, IVacancyView vacancyInfo, string message);


        /// <summary>
        /// Creates the updated vacancy view.
        /// </summary>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="departmentDropDown">The department drop down.</param>
        /// <param name="jobTitleDropDown">The job title drop down.</param>
        /// <param name="gradesDropdown">The grades dropdown.</param>
        /// <returns></returns>
        IVacancyView CreateUpdatedVacancyView(IVacancyView vacancyInfo,
            string processingMessage,
            IList<IDepartment> departmentDropDown,
            IList<IJobTitle> jobTitleDropDown,
            IList<IGrade> gradesDropdown);

        /// <summary>
        /// Creates the vacancy ListView.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="vacancyCollection">The vacancy collection.</param>
        /// <returns></returns>
        IVacancyListView CreateVacancyListView(IVacancyListFilter searchCriteria,
            IList<ICompanyDetail> companyCollection,
            
            IList<IVacancyDetail> vacancyCollection);
        /// <summary>
        /// Creates the vacancy list admin view.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="vacancyCollection">The vacancy collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IVacancyListAdminView CreateVacancyListAdminView(IVacancyListFilter searchCriteria,
            IList<ICompanyDetail> companyCollection,
           IList<IVacancyDetail> vacancyCollection, string message);

        /// <summary>
        /// Edits the vacancy view.
        /// </summary>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IVacancyView EditVacancyView(IVacancyDetail vacancyInfo,  IList<ICompanyDetail> companyCollection);


        /// <summary>
        /// Creates the vacancy ListView.
        /// </summary>
        /// <param name="vacancyCollection">The vacancy collection.</param>
        /// <returns></returns>
        IVacancyListView CreateVacancyListView(IList<IVacancyDetail> vacancyCollection);

        /// <summary>
        /// Creates the vacancy detail.
        /// </summary>
        /// <param name="vacancyDetailInfo">The vacancy detail information.</param>
        /// <param name="hasApplied">if set to <c>true</c> [has applied].</param>
        /// <returns></returns>
        IVacancyDetail CreateVacancyDetail(IVacancyDetail vacancyDetailInfo, bool hasApplied);

        /// <summary>
        /// Creates the vacancy ListView by users.
        /// </summary>
        /// <param name="vacancyCollection">The vacancy collection.</param>
        /// <returns></returns>
        IVacancyListView CreateVacancyListViewByUsers(IList<IApplicationModel> vacancyCollection);

        /// <summary>
        /// Creates the applications ListView.
        /// </summary>
        /// <param name="applicationsCollections">The application model.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IApplicationsListView CreateApplicationsListView(IList<IApplicationModel> applicationsCollections,
            string message);


        /// <summary>
        /// Creates the applications ListView.
        /// </summary>
        /// <param name="selectedVacancyId">The selected vacancy identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedJobTitle">The selected job title.</param>
        /// <param name="applicationsCollections">The applications collections.</param>
        /// <param name="companyList">The company list.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IVacancyListView CreateApplicationsListView(int selectedVacancyId, int selectedCompanyId,

            string selectedJobTitle, IList<IApplicationModel> applicationsCollections,
            IList<ICompanyDetail> companyList,
            string message);
    }
}