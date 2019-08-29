using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    public interface IAdminViewModelFactory
    {

        #region //=======================================Company Section===============================================//

        /// <summary>
        /// Creates the company ListView.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ICompanyListView CreateCompanyListView(IList<ICompanyDetail> companyCollection, string message);

        /// <summary>
        /// Gets the dash board option.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IHomeView GetDashBoardOption(IUserDetail userInfo, IList<ICompanyDetail> companyCollection);

        /// <summary>
        /// Creates the user ListView.
        /// </summary>
        /// <param name="userCollection">The user collection.</param>
        /// <param name="selectedEmail">The selected email.</param>
        /// <param name="selectedName">Name of the selected.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IUserListView CreateUserListView(IList<IUserDetail> userCollection, string selectedEmail,
            string selectedName, string message);

        /// <summary>
        /// Creates the company registration view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="industryCollection">The industry collection.</param>
        /// <returns></returns>
        ICompanyRegistrationView CreateCompanyRegistrationView(IList<ICompanyDetail> companyCollection,
            IList<IIndustry> industryCollection, IList<ICountry> countryCollection);

        /// <summary>
        /// Creates the company registration view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="industryCollection">The industry collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ICompanyRegistrationView CreateCompanyRegistrationView(ICompanyRegistrationView companyInfo,
            IList<ICompanyDetail> companyCollection, IList<IIndustry> industryCollection, IList<ICountry> countryCollection,
            string processingMessage);


        /// <summary>
        /// Creates the company registration view.
        /// </summary>
        /// <returns></returns>
        ICompanyRegistrationView CreateCompanyRegistrationView(ICompanyDetail companyInfo,
            IList<ICompanyDetail> companyCollection, IList<IIndustry> industryCollection, IList<ICountry> countryCollection);

        #endregion
        
        #region //======================================Department Section============================================//

        /// <summary>
        /// Creates the department view.
        /// </summary>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IDepartmentView CreateDepartmentView(IList<IDepartment> departmentCollection, int companyId);

        /// <summary>
        /// Creates the department view.
        /// </summary>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="deptInfo">The dept information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDepartmentView CreateDepartmentView(IList<IDepartment> departmentCollection,
            IDepartmentView deptInfo, string processingMessage);

        /// <summary>
        /// Creates the updated department view.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDepartmentView CreateUpdatedDepartmentView(IDepartmentView deptInfo, IList<IDepartment> departmentCollection,
            string processingMessage);

        /// <summary>
        /// Creates the department ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedDepartmentId">The selected department identifier.</param>
        /// <param name="selectedDepartment">The selected department.</param>
        /// <param name="companyList">The company list.</param>
        /// <param name="departmentsList">The departments list.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDepartmentListView CreateDepartmentListView(int selectedCompanyId, int selectedDepartmentId,
            string selectedDepartment,
            IList<ICompanyDetail> companyList, IList<IDepartment> departmentsList, string message);

        /// <summary>
        /// Creates the updated company view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ICompanyRegistrationView CreateUpdatedCompanyView(ICompanyRegistrationView companyInfo,
            string processingMessage);

        #endregion
        
        #region //================================================JobTitle Section=====================================================//


        /// <summary>
        /// Creates the job title view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IJobTitleView CreateJobTitleView(int companyId);


        /// <summary>
        /// Creates the job title view.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IJobTitleView CreateJobTitleView(IJobTitleView jobTitleInfo,
            string processingMessage);

        /// <summary>
        /// Creates the edit department view.
        /// </summary>
        /// <param name="departmentInfo">The department information.</param>
        /// <param name="departmentsList">The departments list.</param>
        /// <param name="companyList">The company list.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDepartmentView CreateEditDepartmentView(IDepartment departmentInfo, IList<IDepartment> departmentsList, string message);
        
        /// <summary>
        /// Creates the edit job title view.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IJobTitleView CreateEditJobTitleView(IJobTitle jobTitleInfo, string processingMessage);
        
        /// <summary>
        /// Gets the job titles ListView.
        /// </summary>
        /// <param name="seletedJobTitleId">The seleted job title identifier.</param>
        /// <param name="selectedJobTitle">The selected job title.</param>
        /// <param name="jobTitleCollections">The job title collections.</param>
        /// <param name="companyDetail">The company detail.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IJobTitleListView GetJobTitlesListView(int selectedCompanyId,
            string selectedJobTitle,
            IList<IJobTitle> jobTitleCollections,
            ICompanyDetail companyDetail, IList<ICompanyDetail> companyDetails, string message);

        #endregion

        #region //======================================Industry Section===================================================//


        /// <summary>
        /// Creates the industry ListView.
        /// </summary>
        /// <param name="IndustryCollection">The industry collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IIndustryListView CreateIndustryListView(IList<IIndustry> IndustryCollection, string selectedIndustry,
            string message);

        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <returns></returns>
        IIndustryView CreateIndustryView();

        /// <summary>
        /// Creates the updated industry view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IIndustryView CreateUpdatedIndustryView(IIndustryView industryInfo, string processingMessage);

        /// <summary>
        /// Edits the industry view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        IIndustryView EditIndustryView(IIndustry industryInfo);

        /// <summary>
        /// Edits the updated industry view.
        /// </summary>
        /// <param name="IndustryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IIndustryView EditUpdatedIndustryView(IIndustryView IndustryInfo, string processingMessage);

        #endregion
    }
}