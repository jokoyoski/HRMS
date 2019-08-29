using System;
using System.Linq;
using System.Collections.Generic; 
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Services;
using AA.Infrastructure.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using System.Web;
using System.IO;
using System.Data;
using AA.HRMS.Domain.Models;


namespace AA.HRMS.Domain.Services
{
    
    public class AdminService : IAdminService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IAdminViewModelFactory adminViewModelFactory;
        private readonly ILookupRepository lookupRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IJobTitleRepository jobTitleRepository;
        private readonly IIndustryRepository industryRepository;
        private readonly IUsersRepository usersRepository;
        private readonly ISessionStateService session;
        private readonly IAccountRepository accountRepository;
        private readonly IDigitalFileService digitalFileService;
        private readonly IGenerateDocumentService generateDocumentService;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly IDigitalFileRepository digitalFileRepository;
    
        
        public AdminService(ICompanyRepository companyRepository, IAdminViewModelFactory adminViewModelFactory, IDigitalFileRepository digitalFileRepository,
            ILookupRepository lookupRepository, IDepartmentRepository departmentRepository, IEmployeeOnBoardRepository employeeOnBoardRepository,
            IJobTitleRepository jobTitleRepository, ISessionStateService session, IAccountRepository accountRepository,
            IIndustryRepository industryRepository, IUsersRepository usersRepository, IDigitalFileService digitalFileService,
            IGenerateDocumentService generateDocumentService)
        {
            this.companyRepository = companyRepository;
            this.adminViewModelFactory = adminViewModelFactory;
            this.lookupRepository = lookupRepository;
            this.departmentRepository = departmentRepository;
            this.jobTitleRepository = jobTitleRepository;
            this.industryRepository = industryRepository;
            this.usersRepository = usersRepository;
            this.session = session;
            this.accountRepository = accountRepository;
            this.digitalFileService = digitalFileService;
            this.generateDocumentService = generateDocumentService;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.digitalFileRepository = digitalFileRepository;
        }

        public IHomeView ChooseCompany()
        {
            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));
            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);
            var employee = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);


            var viewModel = this.adminViewModelFactory.GetDashBoardOption(userInfo, companyCollection);
            
            if (SessionKey.UserRoles.Contains("Employee") && employee != null)
            {
                viewModel.CompanyId = employee.CompanyId;
            }
            

            return viewModel;
        }


        #region //------------------------------------Company Section-----------------------------------//
        
        /// <summary>
        /// Gets the company ListView model.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ICompanyListView GetCompanyListViewModel(string message)
        {

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            //Generate Vacancy From Factory
            var viewModel = this.adminViewModelFactory.CreateCompanyListView(companyCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the register company view model.
        /// </summary>
        /// <returns></returns>
        public ICompanyRegistrationView GetRegisterCompanyViewModel()
        {
            int userId = (int)session.GetSessionValue(SessionKey.UserId);

            var userInfo = usersRepository.GetUserById(userId);

            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            var industryCollection = this.lookupRepository.GetIndustryCollection();

            var countryCollection = this.lookupRepository.GetCountryCollection();

            //Get View Model From Factory 
            var viewModel =
                this.adminViewModelFactory.CreateCompanyRegistrationView(companyCollection, industryCollection, countryCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the register company view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ICompanyRegistrationView GetRegisterCompanyViewModel(ICompanyRegistrationView viewModel, string message)
        {

            var userInfo = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));
            
            // get company collection  to build Parent company drop down list
            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            var industryCollection = this.lookupRepository.GetIndustryCollection().ToList();

            var counrtyCollection = this.lookupRepository.GetCountryCollection();

            //Get View Model From Factory
            viewModel = this.adminViewModelFactory.CreateCompanyRegistrationView(viewModel, companyCollection,
                industryCollection, counrtyCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the company registration information.
        /// </summary>
        /// <param name="companyRegistrationInfo">The company registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyRegistrationInfo</exception>
        public string ProcessCompanyRegistrationInfo(ICompanyRegistrationView companyRegistrationInfo, HttpPostedFileBase companyLogo)
        {
            if (companyRegistrationInfo == null)
            {
                throw new ArgumentNullException(nameof(companyRegistrationInfo));
            }

            int userId = (int) this.session.GetSessionValue(SessionKey.UserId);

            int companyId = 0;
            int digitalFileId = 0;

            string processingMessage = string.Empty;

            //Validate Current Company is Not Registered via CAC Number -

            var companyInfo =
                this.companyRepository.GetCompanyByCACNumber(companyRegistrationInfo.CACRegistrationNumber);

            var userInfo = this.usersRepository.GetUserById(userId);

            if (userInfo.CompanyId > 0 && companyRegistrationInfo.ParentCompanyId < 1)
            {

                processingMessage = Messages.CompanyMostBeAChildofExistingCompany;

                return processingMessage;
            }

            if (companyInfo != null)
            {

                processingMessage = Messages.CACNumberAlreadyExisted;
            }
            else
            {
                //Save Company Logo
                var digitalFile = this.digitalFileService.SaveFile(FileType.Image, companyLogo, out digitalFileId);

                //Passing the digital fileId into the companyInfo
                companyRegistrationInfo.LogoDigitalFileId = digitalFileId;

                //Store Compnay Information
                processingMessage = this.companyRepository.SaveCompanyRegistrationInfo(companyRegistrationInfo, out companyId);

                int companySessionId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

                if (companySessionId <= 0)
                {
                    session.AddValueToSession(SessionKey.CompanyId, companyId);
                }


                if (userInfo.CompanyId <= 0)
                {
                    userInfo.CompanyId = companyId;
                    accountRepository.UpdateUserCompany(userInfo);
                    accountRepository.SaveCompanyAdmin(userInfo);
                }

   
            }

            return processingMessage;
        }

        /// <summary>
        /// Gets the selected company information.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public ICompanyRegistrationView GetSelectedCompanyInfo(int companyId)
        {
            //Get The Selected Company by companyId
            var companyInfo = this.companyRepository.GetCompanyById(companyId);

            companyInfo.CompanyLogo = this.digitalFileRepository.GetDigitalFileDetail(companyInfo.LogoDigitalFileId ?? 0);

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            // get company collection  to build Parent company drop down list
            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId).ToList();

            var industryCollection = this.lookupRepository.GetIndustryCollection();

            var countryCollection = this.lookupRepository.GetCountryCollection();
          
            // get the registration view to be used for both view and edit
            var viewModel = this.adminViewModelFactory.CreateCompanyRegistrationView(companyInfo, companyCollection, industryCollection, countryCollection);

            return viewModel;
        }

        /// <summary>
        /// Deletes the company information.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public ICompanyRegistrationView DeleteCompanyInfo(ICompanyRegistrationView companyInfo)
        {
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //Generate a Return View Model
            var returnViewModel = adminViewModelFactory.CreateUpdatedCompanyView(companyInfo, processingMessage);

            //If Not
            //Store Grade Information
            if (!isDataOkay)
            {
                return returnViewModel;
            }

            var updateData = this.companyRepository.DeleteCompanyInfo(companyInfo);


            return returnViewModel;
        }

        /// <summary>
        /// Updates the company registration information.
        /// </summary>
        /// <param name="companyRegistrationInfo">The company registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyRegistrationInfo</exception>
        public string UpdateCompanyRegistrationInfo(ICompanyRegistrationView companyRegistrationInfo, HttpPostedFileBase companyLogo)
        {
            if (companyRegistrationInfo == null)
            {
                throw new ArgumentNullException(nameof(companyRegistrationInfo));
            }

            if (companyLogo != null)
            {
                int digitalFileId = 0;

                //Save Company Logo
                var digitalFile = this.digitalFileService.SaveFile(FileType.Image, companyLogo, out digitalFileId);

                companyRegistrationInfo.LogoDigitalFileId = digitalFileId;

                session.RemoveSessionValue(SessionKey.CompanyLogo);
                
                var imgSrc = companyRegistrationInfo.CompanyName;

                byte[] theContent;

                using (Stream inputStream = companyLogo.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    theContent = memoryStream.ToArray();
                }

                var base64 = Convert.ToBase64String(theContent);
                imgSrc = string.Format("data:{0};base64,{1}", companyLogo.ContentType, base64);
                
            }
            
            var processingMessage = this.companyRepository.UpdateCompanyRegistrationInfo(companyRegistrationInfo);

            return processingMessage;
        }

        #endregion

        #region//----------------------------------------User Section start--------------------------------------//

        /// <summary>
        /// Gets the user ListView model.
        /// </summary>
        /// <param name="selectedEmail">The selected email.</param>
        /// <param name="selectedName">Name of the selected.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IUserListView GetUserListViewModel(string selectedEmail, string selectedName, string message)
        {

            var loggedInDetails = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)session.GetSessionValue(SessionKey.CompanyId);
            
            var userCollection = this.usersRepository.GetAllUserListByCompanyId(companyId);

            //Generate User Model View
            var viewModel =
                this.adminViewModelFactory.CreateUserListView(userCollection, selectedEmail, selectedName, message);

            return viewModel;
        }


        #endregion
        
        #region//----------------------------------------Department Section------------------------------------//  

        /// <summary>
        /// Gets the department registration view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public IDepartmentView GetDepartmentRegistrationView()
        {
            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            //Department Collection
            var departmentsList = this.departmentRepository.GetAllMyDepartments(companyId);

            //Generating View Models
            var viewModel = this.adminViewModelFactory.CreateDepartmentView(departmentsList, companyId);

            return viewModel;
        }

        /// <summary>
        /// Gets the department registration view.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IDepartmentView GetDepartmentRegistrationView(IDepartmentView deptInfo, string message)
        {

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var departmentsList = this.departmentRepository.GetAllMyDepartments(companyId);

            var viewModel =
                this.adminViewModelFactory.CreateDepartmentView(departmentsList, deptInfo, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the department information.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deptInfo</exception>
        public string ProcessDepartmentInfo(IDepartmentView deptInfo)
        {
            if (deptInfo == null)
            {
                throw new ArgumentNullException(nameof(deptInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //Check that This Company Has not registered this Department Before
            var departmentData =
                this.departmentRepository.GetCompanyDepartmentByName(deptInfo.DepartmentName, deptInfo.CompanyId);

            if (departmentData != null)
            {
                processingMessage = Messages.DepartmentAlreadyExisted;
                isDataOkay = false;
            }

            // check if parentDepartment is setup for company before
            if (deptInfo.ParentDepartmentId.HasValue && (deptInfo.ParentDepartmentId.Value > 0) && isDataOkay)
            {
                var parentDepartmentData =
                    this.departmentRepository.GetCompanyDepartmentById(deptInfo.ParentDepartmentId.Value,
                        deptInfo.CompanyId);

                if (parentDepartmentData == null)
                {
                    processingMessage = Messages.ParentDepartmentNotSetupText;
                    isDataOkay = false;
                }
            }

            if (!isDataOkay)
            {
                return processingMessage;
            }


            //Everything is Okay, Proceed to store
            var savedDataMessage = this.departmentRepository.SaveDepartmentInfo(deptInfo);

            return savedDataMessage;
        }

        public string ProcessUploadExcelDepartment(HttpPostedFileBase departmentExcelFile)
        {

            if (departmentExcelFile == null) throw new ArgumentNullException(nameof(departmentExcelFile));

            var result = string.Empty;

            var departmentCollection = this.generateDocumentService.ExcelUpload(departmentExcelFile);

            foreach (DataRow r in departmentCollection.Rows)
            {
                var departmentView = new DepartmentView();

                departmentView.DepartmentName = r.ItemArray[0].ToString();
                departmentView.Description = (string)r.ItemArray[1];
                departmentView.CompanyId = (int)session.GetSessionValue(SessionKey.CompanyId);

                var isDataOkay = (this.departmentRepository.GetCompanyDepartmentById(departmentView.DepartmentId, departmentView.CompanyId) == null) ? true : false;


                if (!isDataOkay)
                {
                    result = Messages.DepartmentAlreadyExisted;
                    return result;
                }

                result = this.departmentRepository.SaveDepartmentInfo(departmentView);


                if (!string.IsNullOrEmpty(result)) return result;

            }

            return result;
        }


        /// <summary>
        /// Gets the departments list.
        /// </summary>
        /// <param name="parentCompanyId">The parent company identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedDepartmentId">The selected department identifier.</param>
        /// <param name="selectedDepartment">The selected department.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IDepartmentListView GetDepartmentsList(int selectedCompanyId, int selectedDepartmentId,
            string selectedDepartment, string message)
        {

            var companyId = (int)session.GetSessionValue(SessionKey.CompanyId);

            //Get Departments List
            var departmentsList = this.departmentRepository.GetAllMyDepartments(companyId).ToList();

            var companyList = this.companyRepository.GetMyCompanies(companyId).ToList();
            
            //Generate View Model
            var viewModel = this.adminViewModelFactory.CreateDepartmentListView(selectedCompanyId, selectedDepartmentId,
                selectedDepartment, companyList, departmentsList, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the department edit view.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">departmentInfo</exception>
        public IDepartmentView GetDepartmentEditView(int departmentId, string message)
        {
            var departmentInfo = departmentRepository.GetDepartmentById(departmentId);

            if (departmentInfo == null)
            {
                throw new ApplicationException(nameof(departmentInfo));
            }

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var departmentsList = this.departmentRepository.GetAllMyDepartments(companyId).ToList();

            var companyList = this.companyRepository.GetMyCompanies(companyId).ToList();

            var viewModel =
                this.adminViewModelFactory.CreateEditDepartmentView(departmentInfo, departmentsList,
                    message);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit department information.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deptInfo</exception>
        public string ProcessEditDepartmentInfo(IDepartmentView deptInfo)
        {
            if (deptInfo == null)
            {
                throw new ArgumentNullException(nameof(deptInfo));
            }

            string processingMessage = string.Empty;
            bool isDataOkay = true;

            //Check that This Company Has not registered this Department Before
            var departmentData =
                this.departmentRepository.GetCompanyDepartmentByName(deptInfo.DepartmentName, deptInfo.CompanyId);

            if ((departmentData != null) && (departmentData.DepartmentId != deptInfo.DepartmentId))
            {
                processingMessage = Messages.DepartmentAlreadyExisted;
                isDataOkay = false;
            }

            // check if parentDepartment is setup for company before
            if (deptInfo.ParentDepartmentId.HasValue && (deptInfo.ParentDepartmentId.Value > 0) && isDataOkay)
            {
                var parentDepartmentData =
                    this.departmentRepository.GetCompanyDepartmentById(deptInfo.ParentDepartmentId.Value,
                        deptInfo.CompanyId);

                if (parentDepartmentData == null)
                {
                    processingMessage = Messages.ParentDepartmentNotSetupText;
                    isDataOkay = false;
                }
            }

            if (!isDataOkay)
            {
                return processingMessage;
            }

            //Store Department Information
            processingMessage = this.departmentRepository.UpdateDepartmentInfo(deptInfo);

            return processingMessage;
        }

        /// <summary>
        /// Processes the delete department information.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">departmentId</exception>
        public string ProcessDeleteDepartmentInfo(int departmentId)
        {
            if (departmentId < 1)
            {
                throw new ArgumentOutOfRangeException("departmentId");
            }

            var deleteMessage = this.departmentRepository.DeleteDepartmentInfo(departmentId);

            return deleteMessage;
        }

        /// <summary>
        /// Gets the department collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public IList<IDepartment> GetDepartmentCollection(int companyId)
        {
            //Get The List Of jobTitles for the Company
            var departmentsCollection = this.lookupRepository.GetDepartmentCollectionByCompanyId(companyId).ToList();
            return departmentsCollection;
        }

        #endregion

        #region//---------------------------------------------Job Title Section-------------------------------------//
        
        /// <summary>
        /// Gets the list of job title.
        /// </summary>
        /// <param name="selectedJobTitleId">The selected job title identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedjobTitle">The selectedjob title.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IJobTitleListView GetListOfJobTitle(int selectedCompanyId, int companyId, string selectedjobTitle,
            string message) 
        {

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo.Username);

            var companIdSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);
            
            var jobTitlesCollection = lookupRepository.GetJobTitleCollectionByCompanyId(companIdSession);
            
            if (jobTitlesCollection == null)
            {
                throw new ArgumentNullException(nameof(jobTitlesCollection));
            }

            var companyInfo = this.companyRepository.GetCompanyById(companIdSession);
            
            var viewModel = this.adminViewModelFactory.GetJobTitlesListView(selectedCompanyId,selectedjobTitle
                ,jobTitlesCollection, companyInfo, companyCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the job title view.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns> 
        public IJobTitleView GetJobTitleView()
        {

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var viewModel = this.adminViewModelFactory.CreateJobTitleView(companyId);

            return viewModel;
        }

        /// <summary>
        /// Gets the job title update view.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// jobTitleInfo
        /// or
        /// loggedInUser
        /// </exception>
        public IJobTitleView GetJobTitleUpdateView(IJobTitleView jobTitleInfo, string processingMessage)
        {

            if(jobTitleInfo == null) throw new ArgumentNullException(nameof(jobTitleInfo));

            var loggedInUser = (int)this.session.GetSessionValue(SessionKey.UserId);

            if (loggedInUser <= 0) throw new ArgumentNullException(nameof(loggedInUser));

            var userInfo = this.usersRepository.GetUserById(loggedInUser);

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var viewModel = this.adminViewModelFactory.CreateJobTitleView(jobTitleInfo, processingMessage);

            return viewModel;
        }
        
        /// <summary>
        /// Processes the department information.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleInfo</exception>
        public string ProcessJobTitleInfo(IJobTitleView jobTitleInfo)
        {
            if (jobTitleInfo == null)
            {
                throw new ArgumentNullException(nameof(jobTitleInfo));
            }

            var processMessage = string.Empty;
            var isDataOkay = true;

            var jobTitleData =
                this.jobTitleRepository.GetJobTitleByCompany(jobTitleInfo.CompanyId, jobTitleInfo.JobTitleName);
             
            if (jobTitleData != null)
            {
                processMessage = Messages.JobTitleAlreadyExist;
                isDataOkay = false;
            }


            if (!isDataOkay)
            {
                return processMessage;
            }

            var saveJobTitle = this.jobTitleRepository.SaveJobTitleInfo(jobTitleInfo);

            return saveJobTitle;
        }

        public string ProcessUploadExcelJobTitle(HttpPostedFileBase jobTitleExcelFile)
        {

            if (jobTitleExcelFile == null) throw new ArgumentNullException(nameof(jobTitleExcelFile));

            var result = string.Empty;

            var jobTitleCollection = this.generateDocumentService.ExcelUpload(jobTitleExcelFile);

            foreach(DataRow r in jobTitleCollection.Rows)
            {
                var jobTitleView = new JobTitleView();

                jobTitleView.JobTitleName = r.ItemArray[0].ToString();
                jobTitleView.JobDefinition = (string)r.ItemArray[1];
                jobTitleView.JobFunction = (string)r.ItemArray[2];
                jobTitleView.CompanyId = (int)session.GetSessionValue(SessionKey.CompanyId);

                var isDataOkay = (this.jobTitleRepository.GetJobTitleByCompany(jobTitleView.CompanyId, jobTitleView.JobTitleName) == null) ? true : false;
                

                if (!isDataOkay)
                {
                    result = Messages.JobTitleAlreadyExist;
                    return result;
                }

                result = this.jobTitleRepository.SaveJobTitleInfo(jobTitleView);


                if (!string.IsNullOrEmpty(result)) return result;

            }

            return result;
        }

        /// <summary>
        /// Gets the job title edit view.
        /// </summary>
        /// <param name="jobTitleId">The job title identifier.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleData</exception>
        public IJobTitleView GetJobTitleEditView(int jobTitleId, string processingMesage)
        {
            //Get The Job By ID here
            var jobTitleData = jobTitleRepository.GetJobTitleById(jobTitleId);

            if (jobTitleData == null)
            {
                throw new ArgumentNullException(nameof(jobTitleData));
            }

            //Get The Updated View Here
            var viewModel = this.adminViewModelFactory.CreateEditJobTitleView(jobTitleData, processingMesage);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit job title information.
        /// </summary>
        /// <param name="jobTitleInfo">The job title information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jobTitleInfo</exception>
        public string ProcessEditJobTitleInformation(IJobTitleView jobTitleInfo)
        {
            if (jobTitleInfo == null)
            {
                throw new ArgumentNullException(nameof(jobTitleInfo));
            }

            //Store Vacancy Information
            var storeVacancy = jobTitleRepository.UpdateJobTitleInfo(jobTitleInfo);

            return storeVacancy;
        }

        /// <summary>
        /// Deletes the job title.
        /// </summary>
        /// <param name="jobTitleId"></param>
        /// <returns></returns>
        public string DeleteJobTitle(int jobTitleId)
        {
            var viewModel = this.jobTitleRepository.DeleteJobTitle(jobTitleId);

            return viewModel;
        }

        /// <summary>
        /// Gets the job title collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public IList<IJobTitle> GetJobTitleCollection(int companyId)
        {
            //Get The List Of jobTitles for the Company
            var jobTitlesCollection = this.lookupRepository.GetJobTitleCollectionByCompanyId(companyId).ToList();
            return jobTitlesCollection; 
        }

        #endregion
        
        #region //-------------------------------------Industry Section----------------------------------------//        

        /// <summary>
        /// Gets the industry ListView model.
        /// </summary>
        /// <param name="selectedIndustry"></param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IIndustryListView GetIndustryListViewModel(string selectedIndustry, string message)
        {
            // Get parts needed to build industry list view
            // ---- get Industry collection     
            var IndustryCollection = this.industryRepository.GetAllIndustry();

            //Generate Industry From Factory
            var viewModel =
                this.adminViewModelFactory.CreateIndustryListView(IndustryCollection, selectedIndustry, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the industry create view.
        /// </summary>
        /// <returns></returns>
        public IIndustryView GetIndustryCreateView()
        {
            var viewModel = this.adminViewModelFactory.CreateIndustryView();

            return viewModel;
        }

        /// <summary>
        /// Gets the industry create view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IIndustryView GetIndustryCreateView(IIndustryView industryInfo, string processingMessage)
        {
            var returnViewModel = this.adminViewModelFactory.CreateUpdatedIndustryView(industryInfo, processingMessage);

            return returnViewModel;
        }

        /// <summary>
        /// Processes the industry create view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        public string ProcessIndustryCreateView(IIndustryView industryInfo)
        {
            if (industryInfo == null)
            {
                throw new ArgumentNullException(nameof(industryInfo));
            }

            var message = String.Empty;

            // Check if the Insdustry is already Created Befre to Prevent Duplicate
            var recordExisted = this.industryRepository.GetIndustryByName(industryInfo.IndustryName);

            if (recordExisted != null)
            {
                message = Messages.IndustryAlreadyExisted;
            }
            else
            {
                message = this.industryRepository.SaveIndustryInfo(industryInfo);
            }


            return message;
        }

        /// <summary>
        /// Gets the industry edit view.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        public IIndustryView GetIndustryEditView(int industryId)
        {
            var industryInfo = industryRepository.GetIndustryById(industryId);

            var viewModel = this.adminViewModelFactory.EditIndustryView(industryInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the industry edit view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">IndustryInfo</exception>
        public string ProcessIndustryEditView(IIndustryView industryInfo)
        {
            if (industryInfo == null)
            {
                throw new ArgumentNullException(nameof(industryInfo));
            }

            var message = String.Empty;

            // Check if the Insdustry is already Created Before to Prevent Duplicate
            var recordExisted = this.industryRepository.GetIndustryByName(industryInfo.IndustryName);

            if (recordExisted != null)
            {
                message = Messages.IndustryAlreadyExisted;
            }
            else
            {
                message = this.industryRepository.UpdateIndustryInfo(industryInfo);
            }


            return message;
        }

        /// <summary>
        /// Processes the delete industry information.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">IndustryId</exception>
        public string ProcessDeleteIndustryInfo(int industryId)
        {
            if (industryId < 1)
            {
                throw new ArgumentOutOfRangeException("industryId");
            }

            var deleteMessage = this.industryRepository.DeleteIndustryInfo(industryId);

            return deleteMessage;
        }

        #endregion
    }
}