using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Services;
using AA.Infrastructure.Extensions;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AA.HRMS.Domain.Services
{
    public class CompanySetupServices : ICompanySetupServices
    {
        private readonly IBenefitRepository benefitRepository;
        private readonly IGradeRepository gradeRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly ICompanySetupViewModelFactory companySetupViewModelFactory;
        private readonly ICompanyRepository companyRepository;
        private readonly ILeaveModelViewFactory leaveModelViewFactory;
        private readonly ILeaveRepository leaveModelRepository;
        private readonly IRewardRepository rewardRepository;
        private readonly IDeductionRepository deductionRepository;
        private readonly ILevelRepository levelRepository;
        private readonly ILoanRepository loanRepository;
        private readonly IUsersRepository usersRepository;
        private readonly ISessionStateService sessionServiceProvider;
        private readonly ILevelGradeRepository levelGradeRepository;
        private readonly ITaxRepository taxRepository;
        private readonly IEmployeeLoanRepository employeeLoanRepository;
        private readonly IOverTimesheetRepository overTimesheetRepository;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly IEmployeeDeductionRepository employeeDeductionRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeRewardRepository employeeRewardRepository;
        private readonly IGenerateDocumentService generateDocumentService;
        private readonly IPerformanceManagementRepository performanceManagementRepository;
   
        
        public CompanySetupServices(IBenefitRepository benefitRepository, IGradeRepository gradeRepository,
            ILookupRepository lookupRepository, ILoanRepository loanRepository,
            ILevelGradeRepository levelGradeRepository, IOverTimesheetRepository overTimesheetRepository,
            ICompanySetupViewModelFactory companySetupViewModelFactory, ICompanyRepository companyRepository,
            ILeaveRepository leaveModelRepository, IUsersRepository usersRepository, ITaxRepository taxRepository,
            ILeaveModelViewFactory leaveModelViewFactory, IRewardRepository rewardRepository,
            ILevelRepository levelRepository, IDeductionRepository deductionRepository, IPerformanceManagementRepository performanceManagementRepository,
            ISessionStateService sessionServiceProvider,IEmployeeLoanRepository employeeLoanRepository, IEmployeeDeductionRepository employeeDeductionRepository,
            IEmployeeOnBoardRepository employeeOnBoardRepository,IEmployeeRepository employeeRepository,IEmployeeRewardRepository employeeRewardRepository,
            IGenerateDocumentService generateDocumentService)
        {
            this.benefitRepository = benefitRepository;
            this.gradeRepository = gradeRepository;
            this.lookupRepository = lookupRepository;
            this.companySetupViewModelFactory = companySetupViewModelFactory;
            this.companyRepository = companyRepository;
            this.leaveModelRepository = leaveModelRepository;
            this.leaveModelViewFactory = leaveModelViewFactory;
            this.rewardRepository = rewardRepository;
            this.levelRepository = levelRepository;
            this.loanRepository = loanRepository;
            this.deductionRepository = deductionRepository;
            this.usersRepository = usersRepository;
            this.sessionServiceProvider = sessionServiceProvider;
            this.levelGradeRepository = levelGradeRepository;
            this.taxRepository = taxRepository;
            this.employeeLoanRepository = employeeLoanRepository;
            this.overTimesheetRepository = overTimesheetRepository;
            this.employeeDeductionRepository = employeeDeductionRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.employeeRepository = employeeRepository;
            this.employeeRewardRepository = employeeRewardRepository;
            this.generateDocumentService = generateDocumentService;
            this.performanceManagementRepository = performanceManagementRepository;

        }

        #region //-----------------------------------Grade Section--------------------------------//

        /// <summary>
        /// Gets the grade registration view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        /// IGradeView.
        /// </returns>
        /// 
        public IList<IGrade> GetGradesCollection(int companyId)
        {
            var levelGrade = this.levelGradeRepository.GetLevelGradeByCompanyId(companyId);

            var gradeCollection = new List<IGrade>();

            foreach (var item in levelGrade)
            {
                var grade = this.gradeRepository.GetGradeById(item.GradeId);

                if (!gradeCollection.Contains(grade))
                {
                    gradeCollection.Add(grade);
                }  
            }

            //var gradeCollection = this.gradeRepository.GetGradeByCompanyId(companyId);
            
            return gradeCollection;
        }

        /// <summary>
        /// Gets the grade registration view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IGradeView GetGradeView()
        {
            var userInfo = this.usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);
            
            var viewModel = companySetupViewModelFactory.CreateGradeView(companyId);

            return viewModel;
        }

        /// <summary>
        /// Gets the grade registration view.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IGradeView GetGradeView(IGradeView gradeInfo, string processingMessage)
        {
            if (gradeInfo == null)
            {
                throw new ArgumentNullException(nameof(gradeInfo));
            }

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);
            
            var viewModel = companySetupViewModelFactory.CreateGradeView(gradeInfo, processingMessage);

            return viewModel;
        }

        public string ProcessUploadExcelGrade(HttpPostedFileBase gradeExcelFile)
        {

            if (gradeExcelFile == null) throw new ArgumentNullException(nameof(gradeExcelFile));

            var result = string.Empty;

            var gradeCollection = this.generateDocumentService.ExcelUpload(gradeExcelFile);

            foreach (DataRow r in gradeCollection.Rows)
            {
                var gradeView = new GradeView();

                gradeView.GradeName = r.ItemArray[0].ToString();
                gradeView.GradeDescription = (string)r.ItemArray[1];
                gradeView.AnnualLeaveDuration = Convert.ToInt32(r.ItemArray[2]);
                gradeView.CompanyId = (int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

                var isDataOkay = (gradeRepository.GetGradeByName(gradeView.GradeName, gradeView.CompanyId) == null) ? true : false;
                var grade = gradeRepository.GetGradeByName(gradeView.GradeName, gradeView.CompanyId);

                if (!isDataOkay)
                {
                    result = Messages.GradeAlreadyExisted;
                    return result;
                }

                result = this.gradeRepository.SaveGradeInfo(gradeView);


                if (!string.IsNullOrEmpty(result)) return result;

            }

            return result;
        }

        /// <summary>
        /// Processes the grade information.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        public string ProcessGradeInfo(IGradeView gradeInfo)
        {
            if (gradeInfo == null)
            {
                throw new ArgumentNullException(nameof(gradeInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //Check that This Company Has not registered this Grade Before
            var returnValue = gradeRepository.GetGradeByName(gradeInfo.GradeName, gradeInfo.CompanyId);

            if (returnValue != null)
            {
                isDataOkay = false;
                processingMessage = Messages.GradeAlreadyExisted;
            }

            //If Not
            //Store Grade Information
            if (!isDataOkay)
            {
                return processingMessage;
            }
            
            processingMessage = this.gradeRepository.SaveGradeInfo(gradeInfo);


            return processingMessage;
        }

        /// <summary>
        /// Creates the grade list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedGrade"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">companyInfo</exception>
        public IGradeListView CreateGradeList(int? selectedCompanyId, string selectedGrade, string processingMessage)
        {
            

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            var companyIdSession = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var gradesCollection = lookupRepository.GetGradesCollectionByCompanyId(companyIdSession);
            
            var gradeView =
                this.companySetupViewModelFactory.CreateGradeListView(gradesCollection, selectedCompanyId, companyCollection, selectedGrade,
                    processingMessage);

            return gradeView;
        }

        /// <summary>
        /// Gets the grade update view.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        public IGradeView GetGradeUpdateView(int gradeId)
        {
            if (gradeId <= 0)
            {
                throw new ArgumentNullException(nameof(gradeId));
            }

            var gradeInfo = this.gradeRepository.GetGradeById(gradeId);

            if (gradeInfo == null)
            {
                throw new ArgumentNullException(nameof(gradeInfo));
            }

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var benefitCollection = this.lookupRepository.GetBenefitByCompanyId(companyId);
            

            var returnView = this.companySetupViewModelFactory.CreateGradeUpdateView(gradeInfo, benefitCollection);

            return returnView;
        }

        /// <summary>
        /// Updates the grade information.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        public string UpdateGradeInfo(IGradeView gradeInfo)
        {
            if (gradeInfo == null)
            {
                throw new ArgumentNullException(nameof(gradeInfo));
            }

            var processingMessage = string.Empty;

            var isDataOkay = true;

            //If Not
            //Store Grade Information
            if (!isDataOkay)
            {
                return processingMessage;
            }

            processingMessage = this.gradeRepository.UpdateGradeInfo(gradeInfo);


            return processingMessage;
        }

        /// <summary>
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">gradeId</exception>
        public string DeleteGradeInfo(int gradeId)
        {
                if (gradeId == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(gradeId));
                }

            var processingMessage = string.Empty;


            processingMessage = this.gradeRepository.DeleteGradeInfo(gradeId);


            return processingMessage;
        }

        #endregion

        #region //---------------------------------------Benefit Section----------------------------------------------// 

        /// <summary>
        /// Creates the benefit list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedBenefit">The selected benefit.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public IBenefitListView CreateBenefitList(string selectedBenefit, string selectedCompany,
            string processingMessage)
        {
            var loggedUserInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));
            
            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUserInfo.Username);

            var companyIdSession = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var benefitCollection = lookupRepository.GetBenefitByCompanyId(companyIdSession);
            
            var benefitList =
                this.companySetupViewModelFactory.CreateBenefitListView(benefitCollection, selectedBenefit,
                    processingMessage);

            return benefitList;
        }

        /// <summary>
        /// Gets the benefit create view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">companyId</exception>
        public IBenefitModelView GetBenefitCreateView()
        {

            var loggedInUserInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var periodCollection = this.lookupRepository.GetAppraisalPeriod();

            var viewModel = companySetupViewModelFactory.CreateBenefitView(companyId, periodCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the benefit create view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public IBenefitModelView GetBenefitCreateView(IBenefitModelView benefitInfo, string processingMessage)
        {
            if (benefitInfo == null) throw new ArgumentNullException(nameof(benefitInfo));

            var userName = (string)this.sessionServiceProvider.GetSessionValue(SessionKey.UserName);

            var periodCollection = this.lookupRepository.GetAppraisalPeriod();

            var viewModel = companySetupViewModelFactory.CreateBenefitView(benefitInfo, periodCollection, processingMessage);

            return viewModel;
        }
        
        /// <summary>
        /// Creates the edit view.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitId</exception>
        public IBenefitModelView GetBenefitEditView(int benefitId)
        {
            if (benefitId <= 0)
            {
                throw new ArgumentNullException(nameof(benefitId));
            }

            var model = this.benefitRepository.GetBenefitById(benefitId);

            var periodCollection = this.lookupRepository.GetAppraisalPeriod();

            
            var viewModel = this.companySetupViewModelFactory.CreateEditView(model, periodCollection);

            return viewModel;
        }
        
        /// <summary>
        /// Processes the benefit information.
        /// </summary>
        /// <param name="benefitInfo">The benefit information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitInfo</exception>
        public string ProcessBenefitInfo(IBenefitModelView benefitInfo)
        {
            if (benefitInfo == null)
            {
                throw new ArgumentNullException(nameof(benefitInfo));
            }

            var processingMessage = string.Empty;

            var isDataOkay = true;

            //Check that This Company Has not registered this Grade Before
            var returnValue = this.benefitRepository.GetBenefitByName(benefitInfo.BenefitName, benefitInfo.CompanyId);

            if (returnValue != null)
            {
                isDataOkay = false;
                processingMessage = Messages.BenefitAlreadyExisted;
            }

            //Store Grade Information
            if (!isDataOkay)
            {
                return processingMessage;
            }

            var viewModel = this.benefitRepository.SaveBenefit(benefitInfo);

            return viewModel;
        }

        public string ProcessUploadExcelBenefit(HttpPostedFileBase benefitExcelFile)
        {

            if (benefitExcelFile == null) throw new ArgumentNullException(nameof(benefitExcelFile));

            var result = string.Empty;

            var benefitCollection = this.generateDocumentService.ExcelUpload(benefitExcelFile);

            
            var periodCollection = this.lookupRepository.GetAppraisalPeriod();


            foreach (DataRow r in benefitCollection.Rows)
            {
                var Monetized = true;
                var Taxable = true;
                var periodId = periodCollection.SingleOrDefault(p => p.Appraisalperiod1.Equals((string)r.ItemArray[2])).AppraisalPeriodId;

                Monetized = (r.ItemArray[3].ToString() == "Yes")?
                    true : false;

                Taxable = (r.ItemArray[4].ToString() == "Yes") ? true : false;
                   
                    
                var benefitView = new BenefitModelView();

                benefitView.BenefitName = r.ItemArray[0].ToString();
                benefitView.BenefitDescription = (string)r.ItemArray[1];
                benefitView.Period = periodId;
                benefitView.IsMonetized = Monetized;
                benefitView.IsTaxable = Taxable;
                benefitView.CompanyId = (int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

                var isDataOkay = (this.benefitRepository.GetBenefitByName(benefitView.BenefitName, benefitView.CompanyId) == null) ? true : false;


                if (!isDataOkay)
                {
                    result = Messages.JobTitleAlreadyExist;
                    return result;
                }

                result = this.benefitRepository.SaveBenefit(benefitView);


                if (!string.IsNullOrEmpty(result)) return result;

            }

            return result;
        }

        /// <summary>
        /// Processes the edit benefit information.
        /// </summary>
        /// <param name="benefitInfo">The benefit information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitInfo</exception>
        public string ProcessEditBenefitInfo(IBenefitModelView benefitInfo)
        {
            if (benefitInfo == null)
            {
                throw new ArgumentNullException(nameof(benefitInfo));
            }

            var viewModel = this.benefitRepository.SaveEditBenefit(benefitInfo);


            return viewModel;
        }

        /// <summary>
        /// Processes the delete benefit information.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitId</exception>
        public string ProcessDeleteBenefitInfo(int benefitId)
        {
            if (benefitId < 0)
            {
                throw new ArgumentNullException(nameof(benefitId));
            }

            var viewModel = this.benefitRepository.SaveDeletedBenefit(benefitId);

            return viewModel;
        }

        #endregion

        #region //------------------------------------------Leave Section-------------------------------------------------//  

        /// <summary>
        /// Gets the leave type list for logged in user.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ILeaveTypeListView GetLeaveTypeListForLoggedInUser(string processingMessage)
        {
            var userInfo = usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyIdSession = this.companyRepository.GetCompanyById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId));

            var model = this.leaveModelRepository.GetLeaveTypeListForCompanyId(companyIdSession.CompanyId);

            var viewModel = this.companySetupViewModelFactory.GetLeaveTypeListView(model, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the leave type model view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveTypeModelView GetLeaveTypeCreationView(string message)
        {
            var userId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId);

            var userInfo = usersRepository.GetUserById(userId);

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            //Get View Model From Factory
            var viewModel = this.companySetupViewModelFactory.CreateLeaveTypeView(companyId, message);
            return viewModel;
        }

        /// <summary>
        /// Gets the leave type update view.
        /// </summary>
        /// <param name="leaveTypeModelView">The leave type model view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeModelView</exception>
        public ILeaveTypeModelView GetLeaveTypeUpdateView(ILeaveTypeModelView leaveTypeModelView,
            string processingMessage)
        {
            if (leaveTypeModelView == null)
            {
                throw new ArgumentNullException(nameof(leaveTypeModelView));
            }

            var userId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId);

            var userInfo = usersRepository.GetUserById(userId).Username;


            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo);

            return this.companySetupViewModelFactory.CreateUpdatedLeaveTypeModelView(leaveTypeModelView,
                companyCollection, processingMessage);
        }

        /// <summary>
        /// Processes the type of the upload excel leave.
        /// </summary>
        /// <param name="leaveTypeExcelFile">The leave type excel file.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">leaveTypeExcelFile</exception>
        public string ProcessUploadExcelLeaveType(HttpPostedFileBase leaveTypeExcelFile)
        {

            if (leaveTypeExcelFile == null) throw new ArgumentNullException(nameof(leaveTypeExcelFile));

            var result = string.Empty;

            var leaveTypeCollection = this.generateDocumentService.ExcelUpload(leaveTypeExcelFile);

            foreach (DataRow r in leaveTypeCollection.Rows)
            {
                var leaveTypeView = new LeaveTypeModelView();

                leaveTypeView.LeaveTypeName = r.ItemArray[0].ToString();
                leaveTypeView.Description = (string)r.ItemArray[1];
                leaveTypeView.Duration = Convert.ToInt32(r.ItemArray[2]);
                leaveTypeView.CompanyID = (int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

                var isDataOkay = (leaveModelRepository.GetLeaveTypeByName(leaveTypeView.LeaveTypeName, leaveTypeView.CompanyID) == null) ? true : false;
                var grade = leaveModelRepository.GetLeaveTypeByName(leaveTypeView.LeaveTypeName, leaveTypeView.CompanyID);
                if (!isDataOkay)
                {
                    result = Messages.GradeAlreadyExisted;
                    return result;
                }

                result = this.leaveModelRepository.SaveLeaveTypeModelInfo(leaveTypeView);


                if (!string.IsNullOrEmpty(result)) return result;

            }

            return result;
        }

        /// <summary>
        /// Gets the leave type edit view.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveTypeModelView GetLeaveTypeEditView(int leaveTypeId, string message)
        {
            var leaveTypeData = leaveModelRepository.GetLeaveTypeById(leaveTypeId);

            var userId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId);

            var userInfo = usersRepository.GetUserById(userId).Username;

            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo);

            var viewModel = companySetupViewModelFactory.CreateLeaveTypeEditView(companyCollection, message, leaveTypeData);

            return viewModel;
        }

        /// <summary>
        /// Deletes the type of the leave.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <returns></returns>
        public string DeleteLeaveType(int leaveTypeId)
        {
            var viewModel = leaveModelRepository.DeleteLeaveType(leaveTypeId);

            return viewModel;
        }

        /// <summary>
        /// Processes the leave type view information.
        /// </summary>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeInfo</exception>
        public string ProcessLeaveTypeViewInfo(ILeaveTypeModelView leaveTypeInfo)
        {
            if (leaveTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveTypeInfo));
            }

            string processingMessage = string.Empty;

            bool isDataOkay = true;

            isDataOkay = ((this.leaveModelRepository.GetLeaveTypeByName(leaveTypeInfo.LeaveTypeName, leaveTypeInfo.CompanyID)) == null) ? true : false;


            if (!isDataOkay)
            {
                processingMessage = Messages.LeaveTypeNameAlreadyExist;

                return processingMessage;
            }

            //Store Compnay Information
            processingMessage = this.leaveModelRepository.SaveLeaveTypeModelInfo(leaveTypeInfo);

            return processingMessage;
        }

        /// <summary>
        /// Processes the type of the edit leave.
        /// </summary>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeInfo</exception>
        public string ProcessEditLeaveType(ILeaveTypeModelView leaveTypeInfo)
        {
            if (leaveTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveTypeInfo));
            }

            var processingMessage = string.Empty;

            bool isDataOkay = true;

            isDataOkay = ((this.leaveModelRepository.GetLeaveTypeByName(leaveTypeInfo.LeaveTypeName, leaveTypeInfo.CompanyID)) == null) ? true : false;


            if (!isDataOkay)
            {
                processingMessage = Messages.LeaveTypeNameAlreadyExist;

                return processingMessage;
            }

            processingMessage = leaveModelRepository.UpdateLeaveTypeInfo(leaveTypeInfo);

            return processingMessage;
        }

        #endregion

        #region //-------------------------------------------Reward Section-----------------------------------------------//   

        /// <summary>
        /// Gets the reward list.
        /// </summary>
        /// <param name="selectedReward">The selected reward.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IRewardListView GetRewardList(string selectedReward, string processingMessage)
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var rewardCollection = this.lookupRepository.GetRewardByCompanyId(companyId);
            
            var viewModel =
                this.companySetupViewModelFactory.CreateRewardListView(selectedReward, rewardCollection,
                    processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the create reward view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IRewardView GetCreateRewardView()
        {
            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId));

            var companyId = (int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var viewModel = this.companySetupViewModelFactory.CreateRewardView(companyId);

            return viewModel;
        }

        /// <summary>
        /// Gets the reward upadte view.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">reward</exception>
        public IRewardView GetRewardUpadteView(IRewardView reward, string processingMessage)
        {
            if (reward == null)
            {
                throw new ArgumentNullException(nameof(reward));
            }

            var userName = (string)this.sessionServiceProvider.GetSessionValue(SessionKey.UserName);

            var viewModel =
                this.companySetupViewModelFactory.CreateRewardUpdatedView(reward, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the reward edit view.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">reward</exception>
        public IRewardView GetRewardEditView(int rewardId)
        {
            if (rewardId <= 0)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            var reward = this.rewardRepository.GetRewardById(rewardId);

            var viewModel = this.companySetupViewModelFactory.CreateEditRewardView(reward);

            return viewModel;
        }

        /// <summary>
        /// Processes the create reward information.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">reward</exception>
        public string ProcessCreateRewardInfo(IRewardView reward)
        {
            if (reward == null)
            {
                throw new ArgumentNullException(nameof(reward));
            }

            bool IsDataOkay = true;

            var processingMessage = string.Empty;

            //Check for the existence of reward with the same name
            var model = this.rewardRepository.GetRewardByName(reward.RewardName);

            if (model != null)
            {
                IsDataOkay = false;
                processingMessage = Messages.RewardAlreadyExist;
            }

            if (!IsDataOkay)
            {
                return processingMessage;
            }

            processingMessage = this.rewardRepository.SaveRewardInfo(reward);

            return processingMessage;
        }

        /// <summary>
        /// Processes the edit reward information.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">reward</exception>
        public string ProcessEditRewardInfo(IRewardView reward)
        {
            if (reward == null)
            {
                throw new ArgumentNullException(nameof(reward));
            }

            string result = string.Empty;

            result = this.rewardRepository.SaveEditRewardInfo(reward);


            return result;
        }

        /// <summary>
        /// Processes the delete reward information.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardId</exception>
        public string ProcessDeleteRewardInfo(int rewardId)
        {
            if (rewardId <= 0)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            var result = this.rewardRepository.SaveDeleteRewardInfo(rewardId);

            return result;
        }

        #endregion

        #region //------------------------------------------------Level Section-------------------------------------------//

        /// <summary>
        /// Gets the level list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ILevelListView GetLevelList(string selectedLevel, int? selectedCompanyId, string processingMessage)
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyCollection = this.companyRepository.GetCompaniesForHR(userInfo.Username);

            var companyIdSession = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var levelCollection = lookupRepository.GetLevelByCompanyId(companyIdSession);
            

            var viewModel =
                this.companySetupViewModelFactory.CreateLevelListView(selectedCompanyId, levelCollection, companyCollection, selectedLevel,
                    processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the level registration view.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public ILevelView GetLevelRegistrationView()
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var viewModel =
                this.companySetupViewModelFactory.CreateLevelView(companyId);

            return viewModel;
        }

        /// <summary>
        /// Gets the level update view.
        /// </summary>
        /// <param name="levelView">The level view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelView</exception>
        public ILevelView GetLevelUpdateView(ILevelView levelView, string processingMessage)
        {
            if(levelView == null)
            {
                throw new ArgumentNullException(nameof(levelView));
            }
            
            return this.companySetupViewModelFactory.CreateUpdatedLevelView(levelView, processingMessage);
        }

        /// <summary>
        /// Processes the level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelInfo</exception>
        public string ProcessLevelInfo(ILevelView levelInfo)
        {
            if (levelInfo == null)
            {
                throw new ArgumentNullException(nameof(levelInfo));
            }


            var processingMessage = string.Empty;
            var isDataOkay = true;


            var taxCollection = this.taxRepository.GetAllTax();

            isDataOkay = (this.levelRepository.GetLevelByNameCompanyId(levelInfo.CompanyId, levelInfo.LevelName) == null)?true:false;

            //If Not
            //Store Grade Information
            if (!isDataOkay)
            {
                processingMessage = Messages.LevelRecordAlreadyExit;

                return processingMessage;
            }
            

            var viewModel = this.levelRepository.SaveLevelInfo(levelInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the upload excel.
        /// </summary>
        /// <param name="levelExcel">The level excel.</param>
        /// <returns></returns>
        public string ProcessUploadExcelLevel(HttpPostedFileBase levelExcel)
        {
            string result = string.Empty;

            var levelExcelContent = this.generateDocumentService.ExcelUpload(levelExcel);

            foreach (DataRow r in levelExcelContent.Rows)
            {

                ILevelView level = new LevelView();

                level.LevelName = (string)r.ItemArray[0];
                level.LevelDescription = (string)r.ItemArray[1];
                level.CompanyId = (int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

                var isDataOkay = (this.levelRepository.GetLevelByNameCompanyId(level.CompanyId, level.LevelName) == null) ? true : false;

                //If Not
                //Store Grade Information
                if (!isDataOkay)
                {
                    result = Messages.LevelRecordAlreadyExit;

                    return result;
                }


                result = this.levelRepository.SaveLevelInfo(level);

                if (!string.IsNullOrEmpty(result)) return result;
            }
            
            return result;
        }

        /// <summary>
        /// Gets the level edit view.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelInfo</exception>
        public ILevelView GetLevelEditView(int levelId)
        {

            if (levelId <= 0)
            {
                throw new ArgumentNullException(nameof(levelId));
            }

            var levelInfo = levelRepository.GetLevelById(levelId);

            if (levelInfo == null)
            {
                throw new ArgumentNullException(nameof(levelInfo));
            }
            
            var viewModel = this.companySetupViewModelFactory.CreateEditLevelView(levelInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelInfo</exception>
        public string ProcessEditLevelInfo(ILevelView levelInfo)
        {
            if (levelInfo == null)
            {
                throw new ArgumentNullException(nameof(levelInfo));
            }

            string processingMessage = string.Empty;

            //Store level info
            processingMessage = this.levelRepository.UpdateLevelInfo(levelInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delete level information.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelId</exception>
        public string ProcessDeleteLevelInfo(int levelId)
        {
            if (levelId < 1)
            {
                throw new ArgumentNullException(nameof(levelId));
            }


            string processingMessage = string.Empty;


            var updateData = this.levelRepository.DeleteLevelInfo(levelId);


            return updateData;
        }

        /// <summary>
        /// Gets the level collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public IList<ILevel> GetLevelCollection(int companyId)
        {

            var levelGrade = this.levelGradeRepository.GetLevelGradeByCompanyId(companyId);

            var levelCollection = new List<ILevel>();

            foreach (var item in levelGrade)
            {
                var level = this.levelRepository.GetLevelById(item.LevelId);

                if (!levelCollection.Contains(level))
                {
                    levelCollection.Add(level);
                }
            }

            //var levelCollection = this.levelRepository.GetLevelByCompanyId(companyId);

            return levelCollection;
        }

        #endregion

        #region //-----------------------------------------------Loan Section----------------------------------------//

        /// <summary>
        /// Gets the loans list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedLoanId">The selected loan identifier.</param>
        /// <returns></returns>
        public ILoanListView GetLoansList(int? selectedLoanId, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var loanCollection = this.lookupRepository.GetLoan();
            
            var viewModel =
                this.companySetupViewModelFactory.CreateLoanListView(selectedLoanId, loanCollection, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee loans list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedEmployeeLoan">The selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeLoanListView GetEmployeeLoansList(string selectedEmployeeLoan,
            string selectedCompanyName,
            string selectedEmployeeName, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));
            
            var companyInSession = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var loanCollection = loanRepository.GetEmployeeLoanByCompanyId(companyInSession);
            
            var viewModel = this.companySetupViewModelFactory.CreateEmployeeLoanListViewByEmployee(selectedEmployeeLoan,
                selectedCompanyName,
                selectedEmployeeName, loanCollection, processingMessage);

            return viewModel;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="selectedEmployeeLoan"></param>
        /// <param name="selectedCompanyName"></param>
        /// <param name="selectedEmployeeName"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public IEmployeeLoanListView GetEmployeeLoansListByEmployee(string selectedEmployeeLoan,
           string selectedCompanyName,
           string selectedEmployeeName, string processingMessage)
        {
            var userInfo = usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);
          
            var companyCollection = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);

            var loanCollection = loanRepository.GetEmployeeLoanByEmployeeId(employeeInfo.EmployeeId);

            var viewModel = this.companySetupViewModelFactory.CreateEmployeeLoanListView(selectedEmployeeLoan,
                selectedCompanyName,
                selectedEmployeeName, loanCollection, companyCollection, employeeInfo, processingMessage);

            return viewModel;
        }
        
        /// <summary>
        /// Gets the employee loans list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeLoanListView GetEmployeeLoansList(int employeeId, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var employee = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            var employeeloanCollection = this.employeeLoanRepository.GetEmployeeLoanListByEmployeeId(employeeId);
            
            var viewModel = this.companySetupViewModelFactory.CreateEmployeeLoanListView(employee, employeeloanCollection, processingMessage);

            return viewModel;
        }


        /// <summary>
        /// Gets the loan registration view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public ILoanView GetLoanRegistrationView()
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);
            
            var viewModel =
                this.companySetupViewModelFactory.CreateLoanView(companyId);

            return viewModel;
        }

        /// <summary>
        /// Gets the loan upadte view.
        /// </summary>
        /// <param name="loan">The loan.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loan</exception>
        public ILoanView GetLoanUpadteView(ILoanView loan, string processingMessage)
        {
            if (loan == null)
            {
                throw new ArgumentNullException(nameof(loan));
            }

            var userName = (string)sessionServiceProvider.GetSessionValue(SessionKey.UserName);

            var companyCollection = this.companyRepository.GetCompaniesForHR(userName);

            var viewModel =
                this.companySetupViewModelFactory.CreateUpdatedLoanView(loan, companyCollection, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Processes the loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanInfo</exception>
        public string ProcessLoanInfo(ILoanView loanInfo)
        {
            if (loanInfo == null)
            {
                throw new ArgumentNullException(nameof(loanInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;


            //If Not
            //Store Grade Information
            if (!isDataOkay)
            {
                return processingMessage;
            }


            var savedData = this.loanRepository.SaveLoanInfo(loanInfo);

            return savedData;
        }

        /// <summary>
        /// Gets the loan edit view.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanInfo</exception>
        public ILoanView GetLoanEditView(int loanId)
        {

            if (loanId <= 0)
            {
                throw new ArgumentNullException(nameof(loanId));
            }

            var loanInfo = loanRepository.GetLoanById(loanId);

            if (loanInfo == null)
            {
                throw new ArgumentNullException(nameof(loanInfo));
            }

            var viewModel = this.companySetupViewModelFactory.CreateEditLoanView(loanInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanInfo</exception>
        public string ProcessEditLoanInfo(ILoanView loanInfo)
        {
            if (loanInfo == null)
            {
                throw new ArgumentNullException(nameof(loanInfo));
            }

            string processingMessage = string.Empty;

            bool isDataOkay = true;
            

            if (!isDataOkay)
            {
                return processingMessage;
            }


            //Store level info
            processingMessage = this.loanRepository.UpdateLoanInfo(loanInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delete loan information.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanId</exception>
        public string ProcessDeleteLoanInfo(int loanId)
        {
            if (loanId < 1)
            {
                throw new ArgumentNullException(nameof(loanId));
            }


            string processingMessage = string.Empty;


            var updateData = this.loanRepository.DeleteLoanInfo(loanId);


            return updateData;
        }

        /// <summary>
        /// Gets the employee loan registration view.
        /// </summary>
        /// <returns></returns>
        public IEmployeeLoanView GetEmployeeLoanRegistrationView()
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var employeeCollection = this.lookupRepository.GetEmployeeByCompanyId(companyId);

            var loanCollection = this.lookupRepository.GetLoan();


            var viewModel =
                this.companySetupViewModelFactory.CreateEmployeeLoanView(companyId, employeeCollection,
                    loanCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee loan registration view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public IEmployeeLoanView GetEmployeeLoanRegistrationView(int employeeId)
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));
            
            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);
            
            var loanCollection = this.lookupRepository.GetLoan();
            
            var viewModel =
                this.companySetupViewModelFactory.CreateEmployeeLoanView(employeeId, companyId,
                    loanCollection);

            return viewModel;
        }
        
        /// <summary>
        /// Gets the employeet loan update view.
        /// </summary>
        /// <param name="employeeLoanInfo">The employee loan information.</param>
        /// <param name="logUserId"></param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoanInfo</exception>
        public IEmployeeLoanView GetEmployeetLoanUpdateView(IEmployeeLoanView employeeLoanInfo,
            string message)
        {
            if (employeeLoanInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeLoanInfo));
            }

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById((int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId));

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyInfo.CompanyId);

            var loanCollection = lookupRepository.GetLoan();


            var viewModel = this.companySetupViewModelFactory.CreateUpdatedEmployeeLoanView(employeeLoanInfo,
                companyInfo, employeeCollection, loanCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the employee loan information.
        /// </summary>
        /// <param name="employeeLoanInfo">The employee loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoanInfo</exception>
        public string ProcessEmployeeLoanInfo(IEmployeeLoanView employeeLoanInfo)
        {
            if (employeeLoanInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeLoanInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            var employeeloan = this.employeeLoanRepository.GetEmployeeLoanByEmployeeLoanId(employeeLoanInfo.EmployeeId, employeeLoanInfo.LoanId);

            //If Not
            //Store Grade Information
            //if (employeeloan.Tenure != 0)
            //{
            //    processingMessage = Messages.AlreadyRunningLoan;

            //    return processingMessage;
                
            //}

            var loan = this.loanRepository.GetLoanById(employeeLoanInfo.LoanId);

            employeeLoanInfo.Tenure = employeeLoanInfo.Tenure; 

            var savedData = this.employeeLoanRepository.SaveEmployeeLoanInfo(employeeLoanInfo);
            //if(savedData != null)
            //{
            //    savedData = this.employeeLoanRepository.UpdateEmployeeLoanInterestRate(employeeLoanInfo);
            //}
            //else
            //{
            //    throw new ArgumentNullException(nameof(savedData));
            //}
             
            return savedData;
        }


        #endregion

        #region //-----------------------------------------------Deduction Section-----------------------------------//

        /// <summary>
        /// Gets the deduction list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedDeduction">The selected deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IDeductionListView GetDeductionList(string selectedDeduction, string processingMessage)
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var deductionCollection = this.lookupRepository.GetDeductionByCompanyId(companyId);
                
            var viewModel =
                this.companySetupViewModelFactory.CreateDeductionListView(selectedDeduction, deductionCollection,
                    processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the create deduction view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IDeductionViewModel GetCreateDeductionView()
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var viewModel = this.companySetupViewModelFactory.CreateDeductionView(companyId);

            return viewModel;
        }

        /// <summary>
        /// Gets the deduction upadte view.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deduction</exception>
        public IDeductionViewModel GetDeductionUpadteView(IDeductionViewModel deduction, string processingMessage)
        {
            if (deduction == null)
            {
                throw new ArgumentNullException(nameof(deduction));
            }

            var viewModel = this.companySetupViewModelFactory.CreateDeductionUpdatedView(deduction, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the deduction edit view.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardId</exception>
        public IDeductionViewModel GetDeductionEditView(int deductionId)
        {
            if (deductionId <= 0)
            {
                throw new ArgumentNullException(nameof(deductionId));
            }

            var deduction = this.deductionRepository.GetDeductionById(deductionId);

            var viewModel = this.companySetupViewModelFactory.CreateEditDeductionView(deduction);

            return viewModel;
        }

        /// <summary>
        /// Processes the create deduction information.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deduction</exception>
        public string ProcessCreateDeductionInfo(IDeductionViewModel deduction)
        {
            if (deduction == null)
            {
                throw new ArgumentNullException(nameof(deduction));
            }

            bool IsDataOkay = true;

            var processingMessage = string.Empty;

            //Check for the existence of deduction with the same name
            var model = this.deductionRepository.GetDeductionByName(deduction.DeductionName);

            if (model != null)
            {
                IsDataOkay = false;
                processingMessage = Messages.DeductionAlreadyExist;
            }

            if (!IsDataOkay)
            {
                return processingMessage;
            }

            processingMessage = this.deductionRepository.SaveDeductionInfo(deduction);

            return processingMessage;
        }

        /// <summary>
        /// Processes the edit deduction information.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deduction</exception>
        public string ProcessEditDeductionInfo(IDeductionViewModel deduction)
        {
            if (deduction == null)
            {
                throw new ArgumentNullException(nameof(deduction));
            }

            string result = string.Empty;

            bool IsDataOkay = true;

            bool dataAlreadyExit = false;

            var model = this.rewardRepository.GetRewardByName(deduction.DeductionName);

            if (model != null)
            {
                dataAlreadyExit = true;
                result = Messages.DeductionAlreadyExist;

                return result;
            }

            result = this.deductionRepository.SaveEditDeductionInfo(deduction);

            if (result != null)
            {
                IsDataOkay = false;

                return result;
            }


            return result;
        }

        /// <summary>
        /// Processes the delete deduction information.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deductionId</exception>
        public string ProcessDeleteDeductionInfo(int deductionId)
        {
            if (deductionId <= 0)
            {
                throw new ArgumentNullException(nameof(deductionId));
            }

            var result = this.deductionRepository.SaveDeleteDeductionInfo(deductionId);

            return result;
        }

        #endregion

        #region //------------------------------------------------Level Grade Section-----------------------------------//   

        /// <summary>
        /// Gets the level grade list.
        /// </summary>
        /// <param name="logInUserId">The log in user identifier.</param>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="selectedGrade">The selected grade.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">logInUserId</exception>
        public ILevelGradeListView GetLevelGradeList(string selectedLevel, string selectedGrade,
            string selectedCompany, string processingMessage)
        {

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyCollection = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            var companyIdSession = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var levelGradeCollection = levelGradeRepository.GetLevelGradeByCompanyId(companyIdSession);
            
            var returnModel = this.companySetupViewModelFactory.CreateLevelGradeListView(selectedLevel, selectedGrade,
                selectedCompany, levelGradeCollection, processingMessage);

            return returnModel;
        }

        /// <summary>
        /// Gets the payscalebenefit.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitId</exception>
        public IPayScaleBenefitListView GetPayscalebenefit(int benefitId, string processingMessage)
        {
            if (benefitId <= 0) throw new ArgumentNullException(nameof(benefitId));

            var payscalebenefit = this.levelGradeRepository.GetIPayScaleBenefitByPayScaleId(benefitId);

            return this.companySetupViewModelFactory.CreatePayScaleBenefitLst(payscalebenefit, processingMessage);
        }

        /// <summary>
        /// Gets the grade level collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public IList<IPayScale> GetGradeLevelCollection(int companyId)
        {
            var levelGrade = this.levelGradeRepository.GetLevelGradeByCompanyId(companyId);
            
            return levelGrade;
        }
        
        /// <summary>
        /// Gets the create level grade view.
        /// </summary>
        /// <param name="logInUserId">The log in user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">logInUserId</exception>
        public IPayScaleUIView GetCreateLevelGradeView()
        {
            var userInfo = this.usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var levelCollection = this.levelRepository.GetLevelByCompanyId(companyId);

            var gradeCollection = this.gradeRepository.GetGradeByCompanyId(companyId);

            var benefitCollecton = this.benefitRepository.GetBenefitByCompanyId(companyId);
            

            var viewModel = this.companySetupViewModelFactory.CreateLevelGradeView(companyId, levelCollection,
                gradeCollection, benefitCollecton);

            return viewModel;
        }

        /// <summary>
        /// Processes the level grade information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeInfo</exception>
        public string ProcessLevelGradeInfo(IPayScale levelGradeInfo, IEnumerable<IPayScaleBenefit> payScalebenefits,
            List<int> selectedBenefits)
        {
            if (levelGradeInfo == null) throw new ArgumentNullException(nameof(levelGradeInfo));

            var processingMessage = string.Empty;

            bool IsRecordExist = false;

            int payScaleId = -1;

            IsRecordExist = (this.levelGradeRepository.GetLevelGradeByLevelIdAndGradeId(levelGradeInfo.CompanyId, levelGradeInfo.LevelId, levelGradeInfo.GradeId) == null) ? false : true;

            if (IsRecordExist)
            {
                processingMessage = Messages.payScaleAlreadyExist;

                return processingMessage;
            }

            processingMessage = this.levelGradeRepository.SaveLevelGradeInfo(levelGradeInfo, out payScaleId);

            if (selectedBenefits != null && selectedBenefits.Any())
            {

                var selectedpayScalebenefits = payScalebenefits.Where(p => selectedBenefits.Contains(p.BenefitId)).ToList();

                foreach (var item in selectedpayScalebenefits)
                {
                    item.PayScaleId = payScaleId;
                    levelGradeRepository.SavePayScaleBenefit(item);
                }
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the level grade upadte view.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <param name="payScaleBenefits">The pay scale benefits.</param>
        /// <param name="selectedBenefits">The selected benefits.</param>
        /// <param name="logUserId">The log user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// levelGradeInfo
        /// or
        /// logUserId
        /// or
        /// payScaleBenefits
        /// </exception>
        public IPayScaleUIView GetLevelGradeUpadteView(IPayScale levelGradeInfo, IEnumerable<IPayScaleBenefit> payScaleBenefits, 
            List<int> selectedBenefits, string message)
        {
            if (levelGradeInfo == null) throw new ArgumentNullException(nameof(levelGradeInfo));

            if (payScaleBenefits == null) throw new ArgumentNullException(nameof(payScaleBenefits));
            
            var userInfo = this.usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            
            var levelCollection = this.levelRepository.GetLevelByCompanyId(companyId);

            var gradeCollection = this.gradeRepository.GetGradeByCompanyId(companyId);

            var benefitCollection = this.benefitRepository.GetBenefitByCompanyId(companyId);
            

            var viewModel = this.companySetupViewModelFactory.CreateLevelGradeView(levelGradeInfo,
                levelCollection, gradeCollection, benefitCollection, payScaleBenefits, selectedBenefits, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the level grade edit view.
        /// </summary>
        /// <param name="levelGrade">The level grade.</param>
        /// <param name="logInUserId">The log in user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// levelGrade
        /// or
        /// levelGradeInfo
        /// or
        /// logInUserId
        /// </exception>
        public IPayScaleUIView GetLevelGradeEditView(int levelGrade)
        {
            if (levelGrade <= 0) throw new ArgumentNullException(nameof(levelGrade));

            var levelGradeInfo = this.levelGradeRepository.GetLevelGradeById(levelGrade);

            if (levelGradeInfo == null) throw new ArgumentNullException(nameof(levelGradeInfo));
            
            var userInfo = this.usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            if (companyId <=0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var levelCollection = this.levelRepository.GetLevelByCompanyId(companyId);

            var gradeCollection = this.gradeRepository.GetGradeByCompanyId(companyId);

            var benefitCollecton = this.benefitRepository.GetBenefitByCompanyId(companyId);

            var payScaleBenefits = this.levelGradeRepository.GetIPayScaleBenefitByPayScaleId(levelGrade);

            var selectedPayScaleBenefit = payScaleBenefits.Select(p => p.BenefitId).ToList();

            var viewModel = this.companySetupViewModelFactory.CreateLevelGradeEditView(levelGradeInfo,
                levelCollection, gradeCollection, benefitCollecton, payScaleBenefits, selectedPayScaleBenefit, string.Empty);

            return viewModel;
        }

        /// <summary>
        /// Processes the level grade edit information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeInfo</exception>
        public string ProcessLevelGradeEditInfo(IPayScale levelGradeInfo, IEnumerable<IPayScaleBenefit> payScaleBeneft, List<int> selectedBenefit)
        {
            if (levelGradeInfo == null) throw new ArgumentNullException(nameof(levelGradeInfo));

            var viewModel = this.levelGradeRepository.SaveLevelGradeEditInfo(levelGradeInfo);

            if (string.IsNullOrEmpty(viewModel))
            {
                // delete previously saved radio airing transactions
                var deleteResult = this.levelGradeRepository.SavePayScaleBenefitDeleteInfo(levelGradeInfo.PayScaleId);

                if (selectedBenefit != null && selectedBenefit.Any())
                {

                    var selectedpayScalebenefits = payScaleBeneft.Where(p => selectedBenefit.Contains(p.BenefitId)).ToList();

                    foreach (var item in selectedpayScalebenefits)
                    {
                        item.PayScaleId = levelGradeInfo.PayScaleId;
                        levelGradeRepository.SavePayScaleBenefit(item);
                    }
                }

            }
            
            return viewModel;
        }

        /// <summary>
        /// Processes the delete level grade information.
        /// </summary>
        /// <param name="levelGradeId">The level grade identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeId</exception>
        public string ProcessDeleteLevelGradeInfo(int levelGradeId)
        {
            if (levelGradeId <= 0) throw new ArgumentNullException(nameof(levelGradeId));

            var viewModel = this.levelGradeRepository.SaveLevelGradeDeleteInfo(levelGradeId);

            return viewModel;
        }

        #endregion

        #region //----------------------------------------------Tax Section-------------------------------------------------//

        /// <summary>
        /// Gets the tax list.
        /// </summary>
        /// <returns></returns>
        public ITaxListView GetTaxList()
        {
            var taxCollection = this.lookupRepository.GetAllTax();

            var returnModel = this.companySetupViewModelFactory.CreateTaxListView(taxCollection, string.Empty);

            return returnModel;
        }

        #endregion
        
        #region //=========================================Overtime Sheet========================================//

        /// <summary>
        /// Createovers the timesheet view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">userId</exception>
        public IOverTimesheetListView GetCreateOverTimeSheetView(string selectedEmployeeName, int? selectedCompanyId, string processingMessage)
        {
            var userInfo = this.usersRepository.GetUserById((int) sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyInfo = this.companyRepository.GetCompanyById((int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId));

            var overTimeSheetCollection = overTimesheetRepository.GetOverTimesheetByCompanyId(companyInfo.CompanyId);

            var returnModel = this.companySetupViewModelFactory.CreateOverTimeSheetListView(selectedEmployeeName, selectedCompanyId, overTimeSheetCollection, processingMessage);

            return returnModel;
        }
        
        /// <summary>
        /// Gets the createover timesheet view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">userId</exception>
        public IOverTimesheetView GetCreateOverTimeSheetView()
        {

            var userInfo = this.usersRepository.GetUserById((int) sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            
            var viewModel = this.companySetupViewModelFactory.CreateOverTimeSheetView(companyId, employeeCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the edit create over time sheet view.
        /// </summary>
        /// <param name="overTimeSheetId">The over time sheet identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">overTimeSheetId</exception>
        public IOverTimesheetView GetEditCreateOverTimeSheetView(int overTimeSheetId)
        {

            if (overTimeSheetId <= 0) throw new ArgumentNullException(nameof(overTimeSheetId));

            var userInfo = this.usersRepository.GetUserById((int) sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var overTimesheet = this.overTimesheetRepository.GetOverTimesheetById(overTimeSheetId);

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            
            var viewModel = this.companySetupViewModelFactory.CreateEditOverTimeSheetView(overTimesheet, companyId, employeeCollection);

            return viewModel;
        }

        /// <summary>
        /// Gets the create over time sheet view.
        /// </summary>
        /// <param name="overTimesheet">The over timesheet.</param>
        /// <param name="processingMessag">The processing messag.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userId
        /// or
        /// overTimesheet
        /// </exception>
        public IOverTimesheetView GetCreateOverTimeSheetView(IOverTimesheetView overTimesheet, string processingMessag)
        {

            if (overTimesheet == null) throw new ArgumentNullException(nameof(overTimesheet));

            var userInfo = this.usersRepository.GetUserById((int) sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)sessionServiceProvider.GetSessionValue(SessionKey.UserId);

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            
            var viewModel = this.companySetupViewModelFactory.CreateOverTimeSheetView(overTimesheet, employeeCollection, processingMessag);

            return viewModel;
        }

        /// <summary>
        /// Processes the over time sheet information.
        /// </summary>
        /// <param name="overTimesheet">The over timesheet.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">overTimesheet</exception>
        public string ProcessOverTimeSheetInfo(IOverTimesheetView overTimesheet)
        {
            if (overTimesheet == null) throw new ArgumentNullException(nameof(overTimesheet));

            string proessingMessage = string.Empty;

            proessingMessage = this.overTimesheetRepository.SaveOverTimesheetInfo(overTimesheet);

            return proessingMessage;
        }

        /// <summary>
        /// Processes the edit over time sheet information.
        /// </summary>
        /// <param name="overTimesheet">The over timesheet.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">overTimesheet</exception>
        public string ProcessEditOverTimeSheetInfo(IOverTimesheetView overTimesheet)
        {
            if (overTimesheet == null) throw new ArgumentNullException(nameof(overTimesheet));

            string proessingMessage = string.Empty;

            proessingMessage = this.overTimesheetRepository.SaveEditOverTimesheetInfo(overTimesheet);

            return proessingMessage;
        }

        /// <summary>
        /// Processes the over time sheet information.
        /// </summary>
        /// <param name="overTimesheetId">The over timesheet identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">overTimesheetId</exception>
        public string ProcessDeleteOverTimeSheetInfo(int overTimesheetId)
        {
            if (overTimesheetId <= 0) throw new ArgumentNullException(nameof(overTimesheetId));

            string proessingMessage = string.Empty;

            proessingMessage = this.overTimesheetRepository.SaveDeleteOverTimesheetInfo(overTimesheetId);

            return proessingMessage;
        }

        #endregion
        
        #region //--------------------------------------------------- Employee Deduction Starts----------------------------------------------------//

        /// <summary>
        /// get Employee Deduction Create View
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="processingMessage"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public IEmployeeDeductionView GetCreateEmployeeDeduction(int userId, string processingMessage, int employeeId)
        {

            if (userId == 0)

            {
                throw new ArgumentNullException(nameof(userId));
            }

            var loggedUser = this.usersRepository.GetUserById(userId);

            var companyCollection = this.companyRepository.GetCompaniesForHR(loggedUser.Username);
            var employee = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);
            var company = this.companyRepository.GetCompanyById(employee.CompanyId);
            var employeeDeduction = this.employeeDeductionRepository.GetEmployeeDeduction(employee.CompanyId);


            var returnModel = this.companySetupViewModelFactory.CreateUpdatedEmployeeDeductionView(employeeDeduction, "", employee, company);

            return returnModel;

        }

        /// <summary>
        /// Processes the create employee deduction information.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeduction</exception>
        public string ProcessCreateEmployeeDeductionInfo(IEmployeeDeductionView employeeDeduction)
        {
            if (employeeDeduction == null)
            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }

            bool IsDataOkay = true;

            var processingMessage = string.Empty;

            //Check for the existence of employee deduction with the same name
            IsDataOkay = (this.employeeDeductionRepository.GetEmployeeDeductionByEmployeeId(employeeDeduction.EmployeeId, employeeDeduction.DeductionId) == null) ? true : false;
            



            if (!IsDataOkay)
            {
                
                processingMessage = Messages.DeductionAlreadyExist;


                return processingMessage;
            }
            

            processingMessage = this.employeeDeductionRepository.SaveEmployeeDeductionInfo(employeeDeduction);

            return processingMessage;
        }
        
        /// <summary>
        /// Processes the deduction information.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeduction</exception>
        public string ProcessDeductionInfo(IDeductionViewModel employeeDeduction)
        {
            if (employeeDeduction == null)
            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }

            bool IsDataOkay = true;

            var processingMessage = string.Empty;

            //Check for the existence of employee deduction with the same name
            IsDataOkay = (this.employeeDeductionRepository.GetEmployeeDeductionByEmployeeId(employeeDeduction.EmployeeId, employeeDeduction.DeductionId) == null) ? true : false;

            if (!IsDataOkay)
            {

                processingMessage = Messages.DeductionAlreadyExist;


                return processingMessage;
            }

            processingMessage = this.employeeDeductionRepository.SaveDeductionInfo(employeeDeduction);

            return processingMessage;
        }
        

        /// <summary>
        /// Gets the employee deduction upadte view.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeduction</exception>
        public IEmployeeDeductionView GetEmployeeDeductionUpadteView(IEmployeeDeductionView employeeDeduction, string processingMessage)
        {
            if (employeeDeduction == null)
            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var employeeDeductionCollection = this.lookupRepository.GetEmployeeDeductionByCompanyId(companyId);
            
            var returnView = this.companySetupViewModelFactory.CreateEmployeeDeductionUpdateView(employeeDeduction, employeeDeductionCollection, processingMessage);

            return returnView;
        }

        /// <summary>
        /// Processes the employee deduction.
        /// </summary>
        /// <param name="employeeDeductionInfo">The employee deduction information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeductionInfo</exception>
        public string ProcessEmployeeDeduction(IEmployeeDeductionView employeeDeductionInfo)
        {
            if (employeeDeductionInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeDeductionInfo));
            }

            var processingMessage = string.Empty;

            var isDataOkay = true;

            //Check that This Company Has not registered this Grade Before
            var returnValue = this.employeeDeductionRepository.GetEmployeeDeductionById(employeeDeductionInfo.CompanyId);

            if (returnValue != null)
            {
                isDataOkay = false;
                processingMessage = Messages.DeductionAlreadyExist;
            }

            //Store Employee Deduction Information
            if (!isDataOkay)
            {
                return processingMessage;
            }

            var viewModel = this.employeeDeductionRepository.SaveEmployeeDeductionInfo(employeeDeductionInfo);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="userId"></param>
        /// <param name="ProcessingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        public IEmployeeDeductionView GetEmployeeDeductionByCompanyId(int employeeId, int userId, string ProcessingMessage)
        {
            if (employeeId <= 0) 
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var userInfo = this.usersRepository.GetUserById(userId);

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            var companyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var deductionCollection = this.lookupRepository.GetDeductionByCompanyId(companyId);
            

            var viewModel =
                this.companySetupViewModelFactory.CreateEmployeeDeductionView(employeeInfo.EmployeeId, employeeInfo.CompanyId, deductionCollection);

            return viewModel;
        }
        
        /// <summary>
        /// Deductions the by company identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        public IDeductionViewModel DeductionByCompanyId(int employeeId, string ProcessingMessage)
        {
            if (employeeId <= 0) 
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var deductionCollection = this.lookupRepository.GetDeductionByCompanyId(companyId);
            
            var viewModel =
                this.companySetupViewModelFactory.CreateDeductionView(employeeInfo.EmployeeId, employeeInfo.CompanyId, deductionCollection);

            return viewModel;
        }

        #endregion

        #region //---------------------------------------------------Employee Reward Section Begins Here -----------------------------------------//

        /// <summary>
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeId
        /// or
        /// loggedUser
        /// </exception>
        public IEmployeeRewardListView GetEmployeeRewardList(int employeeId, string processingMessage)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentNullException("employeeId");
            }

            var loggedUser = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            if (loggedUser == null)
            {
                throw new ArgumentNullException(nameof(loggedUser));
            }

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            var employeeReaward = this.employeeRewardRepository.GetEmployeeRewardByEmployeeId(employeeId);

            var viewModel = this.companySetupViewModelFactory.CreateEmployeeRewardListView(employeeInfo, employeeReaward, processingMessage, loggedUser.UserId);
            return viewModel;

        }

        /// <summary>
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="userId"></param>
        /// <param name="ProcessingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeId
        /// or
        /// userId
        /// </exception>
        public IEmployeeRewardViewModel CreateEmployeeRewardByCompanyId(int employeeId, string ProcessingMessage)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            
            var loggedUser = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));
            
            var comapnyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var rewardCollection = this.lookupRepository.GetRewardByCompanyId(comapnyId);
            

            var employee = this.employeeRepository.GetEmployeeById(employeeId);

            var company = this.companyRepository.GetCompanyById(employee.CompanyId);
            
            var viewmodel = this.companySetupViewModelFactory.CreateEmployeeRewardView(rewardCollection, ProcessingMessage, employee, company);

            return viewmodel;
        }


        /// <summary>
        /// </summary>
        /// <param name="SaveEmployeeDeduction"></param>
        /// <returns></returns>
        public string SaveEmployeeDeduction(IEmployeeDeductionView SaveEmployeeDeduction)
        {

            var save = this.employeeDeductionRepository.SaveEmployeeDeductionInfo(SaveEmployeeDeduction);

            return save;
        }

        /// <summary>
        /// </summary>
        /// <param name="employeeRewardViewModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeRewardViewModel</exception>
        public string ProcessEmployeeReward(IEmployeeRewardViewModel employeeRewardViewModel)
        {
            if (employeeRewardViewModel == null)
            {
                throw new ArgumentNullException(nameof(employeeRewardViewModel));
            }

            var save = this.employeeRewardRepository.saveEmployeeReward(employeeRewardViewModel);

            return save;
        }

        /// <summary>
        /// </summary>
        /// <param name="employeeReward"></param>
        /// <param name="userId"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public IEmployeeRewardViewModel CreateEmployeeRewardEditView(IEmployeeRewardViewModel employeeReward, int userId, string processingMessage)
        {
            
            if (userId == 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var loggedUser = this.usersRepository.GetUserById(userId);

            var rewardCollection = this.rewardRepository.GetRewardByRewardId();

            var viewModel = this.companySetupViewModelFactory.CreateEmployeeRewardEditView(rewardCollection,"" ,employeeReward);
            return viewModel;
        }


        #endregion
        
        #region //=========================================Employee Deduction==============================================================//

        /// <summary>
        /// Gets the deduction by company identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeDeductionListView GetDeductionByCompanyId(string selectedEmployeeName, int? selectedCompanyId, string processingMessage)
        {

            var userInfo = usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var employeeDeductionCollection = this.lookupRepository.GetEmployeeDeductionByCompanyId(companyId);

            return this.companySetupViewModelFactory.GetDeductionByCompanyId(selectedEmployeeName, selectedCompanyId, employeeDeductionCollection, processingMessage);
        }

        /// <summary>
        /// Gets all deduction by company identifier.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IDeductionListView GetAllDeductionByCompanyId(string selectedEmployeeName, int? selectedCompanyId, string processingMessage)
        {

            var userInfo = usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyList = this.companyRepository.GetMyCompanies(userInfo.CompanyId);

            var companyInSession = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var employeeDeductionCollection = lookupRepository.GetAllDeductionByCompanyId(companyInSession);
            
            return this.companySetupViewModelFactory.GetAllDeductionByCompanyId(selectedEmployeeName, selectedCompanyId, employeeDeductionCollection, processingMessage);
        }

        /// <summary>
        /// Creates the edit employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">User Null</exception>
        public IEmployeeLoanView CreateEditEmployeeLoan (int employeeLoanId, string processingMessage)
        {

            var loggedUser = this.usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var loanDetails = lookupRepository.GetLoan();

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);

            var employeeLoan = this.employeeLoanRepository.GetEmployeeLoanById(employeeLoanId);
            
            var viewModel = this.companySetupViewModelFactory.CreateEmployeeLoanEditView(employeeLoan, loanDetails, employeeCollection);
            return viewModel;

        }

        /// <summary>
        /// Processes the edit employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoanView</exception>
        public string ProcessEditEmployeeLoan(IEmployeeLoanView employeeLoanView)
        {
            if (employeeLoanView == null)
            {
                throw new ArgumentNullException(nameof(employeeLoanView));
            }
            
            string processingMessage = string.Empty;

            if ((employeeLoanView.IsApproved == false) && employeeLoanView.InterestRate < 0  && string.IsNullOrEmpty(employeeLoanView.HRComment) &&
                employeeLoanView.DisburstDate == null && employeeLoanView.AgreedDate == null)
            {
                
            }

            processingMessage = this.employeeLoanRepository.UpdateEmployeeLoan(employeeLoanView);

            return processingMessage;
        }

        /// <summary>
        /// Creates the delete employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoanId</exception>
        public IEmployeeLoanView CreateDeleteEmployeeLoan(int employeeLoanId, string processingMessage)
        {
            if (employeeLoanId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeLoanId));
            }

            var loggedUser = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));
            

            var companyId = (int) this.sessionServiceProvider.GetSessionValue(SessionKey.CompanyId);

            var loanDetails = this.lookupRepository.GetLoan();
            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            var employeeLoan = this.employeeLoanRepository.GetEmployeeLoanById(employeeLoanId);
            
            var viewModel = this.companySetupViewModelFactory.CreateEmployeeLoanEditView(employeeLoan, loanDetails, employeeCollection);
            return viewModel;

        }

        /// <summary>
        /// Processes the delete employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoanView</exception>
        public string ProcessDeleteEmployeeLoan(IEmployeeLoanView employeeLoanView)
        {
            if (employeeLoanView == null)
            {
                throw new ArgumentNullException(nameof(employeeLoanView));
            }

            string processingMessage = string.Empty;
            var viewModel = this.employeeLoanRepository.DeleteEmployeeLoan(employeeLoanView);
            return viewModel;
        }
        
        /// <summary>
        /// Gets the employee deduction.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userId
        /// or
        /// employeeId
        /// </exception>
        public IDeductionListView GetEmployeeDeduction(int employeeId)
        {

            if(employeeId == 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var userInfo = this.usersRepository.GetUserById((int)sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);

            var deductionCollection = this.employeeDeductionRepository.GetEmployeeDeductionByEmployeeId(employeeId);

            return this.companySetupViewModelFactory.CreateEmployeeDeductionListView(userInfo, employeeInfo, deductionCollection);

        }
        
        /// <summary>
        /// Gets the edit employ deduction.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeductionId</exception>
        public IDeductionViewModel GetEditEmployeeDeduction(int userId, int employeeDeductionId, int employeeId)
        {
            if (employeeDeductionId == 0)

            {
                throw new ArgumentNullException(nameof(employeeDeductionId));
            }


            var deduction = this.deductionRepository.GetDeductionById(employeeDeductionId);

            var userInfo = this.usersRepository.GetUserById(userId);

            //var employeeInfo = this.employeeOnBoardRepository.GetOnBoarderById(employeeId);
            var employee = this.employeeRepository.GetEmployeeById(employeeId);

            var deductionList = this.lookupRepository.GetDeductionByCompanyId(userInfo.CompanyId);

            var returnModel = this.companySetupViewModelFactory.CreateEditEmployeeDeductionView(deduction, deductionList,employee);

            return returnModel;
        }

        /// <summary>
        /// Gets the update employee deduction.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeduction</exception>
        public IEmployeeDeductionView GetUpdateEmployeeDeduction(IEmployeeDeductionView employeeDeduction, string processingMessage)
        {
            if (employeeDeduction == null)

            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }

            var deductionList = this.lookupRepository.GetDeductionByCompanyId(employeeDeduction.CompanyId);

            var returnModel = this.companySetupViewModelFactory.CreateUpdateEmployeeDeductionView(employeeDeduction, deductionList, processingMessage);

            return returnModel;
        }

        /// <summary>
        /// Gets the update deduction.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeduction</exception>
        public IDeductionViewModel GetUpdateDeduction(IDeductionViewModel employeeDeduction, string processingMessage)
        {
            if (employeeDeduction == null)

            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }


            var deductionList = this.lookupRepository.GetDeductionByCompanyId(employeeDeduction.CompanyId);

            var returnModel = this.companySetupViewModelFactory.CreateUpdatedDeductionView(employeeDeduction, deductionList, processingMessage);

            return returnModel;
        }

        /// <summary>
        /// Saves the delete employee deduction.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeductionId</exception>
        public string SaveDeleteEmployeeDeduction(IDeductionViewModel deduction)
        {

            if(deduction == null)
            {
                throw new ArgumentNullException(nameof(deduction));
            }

            var result = string.Empty;

            result = this.employeeDeductionRepository.SaveDeleteEmployeeDeduction(deduction);

            return result;

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="selectedEmployeeLoan"></param>
        /// <param name="selectedCompanyName"></param>
        /// <param name="selectedEmployeeName"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public IDeductionListView GetEmployeeDeductionsListByEmployee(string selectedEmployeeLoan,
           string selectedCompanyName,
           string selectedEmployeeName, string processingMessage)
        {

            var loggedInUserInfo = this.usersRepository.GetUserById((int)this.sessionServiceProvider.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedInUserInfo.Email);
            
            if (employeeInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeInfo));
            }

            var companyCollection = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);

            var employeeDeductionCollection = deductionRepository.GetDeductionByEmployeeId(employeeInfo.EmployeeId);

            var viewModel = this.companySetupViewModelFactory.CreateEmployeeDeductionListView(selectedEmployeeLoan,
                selectedCompanyName,
                selectedEmployeeName, employeeDeductionCollection, companyCollection, employeeInfo, processingMessage);

            return viewModel;
        }

        #endregion

        /// <summary>
        /// Gets the calendar event.
        /// </summary>
        /// <returns></returns>
        public IList<ICalendarEvent> GetCalendarEvent()
        {
            int userId = (int)sessionServiceProvider.GetSessionValue(SessionKey.UserId);

            var eventCollection = this.lookupRepository.GetCalendarEventsByUserId(userId);

            eventCollection.Where(p => p.UserId != userId).Each(v=>v.IsEditable = false);

            return eventCollection;
        }

        /// <summary>
        /// Processes the calendar event.
        /// </summary>
        /// <param name="calendarEvent">The calendar event.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">calendarEvent</exception>
        public string ProcessCalendarEvent(ICalendarEvent calendarEvent)
        {
            if (calendarEvent == null) throw new ArgumentNullException(nameof(calendarEvent));

            int userId = (int)sessionServiceProvider.GetSessionValue(SessionKey.UserId);

            string[] role = (String[]) sessionServiceProvider.GetSessionValue(SessionKey.UserRoles);

            if(role.Contains("Supervisor") || role.Contains("CompanyAdmin"))
            {
                calendarEvent.IsEditable = false;
            }
            else
            {
                calendarEvent.IsEditable = true; 
            }
           
            calendarEvent.UserId = userId;

            string processingMessage = string.Empty;

            processingMessage = this.usersRepository.SaveCalendarEvent(calendarEvent);
            
            return processingMessage;
        }

        /// <summary>
        /// Processes the delete calendar event.
        /// </summary>
        /// <param name="calendarEventId">The calendar event identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">calendarEventId</exception>
        public string ProcessDeleteCalendarEvent(int calendarEventId)
        {
            if (calendarEventId <= 0) throw new ArgumentNullException(nameof(calendarEventId));

            string processingMessage = string.Empty;

            processingMessage = this.ProcessDeleteCalendarEvent(calendarEventId);

            return processingMessage;
        }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="stop">The stop.</param>
        /// <returns></returns>
        public ICalendarEvent GetEvents(DateTime start, DateTime stop)
        {
            var calendarEvent = this.lookupRepository.GetCalendarEvent(start, stop);
            
            return calendarEvent;
        }
    }
}



