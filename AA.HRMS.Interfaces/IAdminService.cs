using System.Collections.Generic;
using System.Web;

namespace AA.HRMS.Interfaces
{
    public interface IAdminService
    {

        #region //-------------------------------------------------Company Section----------------------------------------------------//

        /// <summary>
        /// Gets the company ListView model.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ICompanyListView GetCompanyListViewModel(string message);

        /// <summary>
        /// Gets the user ListView model.
        /// </summary>
        /// <param name="selectedEmail">The selected email.</param>
        /// <param name="selectedName">Name of the selected.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IUserListView GetUserListViewModel(string selectedEmail, string selectedName, string message);

        /// <summary>
        /// Gets the register company view model.
        /// </summary>
        /// <returns></returns>
        ICompanyRegistrationView GetRegisterCompanyViewModel();

        /// <summary>
        /// Chooses the company.
        /// </summary>
        /// <returns></returns>
        IHomeView ChooseCompany();
        
        /// <summary>
        /// Deletes the company information.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        ICompanyRegistrationView DeleteCompanyInfo(ICompanyRegistrationView companyInfo);

        /// <summary>
        /// Gets the register company view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ICompanyRegistrationView GetRegisterCompanyViewModel(ICompanyRegistrationView viewModel, string message);

        /// <summary>
        /// Gets the selected company information.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        ICompanyRegistrationView GetSelectedCompanyInfo(int companyId);

        /// <summary>
        /// Processes the company registration information.
        /// </summary>
        /// <param name="companyRegistrationInfo">The company registration information.</param>
        /// <returns></returns>
        string ProcessCompanyRegistrationInfo(ICompanyRegistrationView companyRegistrationInfo, HttpPostedFileBase companyLogo);

        /// <summary>
        /// Updates the company registration information.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        string UpdateCompanyRegistrationInfo(ICompanyRegistrationView companyInfo, HttpPostedFileBase companyLogo);

        #endregion

        #region //----------------------------------------------Department Section---------------------------------------------//

        /// <summary>
        /// Gets the departments list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedDepartmentId">The selected department identifier.</param>
        /// <param name="selectedDepartment">The selected department.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDepartmentListView GetDepartmentsList(int selectedCompanyId, int selectedDepartmentId, string selectedDepartment, string message);

        /// <summary>
        /// Gets the department registration view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IDepartmentView GetDepartmentRegistrationView();
        
        /// <summary>
        /// Gets the department registration view.
        /// </summary>
        /// <param name="departmentInfo">The department information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDepartmentView GetDepartmentRegistrationView(IDepartmentView departmentInfo, string message);

        /// <summary>
        /// Processes the department information.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        string ProcessDepartmentInfo(IDepartmentView deptInfo);

        /// <summary>
        /// Processes the upload excel department.
        /// </summary>
        /// <param name="departmentExcelFile">The department excel file.</param>
        /// <returns></returns>
        string ProcessUploadExcelDepartment(HttpPostedFileBase departmentExcelFile);

        /// <summary>
        /// Gets the department edit view.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="messag">The messag.</param>
        /// <returns></returns>
        IDepartmentView GetDepartmentEditView(int departmentId, string messag);

        /// <summary>
        /// Processes the edit department information.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        string ProcessEditDepartmentInfo(IDepartmentView deptInfo);

        /// <summary>
        /// Processes the delete department information.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        string ProcessDeleteDepartmentInfo(int departmentId);
        
        /// <summary>
        /// Gets the department collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IDepartment> GetDepartmentCollection(int companyId);

        #endregion

        #region //--------------------------------------------JobTitle Section------------------------------------------//

        /// <summary>
        /// Gets the job title view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IJobTitleView GetJobTitleView();

        /// <summary>
        /// Gets the job title update view.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IJobTitleView GetJobTitleUpdateView(IJobTitleView jobTitleInfo, string processingMessage);

        /// <summary>
        /// Gets the job title edit view.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IJobTitleView GetJobTitleEditView(int jobTitleId, string processingMessage);

        /// <summary>
        /// Processes the edit job title information.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <returns></returns>
        string ProcessEditJobTitleInformation(IJobTitleView jobTitleInfo);

        /// <summary>
        /// Processes the upload excel job title.
        /// </summary>
        /// <param name="jobTitleExcelFile">The job title excel file.</param>
        /// <returns></returns>
        string ProcessUploadExcelJobTitle(HttpPostedFileBase jobTitleExcelFile);

        /// <summary>
        /// Processes the job title information.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <returns></returns>
        string ProcessJobTitleInfo(IJobTitleView jobTitleInfo);

        /// <summary>
        /// Gets the list of job title.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IJobTitleListView GetListOfJobTitle(int selectedJobTitle, int companyId, string selectedjobTitle, string message);

        /// <summary>
        /// Deletes the job title.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <returns></returns>
        string DeleteJobTitle(int jobTitleId);

        // Utility functions to get collections        
        /// <summary>
        /// Gets the job title collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IJobTitle> GetJobTitleCollection(int companyId);

        #endregion

        #region //------------------------------------------Industry SEction---------------------------------------------//

        /// <summary>
        /// Gets the industry ListView model.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IIndustryListView GetIndustryListViewModel(string selectedIndustry, string message);

        /// <summary>
        /// Gets the industry create view.
        /// </summary>
        /// <returns></returns>
        IIndustryView GetIndustryCreateView();

        /// <summary>
        /// Gets the industry create view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IIndustryView GetIndustryCreateView(IIndustryView industryInfo, string processingMessage);

        /// <summary>
        /// Processes the industry create view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        string ProcessIndustryCreateView(IIndustryView industryInfo);

        /// <summary>
        /// Gets the industry edit view.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        IIndustryView GetIndustryEditView(int industryId);

        /// <summary>
        /// Processes the industry edit view.
        /// </summary>
        /// <param name="IndustryInfo">The industry information.</param>
        /// <returns></returns>
        string ProcessIndustryEditView(IIndustryView IndustryInfo);

        /// <summary>
        /// Processes the delete industry information.
        /// </summary>
        /// <param name="IndustryId">The industry identifier.</param>
        /// <returns></returns>
        string ProcessDeleteIndustryInfo(int IndustryId);

        #endregion


    }
}
