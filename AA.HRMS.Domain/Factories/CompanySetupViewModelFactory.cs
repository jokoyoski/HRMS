using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Repositories.Models;
using AA.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Factories
{

    public class CompanySetupViewModelFactory : ICompanySetupViewModelFactory
    {
        
        #region//-------------------------------------------Benefit Section-------------------------------//

        /// <summary>
        /// Creates the benefit view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalPeriodCollection">The appraisal period collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IBenefitModelView CreateBenefitView(int companyId, IList<IAppraisalPeriod> appraisalPeriodCollection)
        {
            if (companyId < 0)  
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var periodCollection = GetDropDownList.AppraisalPeriodListItem(appraisalPeriodCollection, -1);

            var viewModel = new BenefitModelView
            {
                CompanyId = companyId,
                PeriodCollection = periodCollection
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the benefit view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public IBenefitModelView CreateBenefitView(IBenefitModelView benefitInfo,
            IList<IAppraisalPeriod> periodCollection, string processingMessage)
        {
            if (benefitInfo == null)
            {
                throw new ArgumentNullException(nameof(benefitInfo));
            }

            if (periodCollection == null)
            {
                throw new ArgumentNullException(nameof(periodCollection));
            }
            
            var periodDDL = GetDropDownList.AppraisalPeriodListItem(periodCollection, benefitInfo.Period);
            
            benefitInfo.ProcessingMessage = processingMessage;
            benefitInfo.PeriodCollection = periodDDL;

            return benefitInfo;
        }

        /// <summary>
        /// Creates the benefit ListView.
        /// </summary>
        /// <param name="benefitCollections">The benefit collections.</param>
        /// <param name="selectedBenfit">The selected benfit.</param>
        /// <param name="selectedComapny">The selected comapny.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// benefitCollections
        /// or
        /// companyInfo
        /// </exception>
        public IBenefitListView CreateBenefitListView(IList<IBenefit> benefitCollections,
            string selectedBenfit,
            string processingMessage)
        {
            if (benefitCollections == null) throw new ArgumentNullException(nameof(benefitCollections));

            var filterList = benefitCollections.Where(x => x.BenefitName.Contains(string.IsNullOrEmpty(selectedBenfit)
                ? x.BenefitName
                : selectedBenfit)).ToList();

            var benefitListView = new BenefitListView
            {
                Benefits = filterList,
                ProcessingMessage = processingMessage ?? ""
            };

            return benefitListView;
        }

        /// <summary>
        /// Creates the edit view.
        /// </summary>
        /// <param name="benefitInfo">The benefit information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitInfo</exception>
        public IBenefitModelView CreateEditView(IBenefit benefitInfo,
            IList<IAppraisalPeriod> periodCollection)
        {
            if (benefitInfo == null)
            {
                throw new ArgumentNullException(nameof(benefitInfo));
            }

            if (periodCollection == null)
            {
                throw new ArgumentNullException(nameof(periodCollection));
            }
            
            var perioodDDL = GetDropDownList.AppraisalPeriodListItem(periodCollection, benefitInfo.Period);

            var viewModel = new BenefitModelView
            {
                BenefitId = benefitInfo.BenefitId,
                BenefitName = benefitInfo.BenefitName,
                BenefitDescription = benefitInfo.BenefitDescription,
                IsTaxable = benefitInfo.IsTaxable,
                IsMonetized = benefitInfo.IsMonetized,
                PeriodCollection = perioodDDL,
                Period = benefitInfo.Period,
                CompanyId = benefitInfo.CompanyId
                
            };

            return viewModel;
        }

        #endregion

        #region //----------------------------------------------Grade Section----------------------------------------------------//

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IGradeView CreateGradeView(int companyId)
        {

            if(companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            

            var view = new GradeView
            {
                CompanyId = companyId,
                ProcessingMessage = string.Empty
            };

            return view;
        }

        /// <summary>
        /// Creates the grade view.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        public IGradeView CreateGradeView(IGradeView gradeInfo,
            string processingMessage)
        {
            if (gradeInfo == null) throw new ArgumentNullException(nameof(gradeInfo));
            
            gradeInfo.ProcessingMessage = processingMessage;

            return gradeInfo;
        }

        /// <summary>
        /// Creates the updated grade view.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns>
        /// IGradeView.
        /// </returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        public IGradeView CreateUpdatedGradeView(IGradeView gradeInfo, IList<ICompanyDetail> companyCollection, IList<IBenefit> benefitCollection, string processingMessage)
        {
            if (gradeInfo == null) throw new ArgumentNullException(nameof(gradeInfo));
            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, gradeInfo.CompanyId);

            gradeInfo.CompanyDropDownList = companyDDL;
            gradeInfo.ProcessingMessage = processingMessage;

            return gradeInfo;
        }

        /// <summary>
        /// Creates the grade ListView.
        /// </summary>
        /// <param name="gradesCollections">The grades collections.</param>
        /// <param name="selectedGrade"></param>
        /// <param name="companyInfo"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// gradesCollections
        /// or
        /// companyInfo
        /// </exception>
        public IGradeListView CreateGradeListView(IList<IGrade> gradesCollections, int? selectedCompanyId, IList<ICompanyDetail> companyCollection,
            string selectedGrade,
            string processingMessage)
        {
            if (gradesCollections == null) throw new ArgumentNullException(nameof(gradesCollections));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            var filterList = gradesCollections.Where(x => x.GradeName.Contains(string.IsNullOrEmpty(selectedGrade)
                ? x.GradeName
                : selectedGrade)).ToList();

            filterList = filterList.Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();



            var gradeListView = new GradeListView
            {
                CompanyDropDown = companyDDL,
                GradesCollection = filterList,
                ProcessingMessage = processingMessage ?? ""
            };

            return gradeListView;
        }

        /// <summary>
        /// Creates the grade update view.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        public IGradeView CreateGradeUpdateView(IGrade gradeInfo, IList<IBenefit> benefitCollection)
        {
            if (gradeInfo == null) throw new ArgumentNullException(nameof(gradeInfo));

            var gradeView = new GradeView
            {
                GradeId = gradeInfo.GradeId,
                GradeName = gradeInfo.GradeName,
                GradeDescription = gradeInfo.GradeDescription,
                CompanyId = gradeInfo.CompanyId,
                IsActive = gradeInfo.IsActive,
                AnnualLeaveDuration = gradeInfo.AnnualLeaveDuration
            };

            return gradeView;
        }

        #endregion

        #region //------------------------------------------------------Reward Section------------------------------------------------//


        /// <summary>
        /// Creates the reward ListView.
        /// </summary>
        /// <param name="selectedReward">The selected reward.</param>
        /// <param name="rewardCollection">The reward collection.</param>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public IRewardListView CreateRewardListView(string selectedReward, IList<IReward> rewardCollection,
            string processingMessage)
        {
            var filterList = rewardCollection.Where(x => x.RewardName.Contains(string.IsNullOrEmpty(selectedReward)
                ? x.RewardName
                : selectedReward)).ToList();

            var viewModel = new RewardListView
            {
                RewardCollection = filterList,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the reward view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IRewardView CreateRewardView(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            

            var viewModel = new RewardView
            {
                CompanyId = companyId,
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the reward updated view.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">reward</exception>
        public IRewardView CreateRewardUpdatedView(IRewardView reward, 
            string processingMessage)
        {
            if (reward == null)
            {
                throw new ArgumentNullException(nameof(reward));
            }
            
            reward.ProcessingMessage = processingMessage;

            return reward;
        }

        /// <summary>
        /// Creates the edit reward view.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">reward</exception>
        public IRewardView CreateEditRewardView(IReward reward)
        {
            if (reward == null)
            {
                throw new ArgumentNullException(nameof(reward));
            }

            var viewResult = new RewardView
            {
                RewardId = reward.RewardId,
                RewardName = reward.RewardName,
                CompanyId = reward.CompanyId,
                Amount = reward.Amount,
                IsActive = reward.IsActive_,
                DateCreated = reward.DateCreated
            };

            return viewResult;
        }

        #endregion

        #region //------------------------------------------------------Loan Setup-----------------------------------------------------//

        /// <summary>
        /// Creates the loan view.
        /// </summary>
        /// <returns></returns>
        public ILoanView CreateLoanView(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var viewModel = new LoanView
            {
                CompanyId = companyId
            };
            return viewModel;
        }

        /// <summary>
        /// Creates the loan ListView.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedLoanId">The selected loan identifier.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        public ILoanListView CreateLoanListView(int? selectedLoanId, IList<ILoan> loanCollection,
            string processingMessage)
        {

            if (loanCollection == null) throw new ArgumentNullException(nameof(loanCollection));

            var viewModel = new LoanListView
            {
                LoanCollection = loanCollection,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the employee loan ListView.
        /// </summary>
        /// <param name="selectedEmployeeLoanName">Name of the selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="employeeloanCollection">The employeeloan collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeLoanListView CreateEmployeeLoanListView(string selectedEmployeeLoanName,
            string selectedCompanyName, string selectedEmployeeName, IList<IEmployeeLoan> employeeloanCollection,
            ICompanyDetail company, IEmployee employee, string processingMessage)
        {
            //var filterList = employeeloanCollection.Where(x => x.LoanName.Contains(
            //    string.IsNullOrEmpty(selectedEmployeeLoanName)
            //        ? x.LoanName
            //        : selectedEmployeeLoanName)).ToList();

           var filterList = employeeloanCollection.Where(x => x.CompanyName.Contains(
                string.IsNullOrEmpty(selectedCompanyName)
                    ? x.CompanyName
                    : selectedCompanyName)).ToList();

            filterList = employeeloanCollection.Where(x => x.EmployeeName.Contains(
                string.IsNullOrEmpty(selectedEmployeeName)
                    ? x.EmployeeName
                    : selectedEmployeeName)).ToList();


            var viewModel = new EmployeeLoanListView
            {
                EmployeeLoanCollection = filterList,
                Employee = employee,
                Company = company,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }
        
        /// <summary>
        /// Creates the employee loan ListView by employee.
        /// </summary>
        /// <param name="selectedEmployeeLoanName">Name of the selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="employeeloanCollection">The employeeloan collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeLoanListView CreateEmployeeLoanListViewByEmployee(string selectedEmployeeLoanName,
           string selectedCompanyName, string selectedEmployeeName, IList<IEmployeeLoan> employeeloanCollection,
           string processingMessage)
        {
            //filterList = employeeloanCollection.Where(x => x.LoanName.Contains(
            //    string.IsNullOrEmpty(selectedEmployeeLoanName)
            //        ? x.LoanName
            //        : selectedEmployeeLoanName)).ToList();

          var filterList = employeeloanCollection.Where(x => x.CompanyName.Contains(
                string.IsNullOrEmpty(selectedCompanyName)
                    ? x.CompanyName
                    : selectedCompanyName)).ToList();

            filterList = employeeloanCollection.Where(x => x.EmployeeName.Contains(
                string.IsNullOrEmpty(selectedEmployeeName)
                    ? x.EmployeeName
                    : selectedEmployeeName)).ToList();


            var viewModel = new EmployeeLoanListView
            {
                EmployeeLoanCollection = filterList,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the employee loan ListView.
        /// </summary>
        /// <param name="Employee">The employee.</param>
        /// <param name="employeeloanCollection">The employeeloan collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Employee
        /// or
        /// employeeloanCollection
        /// </exception>
        public IEmployeeLoanListView CreateEmployeeLoanListView(IEmployee Employee, IList<IEmployeeLoan> employeeloanCollection,
            string processingMessage)
        {

            if (Employee == null)
            {
                throw new ArgumentNullException(nameof(Employee));
            }

            if (employeeloanCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeloanCollection));
            }


            var viewModel = new EmployeeLoanListView
            {
                EmployeeLoanCollection = employeeloanCollection,
                Employee = Employee,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated loan view.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">loanInfo</exception>
        public ILoanView CreateUpdatedLoanView(ILoanView loanInfo, IList<ICompanyDetail> companyCollection,
            string processingMessage)
        {
            if (loanInfo == null)
                throw new ArgumentException(nameof(loanInfo));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            loanInfo.CompanyDropDown = companyDDL;

            loanInfo.ProcessingMessage = processingMessage;

            return loanInfo;
        }

        /// <summary>
        /// Creates the loan update view.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanInfo</exception>
        public ILoanView CreateLoanUpdateView(ILoan loanInfo)
        {
            if (loanInfo == null) throw new ArgumentNullException(nameof(loanInfo));

            var returnLoan = new LoanView
            {
                
                LoanTypeId = loanInfo.LoanTypeId,
                LoanType = loanInfo.LoanType,
                IsActive = loanInfo.IsActive,
                DateCreated = loanInfo.DateCreated,
                
            };

            return returnLoan;
        }

        /// <summary>
        /// Creates the edit loan view.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanInfo</exception>
        public ILoanView CreateEditLoanView(ILoan loanInfo)
        {
            if (loanInfo == null) throw new ArgumentNullException(nameof(loanInfo));

            var returnLoan = new LoanView
            {
                LoanTypeId = loanInfo.LoanTypeId,
                LoanType = loanInfo.LoanType,
                IsActive = loanInfo.IsActive,
                DateCreated = loanInfo.DateCreated,
            };

            return returnLoan;
        }
        
        /// <summary>
        /// Creates the employee loan view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// employee
        /// or
        /// loanCollection
        /// </exception>
        public IEmployeeLoanView CreateEmployeeLoanView(IList<ICompanyDetail> companyCollection,
            IEmployee employee, IList<ILoan> loanCollection)
        {
            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            if (loanCollection == null)
            {
                throw new ArgumentNullException(nameof(loanCollection));
            }

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);
            var loanDDL = GetDropDownList.LoanListItems(loanCollection, -1);


            var result = new EmployeeLoanView
            {
                CompanyDropDown = companyDDL,
                EmployeeId = employee.EmployeeId,
                CompanyId = employee.CompanyId,
                LoanDropDown = loanDDL,
            };

            return result;
        }


        #endregion

        #region  //------------------------------------------------Level Setup------------------------------------------------------------//

        /// <summary>
        /// Creates the level ListView.
        /// </summary>
        /// <param name="levelCollections">The level collections.</param>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// levelCollections
        /// or
        /// companyInfo
        /// </exception>
        public ILevelListView CreateLevelListView(int? selectedCompanyId, IList<ILevel> levelCollections, IList<ICompanyDetail> companyCollection,
            string selectedLevel,
            string processingMessage)
        {
            if (levelCollections == null) throw new ArgumentNullException(nameof(levelCollections));

            var filterList = levelCollections.Where(x => x.LevelName.Contains(string.IsNullOrEmpty(selectedLevel)
                ? x.LevelName
                : selectedLevel)).ToList();

            filterList = filterList.Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();


            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            var levelListView = new LevelListView
            {
                CompanyDropDown = companyDDL,
                LevelCollection = filterList,
                ProcessingMessage = processingMessage ?? ""
            };

            return levelListView;
        }

        /// <summary>
        /// Creates the level view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public ILevelView CreateLevelView(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var viewModel = new LevelView
            {
                CompanyId = companyId
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated level view.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">levelInfo</exception>
        public ILevelView CreateUpdatedLevelView(ILevelView levelInfo, string processingMessage)
        {
            if (levelInfo == null)
                throw new ArgumentException(nameof(levelInfo));


            levelInfo.ProcessingMessage = processingMessage;

            return levelInfo;
        }
        
        /// <summary>
        /// Creates the edit level view.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelInfo</exception>
        public ILevelView CreateEditLevelView(ILevel levelInfo)
        {

            if (levelInfo == null) throw new ArgumentNullException(nameof(levelInfo));
            
            var returnLevel = new LevelView
            {
                LevelId = levelInfo.LevelId,
                LevelName = levelInfo.LevelName,
                LevelDescription = levelInfo.LevelDescription,
                CompanyId = levelInfo.CompanyId,
                DateCreated = levelInfo.DateCreated,
                IsActive = levelInfo.IsActive
            };

            return returnLevel;
        }

        /// <summary>
        /// Creates the update level view.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelInfo</exception>
        public ILevelView CreateUpdateLevelView(ILevelView levelInfo, string processingMessage)
        {
            if (levelInfo == null) throw new ArgumentNullException(nameof(levelInfo));

            levelInfo.ProcessingMessage = processingMessage;

            return levelInfo;
        }

        #endregion
        
        #region //----------------------------------------------------Deduction Section----------------------------------------------//

        /// <summary>
        /// Creates the deduction ListView.
        /// </summary>
        /// <param name="selectedDeduction">The selected deduction.</param>
        /// <param name="deductionCollection">The deduction collection.</param>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public IDeductionListView CreateDeductionListView(string selectedDeduction,
            IList<IDeduction> deductionCollection, string processingMessage)
        {
            var filterList = deductionCollection.Where(x => x.DeductionName.Contains(
                string.IsNullOrEmpty(selectedDeduction)
                    ? x.DeductionName
                    : selectedDeduction)).ToList();

            var viewModel = new DeductionListView
            {
                DeductionCollection = filterList,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the deduction view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public IDeductionViewModel CreateDeductionView(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var viewModel = new DeductionViewModel
            {
                CompanyId = companyId
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the deduction updated view.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deduction</exception>
        public IDeductionViewModel CreateDeductionUpdatedView(IDeductionViewModel deduction, string processingMessage)
        {
            if (deduction == null)
            {
                throw new ArgumentNullException(nameof(deduction));
            }

            deduction.ProcessingMessage = processingMessage;

            return deduction;
        }

        /// <summary>
        /// Creates the edit deduction view.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deduction</exception>
        public IDeductionViewModel CreateEditDeductionView(IDeduction deduction)
        {
            if (deduction == null)
            {
                throw new ArgumentNullException(nameof(deduction));
            }

            var viewResult = new DeductionViewModel
            {
                DeductionId = deduction.DeductionId,
                DeductionName = deduction.DeductionName,
                CompanyId = deduction.CompanyId,
                DeductionAmount = deduction.DeductionAmount,
                IsActive = deduction.IsActive,
                DateCreated = deduction.DateCreated
            };

            return viewResult;
        }

        #endregion

        #region //-----------------------------------------------------Leave Section----------------------------------------------------//

        /// <summary>
        /// Gets the leave type ListView.
        /// </summary>
        /// <param name="leaveTypesList">The leave types list.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ILeaveTypeListView GetLeaveTypeListView(IList<ILeaveType> leaveTypesList, string processingMessage)
        {

            if (leaveTypesList == null) throw new ArgumentNullException(nameof(leaveTypesList));

            var view = new LeaveTypeListView
            {
                ProcessingMessage = processingMessage,
                LeaveTypes = leaveTypesList
            };

            return view;
        }

        /// <summary>
        /// Creates the leave type view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ILeaveTypeModelView CreateLeaveTypeView(int companyId,
            string processingMessage)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var viewModel = new LeaveTypeModelView
            {
                CompanyID = companyId,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the leave type edit view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeInfo</exception>
        public ILeaveTypeModelView CreateLeaveTypeEditView(IList<ICompanyDetail> companyCollection, string processingMessage, ILeaveType leaveTypeInfo)
        {
            if (leaveTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveTypeInfo));
            }

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, leaveTypeInfo.CompanyID);

            var viewModel = new LeaveTypeModelView
            {
                CompanyDropDown = companyDDL,
                ProcessingMessage = processingMessage,
                LeaveTypeID = leaveTypeInfo.LeaveTypeID,
                CompanyID = leaveTypeInfo.CompanyID,
                LeaveTypeName = leaveTypeInfo.LeaveTypeName,
                Description = leaveTypeInfo.Description,
                IsActive = leaveTypeInfo.IsActive,
                DateCreated = leaveTypeInfo.DateCreated,
                Duration = leaveTypeInfo.Duration

            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated leave type model view.
        /// </summary>
        /// <param name="leaveTypeModelInfo">The leave type model information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeModelInfo</exception>
        public ILeaveTypeModelView CreateUpdatedLeaveTypeModelView(ILeaveTypeModelView leaveTypeModelInfo,
            IList<ICompanyDetail> companyCollection, string processingMessage)
        {
            if (leaveTypeModelInfo == null) throw new ArgumentNullException(nameof(leaveTypeModelInfo));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, leaveTypeModelInfo.CompanyID);

            leaveTypeModelInfo.CompanyDropDown = companyDDL;

            leaveTypeModelInfo.ProcessingMessage = processingMessage;

            return leaveTypeModelInfo;
        }

        #endregion
        
        #region //-------------------------------------------------------LevelGrade Section--------------------------------------------------//        

        /// <summary>
        /// Creates the level grade ListView.
        /// </summary>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="selectedGrade">The selected grade.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="levelGradeCollection">The level grade collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeCollection</exception>
        public ILevelGradeListView CreateLevelGradeListView(string selectedLevel, string selectedGrade,
            string selectedCompany, IList<IPayScale> levelGradeCollection, string processingMessage)
        {
            if (levelGradeCollection == null) throw new ArgumentNullException(nameof(levelGradeCollection));

            var filterList = levelGradeCollection.Where(x => x.LevelName.Contains(string.IsNullOrEmpty(selectedLevel)
                ? x.LevelName
                : selectedLevel)).ToList();

            filterList = levelGradeCollection.Where(x => x.GradeName.Contains(string.IsNullOrEmpty(selectedGrade)
                ? x.GradeName
                : selectedGrade)).ToList();

            filterList = levelGradeCollection.Where(c => c.CompanyName.Contains(string.IsNullOrEmpty(selectedCompany)
                ? c.CompanyName
                : selectedCompany)).ToList();

            var levelGradeList = new LevelGradeListView
            {
                LevelGradeCollection = filterList,
                ProcessingMessage = processingMessage ?? ""
            };

            return levelGradeList;
        }


        /// <summary>
        /// Creates the pay scale benefit LST.
        /// </summary>
        /// <param name="payScaleBeneftCollecton">The pay scale beneft collecton.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payScaleBeneftCollecton</exception>
        public IPayScaleBenefitListView CreatePayScaleBenefitLst(IList<IPayScaleBenefit> payScaleBeneftCollecton, string processingMessage)
        {
            if (payScaleBeneftCollecton == null) throw new ArgumentNullException(nameof(payScaleBeneftCollecton));

            var result = new PayScaleBenefitListView
            {
                PaySCaleBenefitCollection = payScaleBeneftCollecton,
                ProcessingMessage = processingMessage
            };

            return result;
        }

        /// <summary>
        /// Creates the level grade ListView.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="leveCollection">The leve collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="taxCollection">The tax collection.</param>
        /// <returns></returns>
        public IPayScaleUIView CreateLevelGradeView(int companyId,
            IList<ILevel> leveCollection, IList<IGrade> gradeCollection, IList<IBenefit> benefitCollection)
        {

            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var gradeDDL = GetDropDownList.GradeListItems(gradeCollection, -1);
            var levelDDL = GetDropDownList.LevelListItems(leveCollection, -1);

            var payScaleBenefits = new List<IPayScaleBenefit>();

            foreach (var item in benefitCollection)
            {
                var payScale = new PayScaleBenefitModel
                {
                    PercentageofBase = 0,
                    CashValue = 0,
                    isSelected = false
                };

                payScaleBenefits.Add(payScale);
            }

            var view = new PayScaleUIView
            {
                BenefitList = benefitCollection,
                LevelDropDown = levelDDL,
                GradeDropDown = gradeDDL,
                ProcessingMessage = string.Empty,
                PayScalebenefits = payScaleBenefits,
                CompanyId = companyId
            };

            return view;
        }

        /// <summary>
        /// Creates the level grade ListView.
        /// </summary>
        /// <param name="levelGradeView">The level grade view.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="leveCollection">The leve collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="taxCollection">The tax collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPayScaleUIView CreateLevelGradeView(IPayScale levelGradeView,
            IList<ILevel> leveCollection, IList<IGrade> gradeCollection,
            IList<IBenefit> benefitCollection, IEnumerable<IPayScaleBenefit> payScaleBenefits,
            List<int> selectedBenefits, string message)
        {

            if (levelGradeView == null) throw new ArgumentNullException(nameof(levelGradeView));

            if (payScaleBenefits == null) throw new ArgumentNullException(nameof(payScaleBenefits));
            
            var gradeDDL = GetDropDownList.GradeListItems(gradeCollection, levelGradeView.GradeId);
            var levelDDL = GetDropDownList.LevelListItems(leveCollection, levelGradeView.LevelId);

            if ((selectedBenefits != null) && (selectedBenefits.Any()))
            {
                payScaleBenefits.Each(p => p.isSelected = selectedBenefits.Contains(p.BenefitId));

            }

            var updatedPayScaleBenefitList = payScaleBenefits.ToList();

            var result = new PayScaleUIView
            {
                LevelDropDown = levelDDL,
                GradeDropDown = gradeDDL,
                BenefitList = benefitCollection,
                PayScalebenefits = updatedPayScaleBenefitList,
                SelectedBenefits = selectedBenefits,
                ProcessingMessage = message,
                LevelId = levelGradeView.LevelId,
                GradeId = levelGradeView.GradeId,
                PayScaleId = levelGradeView.PayScaleId,
                BasePay = levelGradeView.BasePay,
                CompanyId = levelGradeView.CompanyId,
            };


            return result;
        }

        /// <summary>
        /// Creates the level grade edit view.
        /// </summary>
        /// <param name="levelGradeView">The level grade view.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="leveCollection">The leve collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="taxCollection">The tax collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPayScaleUIView CreateLevelGradeEditView(IPayScale levelGradeView,
            IList<ILevel> leveCollection, IList<IGrade> gradeCollection,
            IList<IBenefit> benefitCollecton, IEnumerable<IPayScaleBenefit> payScaleBenefits, List<int> selectedBenefits, string message)
        {
            var gradeDDL = GetDropDownList.GradeListItems(gradeCollection, levelGradeView.GradeId);
            var levelDDL = GetDropDownList.LevelListItems(leveCollection, levelGradeView.LevelId);

            var updatedPayScaleBenefitList = payScaleBenefits.ToList();

            updatedPayScaleBenefitList.Each(x => x.isSelected = selectedBenefits.Contains(x.BenefitId));

            foreach (var item in benefitCollecton)
            {
                if (!selectedBenefits.Contains(item.BenefitId))
                {
                    var benefits = new PayScaleBenefitModel
                    {
                        BenefitId = item.BenefitId,
                        isSelected = false
                    };

                    updatedPayScaleBenefitList.Add(benefits);
                }
            }

            var result = new PayScaleUIView
            {
                LevelDropDown = levelDDL,
                GradeDropDown = gradeDDL,
                BenefitList = benefitCollecton,
                PayScalebenefits = updatedPayScaleBenefitList,
                SelectedBenefits = selectedBenefits,
                ProcessingMessage = message,
                LevelId = levelGradeView.LevelId,
                GradeId = levelGradeView.GradeId,
                PayScaleId = levelGradeView.PayScaleId,
                BasePay = levelGradeView.BasePay,
                CompanyId = levelGradeView.CompanyId,
            };


            return result;
        }

        #endregion

        #region //-------------------------------------------------------Tax Section-------------------------------------------------------------------------//

        /// <summary>
        /// Creates the tax ListView.
        /// </summary>
        /// <param name="taxCollection">The tax collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">taxCollection</exception>
        public ITaxListView CreateTaxListView(IList<ITax> taxCollection, string processingMessage)
        {
            if (taxCollection == null) throw new ArgumentNullException(nameof(taxCollection));


            var taxList = new TaxListView
            {
                TaxCollection = taxCollection,
                ProcessingMessage = processingMessage
            };
            return taxList;
        }

        #endregion

        #region //----------------------------------------------------------overTime Sheet Section----------------------------------------------------------------//

        /// <summary>
        /// Creates the over time sheet ListView.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="overTimeSheetCollection">The over time sheet collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">overTimeSheetCollection</exception>
        public IOverTimesheetListView CreateOverTimeSheetListView(string selectedEmployeeName, int? selectedCompanyId, IList<IOverTimesheet> overTimeSheetCollection, string processingMessage)
        {
            if (overTimeSheetCollection == null)
            {
                throw new ArgumentNullException(nameof(overTimeSheetCollection));
            }

            var filterList = overTimeSheetCollection.Where(p => p.CompanyId.Equals(selectedCompanyId < 1 ? p.CompanyId : selectedCompanyId)).ToList();

            var result = new OverTimesheetListView
            {
                OverTimesheetCollection = filterList,
                
                ProcessingMessage = processingMessage
            };

            return result;
        }


        /// <summary>
        /// Creates the over time sheet view.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// employeeCollection
        /// </exception>
        public IOverTimesheetView CreateOverTimeSheetView(int companyId, IList<IEmployee> employeeCollection)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }
            
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);

            var result = new OverTimesheetView
            {
                CompanyId = companyId,
                EmployeeDropDownList = employeeDDL,
            };

            return result;
        }


        /// <summary>
        /// Creates the over time sheet view.
        /// </summary>
        /// <param name="overTimesheetView">The over timesheet view.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeCollection</exception>
        public IOverTimesheetView CreateOverTimeSheetView(IOverTimesheetView overTimesheetView, IList<IEmployee> employeeCollection, string processingMessage)
        {

            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }
            
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, overTimesheetView.EmployeeId);

            overTimesheetView.EmployeeDropDownList = employeeDDL;

            overTimesheetView.ProcessingMessage = processingMessage;

            return overTimesheetView;
        }

        /// <summary>
        /// Creates the edit over time sheet view.
        /// </summary>
        /// <param name="overTimesheet">The over timesheet.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyId
        /// or
        /// employeeCollection
        /// </exception>
        public IOverTimesheetView CreateEditOverTimeSheetView(IOverTimesheet overTimesheet, int companyId, IList<IEmployee> employeeCollection)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }
            
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);

            var result = new OverTimesheetView
            {
                CompanyId =  companyId,
                EmployeeId = overTimesheet.EmployeeId,
                NumberofHours = overTimesheet.NumberofHours,
                OverTimeDate = overTimesheet.OverTimeDate,
                OverTimesheetId = overTimesheet.OverTimesheetId,
                EmployeeDropDownList = employeeDDL,
            };

            return result;
        }

        #endregion

        #region //------------------------------------------------------------------------Employee Reward Section Begins Here-----------------------------------------------------------------//

        /// <summary>
        /// Creating Emplyee Reward View
        /// </summary>
        /// <param name="rewardCollection"></param>
        /// <param name="ProcessingMessage"></param>
        /// <param name="employee"></param>
        /// <param name="companyDetail"></param>
        /// <returns></returns>
        public IEmployeeRewardViewModel CreateEmployeeRewardView(IList<IReward> rewardCollection, string ProcessingMessage, IEmployee employee, ICompanyDetail companyDetail)
        {
            var rewardDDL = GetDropDownList.RewardListItems(rewardCollection, -1);

            var result = new Models.EmployeeRewardViewModel
            {

                RewardDropdownList = rewardDDL,
                EmployeeId = employee.EmployeeId,
                CompanyId = employee.CompanyId,
                ProcessingMessage = ProcessingMessage
            };
            return result;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="rewardCollection"></param>
        /// <param name="ProcessingMessage"></param>
        /// <param name="employeeReward"></param>
        /// <returns></returns>
        public IEmployeeRewardViewModel CreateEmployeeRewardEditView(IList<IReward> rewardCollection, string ProcessingMessage, IEmployeeRewardViewModel employeeReward)
        {
            var rewardDDL = GetDropDownList.RewardListItems(rewardCollection, employeeReward.RewardId);

            employeeReward.ProcessingMessage = ProcessingMessage;
            employeeReward.RewardDropdownList = rewardDDL;

            return employeeReward;
        }

        #endregion

        #region //-------------------------------------------------------------------------Employee Deduction Starts----------------------------------------------------------------------------//

        /// <summary>
        /// Creates the employee deduction ListView.
        /// </summary>
        /// <param name="selectedEmployeeDeductionId">The selected employee deduction identifier.</param>
        /// <param name="employeeDeductionCollection">The employee deduction collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeDeductionListView CreateEmployeeDeductionListView(int? selectedEmployeeDeductionId, IList<IEmployeeDeduction> employeeDeductionCollection, IList<ICompanyDetail> companyCollection, string processingMessage)
        {
            var filteredList = employeeDeductionCollection
                .Where(x => x.CompanyId.Equals(selectedEmployeeDeductionId < 1 ? x.CompanyId : selectedEmployeeDeductionId)).ToList();

            var viewModel = new EmployeeDeductionListView
            {
                EmployeeDeductionCollection = filteredList,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }
        
        /// <summary>
        /// Creates the employee deduction view.
        /// </summary>
        /// <param name="employeeDeductionInfo">The employee deduction information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeDeductionCollection">The employee deduction collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeductionInfo</exception>
        public IEmployeeDeductionView CreateEmployeeDeductionView(IEmployeeDeductionView employeeDeductionInfo, IList<IEmployeeDeduction> employeeDeductionCollection, string processingMessage)
        {
            if (employeeDeductionInfo == null) throw new ArgumentNullException(nameof(employeeDeductionInfo));

            var returnEmployeeDeduction = new EmployeeDeductionView
            {
                EmployeeDeductionId = employeeDeductionInfo.EmployeeDeductionId,
                EmployeeId = employeeDeductionInfo.EmployeeId,
                DeductionId = employeeDeductionInfo.DeductionId,
                IsActive = employeeDeductionInfo.IsActive,
                DateCreated = employeeDeductionInfo.DateCreated,
                CompanyId = employeeDeductionInfo.CompanyId
            };

            return returnEmployeeDeduction;
        }

        /// <summary>
        /// getEmployeeRewardListview
        /// </summary>
        /// <param name="employeeReward"></param>
        /// <param name="processingMessage"></param>
        /// <param name="companyDetail"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEmployeeRewardListView CreateEmployeeRewardListView(IEmployee employee, IList<IEmployeeReward> employeeReward, string processingMessage, int userId)
        {
            if(employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            if (employeeReward == null)
            {
                throw new ArgumentNullException(nameof(employeeReward));
            }

            var employeeDeduction = new Models.EmployeeRewardListView
            {
                Employee = employee,

                employeeReward = employeeReward,

                UserId = userId,

                ProcessingMessage = processingMessage
            };

            return employeeDeduction;
        }

        /// <summary>
        /// Creates the employee deduction update view.
        /// </summary>
        /// <param name="employeeDeductionInfo">The employee deduction information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeductionInfo</exception>
        public IEmployeeDeductionView CreateEmployeeDeductionUpdateView(IEmployeeDeduction employeeDeductionInfo)
        {
            if (employeeDeductionInfo == null) throw new ArgumentNullException(nameof(employeeDeductionInfo));

            var returnEmployeeDeduction = new EmployeeDeductionView
            {
                EmployeeDeductionId = employeeDeductionInfo.EmployeeDeductionId,
                EmployeeId = employeeDeductionInfo.EmployeeId,
                DeductionId = employeeDeductionInfo.DeductionId,
                IsActive = employeeDeductionInfo.IsActive,
                DateCreated = employeeDeductionInfo.DateCreated,
                CompanyId = employeeDeductionInfo.CompanyId
            };

            return returnEmployeeDeduction;
        }

        /// <summary>
        /// Creates the employee deduction view.
        /// </summary>
        /// <param name="deductionCollection">The deduction collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// deductionCollection
        /// </exception>
        public IEmployeeDeductionView CreateEmployeeDeductionView(int employeeId, int companyId, IList<IDeduction> deductionCollection)
        {

            if (deductionCollection == null) throw new ArgumentNullException(nameof(deductionCollection));
            

            var deductionDDL = GetDropDownList.DeductionListItem(deductionCollection, -1);

            var viewModel = new EmployeeDeductionView
            {
                //Assigning the drop down to the View model
                EmployeeId = employeeId,
                CompanyId = companyId,
                DeductionDropDown = deductionDDL
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the deduction view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="deductionCollection">The deduction collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deductionCollection</exception>
        public IDeductionViewModel CreateDeductionView(int employeeId, int companyId, IList<IDeduction> deductionCollection)
        {

            if (deductionCollection == null) throw new ArgumentNullException(nameof(deductionCollection));
            

            var deductionDDL = GetDropDownList.DeductionListItem(deductionCollection, -1);

            var viewModel = new DeductionViewModel
            {
                //Assigning the drop down to the View model
                EmployeeId = employeeId,
                CompanyId = companyId,
               

                //DeductionDropDown = deductionDDL
            };

            return viewModel;
        }
        
        /// <summary>
        /// Creates the employee deduction update view.
        /// </summary>
        /// <param name="employeeDeductionInfo">The employee deduction information.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeDeductionCollection">The employee deduction collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeductionInfo</exception>
        public IEmployeeDeductionView CreateEmployeeDeductionUpdateView(IEmployeeDeductionView employeeDeductionInfo, IList<IEmployeeDeduction> employeeDeductionCollection, string processingMessage)
        {
            //Throw exception for null companyCollection
            if (employeeDeductionInfo == null) throw new ArgumentNullException(nameof(employeeDeductionInfo));
            
            
            //Assigning processingMessage if any back to the view
            employeeDeductionInfo.ProcessingMessage = processingMessage;

            return employeeDeductionInfo;
        }

        /// <summary>
        /// Creates the updated employee deduction view.
        /// </summary>
        /// <param name="employeeDeductionCollection">The employee deduction collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="companyDetail">The company detail.</param>
        /// <returns></returns>
        public IEmployeeDeductionView CreateUpdatedEmployeeDeductionView(IList<IEmployeeDeduction> employeeDeductionCollection, string processingMessage, IEmployee employee, ICompanyDetail companyDetail)
        {
            var employeeDeduction = new Models.EmployeeDeductionView
            {
                EmployeeId = employee.EmployeeId,
                CompanyId = employee.CompanyId,
                ProcessingMessage = processingMessage
            };
            return employeeDeduction;
        }

        /// <summary>
        /// Creates the edit employee deduction view.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <param name="deductions">The deductions.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeDeduction
        /// or
        /// deductions
        /// </exception>
        public IDeductionViewModel CreateEditEmployeeDeductionView(IDeduction employeeDeduction, IList<IDeduction> deductions, IEmployee employee)
        {

            if (employeeDeduction == null)
            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }

            if (deductions == null)
            {
                throw new ArgumentNullException(nameof(deductions));
            }

            var deductionDDL = GetDropDownList.DeductionListItem(deductions, employeeDeduction.DeductionId);

            var result = new Models.DeductionViewModel
            {

                DeductionId = employeeDeduction.DeductionId,
                EmployeeId = employee.EmployeeId,
                CompanyId = employeeDeduction.CompanyId,
                EmployeeName = employeeDeduction.EemployeeName,
                DeductionName = employeeDeduction.DeductionName,
                DeductionAmount = employeeDeduction.DeductionAmount,
                DateTerminated = employeeDeduction.DateTerminated,
                DateStarted= employeeDeduction.DateStarted,
                DateCreated = employeeDeduction.DateCreated,
                IsActive = employeeDeduction.IsActive,
                ProcessingMessage = string.Empty,
                
                //DeductionDropDown = deductionDDL,

            };

            return result;
        }

        /// <summary>
        /// Creates the update employee deduction view.
        /// </summary>
        /// <param name="employeeDeductionView">The employee deduction view.</param>
        /// <param name="deductions">The deductions.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeDeductionView
        /// or
        /// deductions
        /// </exception>
        public IEmployeeDeductionView CreateUpdateEmployeeDeductionView(IEmployeeDeductionView employeeDeductionView, IList<IDeduction> deductions, string processingMessage)
        {

            if (employeeDeductionView == null)
            {
                throw new ArgumentNullException(nameof(employeeDeductionView));
            }

            if (deductions == null)
            {
                throw new ArgumentNullException(nameof(deductions));
            }

            var deductionDDL = GetDropDownList.DeductionListItem(deductions, employeeDeductionView.DeductionId);

            employeeDeductionView.DeductionDropDown = deductionDDL;
            employeeDeductionView.ProcessingMessage = processingMessage;

            return employeeDeductionView;
        }

        /// <summary>
        /// Creates the updated deduction view.
        /// </summary>
        /// <param name="employeeDeductionView">The employee deduction view.</param>
        /// <param name="deductions">The deductions.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeDeductionView
        /// or
        /// deductions
        /// </exception>
        public IDeductionViewModel CreateUpdatedDeductionView(IDeductionViewModel employeeDeductionView, IList<IDeduction> deductions, string processingMessage)
        {

            if (employeeDeductionView == null)
            {
                throw new ArgumentNullException(nameof(employeeDeductionView));
            }

            if (deductions == null)
            {
                throw new ArgumentNullException(nameof(deductions));
            }

            var deductionDDL = GetDropDownList.DeductionListItem(deductions, employeeDeductionView.DeductionId);

            //employeeDeductionView.DeductionDropDown = deductionDDL;
            employeeDeductionView.ProcessingMessage = processingMessage;

            return employeeDeductionView;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="selectedEmployeeName"></param>
        /// <param name="selectedCompanyId"></param>
        /// <param name="companyCollection"></param>
        /// <param name="employeeDeductioncollection"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyCollection</exception>
        public IEmployeeDeductionListView GetDeductionByCompanyId(string selectedEmployeeName, int? selectedCompanyId, IList<IEmployeeDeduction> employeeDeductioncollection, string processingMessage)
        {
            var filterList = employeeDeductioncollection.Where(p => p.CompanyId.Equals(selectedCompanyId < 1 ? p.CompanyId : selectedCompanyId)).ToList();

            var result = new EmployeeDeductionListView
            {
                EmployeeDeductionCollection = filterList,
                ProcessingMessage = processingMessage
            };

            return result;
        }

        /// <summary>
        /// Gets all deduction by company identifier.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="deductioncollection">The deductioncollection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyCollection</exception>
        public IDeductionListView GetAllDeductionByCompanyId(string selectedEmployeeName, int? selectedCompanyId, IList<IDeduction> deductioncollection, string processingMessage)
        {
            if (deductioncollection == null)
            {
                throw new ArgumentNullException(nameof(deductioncollection));
            }

            var filterList = deductioncollection.Where(p => p.CompanyId.Equals(selectedCompanyId < 1 ? p.CompanyId : selectedCompanyId)).ToList();

            var result = new DeductionListView
            {
                DeductionCollection = filterList,

                ProcessingMessage = processingMessage
            };

            return result;
        }

        /// <summary>
        /// Creates the employee deduction ListView.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="employeeDeductions">The employee deductions.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userDetail
        /// or
        /// employee
        /// or
        /// employeeDeductions
        /// </exception>
        public IDeductionListView CreateEmployeeDeductionListView(IUserDetail userDetail, IEmployee employee, IList<IDeduction> employeeDeductions)
        {
            if (userDetail == null)
            {
                throw new ArgumentNullException(nameof(userDetail));
            }

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            if (employeeDeductions == null)
            {
                throw new ArgumentNullException(nameof(employeeDeductions));
            }

            var result = new DeductionListView
            {
                DeductionCollection = employeeDeductions,
                User = userDetail,
                Employee = employee

            };

            return result;

        }

        #endregion

        #region //.........................................Employee loan starts..............................................................//

        /// <summary>
        /// Creates the employee loan ListView.
        /// </summary>
        /// <param name="selectedEmployeeLoanId">The selected employee loan identifier.</param>
        /// <param name="employeeLoanCollection">The employee loan collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeLoanListView CreateEmployeeLoanListView(int? selectedEmployeeLoanId, IList<IEmployeeLoan> employeeLoanCollection, IList<ICompanyDetail> companyCollection, string processingMessage)
        {
            var filteredList = employeeLoanCollection
                .Where(x => x.CompanyId.Equals(selectedEmployeeLoanId < 1 ? x.CompanyId : selectedEmployeeLoanId)).ToList();

            var viewModel = new EmployeeLoanListView
            {
                EmployeeLoanCollection = filteredList,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the employee loan view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// employeeCollection
        /// or
        /// loanCollection
        /// </exception>
        public IEmployeeLoanView CreateEmployeeLoanView(int companyId, IList<IEmployee> employeeCollection, IList<ILoan> loanCollection)
        {

            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }

            if (loanCollection == null)
            {
                throw new ArgumentNullException(nameof(loanCollection));
            }
            
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var loanDDL = GetDropDownList.LoanListItems(loanCollection, -1);


            var result = new EmployeeLoanView
            {
                CompanyId = companyId,
                EmployeeDropDown = employeeDDL,
                LoanDropDown = loanDDL,
            };

            return result;
        }

        /// <summary>
        /// Creates the employee loan view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="loanCollection">The loan collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanCollection</exception>
        public IEmployeeLoanView CreateEmployeeLoanView(int employeeId, int companyId, IList<ILoan> loanCollection)
        {
            if (loanCollection == null)
            {
                throw new ArgumentNullException(nameof(loanCollection));
            }
            
            var loanDDL = GetDropDownList.LoanListItems(loanCollection, -1);


            var result = new EmployeeLoanView
            {
                CompanyId = companyId,
                EmployeeId = employeeId,
                LoanDropDown = loanDDL,
            };

            return result;
        }
        
        /// <summary>
        /// Creates the updated employee loan view.
        /// </summary>
        /// <param name="employeeLoanInfo">The employee loan information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEmployeeLoanView CreateUpdatedEmployeeLoanView(IEmployeeLoanView employeeLoanInfo,
            ICompanyDetail companyInfo, IList<IEmployee> employeeCollection, IList<ILoan> loanCollection,
            string message)
        {
            if (employeeLoanInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeLoanInfo));
            }

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }

            if (loanCollection == null)
            {
                throw new ArgumentNullException(nameof(loanCollection));
            }

            var loanDDL = GetDropDownList.LoanListItems(loanCollection, employeeLoanInfo.LoanId);
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, employeeLoanInfo.EmployeeId);

            employeeLoanInfo.ProcessingMessage = message;
            employeeLoanInfo.LoanDropDown = loanDDL;
            employeeLoanInfo.EmployeeDropDown = employeeDDL;


            return employeeLoanInfo;
        }

        /// <summary>
        /// </summary>
        /// <param name="employeeLoan"></param>
        /// <param name="loanCollection"></param>
        /// <param name="companyDetailCollection"></param>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        public IEmployeeLoanView CreateEmployeeLoanEditView(IEmployeeLoan employeeLoan, IList<ILoan> loanCollection, IList<IEmployee> employeeDetails)
            {
                
                var employeeDDL = GetDropDownList.EmployeeListitems(employeeDetails, employeeLoan.EmployeeId);
                var loanDDL = GetDropDownList.LoanListItems(loanCollection, employeeLoan.LoanTypeId);

                var result = new EmployeeLoanView
                {
                    EmployeeDropDown = employeeDDL,
                    LoanDropDown = loanDDL,
                    CompanyId = employeeLoan.CompanyId,
                    EmployeeLoanId = employeeLoan.EmployeeLoanId,
                    LoanId = employeeLoan.LoanTypeId,
                    Tenure = employeeLoan.Tenure,
                    Reason = employeeLoan.Reason,
                    EmployeeId = employeeLoan.EmployeeId,
                    ProcessingMessage = string.Empty,
                    LoanAmount = employeeLoan.Amount,
                    DisburstDate = employeeLoan.DateDisburst,
                    HRComment = employeeLoan.HRComment,
                    AgreedDate = employeeLoan.AgreedDate,
                    IsApproved = employeeLoan.IsApproved,
                    LoanName = employeeLoan.LoanName,
                    ExpectedDate = employeeLoan.ExpectedDate,
                    InterestRate = employeeLoan.InterestRate,
                    IsActive = employeeLoan.IsActive,
                    DateCreated = employeeLoan.DateCreated,
                    PeriodRemain = employeeLoan.PeriodRemain,

                };
                return result;
            }

        /// <summary>
        /// Creates the employee loan ListView.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="employeeLoans">The employee loans.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userDetail
        /// or
        /// employee
        /// or
        /// employeeLoans
        /// </exception>
        public IEmployeeLoanListView CreateEmployeeLoanListView(IUserDetail userDetail, IEmployee employee, IList<IEmployeeLoan> employeeLoans)
            {
                if (userDetail == null)
                {
                    throw new ArgumentNullException(nameof(userDetail));
                }

                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }

                if (employeeLoans == null)
                {
                    throw new ArgumentNullException(nameof(employeeLoans));
                }

                var result = new EmployeeLoanListView
                {
                    EmployeeLoanCollection = employeeLoans,
                    User = userDetail,
                    Employee = employee

                };

                return result;

            }

        /// <summary>
        /// Gets the loan by company identifier.
        /// </summary>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="employeeLoanCollection">The employee loan collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyCollection</exception>
        public IEmployeeLoanListView GetLoanByCompanyId(string selectedEmployeeName, int? selectedCompanyId, IList<ICompanyDetail> companyCollection, IList<IEmployeeLoan> employeeLoanCollection, string processingMessage)
            {
                if (companyCollection == null)
                {
                    throw new ArgumentNullException(nameof(companyCollection));
                }


                var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

                var filterList = employeeLoanCollection.Where(p => p.CompanyId.Equals(selectedCompanyId < 1 ? p.CompanyId : selectedCompanyId)).ToList();

                var result = new EmployeeLoanListView
                {
                    EmployeeLoanCollection = filterList,
                    CompanyDropDownList = companyDDL,
                    ProcessingMessage = processingMessage
                };

                return result;
            }

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
        public IDeductionListView CreateEmployeeDeductionListView(string selectedEmployeeLoanName,
               string selectedCompanyName, string selectedEmployeeName, IList<IDeduction> employeeloanCollection, ICompanyDetail company, IEmployee employee,
               string processingMessage)
        {

                var viewModel = new DeductionListView
                {
                    DeductionCollection = employeeloanCollection,
                   Employee = employee,
                   Company  = company,
                    ProcessingMessage = processingMessage
                };

                return viewModel;
        }

        #endregion

    }
}











