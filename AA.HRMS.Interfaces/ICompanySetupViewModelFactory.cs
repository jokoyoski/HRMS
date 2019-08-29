using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ICompanySetupViewModelFactory
    {

        #region //------------------------------------Benefits Section-----------------------------------//

        /// <summary>
        /// Creates the benefit ListView.
        /// </summary>
        /// <param name="benefitCollections">The benefit collections.</param>
        /// <param name="selectedBenfit">The selected benfit.</param>
        /// <param name="selectedComapny">The selected comapny.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IBenefitListView CreateBenefitListView(IList<IBenefit> benefitCollections,
            string selectedBenfit, string processingMessage);

        /// <summary>
        /// Creates the benefit view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IBenefitModelView CreateBenefitView(int companyId, IList<IAppraisalPeriod> appraisalPeriodCollection);

        /// <summary>
        /// Creates the benefit view.
        /// </summary>
        /// <param name="benefitInfo">The benefit information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IBenefitModelView CreateBenefitView(IBenefitModelView benefitInfo, IList<IAppraisalPeriod> periodCollection, string processingMessage);

        /// <summary>
        /// Creates the edit view.
        /// </summary>
        /// <param name="benefitInfo">The benefit information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IBenefitModelView CreateEditView(IBenefit benefitInfo, IList<IAppraisalPeriod> periodCollection);

        #endregion

        #region //---------------------------------------Grade Section--------------------------------------//

        /// <summary>
        /// Creates the grade ListView.
        /// </summary>
        /// <param name="gradesCollections">The grades collections.</param>
        /// <param name="selectedGrade">The selected grade.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IGradeListView CreateGradeListView(IList<IGrade> gradesCollections, int? selectedCompanyId, IList<ICompanyDetail> companyCollection,
            string selectedGrade,
            string processingMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyCollection"></param>
        /// <param name="benefitCollection"></param>
        /// <returns></returns>
        IGradeView CreateGradeView(int companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gradeInfo"></param>
        /// <param name="companyCollection"></param>
        /// <param name="benefitCollection"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        IGradeView CreateGradeView(IGradeView gradeInfo, 
            string processingMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gradeInfo"></param>
        /// <param name="companyCollection"></param>
        /// <param name="benefitCollection"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        IGradeView CreateUpdatedGradeView(IGradeView gradeInfo, IList<ICompanyDetail> companyCollection, IList<IBenefit> benefitCollection, string processingMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gradeInfo"></param>
        /// <param name="companyCollection"></param>
        /// <param name="benefitCollection"></param>
        /// <returns></returns>
        IGradeView CreateGradeUpdateView(IGrade gradeInfo, IList<IBenefit> benefitCollection);

        #endregion

        #region //-------------------------------------------Reward Section---------------------------------//

        /// <summary>
        /// Creates the reward ListView.
        /// </summary>
        /// <param name="selectedReward">The selected reward.</param>
        /// <param name="rewardCollection">The reward collection.</param>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        IRewardListView CreateRewardListView(string selectedReward, IList<IReward> rewardCollection, string processingMessage);

        /// <summary>
        /// Creates the reward view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IRewardView CreateRewardView(int companyId);

        /// <summary>
        /// Creates the reward updated view.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IRewardView CreateRewardUpdatedView(IRewardView reward, string processingMessage);

        /// <summary>
        /// Creates the edit reward view.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        IRewardView CreateEditRewardView(IReward reward);

        #endregion

        #region //--------------------------------------------Loan Section-------------------------------------//

        /// <summary>
        /// Creates the loan view.
        /// </summary>
        /// <returns></returns>
        ILoanView CreateLoanView(int companyId);

        /// <summary>
        /// Creates the loan ListView.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        ILoanListView CreateLoanListView(int? selectedLoanId, IList<ILoan> loanCollection, string processingMessage);

        /// <summary>
        /// Creates the updated loan view.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILoanView CreateUpdatedLoanView(ILoanView loanInfo, IList<ICompanyDetail> companyCollection, string processingMessage);

        /// <summary>
        /// Creates the loan update view.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        ILoanView CreateLoanUpdateView(ILoan loanInfo);

        /// <summary>
        /// Creates the edit loan view.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        ILoanView CreateEditLoanView(ILoan loanInfo);

        /// <summary>
        /// Creates the employee loan ListView.
        /// </summary>
        /// <param name="selectedEmployeeLoanName">Name of the selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="employeeloanCollection">The employeeloan collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeLoanListView CreateEmployeeLoanListView(string selectedEmployeeLoanName, string selectedCompanyName, string selectedEmployeeName, IList<IEmployeeLoan> employeeloanCollection, 
            ICompanyDetail Company, IEmployee employee, string processingMessage);

        /// <summary>
        /// Creates the employee loan view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        IEmployeeLoanView CreateEmployeeLoanView(int companyId, IList<IEmployee> employeeCollection, IList<ILoan> loanCollection);

        /// <summary>
        /// Creates the employee loan view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        IEmployeeLoanView CreateEmployeeLoanView(int companyId, int employeeId, IList<ILoan> loanCollection);

        /// <summary>
        /// Creates the employee loan view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        IEmployeeLoanView CreateEmployeeLoanView(IList<ICompanyDetail> companyCollection, IEmployee employee, IList<ILoan> loanCollection);

        /// <summary>
        /// Creates the updated employee loan view.
        /// </summary>
        /// <param name="employeeLoanInfo">The employee loan information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeLoanView CreateUpdatedEmployeeLoanView(IEmployeeLoanView employeeLoanInfo, ICompanyDetail companyInfo, IList<IEmployee> employeeCollection, IList<ILoan> loanCollection, string message);

        #endregion

        #region //----------------------------------------------Level sectioon------------------------------------//

        /// <summary>
        /// Creates the level ListView.
        /// </summary>
        /// <param name="levelCollections">The level collections.</param>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILevelListView CreateLevelListView(int? selectedCompanyId, IList<ILevel> levelCollections, IList<ICompanyDetail> companyCollection,
            string selectedLevel,
            string processingMessage);

        /// <summary>
        /// Creates the level view.
        /// </summary>
        /// <returns></returns>
        ILevelView CreateLevelView(int companyId);



        /// <summary>
        /// Creates the updated level view.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILevelView CreateUpdatedLevelView(ILevelView levelInfo, string processingMessage);

        /// <summary>
        /// Creates the edit level view.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        ILevelView CreateEditLevelView(ILevel levelInfo);

        #endregion

        #region //-----------------------------------------------Deduction Section-------------------------------------//


        /// <summary>
        /// Creates the edit employee deduction view.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <param name="deductions">The deductions.</param>
        /// <returns></returns>
        IDeductionViewModel CreateEditEmployeeDeductionView(IDeduction employeeDeduction, IList<IDeduction> deductions, IEmployee employee);

        /// <summary>
        /// Creates the update employee deduction view.
        /// </summary>
        /// <param name="employeeDeductionView">The employee deduction view.</param>
        /// <param name="deductions">The deductions.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeDeductionView CreateUpdateEmployeeDeductionView(IEmployeeDeductionView employeeDeductionView, IList<IDeduction> deductions, string processingMessage);


        /// <summary>
        /// Creates the employee deduction ListView.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="employeeDeductions">The employee deductions.</param>
        /// <returns></returns>
        IDeductionListView CreateEmployeeDeductionListView(IUserDetail userDetail, IEmployee employee, IList<IDeduction> employeeDeductions);

        /// <summary>
        /// Creates the deduction ListView.
        /// </summary>
        /// <param name="selectedDeduction">The selected deduction.</param>
        /// <param name="deductionCollection">The deduction collection.</param>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        IDeductionListView CreateDeductionListView(string selectedDeduction, IList<IDeduction> deductionCollection, string processingMessage);

        /// <summary>
        /// Creates the deduction view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IDeductionViewModel CreateDeductionView(int companyId);

        /// <summary>
        /// Creates the deduction updated view.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionViewModel CreateDeductionUpdatedView(IDeductionViewModel deduction, string processingMessage);

        /// <summary>
        /// Creates the edit deduction view.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        IDeductionViewModel CreateEditDeductionView(IDeduction deduction);

        #endregion

        #region //-------------------------------------------------Leave Section--------------------------------------------//

        ILeaveTypeListView GetLeaveTypeListView(IList<ILeaveType> leaveTypesList, string processingMessage);

        /// <summary>
        /// Creates the leave type view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILeaveTypeModelView CreateLeaveTypeView(int companyId, string processingMessage);

        /// <summary>
        /// Creates the leave type edit view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        ILeaveTypeModelView CreateLeaveTypeEditView(IList<ICompanyDetail> companyCollection, string processingMessage, ILeaveType leaveTypeInfo);


        /// <summary>
        /// Creates the updated leave type model view.
        /// </summary>
        /// <param name="leaveTypeModelInfo">The leave type model information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILeaveTypeModelView CreateUpdatedLeaveTypeModelView(ILeaveTypeModelView leaveTypeModelInfo, IList<ICompanyDetail> companyCollecction, string processingMessage);

        #endregion

        #region //-------------------------------------------------Level Grade Section------------------------------------------------//        

        /// <summary>
        /// Creates the level grade ListView.
        /// </summary>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="selectedGrade">The selected grade.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="levelGradeCollection">The level grade collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILevelGradeListView CreateLevelGradeListView(string selectedLevel, string selectedGrade, string selectedCompany, IList<IPayScale> levelGradeCollection, string processingMessage);

        /// <summary>
        /// Creates the level grade view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="leveCollection">The leve collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="benefitCollection">The benefit collection.</param>
        /// <returns></returns>
        IPayScaleUIView CreateLevelGradeView(int companyId, IList<ILevel> leveCollection, IList<IGrade> gradeCollection, IList<IBenefit> benefitCollection);

        /// <summary>
        /// Creates the level grade view.
        /// </summary>
        /// <param name="levelGradeView">The level grade view.</param>
        /// <param name="leveCollection">The leve collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="benefitCollection">The benefit collection.</param>
        /// <param name="payScaleBenefits">The pay scale benefits.</param>
        /// <param name="selectedBenefits">The selected benefits.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPayScaleUIView CreateLevelGradeView(IPayScale levelGradeView, IList<ILevel> leveCollection, IList<IGrade> gradeCollection,
            IList<IBenefit> benefitCollection, IEnumerable<IPayScaleBenefit> payScaleBenefits, List<int> selectedBenefits, string message);

        /// <summary>
        /// Creates the level grade edit view.
        /// </summary>
        /// <param name="levelGradeView">The level grade view.</param>
        /// <param name="leveCollection">The leve collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="benefitCollecton">The benefit collecton.</param>
        /// <param name="payScaleBenefits">The pay scale benefits.</param>
        /// <param name="selectedBenefits">The selected benefits.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPayScaleUIView CreateLevelGradeEditView(IPayScale levelGradeView, IList<ILevel> leveCollection, IList<IGrade> gradeCollection,
            IList<IBenefit> benefitCollecton, IEnumerable<IPayScaleBenefit> payScaleBenefits, List<int> selectedBenefits, string message);

        /// <summary>
        /// Creates the pay scale benefit LST.
        /// </summary>
        /// <param name="payScaleBeneftCollecton">The pay scale beneft collecton.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IPayScaleBenefitListView CreatePayScaleBenefitLst(IList<IPayScaleBenefit> payScaleBeneftCollecton, string processingMessage);

        #endregion

        #region //--------------------------------------------------------Tax Section-------------------------------------------------//

        /// <summary>
        /// Creates the tax ListView.
        /// </summary>
        /// <param name="taxCollection">The tax collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITaxListView CreateTaxListView(IList<ITax> taxCollection, string message);

        #endregion
        
        #region //=================================================Overtime Sheet=================================================//

        /// <summary>
        /// Creates the over time sheet ListView.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="overTimeSheetCollection">The over time sheet collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IOverTimesheetListView CreateOverTimeSheetListView(string selectedEmployeeName, int? selectedCompanyId,
                IList<IOverTimesheet> overTimeSheetCollection, string processingMessage);

        /// <summary>
        /// Creates the over time sheet view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <returns></returns>
        IOverTimesheetView CreateOverTimeSheetView(int companyId, IList<IEmployee> employeeCollection);

        /// <summary>
        /// Creates the over time sheet view.
        /// </summary>
        /// <param name="overTimesheetView">The over timesheet view.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IOverTimesheetView CreateOverTimeSheetView(IOverTimesheetView overTimesheetView, IList<IEmployee> employeeCollection, string processingMessage);

        /// <summary>
        /// Creates the edit over time sheet view.
        /// </summary>
        /// <param name="overTimesheet">The over timesheet.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <returns></returns>
        IOverTimesheetView CreateEditOverTimeSheetView(IOverTimesheet overTimesheet, int companyId, IList<IEmployee> employeeCollection);

        #endregion
        
        #region //----------------------------------------------------------------Employee Deduction----------------------------------------------------------------------------//

        /// <summary>
        /// Creates the employee deduction ListView.
        /// </summary>
        /// <param name="selectedEmployeeLoanName">Name of the selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="employeeloanCollection">The employeeloan collection.</param>
        /// <param name="company">The company.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionListView CreateEmployeeDeductionListView(string selectedEmployeeLoanName,
               string selectedCompanyName, string selectedEmployeeName, IList<IDeduction> employeeloanCollection, ICompanyDetail company, IEmployee employee,
               string processingMessage);

        /// <summary>
        /// Creates the employee deduction view.
        /// </summary>
        /// <param name="employeeDeductionInfo">The employee deduction information.</param>
        /// <param name="employeeDeductionCollection">The employee deduction collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeDeductionView CreateEmployeeDeductionView(IEmployeeDeductionView employeeDeductionInfo, IList<IEmployeeDeduction> employeeDeductionCollection, string processingMessage);

        /// <summary>
        /// Creates the employee deduction view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="deductionCollection">The deduction collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        IEmployeeDeductionView CreateEmployeeDeductionView(int employeeId, int companyId, IList<IDeduction> deductionCollection);

        /// <summary>
        /// Creates the updated employee deduction view.
        /// </summary>
        /// <param name="employeeDeductionCollection">The employee deduction collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="companyDetail">The company detail.</param>
        /// <returns></returns>
        IEmployeeDeductionView CreateUpdatedEmployeeDeductionView(IList<IEmployeeDeduction> employeeDeductionCollection, string processingMessage, IEmployee employee, ICompanyDetail companyDetail);

        /// <summary>
        /// Creates the employee deduction update view.
        /// </summary>
        /// <param name="employeeDeductionInfo">The employee deduction information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeDeductionCollection">The employee deduction collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeDeductionView CreateEmployeeDeductionUpdateView(IEmployeeDeductionView employeeDeductionInfo, IList<IEmployeeDeduction> employeeDeductionCollection, string processingMessage);

        /// <summary>
        /// Creating Emplyee Reward View
        /// </summary>
        /// <param name="employeeRewardCollection"></param>
        /// <param name="companyDetailCollection"></param>
        /// <param name="employeeCollection"></param>
        /// <param name="rewardCollection"></param>
        /// <returns></returns>
        IEmployeeRewardViewModel CreateEmployeeRewardView(IList<IReward> rewardCollection, string ProcessingMessage, IEmployee employee, ICompanyDetail companyDetail);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rewardCollection"></param>
        /// <param name="ProcessingMessage"></param>
        /// <param name="employee"></param>
        /// <param name="companyDetail"></param>
        /// <param name="employeeReward"></param>
        /// <returns></returns>
        IEmployeeRewardViewModel CreateEmployeeRewardEditView(IList<IReward> rewardCollection, string ProcessingMessage, IEmployeeRewardViewModel employeeReward);

        /// <summary>
        /// getEmployeeRewardListview
        /// </summary>
        /// <param name="employeeReward"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        IEmployeeRewardListView CreateEmployeeRewardListView(IEmployee employee, IList<IEmployeeReward> employeeReward, string processingMessage, int userId);

        /// <summary>
        /// Gets the deduction by company identifier.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeDeductioncollection">The employee deductioncollection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeDeductionListView GetDeductionByCompanyId(string selectedEmployeeName, int? selectedCompanyId, IList<IEmployeeDeduction> employeeDeductioncollection, string processingMessage);
        
        /// <summary>
        /// Creates the employee loan edit view.
        /// </summary>
        /// <param name="employeeLoan">The employee loan.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <param name="companyDetailCollection">The company detail collection.</param>
        /// <param name="employeeDetails">The employee details.</param>
        /// <returns></returns>
        IEmployeeLoanView CreateEmployeeLoanEditView(IEmployeeLoan employeeLoan, IList<ILoan> loanCollection, IList<IEmployee> employeeDetails);

        /// <summary>
        /// Creates the employee loan ListView.
        /// </summary>
        /// <param name="Employee">The employee.</param>
        /// <param name="employeeloanCollection">The employeeloan collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeLoanListView CreateEmployeeLoanListView(IEmployee Employee, IList<IEmployeeLoan> employeeloanCollection,
            string processingMessage);

        /// <summary>
        /// Creates the employee loan ListView by employee.
        /// </summary>
        /// <param name="selectedEmployeeLoanName">Name of the selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="employeeloanCollection">The employeeloan collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeLoanListView CreateEmployeeLoanListViewByEmployee(string selectedEmployeeLoanName,
           string selectedCompanyName, string selectedEmployeeName, IList<IEmployeeLoan> employeeloanCollection,
           string processingMessage);

        /// <summary>
        /// Creates the deduction view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="deductionCollection">The deduction collection.</param>
        /// <returns></returns>
        IDeductionViewModel CreateDeductionView(int employeeId, int companyId, IList<IDeduction> deductionCollection);

        /// <summary>
        /// Creates the updated deduction view.
        /// </summary>
        /// <param name="employeeDeductionView">The employee deduction view.</param>
        /// <param name="deductions">The deductions.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionViewModel CreateUpdatedDeductionView(IDeductionViewModel employeeDeductionView, IList<IDeduction> deductions, string processingMessage);

        /// <summary>
        /// Gets all deduction by company identifier.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="deductioncollection">The deductioncollection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDeductionListView GetAllDeductionByCompanyId(string selectedEmployeeName, int? selectedCompanyId, IList<IDeduction> deductioncollection, string processingMessage);

        #endregion

    }

}
