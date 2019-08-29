using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Factories
{

    public class AdminViewModelFactory : IAdminViewModelFactory
    {

        public IHomeView GetDashBoardOption(IUserDetail userInfo, IList<ICompanyDetail> companyCollection)
        {

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            var result = new HomeModelView
            {
                CompanyCollection = companyCollection,
                CompanyDropDown = companyDDL,
                User = userInfo
                
            };
            return result;
        }

        #region //------------------------------------------------Company Section----------------------------------//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyCollection"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ICompanyListView CreateCompanyListView(IList<ICompanyDetail> companyCollection, string message)
        {
            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            var returnView = new CompanyListView
            {
                CompanyCollection = companyCollection,
                ProcessingMessage = message ?? ""
            };

            return returnView;
        }
        
        /// <summary>
        /// Creates the user ListView.
        /// </summary>
        /// <param name="userCollection">The user collection.</param>
        /// <param name="selectedEmail">The selected email.</param>
        /// <param name="selectedName">Name of the selected.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userCollection</exception>
        public IUserListView CreateUserListView(IList<IUserDetail> userCollection, string selectedEmail,
            string selectedName, string message)
        {
            if (userCollection == null)
            {
                throw new ArgumentNullException(nameof(userCollection));
            }


            //filter with Email
            var filteredList = userCollection.Where(x =>
                x.Email.Contains(string.IsNullOrEmpty(selectedEmail)
                    ? x.Email
                    : selectedEmail)).ToList();

            //Filter by Name

            filteredList = filteredList.Where(x =>
                (x.FirstName + " " + x.LastName).Contains(string.IsNullOrEmpty(selectedName)
                    ? (x.FirstName + " " + x.LastName)
                    : selectedName)).ToList();

            var returnView = new UserListView
            {
                UserCollection = filteredList,
                SelectedEmail = selectedEmail,
                SelectedName = selectedName,
                ProcessingMessage = message ?? ""
            };

            return returnView;
        }

        /// <summary>
        /// Creates the company registration view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="industryCollection"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// industryCollection
        /// </exception>
        public ICompanyRegistrationView CreateCompanyRegistrationView(IList<ICompanyDetail> companyCollection, IList<IIndustry> industryCollection, IList<ICountry> countryCollection)
        {
            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            if(industryCollection == null)
            {
                throw new ArgumentNullException(nameof(industryCollection));
            }

            if (countryCollection == null)
            {
                throw new ArgumentNullException(nameof(countryCollection));
            }

            // get parentcompany  drop down list
            var parentCompanytDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            var industryDDl = GetDropDownList.IIndsutryListItems(industryCollection, -1);

            var countryDDL = GetDropDownList.CountryListItem(countryCollection, 161);

            var model = new CompanyRegistrationView()
            {
                IndustryDropDownList = industryDDl,
                ParentCompanyDropDownList = parentCompanytDDL,
                CountryDropDownList = countryDDL,
                CompanyCountryId = 161
            };

            return model;
        }

        /// <summary>
        /// Creates the updated company view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public ICompanyRegistrationView CreateUpdatedCompanyView(ICompanyRegistrationView companyInfo,
            string processingMessage)
        {
            if (companyInfo == null) throw new ArgumentNullException(nameof(companyInfo));

            companyInfo.ProcessingMessage = processingMessage;

            return companyInfo;
        }

        /// <summary>
        /// Creates the company registration view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="industryCollection"></param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyInfo
        /// or
        /// companyCollection
        /// or
        /// industryCollection
        /// </exception>
        public ICompanyRegistrationView CreateCompanyRegistrationView(ICompanyRegistrationView companyInfo,
            IList<ICompanyDetail> companyCollection, IList<IIndustry> industryCollection, IList<ICountry> countryCollection,
            string processingMessage)
        {
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            if(industryCollection == null)
            {
                throw new ArgumentNullException(nameof(industryCollection));
            }

            // get parentcompany  drop down list
            var parentCompanytDDL =
                GetDropDownList.CompanyListItems(companyCollection, companyInfo.ParentCompanyId ?? -1);

            var industryDDL =
               GetDropDownList.IIndsutryListItems(industryCollection, companyInfo.IndustryId);

            var countryDDL =
                GetDropDownList.CountryListItem(countryCollection, companyInfo.CompanyCountryId);

            var viewModel = companyInfo;
            viewModel.ParentCompanyDropDownList = parentCompanytDDL;
            viewModel.IndustryDropDownList = industryDDL;
            viewModel.CountryDropDownList = countryDDL;
            viewModel.ProcessingMessage = processingMessage;

            return viewModel;
        }

        /// <summary>
        /// Creates the company registration view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyCollection</exception>
        public ICompanyRegistrationView CreateCompanyRegistrationView(ICompanyDetail companyInfo,
            IList<ICompanyDetail> companyCollection, IList<IIndustry> industryCollection, IList<ICountry> countryCollection)
        {
            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            if (industryCollection == null)
            {
                throw new ArgumentNullException(nameof(industryCollection));
            }

            // get parentcompany  drop down list
            var parentCompanytDDL =
                GetDropDownList.CompanyListItems(companyCollection, companyInfo.ParentCompanyId ?? -1);

            var industryDDL =
                GetDropDownList.IIndsutryListItems(industryCollection, companyInfo.IndustryId);

            var countryDDL =
                GetDropDownList.CountryListItem(countryCollection, 161);

            var model = new CompanyRegistrationView()
            {
                ParentCompanyDropDownList = parentCompanytDDL,
                CountryDropDownList = countryDDL,
                ProcessingMessage = string.Empty,
                CompanyCountry = companyInfo.CompanyCountry,
                CACRegistrationNumber = companyInfo.CACRegistrationNumber,
                CompanyAddressLine1 = companyInfo.CompanyAddressLine1,
                CompanyAddressLine2 = companyInfo.CompanyAddressLine2,
                CompanyCity = companyInfo.CompanyCity,
                CompanyCountryId = 161,
                CompanyEmail = companyInfo.CompanyEmail,
                CompanyId = companyInfo.CompanyId,
                CompanyName = companyInfo.CompanyName,
                CompanyPhone = companyInfo.CompanyPhone,
                CompanyState = companyInfo.CompanyState,
                CompanyWebsite = companyInfo.CompanyWebsite,
                CompanyZipCode = companyInfo.CompanyZipCode,
                DateCreated = companyInfo.DateCreated,
                ParentCompanyId = companyInfo.ParentCompanyId,
                LogoDigitalFileId = companyInfo.LogoDigitalFileId,
                CompanyAlias = companyInfo.CompanyAlias,
                IsActive = companyInfo.IsActive,
                IndustryDropDownList = industryDDL,
                IndustryId = companyInfo.IndustryId,
                CompanyLogo = companyInfo.CompanyLogo
            };

            return model;
        }

    #endregion

        #region //--------------------------------------------------------------Department Section----------------------------------------//

        /// <summary>
        /// Creates the department view.
        /// </summary>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyCollection"></param>
        /// <returns></returns>
        public IDepartmentView CreateDepartmentView(IList<IDepartment> departmentCollection, int companyId)
        {
            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, -1);

            var view = new DepartmentView
            {
                CompanyId = companyId,
                ParentDepartmentDropDown = departmentDDL,
                ProcessingMessage = string.Empty
            };

            return view;
        }

        /// <summary>
        /// Creates the department view.
        /// </summary>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="deptInfo">The dept information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IDepartmentView CreateDepartmentView(IList<IDepartment> departmentCollection, IDepartmentView deptInfo, string message)
        {
            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, deptInfo.ParentDepartmentId);

            var view = deptInfo;
            view.ProcessingMessage = message;
            view.ParentDepartmentDropDown = departmentDDL;

            return view;
        }

        /// <summary>
        /// Creates the edit department view.
        /// </summary>
        /// <param name="departmentInfo">The department information.</param>
        /// <param name="departmentsList">The departments list.</param>
        /// <param name="companyList">The company list.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// departmentInfo
        /// or
        /// departmentsList
        /// or
        /// companyList
        /// </exception>
        public IDepartmentView CreateEditDepartmentView(IDepartment departmentInfo, IList<IDepartment> departmentsList, string message)
        {
            if (departmentInfo == null)
            {
                throw new ArgumentNullException(nameof(departmentInfo));
            }

            if (departmentsList == null)
            {
                throw new ArgumentNullException(nameof(departmentsList));
            }

            var departmentDDL = GetDropDownList.DepartmentListItems(departmentsList, departmentInfo.ParentDepartmentId);

            var view = new DepartmentView
            {
                DepartmentId = departmentInfo.DepartmentId,
                CompanyId = departmentInfo.CompanyId,
                ParentDepartmentDropDown = departmentDDL,
                ProcessingMessage = message,
                DepartmentName = departmentInfo.DepartmentName,
                Description = departmentInfo.Description,
                IsActive = departmentInfo.IsActive,
                ParentDepartmentId = departmentInfo.ParentDepartmentId,
                DateCreated = departmentInfo.DateCreated
            };

            return view;
        }

        /// <summary>
        /// Creates the updated department view.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deptInfo</exception>
        /// <exception cref="ArgumentException">departmentCollection</exception>
        public IDepartmentView CreateUpdatedDepartmentView(IDepartmentView deptInfo,
            IList<IDepartment> departmentCollection, string processingMessage)
        {
            if (deptInfo == null) throw new ArgumentNullException(nameof(deptInfo));
            if (departmentCollection == null) throw new ArgumentException(nameof(departmentCollection));

            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, -1);

            deptInfo.ParentDepartmentDropDown = departmentDDL;
            deptInfo.ProcessingMessage = processingMessage;

            return deptInfo;
        }

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
        public IDepartmentListView CreateDepartmentListView(int selectedCompanyId, int selectedDepartmentId,
            string selectedDepartment,
            IList<ICompanyDetail> companyList, IList<IDepartment> departmentsList, string message)
        {
            // get parentcompany  drop down list
            var companytDDL = GetDropDownList.CompanyListItems(companyList, selectedCompanyId);

            // filter with companyId
            var filteredList = departmentsList
                .Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();

            //filter with departmentId
            filteredList = filteredList.Where(x =>
                x.DepartmentId.Equals(selectedDepartmentId < 1 ? x.DepartmentId : selectedDepartmentId)).ToList();

            //filter with departmentname
            filteredList = filteredList.Where(x =>
                x.DepartmentName.Contains(string.IsNullOrEmpty(selectedDepartment)
                    ? x.DepartmentName
                    : selectedDepartment)).ToList();


            var viewModel = new DepartmentListView
            {
                CompanyDropDownList = companytDDL,
                DepartmentCollection = filteredList.ToList(),
                ProcessingMessage = message,
                SelectedCompanyId = selectedCompanyId,
                SelectedDepartment = selectedDepartment,
                SelectedDepartmentId = selectedDepartmentId
            };

            return viewModel;
        }

        #endregion

        #region //-------------------------------------------------------------JobTitle Section----------------------------------------//

        /// <summary>
        /// Creates the job title view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IJobTitleView CreateJobTitleView(int companyId)
        {

            if (companyId <= 0) throw new ArgumentNullException(nameof(companyId));

            var view = new JobTitleView
            {
                CompanyId = companyId,
                ProcessingMessage = string.Empty
            };

            return view;
        }
        
        /// <summary>
        /// Creates the job title view.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IJobTitleView CreateJobTitleView(IJobTitleView jobTitleInfo, string processingMessage)
        {

            if (jobTitleInfo == null) throw new ArgumentNullException(nameof(jobTitleInfo));

            jobTitleInfo.ProcessingMessage = processingMessage;

            return jobTitleInfo;
        }

        /// <summary>
        /// Creates the edit job title view.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleInfo</exception>
        public IJobTitleView CreateEditJobTitleView(IJobTitle jobTitleInfo, string processingMessage)
        {
            if (jobTitleInfo == null) throw new ArgumentNullException(nameof(jobTitleInfo));

            var returnView = new JobTitleView
            {
                JobDefinition = jobTitleInfo.JobDefinition,
                JobFunction = jobTitleInfo.JobFunction,
                JobTitleId = jobTitleInfo.JobTitleId,
                JobTitleName = jobTitleInfo.JobTitleName,
                CompanyId = jobTitleInfo.CompanyId,
                DateCreated = jobTitleInfo.DateCreated,
                ProcessingMessage = processingMessage ?? "",
            };

            return returnView;
        }
        
        /// <summary>
        /// Gets the job titles ListView.
        /// </summary>
        /// <param name="seletedJobTitle">The seleted job title.</param>
        /// <param name="selectedJobTitle">The selected job title.</param>
        /// <param name="jobTitleCollections">The job title collections.</param>
        /// <param name="companyDetail">The company detail.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// jobTitleCollections
        /// or
        /// companyDetail
        /// </exception>
        public IJobTitleListView GetJobTitlesListView( int selectedCompanyId,
            string selectedJobTitle,
            IList<IJobTitle> jobTitleCollections,
            ICompanyDetail companyDetail, IList<ICompanyDetail> companyList, string message)
        {
            if (jobTitleCollections == null)
            {
                throw new ArgumentNullException(nameof(jobTitleCollections));
            }
                
            if (companyDetail == null)
            {
                throw new ArgumentNullException(nameof(companyDetail));
            }

            var companyDDL = GetDropDownList.CompanyListItems(companyList, selectedCompanyId);


            var filteredList = jobTitleCollections.Where(x =>
                x.JobTitleName.Contains(string.IsNullOrEmpty(selectedJobTitle)
                    ? x.JobTitleName
                    : selectedJobTitle)).ToList();

            var returnedView = new JobTitleListView
            {
                JobTitlesCollection = filteredList.ToList(),
                CompanyDetails = companyDetail,
                ProcessingMessage = message,
                SelectedJobTitle = selectedJobTitle,
                CompanyDropDownList = companyDDL

            };

            return returnedView;
        }

        #endregion

        #region //---------------------------------------------------------------------Industry Section End---------------------------------------//

        /// <summary>
        /// Creates the industry ListView.
        /// </summary>
        /// <param name="IndustryCollection">The industry collection.</param>
        /// <param name="selectedIndustry"></param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">IndustryCollection</exception>
        public IIndustryListView CreateIndustryListView(IList<IIndustry> IndustryCollection, string selectedIndustry,string message)
        {
            if (IndustryCollection == null)
            {
                throw new ArgumentNullException(nameof(IndustryCollection));
            }

            var filterList = IndustryCollection.Where(x => x.IndustryName.Contains(string.IsNullOrEmpty(selectedIndustry)
                ? x.IndustryName
                : selectedIndustry)).ToList();

            var returnView = new IndustryListView
            {
                IndustryCollection = filterList,
                ProcessingMessage = message ?? ""
            };

            return returnView;
        }

        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <returns></returns>
        public IIndustryView CreateIndustryView()
        {
            var viewModel = new IndustryView
            {
                ProcessingMessage = string.Empty
            };
            return viewModel;
        }

        /// <summary>
        /// Creates the updated industry view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        public IIndustryView CreateUpdatedIndustryView(IIndustryView industryInfo, string processingMessage)
        {
            if (industryInfo == null)
                throw new ArgumentNullException(nameof(industryInfo));
            industryInfo.ProcessingMessage = processingMessage;

            return industryInfo;
        }

        /// <summary>
        /// Edits the industry view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        public IIndustryView EditIndustryView(IIndustry industryInfo)
        {
            if (industryInfo == null)
                throw new ArgumentNullException(nameof(industryInfo));

            var industryView = new IndustryView
            {
                IndustryId = industryInfo.IndustryId,
                IndustryName = industryInfo.IndustryName,
                IsActive = industryInfo.IsActive,
                DateCreated = industryInfo.DateCreated
            };

            return industryView;
        }

        /// <summary>
        /// Edits the updated industry view.
        /// </summary>
        /// <param name="IndustryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">IndustryInfo</exception>
        public IIndustryView EditUpdatedIndustryView(IIndustryView IndustryInfo, string processingMessage)
        {
            if (IndustryInfo == null)
                throw new ArgumentNullException(nameof(IndustryInfo));

            IndustryInfo.ProcessingMessage = processingMessage;

            return IndustryInfo;
        }

        #endregion


    }
}