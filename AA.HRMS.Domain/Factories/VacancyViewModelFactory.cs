using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Models;
using AA.HRMS.Repositories.Services;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IVacancyViewModelFactory" />
    public class VacancyViewModelFactory : IVacancyViewModelFactory
    {
        /// <summary>
        /// The vacancy repository
        /// </summary>
        private readonly IVacancyRepository vacancyRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VacancyViewModelFactory"/> class.
        /// </summary>
        /// <param name="vacancyRepository">The vacancy repository.</param>
        public VacancyViewModelFactory(IVacancyRepository vacancyRepository)
        {
            this.vacancyRepository = vacancyRepository;
        }

        /// <summary>
        /// Creates the vacancy view.
        /// </summary>
        /// <param name="companyCollection"></param>
        /// <returns></returns>
        public IVacancyView CreateVacancyView(IList<ICompanyDetail> companyCollection)
        {
            // get company drop down list
            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            return new VacancyView
            {
                CompanyDropDown = companyDDL,
            };
        }
        /// <summary>
        /// Creates the vacancy view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="departmentDropDown">The department drop down.</param>
        /// <param name="jobTitleDropDown">The job title drop down.</param>
        /// <param name="gradesDropDown">The grades drop down.</param>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IVacancyView CreateVacancyView(IList<ICompanyDetail> companyCollection,
            IList<IDepartment> departmentDropDown,
            IList<IJobTitle> jobTitleDropDown, IList<IGrade> gradesDropDown, IVacancyView vacancyInfo, string message)
        {
            //Get Department
            var departmentDDL = GetDropDownList.DepartmentListItems(departmentDropDown, vacancyInfo.DepartmentId);

            //Get Job titles
            var jobTitleDDL = GetDropDownList.JobTitlesListItems(jobTitleDropDown, vacancyInfo.JobTitleId);

            //Get Grades
            var gradesDDl = GetDropDownList.GradeListItems(gradesDropDown, vacancyInfo.GradeId);

            // get company drop down list
            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, vacancyInfo.CompanyId);

            var viewModel = vacancyInfo;
            viewModel.DepartmentDropDown = departmentDDL;
            viewModel.JobTitleDropDown = jobTitleDDL;
            viewModel.GradesDropDown = gradesDDl;
            viewModel.CompanyDropDown = companyDDL;
            viewModel.ProcessingMessage = message;

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="vacancyInfo"></param>
        /// <param name="companyCollection"></param>
        /// <returns></returns>
        public IVacancyView EditVacancyView(IVacancyDetail vacancyInfo, IList<ICompanyDetail> companyCollection)
        {
            //Get Company
            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, vacancyInfo.CompanyId);

            return new VacancyView
            {
                CompanyDropDown = companyDDL,
                VacancyId = vacancyInfo.VacancyId,
                JobFunction = vacancyInfo.JobFunction,
                JobTitle = vacancyInfo.JobTitle,
                CompanyId = vacancyInfo.CompanyId,
                DepartmentId = vacancyInfo.DepartmentId,
                JobTitleId = vacancyInfo.JobTitleId,
                GradeId = vacancyInfo.GradeId,
                Qualification = vacancyInfo.Qualification,
                Experience = vacancyInfo.Experience,
                NumberToEmploy = vacancyInfo.NumberToEmploy,
                OpenDate = vacancyInfo.OpenDate,
                Closedate = vacancyInfo.Closedate,
                ProcessingMessage = vacancyInfo.ProcessingMessage,
            };
        }

        /// <summary>
        /// Creates the updated vacancy view.
        /// </summary>
        /// <param name="vacancyInfo">The vacancy information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="departmentDropDown">The department drop down.</param>
        /// <param name="jobTitleDropDown">The job title drop down.</param>
        /// <param name="gradesDropDown">The grades drop down.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">vacancyInfo</exception>
        /// <exception cref="System.ArgumentNullException">vacancyInfo</exception>
        public IVacancyView CreateUpdatedVacancyView(IVacancyView vacancyInfo, string processingMessage,
            IList<IDepartment> departmentDropDown,
            IList<IJobTitle> jobTitleDropDown,
            IList<IGrade> gradesDropDown)
        {
            if (vacancyInfo == null) throw new ArgumentNullException(nameof(vacancyInfo));
            if (vacancyInfo == null)
            {
                throw new System.ArgumentNullException(nameof(vacancyInfo));
            }


            var departmentDDL = GetDropDownList.DepartmentListItems(departmentDropDown, vacancyInfo.DepartmentId);

            //Get Grades
            var gradesDDl = GetDropDownList.GradeListItems(gradesDropDown, vacancyInfo.GradeId);


            //Get Job titles
            var jobTitleDDL = GetDropDownList.JobTitlesListItems(jobTitleDropDown, vacancyInfo.JobTitleId);


            vacancyInfo.GradesDropDown = gradesDDl;
            vacancyInfo.DepartmentDropDown = departmentDDL;
            vacancyInfo.JobTitleDropDown = jobTitleDDL;
            vacancyInfo.ProcessingMessage = processingMessage;

            return vacancyInfo;
        }

        /// <summary>
        /// Creates the vacancy ListView.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="vacancyCollection">The vacancy collection.</param>
        /// <returns></returns>
        public IVacancyListView CreateVacancyListView(IVacancyListFilter searchCriteria,
            IList<ICompanyDetail> companyCollection,
            IList<IVacancyDetail> vacancyCollection)
        {
            //Get company list
            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, searchCriteria.SelectedCompanyId);


            var returnView = new VacancyListView
            {
                CompanyDropDownList = companyDDL,
                VacancyDetailCollection = vacancyCollection,
                ProcessingMessage = string.Empty
            };

            return returnView;
        }

        public IVacancyListAdminView CreateVacancyListAdminView(IVacancyListFilter searchCriteria,
            IList<ICompanyDetail> companyCollection,
            IList<IVacancyDetail> vacancyCollection, string message)
        {
            //Get company list
            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, searchCriteria.SelectedCompanyId);


            // implement filter here using search criteria

            // implement filter here using search criteria
            // filter with companyId
            var filteredList = vacancyCollection
                .Where(x => x.CompanyId.Equals(searchCriteria.SelectedCompanyId < 1
                    ? x.CompanyId
                    : searchCriteria.SelectedCompanyId)).ToList();

            //filter with departmentId
            filteredList = filteredList.Where(x =>
                x.VacancyId.Equals(
                    searchCriteria.SelectedVacancyId < 1 ? x.VacancyId : searchCriteria.SelectedVacancyId)).ToList();

            //filter with departmentname
            filteredList = filteredList.Where(x =>
                x.JobTitle.Contains(string.IsNullOrEmpty(searchCriteria.SelectedJobName)
                    ? x.JobTitle
                    : searchCriteria.SelectedJobName)).ToList();

            var returnView = new VacancyListAdminView
            {
                CompanyDropDownList = companyDDL,

                VacancyDetailCollection = filteredList.ToList(),
                SearchCriteria = searchCriteria,
                ProcessingMessage = message
            };

            return returnView;
        }


        /// <summary>
        /// Creates the vacancy ListView by users.
        /// </summary>
        /// <param name="vacancyCollection">The vacancy collection.</param>
        /// <returns></returns>
        public IVacancyListView CreateVacancyListViewByUsers(IList<IApplicationModel> vacancyCollection)
        {
            var returnView = new VacancyListView
            {
                VacancyApplicationcollection = vacancyCollection,
                ProcessingMessage = string.Empty
            };

            return returnView;
        }

        /// <summary>
        /// Creates the vacancy ListView.
        /// </summary>
        /// <param name="vacancyCollection">The vacancy collection.</param>
        /// <returns></returns>
        public IVacancyListView CreateVacancyListView(IList<IVacancyDetail> vacancyCollection)
        {
            var returnView = new VacancyListView
            {
                VacancyDetailCollection = vacancyCollection,
                ProcessingMessage = string.Empty
            };

            return returnView;
        }
        /// <summary>
        /// Creates the vacancy detail.
        /// </summary>
        /// <param name="vacancyDetailInfo">The vacancy detail information.</param>
        /// <param name="hasApplied"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">vacancyDetailInfo</exception>
        public IVacancyDetail CreateVacancyDetail(IVacancyDetail vacancyDetailInfo, bool hasApplied)
        {
            if (vacancyDetailInfo == null)
                throw new ArgumentNullException(nameof(vacancyDetailInfo));

            var vacancyView = new VacancyDetail
            {
                VacancyId = vacancyDetailInfo.VacancyId,
                CompanyId = vacancyDetailInfo.CompanyId,
                CompanyName = vacancyDetailInfo.CompanyName,
                CompanyState = vacancyDetailInfo.CompanyState,
                DepartmentId = vacancyDetailInfo.DepartmentId,
                Department = vacancyDetailInfo.Department,
                JobTitleId = vacancyDetailInfo.JobTitleId,
                JobTitle = vacancyDetailInfo.JobTitle,
                GradeId = vacancyDetailInfo.GradeId,
                Qualification = vacancyDetailInfo.Qualification,
                Experience = vacancyDetailInfo.Experience,
                NumberToEmploy = vacancyDetailInfo.NumberToEmploy,
                OpenDate = vacancyDetailInfo.OpenDate,
                Closedate = vacancyDetailInfo.Closedate,
                JobDefinition = vacancyDetailInfo.JobDefinition,
                JobFunction = vacancyDetailInfo.JobFunction,
                QuestionCollection = vacancyDetailInfo.QuestionCollection,
                ProcessingMessage = vacancyDetailInfo.ProcessingMessage,
                HasApplied = hasApplied,
                CompanyAlias = vacancyDetailInfo.CompanyAlias,
            };

            return vacancyView;
        }

        /// <summary>
        /// Creates the applications ListView.
        /// </summary>
        /// <param name="applicationsCollections">The application model.</param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">applicationsCollections</exception>
        public IApplicationsListView CreateApplicationsListView(IList<IApplicationModel> applicationsCollections,
            string message)
        {
            if (applicationsCollections == null) throw new ArgumentNullException(nameof(applicationsCollections));


            var addedRecCount = 0;
            var k = 1;
            var applicationsInThreeColumns = new List<IApplicationsListInThrees>();
            var aRow = new ApplicationsListViewInThree();
            foreach (var aRecord in applicationsCollections)
            {
                addedRecCount++;
                switch (k) // Counting Number of record
                {
                    case 1:
                        aRow.ColumnOne = aRecord;
                        break;
                    case 2:
                        aRow.ColumnTwo = aRecord;
                        break;
                    case 3:
                        aRow.ColumnThree = aRecord;
                        break;
                }

                if ((k == 3) || (addedRecCount == applicationsCollections.Count))
                {
                    //Add Compledted Row Column to the List
                    applicationsInThreeColumns.Add(aRow);


                    //Initialise variables
                    aRow = new ApplicationsListViewInThree();
                    k = 0;
                }

                k++;
            }

            var returnView = new ApplicationsListView
            {
                ApplicationsCollections = applicationsInThreeColumns,
                ProcessingMesage = message
            };


            return returnView;
        }

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
        public IVacancyListView CreateApplicationsListView(int selectedVacancyId, int selectedCompanyId,
            string selectedJobTitle, IList<IApplicationModel> applicationsCollections,
            IList<ICompanyDetail> companyList,
            string message)
        {
            // get company  drop down list
            var companytDDL = GetDropDownList.CompanyListItems(companyList, selectedCompanyId);

            //Get Job Title DropDownList 

            // filter with companyId
            var filteredList = applicationsCollections
                .Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();

            // filter with ApplicationID
            filteredList = filteredList
                .Where(x => x.VacancyId.Equals(selectedVacancyId < 1
                    ? x.VacancyId
                    : selectedVacancyId)).ToList();


            //filter with Job Title
            filteredList = filteredList.Where(x =>
                x.JobTitle.Contains(string.IsNullOrEmpty(selectedJobTitle)
                    ? x.JobTitle
                    : selectedJobTitle)).ToList();


            var viewModel = new VacancyListView
            {
                CompanyDropDownList = companytDDL,
                VacancyApplicationcollection = filteredList,
                SelectedJobName = selectedJobTitle,
                ProcessingMessage = message,
                SelectedVacancyId = selectedVacancyId,
            };

            return viewModel;
        }
    }
}