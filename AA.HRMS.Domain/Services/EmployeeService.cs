using System;
using System.Collections.Generic;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using AA.HRMS.Interfaces;
using System.Web;
using System.Data;
using AA.HRMS.Domain.Models;
using System.Linq;

namespace AA.HRMS.Domain.Services
{
    public class EmployeeService : IEmployeeOnBoardService
    {
        private readonly IEmployeeOnBoardRepository onBoardingRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly IEmployeeOnBoardViewModelFactory onboardingViewModelFactory;
        private readonly IUsersRepository usersRepository;
        private readonly IDigitalFileService digitalFileService;
        private readonly IAdminService adminService;
        private readonly IDigitalFileRepository digitalFileRepository;
        private readonly ILevelGradeRepository levelGradeRepository;
        private readonly IEmploymentHistoryRepository employmentHistoryRepository;
        private readonly IEducationHistoryRepository educationHistoryRepository;
        private readonly ISkillSetRepository skillSetRepository;
        private readonly IDisciplineRepository disciplineRepository;
        private readonly ILeaveRepository leaveModelRepository;
        private readonly IProfileRepository profileRepository;
        private readonly ITrainingRepository trainingRepository;
        private readonly ILevelRepository levelRepository;
        private readonly IGradeRepository gradeRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ISessionStateService session;
        private readonly IEmployeeViewModelFactory employeeViewModelFactory;
        private readonly IGenerateDocumentService generateDocumentService;
        private readonly ILoanRepository loanRepository;

        public EmployeeService(ICompanyRepository companyRepository, ILevelGradeRepository levelGradeRepository,
            ILeaveRepository leaveModelRepository, ILoanRepository loanRepository,
            IEmployeeOnBoardViewModelFactory onboardingViewModelFactory,
            IEmploymentHistoryRepository employmentHistoryRepository, ITrainingRepository trainingRepository,
            ILookupRepository lookupRepository, IEmployeeOnBoardRepository onBoardingRepository,
            IEducationHistoryRepository educationHistoryRepository,
            IUsersRepository usersRepository, IDigitalFileService digitalFileService,
            ISkillSetRepository skillSetRepository, IProfileRepository profileRepository,
            IAdminService adminService, IDigitalFileRepository digitalFileRepository,
            IDisciplineRepository disciplineRepository, ILevelRepository levelRepository,
            IGradeRepository gradeRepository, IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,ISessionStateService session,
            IEmployeeViewModelFactory employeeViewModelFactory, IGenerateDocumentService generateDocumentService)
        {
            this.companyRepository = companyRepository;
            this.onBoardingRepository = onBoardingRepository;
            this.lookupRepository = lookupRepository;
            this.onboardingViewModelFactory = onboardingViewModelFactory;
            this.usersRepository = usersRepository;
            this.digitalFileService = digitalFileService;
            this.adminService = adminService;
            this.digitalFileRepository = digitalFileRepository;
            this.levelGradeRepository = levelGradeRepository;
            this.disciplineRepository = disciplineRepository;
            this.leaveModelRepository = leaveModelRepository;
            this.profileRepository = profileRepository;
            this.employmentHistoryRepository = employmentHistoryRepository;
            this.educationHistoryRepository = educationHistoryRepository;
            this.skillSetRepository = skillSetRepository;
            this.trainingRepository = trainingRepository;
            this.levelRepository = levelRepository;
            this.gradeRepository = gradeRepository;
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.session = session;
            this.loanRepository = loanRepository;
            this.employeeViewModelFactory = employeeViewModelFactory;
            this.generateDocumentService = generateDocumentService;
        }


        #region //------------------------------------Employee Section--------------------------------------------------//

        /// <summary>
        /// Gets the list of employees.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="searchString"></param>
        /// <param name="message">The message.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userInfo</exception>
        public IEmployeeOnBoardListView GetListOfEmployees(string sortOrder, string searchString,
            string message, int? page)
        {

            int userId = (int)session.GetSessionValue(SessionKey.UserId);

            int companyIdInSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            //Get User Info In Order to get The  Company The HR/Company Administrator belongs to

            var userInfo = this.usersRepository.GetUserById(userId);
            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            //Get The List of employee registered in The Company the HR is Registered to
            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyIdInSession);
            

            foreach (var item in employeeCollection)
            {
                item.Photograph = digitalFileRepository.GetDigitalFileDetail(item.PhotoDigitalFileId ?? 0);
            }

            var viewModel = this.onboardingViewModelFactory.GetEmployeeListView(
                employeeCollection, companyCollection, sortOrder, searchString, message, page);


            return viewModel;
        }

        /// <summary>
        /// Gets the create employee view.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loggedUserDetails</exception>
        public IEmployeeOnBoardView GetCreateEmployeeView()
        {

            int loggedUserId = (int)this.session.GetSessionValue(SessionKey.UserId);

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById(loggedUserId);

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }


            // companyId from Session
            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);
            
            var genderCollection = this.lookupRepository.GetGenderCollection();
            
            var maritalStatusCollection = this.lookupRepository.GetMaritalStatusCollection();
            
            var religionCollection = this.lookupRepository.GetReligionCollection();
            
            var employmentTypeCollection = this.lookupRepository.GetEmploymentTypes();
            
            var dapartmentCollection = this.lookupRepository.GetDepartmentCollectionByCompanyId(companyId);
            
            var gradeCollection = this.gradeRepository.GetGradeByCompanyId(companyId);

            var levelCollection = this.levelRepository.GetLevelByCompanyId(companyId);

            var payScale = this.levelGradeRepository.GetLevelGradeByCompanyId(companyId);

            var employeeCollecction = this.lookupRepository.GetEmployeeByCompanyId(companyId);
            
            var jobTitleCollection = this.lookupRepository.GetJobTitleCollectionByCompanyId(companyId);

            var countryCollection = this.lookupRepository.GetCountryCollection();

            var stateCollecction = this.lookupRepository.GetStateCollection();

            var viewModel = this.onboardingViewModelFactory.CreateEmployeeView(maritalStatusCollection,
                companyId, employeeCollecction,
                religionCollection, genderCollection, dapartmentCollection, levelCollection, gradeCollection, payScale,
                jobTitleCollection, countryCollection, stateCollecction,employmentTypeCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the on boarding view.
        /// </summary>
        /// <param name="onBoarding">The on boarding.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmployeeOnBoardView GetOnBoardingView(IEmployeeOnBoardView onBoarding, string message)
        {
            //Gender Collection
            var genderCollection = this.lookupRepository.GetGenderCollection();

            //Marital Status Collection
            var maritalStatusCollection = this.lookupRepository.GetMaritalStatusCollection();

            //Religion Collection
            var religionCollection = this.lookupRepository.GetReligionCollection();

            //Department Collection
            var dapartmentCollection = this.lookupRepository.GetDepartmentCollectionByCompanyId(onBoarding.CompanyID);

            //Job Title Collection
            var jobTitleCollection = this.lookupRepository.GetJobTitleCollectionByCompanyId(onBoarding.CompanyID);

            //Grade Collection
            var gradeCollection = this.lookupRepository.GetGradesCollectionByCompanyId(onBoarding.CompanyID);


            var payScale = this.levelGradeRepository.GetLevelGradeByCompanyId(onBoarding.CompanyID);

            //Level Collection
            var levelCollection = this.lookupRepository.GetLevelByCompanyId(onBoarding.CompanyID);
            
            var employmentTypeCollection = this.lookupRepository.GetEmploymentTypes();
            
            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(onBoarding.CompanyID);
            
            var countryCollection = this.lookupRepository.GetCountryCollection();

            var stateCollecction = this.lookupRepository.GetStateCollection();

            var viewModel = this.onboardingViewModelFactory.CreateUpdatedEmployeeView(onBoarding, maritalStatusCollection, employeeCollection,
                religionCollection, genderCollection, dapartmentCollection, levelCollection, gradeCollection, payScale, jobTitleCollection, countryCollection, stateCollecction, employmentTypeCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the new employee information.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onboardInfo</exception>
        public string ProcessNewEmployeeInfo(IEmployeeOnBoardView onboardInfo, HttpPostedFileBase profilePicture)
        {
            if (onboardInfo == null)
            {
                throw new ArgumentNullException(nameof(onboardInfo));
            }

            var payScale = this.levelGradeRepository.GetLevelGradeById(onboardInfo.LevelGradeId);

            onboardInfo.LevelID = payScale.LevelId;
            onboardInfo.GradeID = payScale.GradeId;

            var processMessage = string.Empty;
            var isDataOkay = true;

            var onBoardingData =
                this.onBoardingRepository.GetOnBoarderByEmailAndStaffNumber(onboardInfo.CompanyID, onboardInfo.Email,
                    onboardInfo.StaffNumber);

            if (onBoardingData != null)
            {
                processMessage = Messages.OnBoarderAlreadyExist;
                isDataOkay = false;
            }


            if (!isDataOkay)
            {
                return processMessage;
            }

            var imageDigitalFileId = -1;

            var processingImage =
                this.digitalFileService.SaveFile(FileType.Image, profilePicture, out imageDigitalFileId);

            // check if file saved to database and save the Id as part of the profile record
            if (imageDigitalFileId > 0)
            {
                onboardInfo.PhotoDigitalFileId = imageDigitalFileId;
            }

            var saveEmployee = this.onBoardingRepository.SaveOnBoardingInfo(onboardInfo);


            return saveEmployee;
        }

        /// <summary>
        /// Processes the new employee information excel.
        /// </summary>
        /// <param name="employeeExcelSheet">The employee excel sheet.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeExcelSheet
        /// or
        /// employeeExcelDataCollection
        /// </exception>
        public string ProcessNewEmployeeInfoExcel(HttpPostedFileBase employeeExcelSheet)
        {

            if (employeeExcelSheet == null) throw new ArgumentNullException(nameof(employeeExcelSheet));

            var employeeExcelDataCollection = this.generateDocumentService.ExcelUpload(employeeExcelSheet);

            if (employeeExcelDataCollection == null) throw new ArgumentNullException(nameof(employeeExcelDataCollection));

            int companyId = (int)session.GetSessionValue(SessionKey.CompanyId);

            string result = string.Empty;

            //Gender Collection
            var genderCollection = this.lookupRepository.GetGenderCollection();
            
            //Marital Status Collection
            var maritalStatusCollection = this.lookupRepository.GetMaritalStatusCollection();

            //Religion Collection
            var religionCollection = this.lookupRepository.GetReligionCollection();

            //Department Collection
            var dapartmentCollection = this.lookupRepository.GetDepartmentCollectionByCompanyId(companyId);
            if (dapartmentCollection == null) return Messages.CompanySetupNotComplete;

            //Job Title Collection
            var jobTitleCollection = this.lookupRepository.GetJobTitleCollectionByCompanyId(companyId);
            if (jobTitleCollection == null) return Messages.CompanySetupNotComplete;

            //Grade Collection
            var gradeCollection = this.lookupRepository.GetGradesCollectionByCompanyId(companyId);
            if (gradeCollection == null) return Messages.CompanySetupNotComplete;
            
            //PayScale
            var payScale = this.levelGradeRepository.GetLevelGradeByCompanyId(companyId);
            if (payScale == null) return Messages.CompanySetupNotComplete;
            
            //Level Collection
            var levelCollection = this.lookupRepository.GetLevelByCompanyId(companyId);
            if (levelCollection == null) return Messages.CompanySetupNotComplete;
            
            //Employee Type Collection
            var employmentTypeCollection = this.lookupRepository.GetEmploymentTypes();
            if (employmentTypeCollection == null) return Messages.CompanySetupNotComplete;
            
            //Employee Collection 
            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            if (employeeCollection == null) return Messages.CompanySetupNotComplete;
            
            //Country Collection
            var countryCollection = this.lookupRepository.GetCountryCollection();
            if (countryCollection == null) return Messages.CompanySetupNotComplete;
            
            //State Collection
            var stateCollecction = this.lookupRepository.GetStateCollection();
            if (stateCollecction == null) return Messages.CompanySetupNotComplete;


            foreach (DataRow onboardInfo in employeeExcelDataCollection.Rows)
            {

                //Marital Status
                string martialStatus = onboardInfo.ItemArray[8].ToString();
                int martialStatusId = maritalStatusCollection.SingleOrDefault(p => p.Description.Equals(martialStatus)).MaritalStatusId;

                //Gender from excel sheet
                string gender = onboardInfo.ItemArray[9].ToString();
                int genderId = genderCollection.SingleOrDefault(p => p.Description.Equals(gender)).GenderId;
                string otherGender = (genderId > 2) ? gender : null;

                //region
                string religion = onboardInfo.ItemArray[10].ToString();
                int religionId = religionCollection.SingleOrDefault(p => p.Description.Equals(religion)).ReligionId;
                string otherReligion = (religionId > 3) ? religion : null;

                //Nationality
                string nationality = onboardInfo.ItemArray[11].ToString();
                int nationalityId = countryCollection.SingleOrDefault(p => p.Name.Equals(nationality)).CountryId;

                //Permanent State
                string permanentState = onboardInfo.ItemArray[14].ToString();
                int permanentStateId = stateCollecction.SingleOrDefault(p => p.Name.Equals(permanentState)).StateId;

                //Home State
                string homeState = onboardInfo.ItemArray[17].ToString();
                int homeStateId = stateCollecction.SingleOrDefault(p => p.Name.Equals(homeState)).StateId;


                //Level from excel sheet
                string level = onboardInfo.ItemArray[18].ToString();
                //Grade from excel sheet
                string grade = onboardInfo.ItemArray[19].ToString();

                var levelGrade = payScale.SingleOrDefault(p => p.GradeName.Equals(grade) && p.LevelName.Equals(level));

                int levelId = levelGrade.LevelId; //levelCollection.SingleOrDefault(p => p.LevelName.Equals(level)).LevelId;


                int gradeId = levelGrade.GradeId; //gradeCollection.SingleOrDefault(p => p.GradeName.Equals(grade)).GradeId;


                //Employment Type from excel sheet
                string employmentType = onboardInfo.ItemArray[20].ToString();
                int employmentTypeId = employmentTypeCollection.SingleOrDefault(p => p.Name.Equals(employmentType)).EmploymentTypeId;

                //Job Title from excel sheet
                string jobTitle = onboardInfo.ItemArray[21].ToString();
                int jobTitleId = jobTitleCollection.SingleOrDefault(p => p.JobTitleName.Equals(jobTitle)).JobTitleId;
                
                //Supervisor from excel sheet
                //string supervisor = onboardInfo.ItemArray[22].ToString();
                //int supervisorId = employeeCollection.SingleOrDefault(p => p.LastName.Equals(supervisor) || p.FirstName.Equals(supervisor)).EmployeeId;
                
                //Department from excel sheet
                string department = onboardInfo.ItemArray[23].ToString();
                int departmentId = dapartmentCollection.SingleOrDefault(p => p.DepartmentName.Equals(department)).DepartmentId;
                
                

                var newRecord = new EmployeeOnBoardView
                {
                    //Personal Information
                    StaffNumber = onboardInfo.ItemArray[0].ToString(),
                    LastName = onboardInfo.ItemArray[1].ToString(),
                    FirstName = onboardInfo.ItemArray[2].ToString(),
                    MiddleName = onboardInfo.ItemArray[3].ToString(),
                    Email = onboardInfo.ItemArray[4].ToString(),
                    MobileNumber = onboardInfo.ItemArray[5].ToString(),
                    OtherEmail = onboardInfo.ItemArray[6].ToString(),
                    Birthday = Convert.ToDateTime(onboardInfo.ItemArray[7].ToString()),
                    MaritalStatusId = martialStatusId,
                    GenderId = genderId,
                    GenderOther = otherGender,
                    ReligionId = religionId,
                    ReligionOther = otherReligion,
                    NationalityId = nationalityId,
                    CompanyID = companyId,

                    //Permanent Address
                    PermanentAddress = onboardInfo.ItemArray[12].ToString(),
                    PermanentAddressCity = onboardInfo.ItemArray[13].ToString(),
                    PermanentAddressStateId = permanentStateId,

                    //Home Address
                    HomeAddress = onboardInfo.ItemArray[15].ToString(),
                    HomeAddressCity = onboardInfo.ItemArray[16].ToString(),
                    HomeAddressStateId = homeStateId,
                    
                    //Work Information
                    LevelID = levelId,
                    GradeID = gradeId,
                    EmploymentTypeId = employmentTypeId,
                    JobTitleID = jobTitleId,
                    //SupervisorEmployeeId = supervisorId,
                    DepartmentId = departmentId,
                    DateEmployed = Convert.ToDateTime(onboardInfo.ItemArray[24].ToString())

                };
                
                var isDataOkay =
                (this.onBoardingRepository.GetOnBoarderByEmailAndStaffNumber(newRecord.CompanyID, newRecord.Email,
                    newRecord.StaffNumber) == null) ? true : false;

                if (isDataOkay)
                {
                    result = this.onBoardingRepository.SaveOnBoardingInfo(newRecord);
                }


                if (!string.IsNullOrEmpty(result)) return result;

            }

            return result;
        }

        /// <summary>
        /// Gets the on boarding edit view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onBoardingData
        /// or
        /// loggedUserDetails
        /// </exception>
        public IEmployeeOnBoardView GetOnBoardingEditView(int employeeId, string processingMesage)
        {

            int loggedUserId = (int)this.session.GetSessionValue(SessionKey.UserId);

            int companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            //Get The employee data By ID here
            var onBoardingData = onBoardingRepository.GetOnBoarderById(employeeId);

            var gradeLevel = this.levelGradeRepository.GetLevelGradeByLevelIdAndGradeId(companyId, onBoardingData.LevelId, onBoardingData.GradeId);

            onBoardingData.LevelGradeId = gradeLevel.PayScaleId;

            if (onBoardingData == null)
            {
                throw new ArgumentNullException(nameof(onBoardingData));
            }

            //Get The Curretly Logged In User Information
            var loggedUserDetails = usersRepository.GetUserById(loggedUserId);

            if (loggedUserDetails == null)
            {
                throw new ArgumentNullException(nameof(loggedUserDetails));
            }


            var genderCollection = this.lookupRepository.GetGenderCollection();
            var maritalStatusCollection = this.lookupRepository.GetMaritalStatusCollection();
            var religionCollection = this.lookupRepository.GetReligionCollection();
            var employmentTypeCollection = this.lookupRepository.GetEmploymentTypes();

            
            var departmentCollection =
                this.lookupRepository.GetDepartmentCollectionByCompanyId(companyId);
            var gradeCollection = this.lookupRepository.GetGradesCollectionByCompanyId(companyId);
            var jobTitleCollection =
                this.lookupRepository.GetJobTitleCollectionByCompanyId(companyId);
            //Level Collection
            var levelCollection = this.lookupRepository.GetLevelByCompanyId(companyId);

            var employeeCollection = this.lookupRepository.GetEmployeeByCompanyId(companyId);
            
            var countryCollection = this.lookupRepository.GetCountryCollection();

            var stateCollecction = this.lookupRepository.GetStateCollection();
            
            //Get profilePictureDetail
            var profilePictureDetail =
                this.digitalFileRepository.GetDigitalFileDetail(onBoardingData.PhotoDigitalFileId ?? 0);

            //Get the user that's associated with this employee
            var employeeUser = this.usersRepository.GetUserByEmail(onBoardingData.Email);

            //Get The Updated View Here
            var viewModel = this.onboardingViewModelFactory.CreateEditEmployeeView(onBoardingData,
                maritalStatusCollection, religionCollection, genderCollection, employeeCollection, departmentCollection, 
                levelCollection, gradeCollection, jobTitleCollection, profilePictureDetail, employeeUser, countryCollection, stateCollecction, employmentTypeCollection, processingMesage);

            return viewModel;
        }

        /// <summary>
        /// Gets the on boarding view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employee</exception>
        public IEmployeeProfileView GetOnBoardingView(int employeeId, string processingMesage)
        {
            //Get The employee data By ID here
            var employee = employeeRepository.GetEmployeeById(employeeId);

            var supervisor = employeeRepository.GetEmployeeById(employee.SupervisorEmployeeId??0);

            if (supervisor != null) employee.Supervisor = supervisor.LastName + " " + supervisor.FirstName;
 
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }


            if (employee != null)
            {
                //Get  A List of Employement Histories
                var employmentHistories =
                    this.employmentHistoryRepository.GetEmploymentHistoriesByUserId(employee.EmployeeId);

                // Get A List of Education Histories
                var educationHistories =
                    this.educationHistoryRepository.GetEducationHistoriesByUserId(employee.EmployeeId);

                //Get List of Skill SET
                var skillSets = this.skillSetRepository.GetSkillSetByUserId(employee.EmployeeId);

                //Get List of Discipline by EmployeeId and CompanyId
                var disciplineSets =
                    this.lookupRepository.GetDisciplineByCompanyIdandEmployeeId(employee.CompanyId,
                        employee.EmployeeId);

                //Get leave Requested by an Employee
                var leaveRequestCollection =
                    this.leaveModelRepository.GetLeaveRequestByEmployeeId(employee.CompanyId, employee.EmployeeId);

                //Get all my company
                var companyCollection = this.companyRepository.GetMyCompanies(employee.CompanyId);

                //Get profilePictureDetail
                var profilePictureDetail =
                    this.digitalFileRepository.GetDigitalFileDetail(employee.PhotoDigitalFileId ?? 0);

                //Get the user that's associated with this employee
                var employeeUser = this.usersRepository.GetUserByEmail(employee.Email);



                var spouse = this.employeeRepository.GetSpouseInfoById(employee.EmployeeId);

                var emergency = this.lookupRepository.GetEmployeeEmergencyContactById(employee.EmployeeId);

                var children = this.lookupRepository.GetChildrenInformationListById(employee.EmployeeId);

                var nextOfKin = this.lookupRepository.GetNextOfKinListById(employee.EmployeeId);

                var beneficiary = this.lookupRepository.GetBeneficiariesListById(employee.EmployeeId);

                //Get The Updated View Here
                return this.onboardingViewModelFactory.CreateEmployeeView(employee,
                    null, companyCollection, disciplineSets, leaveRequestCollection, employmentHistories,
                    educationHistories, skillSets, profilePictureDetail,spouse,emergency,children,beneficiary,nextOfKin, processingMesage);
             
            }

            return this.onboardingViewModelFactory.CreateEmployeeView(employee,
                null, null, null, null, null, null, null, null,null,null,null,null,null, processingMesage);
        }

        /// <summary>
        /// Gets the admin dash board view.
        /// </summary>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        public IEmployeeProfileView GetAdminDashBoardView(string message)
        {

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var userCompanyInfo = this.companyRepository.GetCompanyById(userInfo.CompanyId);
            

            //Get User Profile From The Profile Table
            var profile = this.profileRepository.GetProfileByUserId(userInfo.UserId);

            if (userInfo != null)
            {
                //Get  A List of Employement Histories
                var employmentHistories =
                    this.employmentHistoryRepository.GetEmploymentHistoriesByUserId(userInfo.UserId);

                // Get A List of Education Histories
                var educationHistories = this.educationHistoryRepository.GetEducationHistoriesByUserId(userInfo.UserId);

                //Get List of Skill SET
                var skillSets = this.skillSetRepository.GetSkillSetByUserId(userInfo.UserId);

                //Get leave Requested by an Employee
                var leaveRequestCollection = this.leaveModelRepository.GetLeaveRequestList();

                var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);
                
                if (companyId > 0)
                {

                    var companyInfo = this.companyRepository.GetCompanyById(companyId);

                    //Get All Discipline
                    var disciplineSets = lookupRepository.GetDisciplineByCompanyId(companyId);

                    //Get All Empployee
                    var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);

                    //Get The List of Registered Departments in the Company
                    var departmentCollection = lookupRepository.GetDepartmentCollectionByCompanyId(companyId);

                    //
                    var trainingCollection = lookupRepository.GetTrainingByCompanyId(companyId);

                    var levelCollection = lookupRepository.GetLevelByCompanyId(companyId);

                    var gradeCollection = lookupRepository.GetGradesCollectionByCompanyId(companyId);
                    
                    var jobTitleCollection = lookupRepository.GetJobTitleCollectionByCompanyId(companyId);
                    
                    var pendingLeaveRequest = leaveModelRepository.GetPendingLeaveRequestByCompanyId(companyId);
                    
                    var pendingTrainingRequest = trainingRepository.GetPendingTrainingByCompanyId(companyId);
                    
                    var pendingLoanRequest = loanRepository.GetPendingLoanRequestByCompanyId(companyId);


                    //Get profilePictureDetail
                    IDigitalFile profilePictureDetail = null;
                    if (profile != null)
                    {
                        profilePictureDetail =
                            this.digitalFileRepository.GetDigitalFileDetail(profile.PictureDigitalFileId);
                    }


                    //Get The Updated View Here
                    var returnModel = this.onboardingViewModelFactory.CreateAdminDashBoardView(userInfo, null, companyInfo, companyCollection,
                        levelCollection, gradeCollection, jobTitleCollection, disciplineSets,
                        leaveRequestCollection, departmentCollection, trainingCollection, employeeCollection,
                        employmentHistories, educationHistories, skillSets, profilePictureDetail, pendingLeaveRequest, pendingLoanRequest, pendingTrainingRequest, message);


                    returnModel.Profile = profile;

                    return returnModel;
                }
                
            }

            return this.onboardingViewModelFactory.CreateAdminDashBoardView(userInfo, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, message);
            
        }

        /// <summary>
        /// Gets the employee dash board view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeProfileView GetEmployeeDashBoardView(string message)
        {

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById((int)this.session.GetSessionValue(SessionKey.CompanyId));

            var employeeInfo = this.onBoardingRepository.GetOnBoarderById((int)this.session.GetSessionValue(SessionKey.EmployeeId));

            if (employeeInfo == null) throw new ArgumentNullException(nameof(employeeInfo));

            //Get User Profile From The Profile Table
            var profile = this.profileRepository.GetProfileByUserId(userInfo.UserId);

            if (userInfo != null)
            {
                //Get  A List of Employement Histories
                var employmentHistories =
                    this.employmentHistoryRepository.GetEmploymentHistoriesByUserId(userInfo.UserId);

                // Get A List of Education Histories
                var educationHistories = this.educationHistoryRepository.GetEducationHistoriesByUserId(userInfo.UserId);

                //Get List of Skill SET
                var skillSets = this.skillSetRepository.GetSkillSetByUserId(userInfo.UserId);

                //Get leave Requested by an Employee
                var leaveRequestCollection = this.leaveModelRepository.GetLeaveRequestByEmployeeId(employeeInfo.EmployeeId);

                var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

                //Get All Discipline
                var disciplineSets = lookupRepository.GetDisciplineByCompanyId(companyInfo.CompanyId);

                //Get All Empployee
                var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

                //Get The List of Registered Departments in the Company
                var departmentCollection = lookupRepository.GetDepartmentCollectionByCompanyId(companyInfo.CompanyId);

                //
                var trainingCollection = lookupRepository.GetTrainingByCompanyId(companyInfo.CompanyId);

                var levelCollection = lookupRepository.GetLevelByCompanyId(companyInfo.CompanyId);

                var gradeCollection = lookupRepository.GetGradesCollectionByCompanyId(companyInfo.CompanyId);

                var jobTitleCollection = lookupRepository.GetJobTitleCollectionByCompanyId(companyInfo.CompanyId);

                var pendingLeaveRequest = leaveModelRepository.GetPendingLeaveRequestByCompanyId(companyInfo.CompanyId);

                var pendingTrainingRequest = trainingRepository.GetPendingTrainingByCompanyId(companyInfo.CompanyId);

                var pendingLoanRequest = loanRepository.GetPendingLoanRequestByCompanyId(companyInfo.CompanyId);


                //Get profilePictureDetail
                IDigitalFile profilePictureDetail = null;

                if (profile != null)
                {
                    profilePictureDetail =
                        this.digitalFileRepository.GetDigitalFileDetail(profile.PictureDigitalFileId);
                }


                //Get The Updated View Here
                var returnModel = this.onboardingViewModelFactory.CreateAdminDashBoardView(userInfo, employeeInfo, companyInfo, companyCollection,
                    levelCollection, gradeCollection, jobTitleCollection, disciplineSets,
                    leaveRequestCollection, departmentCollection, trainingCollection, employeeCollection,
                    employmentHistories, educationHistories, skillSets, profilePictureDetail, pendingLeaveRequest, pendingLoanRequest, pendingTrainingRequest, message);


                returnModel.Profile = profile;

                return returnModel;
            }

            return this.onboardingViewModelFactory.CreateAdminDashBoardView(userInfo, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, message);


        }


        /// <summary>
        /// Processes the employee lock.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public string ProcessEmployeeLock(int employeeId)
        {
            //get the employee to be locked.
            var employeeInfo = this.onBoardingRepository.GetOnBoarderById(employeeId);

            var userInfo = this.usersRepository.GetUserByEmail(employeeInfo.Email);

            //Check the Lock Status
            bool isLocked = employeeInfo.IsLocked ?? false;

            // update the employee lock info
            employeeInfo.IsLocked = isLocked ? false : true;

            userInfo.IsLocked = employeeInfo.IsLocked;

            string processingMessage = string.Empty;

            string message = string.Empty;

            string result = string.Empty;

            if (userInfo != null)
            {
                // Update the user is Locked status in database
                processingMessage = usersRepository.UpdateUserLockInfo(userInfo);
            }

            if(employeeInfo != null)
            {
                // Update the Employee is locked status in database
                string y = onBoardingRepository.UpdateOnBoardingLockInfo(employeeInfo);
            }

            result = processingMessage + message;

            if (string.IsNullOrEmpty(result))
            {
                if (employeeInfo.IsLocked == true)
                {
                    result = "Selected employee successfully locked";
                }
                else
                {
                    result = "Selected employee successfully unlocked";
                }
            }

            return result;
        }

        /// <summary>
        /// Processes the edit on boarding information.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onboardInfo</exception>
        public string ProcessEditOnBoardingInformation(IEmployeeOnBoardView onboardInfo,
            HttpPostedFileBase profilePicture)
        {
            if (onboardInfo == null)
            {
                throw new ArgumentNullException(nameof(onboardInfo));
            }

            var isDataOkay = true;

            var processingMessage = string.Empty;

            var onBoardingData =
                this.onBoardingRepository.GetOnBoarderByCompany(onboardInfo.CompanyID, onboardInfo.LastName);

            if (!isDataOkay)
            {
                return processingMessage;
            }

            if (profilePicture != null)
            {
                var imageDigitalFileId = -1;

                var processingImage =
                    this.digitalFileService.SaveFile(FileType.Image, profilePicture, out imageDigitalFileId);

                // check if file saved to database and save the Id as part of the profile record
                if (imageDigitalFileId > 0)
                {
                    onboardInfo.PhotoDigitalFileId = imageDigitalFileId;
                }
            }

            var storeOnBoarder = onBoardingRepository.UpdateOnBoardingInfo(onboardInfo);

            return storeOnBoarder;
        }

        /// <summary>
        /// Deletes the on boarding.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public string DeleteOnBoarding(int employeeId)
        {
            var viewModel = this.onBoardingRepository.DeleteOnBoarding(employeeId);

            return viewModel;
        }

        /// <summary>
        /// Gets the report of employees.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="genderId">The gender identifier.</param>
        /// <param name="employeeTypeId">The employee type identifier.</param>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="stateOfOriginId">The state of origin identifier.</param>
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
        /// <exception cref="ArgumentNullException">userInfo</exception>
        public IEmployeeOnBoardListView GetReportOfEmployees(string lastName, string firstName, int genderId, int employeeTypeId,
            int countryId, int stateOfOriginId, DateTime? dateExitedFrom, DateTime? dateExitTo, DateTime? dateRetirementFrom, DateTime? dateRetirementTo,
            DateTime? dateOfBirthFrom, DateTime? dateOfBirthTo, int age, int locationStateId, int locationCountryId, int? page,
            DateTime? dateEmployedFrom, DateTime? dateEmployedTo)
        {

            int userId = (int)this.session.GetSessionValue(SessionKey.UserId);

            //Get User Info In Order to get The  Company The HR/Company Administrator belongs to
            var userInfo = this.usersRepository.GetUserById(userId);

            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            var companyInSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            //Get The List of employee registered in The Company the HR is Registered to
            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyInSession);
            
            foreach (var item in employeeCollection)
            {
                item.Photograph = digitalFileRepository.GetDigitalFileDetail(item.PhotoDigitalFileId ?? 0);
            }

            var genderCollection = this.lookupRepository.GetGenderCollection();
            var countryCollection = this.lookupRepository.GetCountryCollection();
            var employmentTypeCollection = this.lookupRepository.GetEmploymentTypes();
            var stateCollection = this.lookupRepository.GetStateCollection();



            var viewModel = this.onboardingViewModelFactory.CreateEmployeeReport(employeeCollection, lastName, firstName, genderId, genderCollection, employeeTypeId, employmentTypeCollection, countryId, countryCollection, stateOfOriginId, stateCollection,
                dateExitedFrom, dateExitTo, dateRetirementFrom, dateRetirementTo, dateOfBirthFrom, dateOfBirthTo, age, locationStateId, locationCountryId, page, dateEmployedFrom, dateEmployedTo);

            return viewModel;
        }


        #endregion

        #region //--------------------------------Next of Kin--------------------------------------//

        /// <summary>
        /// Creates the next of kin view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public INextOfKinView CreateNextOfKinView(int? employeeId)
        {

            var currentUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));
            
            // use the current user's email to get their employee record
            var currentEmployee = onBoardingRepository.GetOnBoarderById(employeeId ?? 0);

            if (currentEmployee != null)
            {
                employeeId = currentEmployee.EmployeeId;
            }
            else
            {
                employeeId = currentUser.UserId;
            }

            var viewModel = this.onboardingViewModelFactory.CreateNextOfKin(employeeId ?? 0, "");

            return viewModel;
        }
        
        /// <summary>
        /// Creates the next of kin view.
        /// </summary>
        /// <param name="nextOfKin">The next of kin.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public INextOfKinView CreateNextOfKinView(INextOfKinView nextOfKin, string message)
        {
             
            //Create a view
            var viewModel = this.onboardingViewModelFactory.CreateNextOfKin(nextOfKin, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the next of kin.
        /// </summary>
        /// <param name="nextOfKin">The next of kin.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">nextOfKin</exception>
        public string ProcessNextOfKin(INextOfKinView nextOfKin)
        {
            if (nextOfKin == null)
            {
                throw new System.ArgumentNullException(nameof(nextOfKin));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //check if description is already in database
            var valueData = this.lookupRepository.GetNextOfKinDescriptionByValue(nextOfKin.NextOfKinName);
            var isRecordExist = (valueData == null) ? false : true;

            if (isRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.NextOfKinExistText;
                return processingMessage;
            }



            var saveNextOfKin = this.employeeRepository.SaveNextOfKin(nextOfKin);
            return saveNextOfKin;
        }
        
        /// <summary>
        /// Gets the next of kin view by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public INextOfKinView GetNextOfKinViewById(int employeeId)
        {
            //Get Next of Kin information from database by Id
            var nextofkin = this.lookupRepository.GetNextOfKinById(employeeId);


            //Create a view
            var viewModel = this.onboardingViewModelFactory.CreateNextOfKinById(nextofkin);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit next of kin.
        /// </summary>
        /// <param name="nextOfKin">The next of kin.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">nextOfKin</exception>
        public string ProcessEditNextOfKin(INextOfKinView nextOfKin)
        {
            if (nextOfKin == null)
            {
                throw new System.ArgumentNullException(nameof(nextOfKin));
            }


            //Save edited next of kin
            var editNextOfKin = this.employeeRepository.EditNextOfKin(nextOfKin);
            return editNextOfKin;
        }

        /// <summary>
        /// Processes the delete next of kin.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeId</exception>
        public string ProcessDeleteNextOfKin(int employeeId)
        {
            if (employeeId < 1)
            {
                throw new ArgumentOutOfRangeException("employeeId");
            }
            var delete = this.employeeRepository.DeleteNextOfKin(employeeId);
            return delete;
        }

        #endregion

        #region //--------------------------------Beneficiary---------------------------------------//

        /// <summary>
        /// Creates the beneficiaries view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public IBeneficiariesView CreateBeneficiariesView(int? employeeId)
        {
            

            var currentUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            // use the current user's email to get their employee record
            var currentEmployee = onBoardingRepository.GetOnBoarderById(employeeId ?? 0);

            if (currentEmployee != null)
            {
                employeeId = currentEmployee.EmployeeId;
            }
            else
            {
                employeeId = currentUser.UserId;
            }

            var viewModel = this.onboardingViewModelFactory.CreateBeneficiaries(employeeId ?? 0, "");

            return viewModel;
        }

        /// <summary>
        /// Creates the beneficiaries view.
        /// </summary>
        /// <param name="beneficiaries">The beneficiaries.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IBeneficiariesView CreateBeneficiariesView(IBeneficiariesView beneficiaries, string message)
        {

            //Create a view
            var viewModel = this.onboardingViewModelFactory.CreateBeneficiaries(beneficiaries, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the beneficiaries.
        /// </summary>
        /// <param name="beneficiaries">The beneficiaries.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">beneficiaries</exception>
        public string ProcessBeneficiaries(IBeneficiariesView beneficiaries)
        {
            if (beneficiaries == null)
            {
                throw new System.ArgumentNullException(nameof(beneficiaries));
            }

            var saveBeneficiaries = this.employeeRepository.SaveBeneficiaries(beneficiaries);
            return saveBeneficiaries;
        }

        /// <summary>
        /// Gets the benefiiaries view by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public IBeneficiariesView GetBenefiiariesViewById(int employeeId)
        {
            //Get Next of Kin information from database by Id
            var beneficiaries = this.lookupRepository.GetBeneficiariesById(employeeId);


            //Create a view
            var viewModel = this.onboardingViewModelFactory.CreateBeneficiariesById(beneficiaries);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit beneficiaries.
        /// </summary>
        /// <param name="beneficiaries">The beneficiaries.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">beneficiaries</exception>
        public string ProcessEditBeneficiaries(IBeneficiariesView beneficiaries)
        {
            if (beneficiaries == null)
            {
                throw new System.ArgumentNullException(nameof(beneficiaries));
            }
            
            //Save edited beneficiary
            var editBeneficiary = this.employeeRepository.EditBeneficiaries(beneficiaries);
            return editBeneficiary;
        }

        /// <summary>
        /// Processes the delete beneficiaries.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeId</exception>
        public string ProcessDeleteBeneficiaries(int employeeId)
        {
            if (employeeId < 1)
            {
                throw new ArgumentOutOfRangeException("employeeId");
            }
            var delete = this.employeeRepository.DeleteBeneficiaries(employeeId);
            return delete;
        }

        #endregion

        #region //---------------------------------Emergency Contact-------------------------------------//
        
        /// <summary>
        /// Creates the emergency contact view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public IEmergencyContactView CreateEmergencyContactView(int? employeeId)
        {
            
            var currentUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            // use the current user's email to get their employee record
            var employeeInfo = this.onBoardingRepository.GetOnBoarderById(employeeId ?? 0);

            if (employeeInfo != null)
            {
                employeeId = employeeInfo.EmployeeId;
            }
            else
            {
                employeeId = currentUser.UserId;
            }
            
            var viewModel = this.onboardingViewModelFactory.CreateEmergencyContact(employeeId ?? 0, "");

            return viewModel;
        }

        /// <summary>
        /// Creates the emergency contact view.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmergencyContactView CreateEmergencyContactView(IEmergencyContactView emergency, string message)
        {

            //Create a view
            var viewModel = this.onboardingViewModelFactory.CreateEmergencyContact(emergency, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the emergency contact.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">emergency</exception>
        public string ProcessEmergencyContact(IEmergencyContactView emergency)
        {
            if (emergency == null)
            {
                throw new System.ArgumentNullException(nameof(emergency));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //check if description is already in database
            var valueData = this.lookupRepository.GetEmergencyContactDescriptionByValue(emergency.EmergencyName);
            var isRecordExist = (valueData == null) ? false : true;

            if (isRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.EmergencyContactAlreadyExists;
                return processingMessage;
            }



            var saveEmergencyContact = this.employeeRepository.SaveEmergencyContact(emergency);
            return saveEmergencyContact;
        }

        /// <summary>
        /// Gets the emergency contact view by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public IEmergencyContactView GetEmergencyContactViewById(int employeeId)
        {
            //Get Next of Kin information from database by Id
            var beneficiaries = this.lookupRepository.GetEmergencyContactDescriptionById(employeeId);


            //Create a view
            var viewModel = this.onboardingViewModelFactory.CreateEmergencyContact(beneficiaries);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit emergency contact.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">emergency</exception>
        public string ProcessEditEmergencyContact(IEmergencyContactView emergency)
        {
            if (emergency == null)
            {
                throw new System.ArgumentNullException(nameof(emergency));
            }
            
            //Save edited beneficiary
            var editEmergency = this.employeeRepository.EditEmergencyContact(emergency);
            return editEmergency;
        }


        /// <summary>
        /// Processes the delete emergency.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeId</exception>
        public string ProcessDeleteEmergency(IEmergencyContactView emergency)
        {
            if (emergency == null)
            {
                throw new ArgumentOutOfRangeException("employeeId");
            }
            var delete = this.employeeRepository.DeleteEmergencyContact(emergency);
            return delete;
        }

        #endregion

        #region //-----------------------------------------Children Section---------------------------------//

        /// <summary>
        /// Creates the children information view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public IChildrenInformationView CreateChildrenInformationView(int? employeeId)
        {

            var currentUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            // use the current user's email to get their employee record
            var currentEmployee = onBoardingRepository.GetOnBoarderById(employeeId??0);

            if (currentEmployee != null)
            {
                employeeId = currentEmployee.EmployeeId;
            }
            else
            {
                employeeId = currentUser.UserId;
            }

            var viewModel = this.onboardingViewModelFactory.CreateChildrenInformation(employeeId ?? 0, "");

            return viewModel;
        }

        /// <summary>
        /// Creates the children information view.
        /// </summary>
        /// <param name="childrenInformation">The children information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IChildrenInformationView CreateChildrenInformationView(IChildrenInformationView childrenInformation, string message)
        {

            //Create a view
            var viewModel = this.onboardingViewModelFactory.CreateChildrenInformation(childrenInformation, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the children information.
        /// </summary>
        /// <param name="childrenInformation">The children information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">childrenInformation</exception>
        public string ProcessChildrenInformation(IChildrenInformationView childrenInformation)
        {
            if (childrenInformation == null)
            {
                throw new ArgumentNullException(nameof(childrenInformation));
            }

            //var processingMessage = string.Empty;
            //var isDataOkay = true;

            ////check if description is already in database
            //var valueData = this.lookupRepository.GetChildrenInformationDescriptionByValue(childrenInformation.ChildName);
            //var isRecordExist = (valueData == null) ? false : true;

            //if (isRecordExist)
            //{
            //    isDataOkay = false;
            //    processingMessage = Messages.ChildInformationAlreadyExist;
            //    return processingMessage;
            //}



            var saveBeneficiaries = this.employeeRepository.SaveChildrenInformation(childrenInformation);
            return saveBeneficiaries;
        }

        /// <summary>
        /// Gets the children information view by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public IChildrenInformationView GetChildrenInformationViewById(int employeeId)
        {
            //Get Next of Kin information from database by Id
            var children = this.lookupRepository.GetChildrenInformationDescriptionById(employeeId);


            //Create a view
            var viewModel = this.onboardingViewModelFactory.CreateChildrenInformationById(children);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit children information.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">information</exception>
        public string ProcessEditChildrenInformation(IChildrenInformationView information)
        {
            if (information == null)
            {
                throw new System.ArgumentNullException(nameof(information));
            }

            var editinformation = this.employeeRepository.EditChildrenInformation(information);
            return editinformation;
        }

        /// <summary>
        /// Processes the delete children information.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">information</exception>
        public string ProcessDeleteChildrenInformation(IChildrenInformationView information)
        {
            if (information == null)
            {
                throw new ArgumentOutOfRangeException("information");
            }

            var delete = this.employeeRepository.DeleteChildrenInformation(information);
            return delete;
        }


        #endregion

        #region //--------------------------------------------Spouse Section----------------------------------------------------//

        /// <summary>
        /// Gets the spouse details for employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public ISpouseViewModel GetSpouseDetailsForEmployee(int? employeeId)
        {

            var currentUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.onBoardingRepository.GetOnBoarderById(employeeId ?? 0);

            if (employeeInfo != null)
            {
                employeeId = employeeInfo.EmployeeId;
            }
            else
            {
                employeeId = currentUser.UserId;
            }

            var viewModel = this.employeeViewModelFactory.CreateSpouseView(employeeId ?? 0, "");


            return viewModel;

        }

        /// <summary>
        /// Processes the spouse create view.
        /// </summary>
        /// <param name="spouseViewModel">The spouse view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseViewModel</exception>
        public string ProcessSpouseCreateView (ISpouseViewModel spouseViewModel)
        {
            if (spouseViewModel == null)
                throw new ArgumentNullException(nameof(spouseViewModel));

            var processingMessage = string.Empty;

            if (spouseViewModel.EmployeeId == 0)
            {

                var user = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

                var employee = this.onBoardingRepository.GetEmployeeByEmail(user.Email);

                if (employee != null)
                {
                    spouseViewModel.EmployeeId = employee.EmployeeId;
                }
                else
                {
                    spouseViewModel.EmployeeId = user.UserId;
                }

               

            }
            processingMessage = this.employeeRepository.SaveSpouseInfo(spouseViewModel);
                return processingMessage;
        }

        /// <summary>
        /// Gets the spouse create view.
        /// </summary>
        /// <param name="spouseViewModel">The spouse view model.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseViewModel</exception>
        public ISpouseViewModel GetSpouseCreateView (ISpouseViewModel spouseViewModel,string processingMessage)
        {
            if (spouseViewModel == null)
            {
                throw new ArgumentNullException(nameof(spouseViewModel));
            }

            var viewModel = this.employeeViewModelFactory.CreateSpouseCreateView(spouseViewModel, processingMessage);
            return viewModel;
        }
        
        /// <summary>
        /// Getspouses the edit view.
        /// </summary>
        /// <param name="spouseId">The spouse identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// spouseId
        /// or
        /// spouseInfo
        /// </exception>
        public ISpouseViewModel GetspouseEditView(int spouseId)
        {
            if (spouseId == 0)
            {
                throw new ArgumentNullException(nameof(spouseId));
            }
            var spouseInfo = this.employeeRepository.GetSpouseById(spouseId);

            if (spouseInfo == null)
            {
                throw new ArgumentNullException(nameof(spouseInfo));
            }

            var viewModel = this.employeeViewModelFactory.EditSpouseView(spouseInfo);
            return viewModel;
        }

        /// <summary>
        /// Processes the spouse edit view.
        /// </summary>
        /// <param name="spouseViewModel">The spouse view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseViewModel</exception>
        public string ProcessSpouseEditView(ISpouseViewModel spouseViewModel)
        {
            if (spouseViewModel == null)
            {
                throw new ArgumentNullException(nameof(spouseViewModel));
            }

            var processingMessage = string.Empty;

            processingMessage = this.employeeRepository.UpdateSpouseInfo(spouseViewModel);

            return processingMessage;
        }

        /// <summary>
        /// Processpouses the delete view.
        /// </summary>
        /// <param name="spouseId">The spouse identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">spouseId</exception>
        public string ProcesspouseDeleteView(int spouseId)
        {
            if (spouseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(spouseId));
            }

            var deleteData = this.employeeRepository.DeleteSpouseInfo(spouseId);

            return deleteData;
        }


        #endregion

        #region //-----------------------------------Promotion Section--------------------------------------------------------//



        public IPromotionListView GetPromotionListView(string message)
        {
            int companyId = (int)session.GetSessionValue(SessionKey.CompanyId);

            var promotionList = this.onBoardingRepository.GetPromotionsByCompanyId(companyId);

            return this.employeeViewModelFactory.CreatePromotionListView(0, promotionList, message);
        }

        /// <summary>
        /// Gets the promotion ListView.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        public IPromotionListView GetPromotionListView(int employeeId, string message)
        {
            if (employeeId < 1) throw new ArgumentNullException(nameof(employeeId));

            var promotionList = this.onBoardingRepository.GetPromotionsByEmployeeId(employeeId);

            var employee = this.onBoardingRepository.GetOnBoarderById(employeeId);


            return this.employeeViewModelFactory.CreatePromotionListView(employeeId, promotionList, message);
        }

        /// <summary>
        /// Gets the promotion view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        public IPromotionView GetPromotionView(int employeeId)
        {
            if (employeeId < 1) throw new ArgumentNullException(nameof(employeeId));

            var employee = this.onBoardingRepository.GetOnBoarderById(employeeId);

            int companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var payScaleCollection = this.levelGradeRepository.GetLevelGradeByCompanyId(companyId);

            return this.employeeViewModelFactory.CreatePromotionView(companyId, employee, payScaleCollection);
        }

        /// <summary>
        /// Gets the promotion view.
        /// </summary>
        /// <param name="promotion">The promotion.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">promotion</exception>
        public IPromotionView GetPromotionView(IPromotionView promotionView, string processingMessage)
        {
            if (promotionView == null) throw new ArgumentNullException(nameof(promotionView));

            int companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var employee = this.onBoardingRepository.GetOnBoarderById(promotionView.EmployeeId);

            var payScaleCollection = this.levelGradeRepository.GetLevelGradeByCompanyId(companyId);

            return this.employeeViewModelFactory.CreatePromotionView(promotionView, employee, payScaleCollection, processingMessage);
        }

        /// <summary>
        /// Processes the promotion.
        /// </summary>
        /// <param name="promotionView">The promotion view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">promotionView</exception>
        public string ProcessPromotion(IPromotionView promotionView)
        {
            if (promotionView == null) throw new ArgumentNullException(nameof(promotionView));

            string result = string.Empty;

            int companyId = (int)session.GetSessionValue(SessionKey.CompanyId);

            var payScaleInfo = this.levelGradeRepository.GetLevelGradeById(promotionView.PayScaleId);

            promotionView.LevelId = payScaleInfo.LevelId;
            promotionView.GradeId = payScaleInfo.GradeId;
            promotionView.CompanyId = companyId;

            result = this.onBoardingRepository.SavePromotionInfo(promotionView);

            if (string.IsNullOrEmpty(result))
            {
                result = this.onBoardingRepository.UpdatePromotion(promotionView);
            }

            return result;
        }
        
        #endregion

    }
}