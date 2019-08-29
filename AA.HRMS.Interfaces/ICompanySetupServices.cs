using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AA.HRMS.Interfaces
{
    public interface ICompanySetupServices
    {
        #region //-------------------------------------Grade Section------------------------------------------//

        IList<IGrade> GetGradesCollection(int companyId);
        /// <summary>
        /// Gets the grade registration view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IGradeView GetGradeView();

        /// <summary>
        /// Gets the grade registration view.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IGradeView GetGradeView(IGradeView gradeInfo, string processingMessage);

        /// <summary>
        /// Processes the grade information.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        string ProcessGradeInfo(IGradeView gradeInfo);

        /// <summary>
        /// Creates the grade list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedGrade">The selected grade.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IGradeListView CreateGradeList(int? selectedCompanyId, string selectedGrade, string processingMessage);

        /// <summary>
        /// Gets the grade update view.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        IGradeView GetGradeUpdateView(int gradeId);

        /// <summary>
        /// Updates the grade information.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        string UpdateGradeInfo(IGradeView gradeInfo);

        string ProcessUploadExcelGrade(HttpPostedFileBase levelExcel);

        /// <summary>
        /// Deletes the grade information.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        string DeleteGradeInfo(int gradeId);

        #endregion

        #region //------------------------------------Benefit Section-------------------------//

        /// <summary>
        /// Creates the benefit list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedBenefit">The selected benefit.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IBenefitListView CreateBenefitList(string selectedBenefit, string selectedCompany, string processingMessage);

        /// <summary>
        /// Gets the benefit create view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IBenefitModelView GetBenefitCreateView();

        /// <summary>
        /// Gets the benefit create view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IBenefitModelView GetBenefitCreateView(IBenefitModelView benefitInfo, string processingMessage);

        /// <summary>
        /// Processes the benefit information.
        /// </summary>
        /// <param name="benefitInfo">The benefit information.</param>
        /// <returns></returns>
        string ProcessBenefitInfo(IBenefitModelView benefitInfo);

        /// <summary>
        /// Gets the benefit edit view.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        IBenefitModelView GetBenefitEditView(int benefitId);

        /// <summary>
        /// Processes the edit benefit information.
        /// </summary>
        /// <param name="benefitInfo">The benefit information.</param>
        /// <returns></returns>
        string ProcessEditBenefitInfo(IBenefitModelView benefitInfo);

        /// <summary>
        /// Processes the upload excel benefit.
        /// </summary>
        /// <param name="benefitExcel">The benefit excel.</param>
        /// <returns></returns>
        string ProcessUploadExcelBenefit(HttpPostedFileBase levelExcel);

        /// <summary>
        /// Processes the delete benefit information.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        string ProcessDeleteBenefitInfo(int benefitId);

        #endregion

        #region //--------------------------------------------Leave Section-------------------------------------------//

        ILeaveTypeListView GetLeaveTypeListForLoggedInUser(string processingMessage);

        /// <summary>
        /// Gets the leave type model view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveTypeModelView GetLeaveTypeCreationView(string message);

        /// <summary>
        /// Gets the leave type edit view.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveTypeModelView GetLeaveTypeEditView(int leaveTypeId, string message);

        string ProcessUploadExcelLeaveType(HttpPostedFileBase levelExcel);

        /// <summary>
        /// Processes the type of the edit leave.
        /// </summary>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        string ProcessEditLeaveType(ILeaveTypeModelView leaveTypeInfo);

        /// <summary>
        /// Gets the leave type update view.
        /// </summary>
        /// <param name="leaveTypeModelView">The leave type model view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILeaveTypeModelView GetLeaveTypeUpdateView(ILeaveTypeModelView leaveTypeModelView, string processingMessage);

        string DeleteLeaveType(int leaveTypeId);
        /// <summary>
        /// Processes the leave type view information.
        /// </summary>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        string ProcessLeaveTypeViewInfo(ILeaveTypeModelView leaveTypeInfo);

        #endregion

        #region //------------------------------------------------Reward Section-------------------------------------//

        /// <summary>
        /// Gets the reward list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedReward">The selected reward.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IRewardListView GetRewardList(string selectedReward, string processingMessage);

        /// <summary>
        /// Gets the create reward view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IRewardView GetCreateRewardView();

        /// <summary>
        /// Gets the reward edit view.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        IRewardView GetRewardEditView(int rewardId);

        /// <summary>
        /// Gets the reward upadte view.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IRewardView GetRewardUpadteView(IRewardView reward, string processingMessage);

        /// <summary>
        /// Processes the create reward information.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        string ProcessCreateRewardInfo(IRewardView reward);

        /// <summary>
        /// Processes the edit reward information.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        string ProcessEditRewardInfo(IRewardView reward);

        /// <summary>
        /// Processes the delete reward information.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        string ProcessDeleteRewardInfo(int rewardId);

        #endregion

        #region //----------------------------------------------------Level Section--------------------------------------//

        /// <summary>
        /// Gets the level registration view.
        /// </summary>
        /// <returns></returns>
        ILevelView GetLevelRegistrationView();

        /// <summary>
        /// Gets the level update view.
        /// </summary>
        /// <param name="levelView">The level view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILevelView GetLevelUpdateView(ILevelView levelView, string processingMessage);

        /// <summary>
        /// Gets the level list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILevelListView GetLevelList(string selectedLevel, int? companyId, string processingMessage);

        /// <summary>
        /// Processes the level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        string ProcessLevelInfo(ILevelView levelInfo);

        /// <summary>
        /// Processes the upload excel.
        /// </summary>
        /// <param name="levelExcel">The level excel.</param>
        /// <returns></returns>
        string ProcessUploadExcelLevel(HttpPostedFileBase levelExcel);

        /// <summary>
        /// Gets the level edit view.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        ILevelView GetLevelEditView(int levelId);

        /// <summary>
        /// Processes the edit level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        string ProcessEditLevelInfo(ILevelView levelInfo);

        /// <summary>
        /// Processes the delete level information.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        string ProcessDeleteLevelInfo(int levelId);

        /// <summary>
        /// Gets the level collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ILevel> GetLevelCollection(int companyId);

        #endregion

        #region //-----------------------------------------------------------Loan Section------------------------------------//

        /// <summary>
        /// Gets the loans list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        ILoanListView GetLoansList(int? selectedCompany, string processingMessage);

        /// <summary>
        /// Gets the loan registration view.
        /// </summary>
        /// <returns></returns>
        ILoanView GetLoanRegistrationView();

        /// <summary>
        /// Processes the loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        string ProcessLoanInfo(ILoanView loanInfo);

        /// <summary>
        /// Gets the loan upadte view.
        /// </summary>
        /// <param name="loan">The loan.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILoanView GetLoanUpadteView(ILoanView loan, string processingMessage);

        /// <summary>
        /// Gets the loan edit view.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        ILoanView GetLoanEditView(int loanId);

        /// <summary>
        /// Processes the edit loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        string ProcessEditLoanInfo(ILoanView loanInfo);

        /// <summary>
        /// Processes the delete loan information.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        string ProcessDeleteLoanInfo(int loanId);

        /// <summary>
        /// Gets the employee loans list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedEmployeeLoan">The selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeLoanListView GetEmployeeLoansList(string selectedEmployeeLoan, string selectedCompanyName,
            string selectedEmployeeName, string processingMessage);

        /// <summary>
        /// Gets the employee loan registration view.
        /// </summary>
        /// <returns></returns>
        IEmployeeLoanView GetEmployeeLoanRegistrationView();

        /// <summary>
        /// Gets the employee loan registration view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmployeeLoanView GetEmployeeLoanRegistrationView(int employeeId);

        /// <summary>
        /// Gets the employeet loan update view.
        /// </summary>
        /// <param name="employeeLoanInfo">The employee loan information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeLoanView GetEmployeetLoanUpdateView(IEmployeeLoanView employeeLoanInfo, string message);

        /// <summary>
        /// Processes the employee loan information.
        /// </summary>
        /// <param name="employeeLoanInfo">The employee loan information.</param>
        /// <returns></returns>
        string ProcessEmployeeLoanInfo(IEmployeeLoanView employeeLoanInfo);


        #endregion

        #region //-------------------------------------------------------------Deduction Section--------------------------------------//

        /// <summary>
        /// Gets the employee deduction.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IDeductionListView GetEmployeeDeduction(int employeeId);

        /// <summary>
        /// Gets the edit employ deduction.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        IDeductionViewModel GetEditEmployeeDeduction(int userId, int employeeDeductionId, int employeeId);

        /// <summary>
        /// Gets the update employee deduction.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeDeductionView GetUpdateEmployeeDeduction(IEmployeeDeductionView employeeDeduction, string processingMessage);

        /// <summary>
        /// Gets the deduction list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedDeduction">The selected deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionListView GetDeductionList(string selectedDeduction, string processingMessage);

        /// <summary>
        /// Gets the create deduction view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IDeductionViewModel GetCreateDeductionView();

        /// <summary>
        /// Gets the deduction edit view.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        IDeductionViewModel GetDeductionEditView(int deductionId);

        /// <summary>
        /// Gets the deduction upadte view.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionViewModel GetDeductionUpadteView(IDeductionViewModel deduction, string processingMessage);

        /// <summary>
        /// Processes the create deduction information.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        string ProcessCreateDeductionInfo(IDeductionViewModel deduction);

        /// <summary>
        /// Processes the edit deduction information.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        string ProcessEditDeductionInfo(IDeductionViewModel deduction);

        /// <summary>
        /// Processes the delete deduction information.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        string ProcessDeleteDeductionInfo(int deductionId);

        #endregion

        #region //--------------------------------------------------------------Level Grade Section--------------------------------------------//      
        
        /// <summary>
        /// Gets the level grade list.
        /// </summary>
        /// <param name="logInUserId">The log in user identifier.</param>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="selectedGrade">The selected grade.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILevelGradeListView GetLevelGradeList(string selectedLevel, string selectedGrade, string selectedCompany, string processingMessage);

        /// <summary>
        /// Gets the payscalebenefit.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IPayScaleBenefitListView GetPayscalebenefit(int benefitId, string processingMessage);

        /// <summary>
        /// Gets the grade level collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IPayScale> GetGradeLevelCollection(int companyId);

        /// <summary>
        /// Gets the create level grade view.
        /// </summary>
        /// <param name="logInUserId">The log in user identifier.</param>
        /// <returns></returns>
        IPayScaleUIView GetCreateLevelGradeView();

        /// <summary>
        /// Processes the level grade information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        string ProcessLevelGradeInfo(IPayScale levelGradeInfo, IEnumerable<IPayScaleBenefit> payScalebenefits,
            List<int> selectedBenefits);

        /// <summary>
        /// Processes the level grade edit information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        string ProcessLevelGradeEditInfo(IPayScale levelGradeInfo, IEnumerable<IPayScaleBenefit> payScaleBeneft, List<int> selectedBenefit);

        /// <summary>
        /// Processes the delete level grade information.
        /// </summary>
        /// <param name="levelGradeId">The level grade identifier.</param>
        /// <returns></returns>
        string ProcessDeleteLevelGradeInfo(int levelGradeId);
        /// <summary>
        /// Gets the level grade upadte view.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPayScaleUIView GetLevelGradeUpadteView(IPayScale levelGradeInfo, IEnumerable<IPayScaleBenefit> payScaleBenefits, List<int> selectedBenefits, string message);

        /// <summary>
        /// Gets the level grade edit view.
        /// </summary>
        /// <param name="levelGrade">The level grade.</param>
        /// <returns></returns>
        IPayScaleUIView GetLevelGradeEditView(int levelGrade);

        #endregion
        
        #region //-----------------------------------------------------------------Tax Section --------------------------------------------------//

        ITaxListView GetTaxList();

        #endregion

        #region //-------------------------------------------------------Overtimesheet Section--------------------------------------------//

        /// <summary>
        /// Gets the create over time sheet view.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IOverTimesheetListView GetCreateOverTimeSheetView(string selectedEmployeeName, int? selectedCompanyId, string processingMessage);

        /// <summary>
        /// Gets the create over time sheet view.
        /// </summary>
        /// <returns></returns>
        IOverTimesheetView GetCreateOverTimeSheetView();

        /// <summary>
        /// Gets the edit create over time sheet view.
        /// </summary>
        /// <param name="overTimeSheetId">The over time sheet identifier.</param>
        /// <returns></returns>
        IOverTimesheetView GetEditCreateOverTimeSheetView(int overTimeSheetId);

        /// <summary>
        /// Gets the create over time sheet view.
        /// </summary>
        /// <param name="overTimesheet">The over timesheet.</param>
        /// <param name="processingMessag">The processing messag.</param>
        /// <returns></returns>
        IOverTimesheetView GetCreateOverTimeSheetView(IOverTimesheetView overTimesheet, string processingMessag);

        /// <summary>
        /// Processes the over time sheet information.
        /// </summary>
        /// <param name="overTimesheet">The over timesheet.</param>
        /// <returns></returns>
        string ProcessOverTimeSheetInfo(IOverTimesheetView overTimesheet);

        /// <summary>
        /// Processes the edit over time sheet information.
        /// </summary>
        /// <param name="overTimesheet">The over timesheet.</param>
        /// <returns></returns>
        string ProcessEditOverTimeSheetInfo(IOverTimesheetView overTimesheet);

        /// <summary>
        /// Processes the delete over time sheet information.
        /// </summary>
        /// <param name="overTimesheetId">The over timesheet identifier.</param>
        /// <returns></returns>
        string ProcessDeleteOverTimeSheetInfo(int overTimesheetId);

        #endregion
        
        #region //---------------------------------------------------------Employee Deduction-------------------------------------------------//

        /// <summary>
        /// get Employee Deduction Create View
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="processingMessage"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        IEmployeeDeductionView GetCreateEmployeeDeduction(int userId, string processingMessage, int employeeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SaveEmployeeDeduction"></param>
        /// <returns></returns>
        string SaveEmployeeDeduction(IEmployeeDeductionView SaveEmployeeDeduction);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="userId"></param>
        /// <param name="ProcessingMessage"></param>
        /// <returns></returns>
        IEmployeeDeductionView GetEmployeeDeductionByCompanyId(int employeeId, int userId, string ProcessingMessage);

        /// <summary>
        /// Gets the employee deduction upadte view.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeDeductionView GetEmployeeDeductionUpadteView(IEmployeeDeductionView employeeDeduction, string processingMessage);

        /// <summary>
        /// Processes the create employee deduction information.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <returns></returns>
        string ProcessCreateEmployeeDeductionInfo(IEmployeeDeductionView employeeDeduction);

        /// <summary>
        /// Processes the employee deduction.
        /// </summary>
        /// <param name="employeeDeductionView">The employee deduction view.</param>
        /// <returns></returns>
        string ProcessEmployeeDeduction(IEmployeeDeductionView employeeDeductionView);

        #endregion
        
        #region //---------------------------------------------------Employee Reward----------------------------------------------------//

        /// <summary>
        /// Creates the employeereward by company identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeRewardViewModel CreateEmployeeRewardByCompanyId(int employeeId, string ProcessingMessage);

        /// <summary>
        /// Processes the employee reward.
        /// </summary>
        /// <param name="employeeRewardViewModel">The employee reward view model.</param>
        /// <returns></returns>
        string ProcessEmployeeReward(IEmployeeRewardViewModel employeeRewardViewModel);

        /// <summary>
        /// Creates the employee reward edit view.
        /// </summary>
        /// <param name="employeeReward">The employee reward.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeRewardViewModel CreateEmployeeRewardEditView(IEmployeeRewardViewModel employeeReward, int userId, string processingMessage);

        /// <summary>
        /// Gets the employee reward list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeRewardListView GetEmployeeRewardList(int employeeId, string processingMessage);

        #endregion
        
        #region //--------------------------------------------------------Employee Loans/Deduction Section---------------------------------------//

        /// <summary>
        /// Creates the edit employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeLoanView CreateEditEmployeeLoan(int employeeLoanId, string processingMessage);

        /// <summary>
        /// Processes the edit employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        string ProcessEditEmployeeLoan(IEmployeeLoanView employeeLoanView);

        /// <summary>
        /// Gets the deduction by company identifier.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeDeductionListView GetDeductionByCompanyId(string selectedEmployeeName, int? selectedCompanyId, string processingMessage);

        /// <summary>
        /// Saves the delete employee deduction.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        string SaveDeleteEmployeeDeduction(IDeductionViewModel deduction);

        /// <summary>
        /// Gets the employee loans list by employee.
        /// </summary>
        /// <param name="selectedEmployeeLoan">The selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeLoanListView GetEmployeeLoansListByEmployee(string selectedEmployeeLoan,
           string selectedCompanyName,
           string selectedEmployeeName, string processingMessage);

        /// <summary>
        /// Gets the employee loans list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeLoanListView GetEmployeeLoansList(int employeeId, string processingMessage);

        /// <summary>
        /// Gets the employee deductions list by employee.
        /// </summary>
        /// <param name="selectedEmployeeLoan">The selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionListView GetEmployeeDeductionsListByEmployee(string selectedEmployeeLoan,
           string selectedCompanyName,
           string selectedEmployeeName, string processingMessage);

        /// <summary>
        /// Deductions the by company identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionViewModel DeductionByCompanyId(int employeeId, string ProcessingMessage);

        /// <summary>
        /// Processes the deduction information.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <returns></returns>
        string ProcessDeductionInfo(IDeductionViewModel employeeDeduction);

        /// <summary>
        /// Gets the update deduction.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionViewModel GetUpdateDeduction(IDeductionViewModel employeeDeduction, string processingMessage);

        /// <summary>
        /// Gets all deduction by company identifier.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionListView GetAllDeductionByCompanyId(string selectedEmployeeName, int? selectedCompanyId, string processingMessage);

        /// <summary>
        /// Processes the delete employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        string ProcessDeleteEmployeeLoan(IEmployeeLoanView employeeLoanView);

        /// <summary>
        /// Creates the delete employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeLoanView CreateDeleteEmployeeLoan(int employeeLoanId, string processingMessage);

        #endregion


        IList<ICalendarEvent> GetCalendarEvent();

        string ProcessDeleteCalendarEvent(int calendarEventId);
  
        string ProcessCalendarEvent(ICalendarEvent calendarEvent);
    }
}
