using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using PagedList;
using AA.HRMS.Domain.Model;
using System.Collections;

namespace AA.HRMS.Domain.Factories
{
    public class EmployeeOnBoardViewModelFactory : IEmployeeOnBoardViewModelFactory
    {

        /// <summary>
        /// Creates the employee view.
        /// </summary>
        /// <param name="maritalStatusCollection">The marital status collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="religionCollection">The religion collection.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="levelCollection">The level collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="countryCollection">The country collection.</param>
        /// <param name="stateCollection">The state collection.</param>
        /// <returns></returns>
        public IEmployeeOnBoardView CreateEmployeeView(IList<IMaritalStatus> maritalStatusCollection, int companyId, IList<IEmployee> employeeCollection,
            IList<IReligion> religionCollection, IList<IYourGender> genderCollection, IList<IDepartment> departmentCollection, IList<ILevel> levelCollection, 
            IList<IGrade> gradeCollection, IList<IPayScale> payScaleCollection, IList<IJobTitle> jobTitleCollection, IList<ICountry> countryCollection, IList<IState> stateCollection, IList<IEmploymentType> employmentTypeCollection)
        {
            var maritalStatusDDL = GetDropDownList.MaritalStatusListItems(maritalStatusCollection, -1);
            var religionDDL = GetDropDownList.ReligionListItems(religionCollection, -1);
            var genderDDL = GetDropDownList.GenderListItems(genderCollection, -1);
            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, -1);
            var gradeDDL = GetDropDownList.GradeListItems(gradeCollection, -1);
            var jobTitleDDL = GetDropDownList.JobTitlesListItems(jobTitleCollection, -1);
            var levelDDL = GetDropDownList.LevelListItems(levelCollection, -1);
            var countryDDL = GetDropDownList.CountryListItem(countryCollection, 161);
            var stateDDL = GetDropDownList.StateListItem(stateCollection, -1);
            var permanentStateDDL = GetDropDownList.StateListItem(stateCollection, -1);
            var homeStateDDL = GetDropDownList.StateListItem(stateCollection, -1);
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var employmentTypeDDL = GetDropDownList.EmploymentTypeListItem(employmentTypeCollection, -1);
            var payScaleDDL = GetDropDownList.PayScaleListItem(payScaleCollection, -1);

            var view = new EmployeeOnBoardView
            {
                MaritalStatusDropDownList = maritalStatusDDL,
                ReligionDropDownList = religionDDL,
                GenderDropDownList = genderDDL,
                LevelDropDownList = levelDDL,
                GradeDropDownList = gradeDDL,
                DepartmentDropDownList = departmentDDL,
                JobTitleDropDownList = jobTitleDDL,
                ProcessingMessage = string.Empty,
                CountryDropDownList = countryDDL,
                HomeStateDropDownList = homeStateDDL,
                PermanentStateDropDownList = permanentStateDDL,
                StateDropDownList = stateDDL,
                EmployeeDropDownList = employeeDDL,
                EmploymentTypeDropDownList = employmentTypeDDL,
                NationalityId = 161,
                CompanyID = companyId,
                PayScaleDropDownList = payScaleDDL
            };

            return view;
        }

        /// <summary>
        /// Creates the on boarding view.
        /// </summary>
        /// <param name="maritalStatusCollection">The marital status collection.</param>
        /// <param name="religionCollection">The religion collection.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeOnBoardView CreateOnBoardingView(IList<IMaritalStatus> maritalStatusCollection,
            IList<IReligion> religionCollection, IList<IYourGender> genderCollection, EmployeeOnBoardView
                onboardInfo, string message)
        {
            var maritalStatusDL =
                GetDropDownList.MaritalStatusListItems(maritalStatusCollection, onboardInfo.MaritalStatusId);
            var religionDDL = GetDropDownList.ReligionListItems(religionCollection, onboardInfo.ReligionId);
            var genderDDL = GetDropDownList.GenderListItems(genderCollection, onboardInfo.GenderId);

            var view = onboardInfo;
            view.ProcessingMessage = message;
            view.ReligionDropDownList = religionDDL;
            view.GenderDropDownList = genderDDL;
            view.MaritalStatusDropDownList = maritalStatusDL;

            return view;
        }

        /// <summary>
        /// Creates the updated employee view.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <param name="maritalStatusCollection">The marital status collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="religionCollection">The religion collection.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="levelCollection">The level collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="countryCollection">The country collection.</param>
        /// <param name="stateCollection">The state collection.</param>
        /// <param name="processMessage">The process message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onboardInfo</exception>
        public IEmployeeOnBoardView CreateUpdatedEmployeeView(IEmployeeOnBoardView onboardInfo, IList<IMaritalStatus> maritalStatusCollection,
            IList<IEmployee> employeeCollection, IList<IReligion> religionCollection, IList<IYourGender> genderCollection, IList<IDepartment> departmentCollection, IList<ILevel> levelCollection, 
            IList<IGrade> gradeCollection, IList<IPayScale> payScaleCollection, IList<IJobTitle> jobTitleCollection, IList<ICountry> countryCollection, IList<IState> stateCollection, 
            IList<IEmploymentType> employmentTypeCollection, string processMessage)
        {
            if (onboardInfo == null)
            {
                throw new ArgumentNullException(nameof(onboardInfo));
            }

            var maritalStatusDDL = GetDropDownList.MaritalStatusListItems(maritalStatusCollection, onboardInfo.MaritalStatusId);
            var religionDDL = GetDropDownList.ReligionListItems(religionCollection, onboardInfo.ReligionId);
            var genderDDL = GetDropDownList.GenderListItems(genderCollection, onboardInfo.GenderId);
            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, onboardInfo.DepartmentId);
            var gradeDDL = GetDropDownList.GradeListItems(gradeCollection, onboardInfo.GradeID);
            var jobTitleDDL = GetDropDownList.JobTitlesListItems(jobTitleCollection, onboardInfo.JobTitleID);
            var levelDDL = GetDropDownList.LevelListItems(levelCollection, onboardInfo.LevelID);
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, onboardInfo.SupervisorEmployeeId);
            var countryDDL = GetDropDownList.CountryListItem(countryCollection, onboardInfo.NationalityId);
            var permanentStateDDL = GetDropDownList.StateListItem(stateCollection, onboardInfo.PermanentAddressStateId);
            var homeStateDDL = GetDropDownList.StateListItem(stateCollection, onboardInfo.HomeAddressStateId);
            var employmentTypeDDL = GetDropDownList.EmploymentTypeListItem(employmentTypeCollection, onboardInfo.EmploymentTypeId);
            var payScaleDDL = GetDropDownList.PayScaleListItem(payScaleCollection, onboardInfo.LevelGradeId);

            onboardInfo.ProcessingMessage = processMessage;
            //Updating drop down list
            onboardInfo.MaritalStatusDropDownList = maritalStatusDDL;
            onboardInfo.ReligionDropDownList = religionDDL;
            onboardInfo.GradeDropDownList = gradeDDL;
            onboardInfo.DepartmentDropDownList = departmentDDL;
            onboardInfo.JobTitleDropDownList = jobTitleDDL;
            onboardInfo.LevelDropDownList = levelDDL;
            onboardInfo.GenderDropDownList = genderDDL;
            onboardInfo.CountryDropDownList = countryDDL;
            onboardInfo.PermanentStateDropDownList = permanentStateDDL;
            onboardInfo.HomeStateDropDownList = homeStateDDL;
            onboardInfo.EmployeeDropDownList = employeeDDL;
            onboardInfo.EmploymentTypeDropDownList = employmentTypeDDL;
            onboardInfo.PayScaleDropDownList = payScaleDDL;

            return onboardInfo;
        }

        /// <summary>
        /// Creates the employee registration view.
        /// </summary>
        /// <returns></returns>
        public IEmployeeOnBoardView CreateEmployeeRegistrationView()
        {
            var viewModel = new EmployeeOnBoardView { };

            return viewModel;
        }

        /// <summary>
        /// Creates the employee view.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="user">The user.</param>
        /// <param name="companyColletion">The company colletion.</param>
        /// <param name="discipline">The discipline.</param>
        /// <param name="leaveRequestModel">The leave request model.</param>
        /// <param name="employmentHistory">The employment history.</param>
        /// <param name="educationHistory">The education history.</param>
        /// <param name="skillSet">The skill set.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeProfileView CreateEmployeeView(IEmployee employee, IUserDetail user, IList<ICompanyDetail> companyColletion, IList<IDiscipline> discipline, IList<ILeaveRequestModel> leaveRequestModel, IList<IEmploymentHistory> employmentHistory,
            IList<IEducationHistory> educationHistory, IList<ISkillSetModel> skillSet, IDigitalFile digitalFile,
           IList<ISpouseModel> spouseModel, IList<IEmergency> emergency,
            IList<IChildrenModel> childrenModel, IList<IBeneficiariesModel> beneficiariesModel,
            IList<INextOfKin> nextOfKin, string processingMessage)
        {
            var returnModel = new EmployeeProfileView
            {
                Employee = employee,
                User = user,
                EducationHistory = educationHistory,
                EmploymentHistory = employmentHistory,
                SkillSet = skillSet,
                ProfilePictureDetail = digitalFile,
                QueryCollection = discipline,
                LeaveTypeCollection = leaveRequestModel,
                CompanyCollection = companyColletion,
                ProcessingMessage = processingMessage,
                spouseModel = spouseModel,
                emergencyModel = emergency,
                nextOfKinModel = nextOfKin,
                childrenModel = childrenModel,
                beneficiaryModel = beneficiariesModel
            };

            return returnModel;
        }

        /// <summary>
        /// Creates the edit employee view.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <param name="maritalStatusCollection">The marital status collection.</param>
        /// <param name="religionCollection">The religion collection.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="levelCollection">The level collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="profilePictureDetail">The profile picture detail.</param>
        /// <param name="employeeUser">The employee user.</param>
        /// <param name="countryCollection">The country collection.</param>
        /// <param name="stateCollection">The state collection.</param>
        /// <param name="employmentTypeCollection">The employment type collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onboardInfo
        /// or
        /// maritalStatusCollection
        /// or
        /// religionCollection
        /// or
        /// genderCollection
        /// or
        /// departmentCollection
        /// or
        /// gradeCollection
        /// or
        /// levelCollection
        /// or
        /// jobTitleCollection
        /// or
        /// employmentTypeCollection
        /// </exception>
        public IEmployeeOnBoardView CreateEditEmployeeView(IEmployee onboardInfo, IList<IMaritalStatus> maritalStatusCollection,
            IList<IReligion> religionCollection, IList<IYourGender> genderCollection, IList<IEmployee> employeeCollection,
            IList<IDepartment> departmentCollection, IList<ILevel> levelCollection, IList<IGrade> gradeCollection, 
            IList<IJobTitle> jobTitleCollection, IDigitalFile profilePictureDetail, IUser employeeUser, IList<ICountry> countryCollection, IList<IState> stateCollection, IList<IEmploymentType> employmentTypeCollection, string processingMessage)
        {
            if (onboardInfo == null)
            {
                throw new ArgumentNullException(nameof(onboardInfo));
            }

            if (maritalStatusCollection == null)
            {
                throw new ArgumentNullException(nameof(maritalStatusCollection));
            }

            if (religionCollection == null)
            {
                throw new ArgumentNullException(nameof(religionCollection));
            }

            if (genderCollection == null)
            {
                throw new ArgumentNullException(nameof(genderCollection));
            }
            

            if (departmentCollection == null)
            {
                throw new ArgumentNullException(nameof(departmentCollection)); 
            }

            if (gradeCollection == null)
            {
                throw new ArgumentNullException(nameof(gradeCollection));
            }

            if (levelCollection == null)
            {
                throw new ArgumentNullException(nameof(levelCollection));
            }

            if (jobTitleCollection == null)
            {
                throw new ArgumentNullException(nameof(jobTitleCollection));
            }

            if (employmentTypeCollection == null) throw new ArgumentNullException(nameof(employmentTypeCollection));

            
            var maritalStatusDDL =
                GetDropDownList.MaritalStatusListItems(maritalStatusCollection, onboardInfo.MartialStatusId);
            var religionDDL = GetDropDownList.ReligionListItems(religionCollection, onboardInfo.ReligionId);
            var genderDDL = GetDropDownList.GenderListItems(genderCollection, onboardInfo.GenderId);
            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, onboardInfo.DepartmentId);
            var gradeDDL = GetDropDownList.GradeListItems(gradeCollection, onboardInfo.GradeId);
            var jobTitleDDL = GetDropDownList.JobTitlesListItems(jobTitleCollection, onboardInfo.JobTitleId ?? -1);
            var levelDDL = GetDropDownList.LevelListItems(levelCollection, onboardInfo.LevelId);
            var countryDDL = GetDropDownList.CountryListItem(countryCollection, onboardInfo.NationalityId);
            var permanentStateDDL = GetDropDownList.StateListItem(stateCollection, onboardInfo.PermanentAddressStateId);
            var homeStateDDL = GetDropDownList.StateListItem(stateCollection, onboardInfo.HomeAddressStateId);
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, onboardInfo.SupervisorEmployeeId);
            var employmentTypeDDL = GetDropDownList.EmploymentTypeListItem(employmentTypeCollection, onboardInfo.EmploymentTypeId);
            var returnView = new EmployeeOnBoardView
            {
                LastName = onboardInfo.LastName,
                FirstName = onboardInfo.FirstName,
                MiddleName = onboardInfo.MiddleName,
                Email = onboardInfo.Email,
                CompanyID = onboardInfo.CompanyId,
                LevelID = onboardInfo.LevelId,
                GradeID = onboardInfo.GradeId,
                LevelGradeId = onboardInfo.LevelGradeId,
                JobTitleID = onboardInfo.JobTitleId ?? -1,
                MobileNumber = onboardInfo.MobileNumber,
                PermanentAddress = onboardInfo.PermanentAddress,
                PermanentAddressCity = onboardInfo.PermanentAddressCity,
                PermanentAddressState = onboardInfo.PermanentAddressState,
                HomeAddress = onboardInfo.HomeAddress,
                HomeAddressCity = onboardInfo.HomeAddressCity,
                HomeAddressState = onboardInfo.HomeAddressState,
                OtherEmail = onboardInfo.OtherEmail,
                Birthday = onboardInfo.Birthday,
                MaritalStatusId = onboardInfo.MartialStatusId,
                GenderId = onboardInfo.GenderId,
                StaffNumber = onboardInfo.StaffNumber,
                DateEmployed = onboardInfo.DateEmployed,
                About = onboardInfo.About,
                DateExited = onboardInfo.DateExited,
                SkillSet = onboardInfo.SkillSet,
                SupervisorEmployeeId = onboardInfo.SupervisorEmployeeId,
                SeatingLocation = onboardInfo.SeatingLocation,
                DepartmentId = onboardInfo.DepartmentId,
                MaidenName = onboardInfo.MaidenName,
                PhotoDigitalFileId = onboardInfo.PhotoDigitalFileId,
                ReligionId = onboardInfo.ReligionId,
                Nationality = onboardInfo.Nationality,
                DateCreated = onboardInfo.DateCreated,
                EmployeeID = onboardInfo.EmployeeId,
                ProcessingMessage = processingMessage ?? "",
                LevelDropDownList = levelDDL,
                DepartmentDropDownList = departmentDDL,
                GradeDropDownList = gradeDDL,
                JobTitleDropDownList = jobTitleDDL,
                GenderDropDownList = genderDDL,
                MaritalStatusDropDownList = maritalStatusDDL,
                ReligionDropDownList = religionDDL,
                ProfilePictureDetail = profilePictureDetail,
                EmployeeUser = employeeUser,
                IsLocked = onboardInfo.IsLocked,
                CountryDropDownList = countryDDL,
                HomeStateDropDownList = homeStateDDL,
                PermanentStateDropDownList = permanentStateDDL,
                NationalityId = onboardInfo.NationalityId,
                PermanentAddressStateId = onboardInfo.PermanentAddressStateId,
                HomeAddressStateId = onboardInfo.HomeAddressStateId,
                EmployeeDropDownList = employeeDDL,
                EmploymentTypeId = onboardInfo.EmploymentTypeId,
                EmploymentTypeDropDownList = employmentTypeDDL,
                GenderOther = onboardInfo.GenderOother,
                ReligionOther = onboardInfo.ReligionOther
            };

            return returnView;
        }

        /// <summary>
        /// Creates the edit updated employee view.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onboardInfo</exception>
        public IEmployeeOnBoardView CreateEditUpdatedEmployeeView(IEmployeeOnBoardView onboardInfo)
        {
            if (onboardInfo == null)
                throw new ArgumentNullException(nameof(onboardInfo));

            return onboardInfo;
        }

        /// <summary>
        /// Gets the employee ListView.
        /// </summary>
        /// <param name="onboardingCollections">The onboarding collections.</param>
        /// <param name="staffNumber">The staff number.</param>
        /// <param name="staffName">Name of the staff.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeOnBoardListView GetEmployeeListView(
            IList<IEmployee> employeeCollections, IList<ICompanyDetail> companyCollection, string sortOrder, string searchString, string message, int? page)
        {

            if (string.IsNullOrEmpty(searchString)) searchString = "";

            searchString.ToLower();

            //Filter Employee by Name
            var filteredList = employeeCollections.Where(x =>
                (x.FirstName.ToLower()).Contains(string.IsNullOrEmpty(searchString)
                ? (x.FirstName.ToLower()) : searchString) || 
                (x.LastName.ToLower()).Contains(string.IsNullOrEmpty(searchString)
                ? (x.LastName.ToLower()) : searchString) || 
                (x.StaffNumber.ToLower()).Contains(string.IsNullOrEmpty(searchString)
                ? (x.StaffNumber.ToLower()) : searchString));
            
            

            switch (sortOrder)
            {
                case "name_desc":
                    filteredList = filteredList.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    filteredList = filteredList.OrderBy(s => s.DateEmployed);
                    break;
                case "date_desc":
                    filteredList = filteredList.OrderByDescending(s => s.DateEmployed);
                    break;
                default:
                    filteredList = filteredList.OrderBy(s => s.LastName);
                    break;
            }



            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            

            var returnedView = new EmployeeOnBoardListView
            {
                EmployeeList = filteredList.ToPagedList(pageNumber, pageSize),
                CompanyDropDown = companyDDL,
                sortOrder = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                searchString = (searchString == "Date" ? "date_desc" : "Date"),
                ProcessingMessage = message,
            };
            
            return returnedView;
        }

        /// <summary>
        /// Creates the admin dash board view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="company">The company.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="levelCollection">The level collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="disciplineCollection">The discipline collection.</param>
        /// <param name="leaveRequestModel">The leave request model.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="employmentHistory">The employment history.</param>
        /// <param name="educationHistory">The education history.</param>
        /// <param name="skillSet">The skill set.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="pendingLeaveRequests">The pending leave requests.</param>
        /// <param name="pendingLoanRequest">The pending loan request.</param>
        /// <param name="pendingTrainingRequest">The pending training request.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeProfileView CreateAdminDashBoardView(IUserDetail user, IEmployee employeeInfo, ICompanyDetail company, IList<ICompanyDetail> companyCollection,IList<ILevel> levelCollection, IList<IGrade> gradeCollection, 
            IList<IJobTitle> jobTitleCollection, IList<IDiscipline> disciplineCollection,  IList<ILeaveRequestModel> leaveRequestModel, IList<IDepartment> departmentCollection, 
            IList<ITraining> trainingCollection, IList<IEmployee> employeeCollection, IList<IEmploymentHistory> employmentHistory, IList<IEducationHistory> educationHistory, IList<ISkillSetModel> skillSet, 
            IDigitalFile digitalFile, IList<ILeaveRequestModel> pendingLeaveRequests, IList<IEmployeeLoan> pendingLoanRequest, IList<IEmployeeTrainingModel> pendingTrainingRequest, string processingMessage)
        {

            var returnModel = new EmployeeProfileView
            {
                User = user,
                Company = company,
                EducationHistory = educationHistory,
                EmploymentHistory = employmentHistory,
                SkillSet = skillSet,
                ProfilePictureDetail = digitalFile,
                QueryCollection = disciplineCollection,
                LeaveTypeCollection = leaveRequestModel,
                DepartmentCollection = departmentCollection,
                TrainingCollection = trainingCollection,
                ProcessingMessage = processingMessage,
                EmployeeCollection = employeeCollection,
                LevelCollection = levelCollection,
                GradeCollection = gradeCollection,
                JobTitle = jobTitleCollection,
                PendingLeaveRquest = pendingLeaveRequests,
                PendingLoanRequest = pendingLoanRequest,
                PendingTrainingRequest = pendingTrainingRequest,
                CompanyCollection = companyCollection,
                Employee = employeeInfo

            };

            return returnModel;
        }

        /// <summary>
        /// Creates the dash board view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="disciplineCollection">The discipline collection.</param>
        /// <param name="leaveRequestModel">The leave request model.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="trainingRequestCollection">The training request collection.</param>
        /// <param name="leaveRequest">The leave request.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="employmentHistory">The employment history.</param>
        /// <param name="educationHistory">The education history.</param>
        /// <param name="skillSet">The skill set.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeProfileView CreateDashBoardView(IUserDetail user, IEmployee employee, IList<ICompanyDetail> companyCollection, IList<IDiscipline> disciplineCollection,
            IList<ILeaveRequestModel> leaveRequestModel, IList<IDepartment> departmentCollection, IList<ITraining> trainingCollection, IList<IEmployeeTrainingModel> trainingRequestCollection, ILeaveRequestModel leaveRequest, IList<IEmployee> employeeCollection,
            IList<IEmploymentHistory> employmentHistory, IList<IEducationHistory> educationHistory, IList<ISkillSetModel> skillSet, IDigitalFile digitalFile, string processingMessage)
        {
            var returnModel = new EmployeeProfileView
            {
                User = user,
                EducationHistory = educationHistory,
                EmploymentHistory = employmentHistory,
                SkillSet = skillSet,
                Employee = employee,
                ProfilePictureDetail = digitalFile,
                QueryCollection = disciplineCollection,
                LeaveTypeCollection = leaveRequestModel,
                CompanyCollection = companyCollection,
                DepartmentCollection = departmentCollection,
                TrainingCollection = trainingCollection,
                ProcessingMessage = processingMessage,
                EmployeeCollection = employeeCollection,
                TrainingRequestCollection = trainingRequestCollection,
                LeaveRequest = leaveRequest,
            };

            return returnModel;
        }

        /// <summary>
        /// Creates the employee report.
        /// </summary>
        /// <param name="employeeCollections">The employee collections.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="genderId">The gender identifier.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="employeeTypeId">The employee type identifier.</param>
        /// <param name="employmentTypeCollection">The employment type collection.</param>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="countryCollection">The country collection.</param>
        /// <param name="stateOfOriginId">The state of origin identifier.</param>
        /// <param name="stateCollection">The state collection.</param>
        /// <param name="dateExitedFrom">The date exited from.</param>
        /// <param name="dateExitTo">The date exit to.</param>
        /// <param name="dateRetirementFrom">The date retirement from.</param>
        /// <param name="dateRetirementTo">The date retirement to.</param>
        /// <param name="dateOfBirthFrom">The date of birth from.</param>
        /// <param name="dateOfBirthTo">The date of birth to.</param>
        /// <param name="age">The age.</param>
        /// <param name="locationStateId">The location state identifier.</param>
        /// <param name="locationCountryId">The location country identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IEmployeeOnBoardListView CreateEmployeeReport(IList<IEmployee> employeeCollections, string lastName, string firstName, int genderId, IList<IYourGender> genderCollection, 
            int employeeTypeId, IList<IEmploymentType> employmentTypeCollection, int countryId, IList<ICountry> countryCollection, int stateOfOriginId, IList<IState> stateCollection, 
            DateTime? dateExitedFrom, DateTime? dateExitTo, DateTime? dateRetirementFrom, DateTime? dateRetirementTo, DateTime? dateOfBirthFrom, DateTime? dateOfBirthTo, int age, 
            int locationStateId, int locationCountryId, int? page, DateTime? dateEmployedFrom, DateTime? dateEmployedTo)
        {


            var stateDDL = GetDropDownList.StateListItem(stateCollection, -1);
            var genderDDL = GetDropDownList.GenderListItems(genderCollection, -1);
            var employeeTypeDDL = GetDropDownList.EmploymentTypeListItem(employmentTypeCollection, -1);
            var countryDDL = GetDropDownList.CountryListItem(countryCollection, -1);
           

            //Filter Employee by Name
            var filteredList = employeeCollections.Where(x => x.LastName.Contains(string.IsNullOrEmpty(lastName)
                ? x.LastName 
                : lastName)).ToList();

            filteredList = filteredList.Where(x => x.FirstName.Contains(string.IsNullOrEmpty(firstName)
                ? x.FirstName
                : firstName)).ToList();

            filteredList = filteredList.Where(x => x.GenderId.Equals(genderId < 1 ? x.GenderId : genderId)).ToList();

            filteredList = filteredList.Where(x => x.EmploymentTypeId.Equals(employeeTypeId < 1 ? x.EmploymentTypeId : employeeTypeId)).ToList();

            filteredList = filteredList.Where(x => x.NationalityId.Equals(countryId < 1 ? x.NationalityId : countryId)).ToList();
            
            filteredList = filteredList.Where(x => x.PermanentAddressStateId.Equals(stateOfOriginId < 1 ? x.PermanentAddressStateId : stateOfOriginId)).ToList();

            filteredList = filteredList.Where(x => x.HomeAddressStateId.Equals(locationStateId < 1  ? x.HomeAddressStateId : locationStateId)).ToList();

            foreach (var item in filteredList)
            {
                if ((item.DateExited >= dateExitedFrom && item.DateExited <= dateExitTo))
                {
                    filteredList = filteredList.Where((x=>x.DateExited >= dateExitedFrom && x.DateExited <= dateExitTo)).ToList();
                }
                else
                {
                    filteredList = filteredList.Where(x => x.DateExited.Equals(x.DateExited)).ToList();
                }

                if ((item.DateEmployed >= dateEmployedFrom && item.DateEmployed <= dateEmployedTo))
                {
                    filteredList = filteredList.Where((x => x.DateEmployed >= dateEmployedFrom && x.DateEmployed <= dateEmployedFrom)).ToList();
                }
                else
                {
                    filteredList = filteredList.Where(x => x.DateEmployed.Equals(x.DateEmployed)).ToList();
                }

                if (item.Birthday >= dateOfBirthFrom && item.Birthday <= dateOfBirthTo)
                {
                    filteredList = filteredList.Where((x=>x.Birthday >= dateOfBirthFrom && x.Birthday <= dateOfBirthTo)).ToList();
                }
                else
                {
                    filteredList = filteredList.Where(x => x.Birthday.Equals(x.Birthday)).ToList();
                }



                //if (ageFrom >= employeeAge && ageTo <= employeeAge)
                //{ 
                //    var employeeAge = (int) (DateTime.UtcNow - (DateTime)item.Birthday).Days * 0.00273973;
                //    filteredList = filteredList.Where(x => employeeAge.Equals(age)).ToList();
                //}
            }

            //filteredList = filteredList.Where(x => ((int)(DateTime.Now-(DateTime)x.Birthday).TotalDays / 365.25).Equals(age < 1  ? ((int)(DateTime.Now - (DateTime)x.Birthday).TotalDays / 365.25) : age)).ToList();

           


            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var result = new EmployeeOnBoardListView
            {
                EmployeeList = filteredList.ToPagedList(pageNumber, pageSize),
                GenderDropDown = genderDDL,
                StateDropDown = stateDDL,
                CountryDropDown = countryDDL,
                EmploymentTypeDropDown = employeeTypeDDL,
                SelectedGenderId = genderId,
                SelectedFirstName = firstName,
                SelectedLastName = lastName,
                SelectedCountryId = countryId,
                SelectedLocationStateId = locationStateId,
                SelectedStateOriginId = stateOfOriginId,
                SelectedEmploymentTypeId = employeeTypeId,
                SelectedDateExitFrom = dateExitedFrom,
                SelectedDateExitTo = dateExitTo,
                SelectedDateOfBirthFrom = dateOfBirthFrom,
                SelectedDateOfBirthTo = dateOfBirthTo
                

            };

            return result;
        }


        public IEmployeeOnBoardListView CreateViewReport(IList<IEmployee> employee)
        {
            

            var result = new EmployeeOnBoardListView
            {
                employee = employee
            };

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public INextOfKinView CreateNextOfKin(int employeeId, string message)
        {
            if(employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var viewModel = new NextOfKinView
            {
                EmployeeId = employeeId,
                ProcessingMessages = message
            };
            return viewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextOfKin"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public INextOfKinView CreateNextOfKin(INextOfKinView nextOfKin,string message)
        {
            if (nextOfKin == null)
            {
                throw new ArgumentNullException(nameof(nextOfKin));
            }

            
            nextOfKin.ProcessingMessages = string.Empty;
            return nextOfKin;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public INextOfKinView CreateNextOfKinById(INextOfKin nextOfKin)
        {
            if (nextOfKin == null) throw new ArgumentNullException(nameof(nextOfKin));

            var view = new NextOfKinView
            {
                NextOfKinId = nextOfKin.NextOfKinId,
                EmployeeId = nextOfKin.EmployeeId,
                Address = nextOfKin.Address,
                Relationship = nextOfKin.Relationship,
                Emial = nextOfKin.Emial,
                Mobile = nextOfKin.Mobile,
                DateOfBirth = nextOfKin.DateOfBirth,
                DateCreated = DateTime.Now,
                IsApproved = nextOfKin.IsApproved,
                NextOfKinName = nextOfKin.NextOfKinName,
                ProcessingMessages = "",

            };
            return view;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IBeneficiariesView CreateBeneficiaries(int employeeId, string message)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

                var viewModel = new BeneficiariesView
                {
                    EmployeeId = employeeId,
                    ProcessingMessage = message
                };
                return viewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beneficiaries"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IBeneficiariesView CreateBeneficiaries(IBeneficiariesView beneficiaries, string message)
        {
            if (beneficiaries == null)
            {
                throw new ArgumentNullException(nameof(beneficiaries));
            }


            beneficiaries.ProcessingMessage = string.Empty;
            return beneficiaries;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="beneficiaries"></param>
        /// <returns></returns>
        //public IBeneficiariesView CreateBeneficiariesById(IBeneficiariesModel beneficiaries)
        //{
        //    if (beneficiaries == null) throw new ArgumentNullException(nameof(beneficiaries));

        //    var view = new BeneficiariesView
        //    {
        //       // EmployeeId = beneficiaries.EmployeeId,
        //       // Address = beneficiaries.Address,
        //       // Email = beneficiaries.Email,
        //       // Mobile = beneficiaries.Mobile,
        //       // DateOfBirth = beneficiaries.DateOfBirth,
        //       // DateCreated = DateTime.Now,
        //       // IsApproved = false,
        //       // BeneficiaryName = beneficiaries.BeneficiaryName,
        //       // BeneficiaryId = beneficiaries.BeneficiaryId,
        //       //// ProcessingMessage = string.Empty,
        //       // IsActive = beneficiaries.IsActive,
        //       // DateModified = beneficiaries.DateModified,

        //     
        //    };
        //    return view;
        //}


        public IBeneficiariesView CreateBeneficiariesById(IBeneficiariesModel beneficiaries)
        {
            if (beneficiaries == null)
            {
                throw new ArgumentNullException(nameof(beneficiaries));
            }
            var viewModel = new BeneficiariesView
            {
                BeneficiaryId = beneficiaries.BeneficiaryId,
                BeneficiaryName = beneficiaries.BeneficiaryName,
                EmployeeId = beneficiaries.EmployeeId,
                Email = beneficiaries.Email,
                Address = beneficiaries.Address,
                DateCreated = beneficiaries.DateCreated,
                DateModified = beneficiaries.DateModified,
                DateOfBirth = beneficiaries.DateOfBirth,
                IsActive = beneficiaries.IsActive,
                IsApproved = beneficiaries.IsApproved,
                Mobile = beneficiaries.Mobile,
                ProcessingMessage = string.Empty
            };

            return viewModel;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IEmergencyContactView CreateEmergencyContact(int employeeId, string message)
        {

            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var viewModel = new EmergencyContactView
            {
                EmployeeId = employeeId,
                ProcessingMessage = message
            };
            return viewModel;

            
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="emergencyContact"></param>
       /// <param name="message"></param>
       /// <returns></returns>
        public IEmergencyContactView CreateEmergencyContact(IEmergencyContactView emergencyContact, string message)
        {
            if (emergencyContact == null)
            {
                throw new ArgumentNullException(nameof(emergencyContact));
            }


            emergencyContact.ProcessingMessage = string.Empty;
            return emergencyContact;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="emergency"></param>
        /// <returns></returns>
        public IEmergencyContactView CreateEmergencyContact(IEmergency emergency)
        {
            if (emergency == null) throw new ArgumentNullException(nameof(emergency));

            var view = new EmergencyContactView
            {
                EmployeeId = emergency.EmployeeId,
                Address = emergency.Address,
                Email = emergency.Email,
                Mobile = emergency.Mobile,
                DateOfBirth = emergency.DateOfBirth,
                DateCreated = DateTime.Now,
                IsApproved = false,
                EmergencyName = emergency.EmergencyName,
                EmergencyId = emergency.EmergencyId,
                //IsActive =  true,
                ProcessingMessage = ""
            };
            return view;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IChildrenInformationView CreateChildrenInformation(int employeeId, string message)
        {

            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var viewModel = new ChildrenInformationView
            {
                EmployeeId = employeeId,
                ProcessingMessage = message
            };
            return viewModel;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childrenInformation"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IChildrenInformationView CreateChildrenInformation(IChildrenInformationView childrenInformation, string message)
        {
            if (childrenInformation == null)
            {
                throw new ArgumentNullException(nameof(childrenInformation));
            }


            childrenInformation.ProcessingMessage = string.Empty;
            return childrenInformation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childrenInformation"></param>
        /// <returns></returns>
        public IChildrenInformationView CreateChildrenInformationById(IChildrenModel childrenInformation)
        {
            if (childrenInformation == null) throw new ArgumentNullException(nameof(childrenInformation));

            var view = new ChildrenInformationView
            {
                EmployeeId = childrenInformation.EmployeeId,
                Address = childrenInformation.Address,
                Email = childrenInformation.Email,
                Mobile = childrenInformation.Mobile,
                DateOfBirth = childrenInformation.DateOfBirth,
                DateCreated =childrenInformation.DateCreated,
                IsApproved = false,
                DateModified = childrenInformation.DateModified,
                IsActive = childrenInformation.IsActive,
                ChildName = childrenInformation.ChildName,
                ChildrenId = childrenInformation.ChildrenId,
                ProcessingMessage = "",
                
            };
            return view;
        }

    }
}