using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin()]
    public class CompanySetupController : Controller
    {

        private readonly ICompanySetupServices companySetupServices;
        private readonly ISessionStateService session;
        private readonly ICompanyRepository companyRepository;
        private readonly IGenerateDocumentService generateDocumentService;

        public CompanySetupController(ICompanySetupServices companySetupServices, ISessionStateService session, ICompanyRepository companyRepository,
            IGenerateDocumentService generateDocumentService)
        {
            this.companySetupServices = companySetupServices;
            this.session = session;
            this.companyRepository = companyRepository;
            this.generateDocumentService = generateDocumentService;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        #region //----------------------------------------------------------------Leave Section--------------------------------------//

        /// <summary>
        /// Leaves the type list.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">viewModel</exception>
        public ActionResult LeaveTypeList(string message)
        {
            var viewModel = companySetupServices.GetLeaveTypeListForLoggedInUser(message);
            
            return View("LeaveTypeList", viewModel);
        }

        /// <summary>
        /// Leaves the setup.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateLeaveType(string message)
        {
            var viewModel = this.companySetupServices.GetLeaveTypeCreationView(message);

            return this.PartialView("CreateLeaveType", viewModel);
        }

        /// <summary>
        /// Leaves the setup.
        /// </summary>
        /// <param name="leaveTypeModelView">The leave type model view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeModelView</exception>
        [HttpPost]
        public ActionResult CreateLeaveType(LeaveTypeModelView leaveTypeModelView, HttpPostedFileBase leaveTypeExcelFile)
        {
            
            var processingMessage = String.Empty;
            if (leaveTypeExcelFile != null)
            {
                processingMessage = this.companySetupServices.ProcessUploadExcelLeaveType(leaveTypeExcelFile);


                if (!string.IsNullOrEmpty(processingMessage))
                {
                    var viewModel = this.companySetupServices.GetLeaveTypeUpdateView(leaveTypeModelView, processingMessage);

                    return this.View("CreateLeaveType", viewModel);
                }

                processingMessage = string.Format("{0} successful added", leaveTypeModelView.LeaveTypeName);

                return this.RedirectToAction("LeaveTypeList", "CompanySetup", new { message = processingMessage });
            }


            if (leaveTypeModelView == null)
            {
                throw new ArgumentNullException(nameof(leaveTypeModelView));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetLeaveTypeUpdateView(leaveTypeModelView, string.Empty);

                return this.View("CreateLeaveType", viewModel);
            }

            var returnViewModel = this.companySetupServices.ProcessLeaveTypeViewInfo(leaveTypeModelView);

            if (!string.IsNullOrEmpty(returnViewModel))
            {
                var viewModel = this.companySetupServices.GetLeaveTypeUpdateView(leaveTypeModelView, returnViewModel);

                return this.View("CreateLeaveType", viewModel);
            }

            returnViewModel = string.Format("New Leave Type {0} Created", leaveTypeModelView.LeaveTypeName);

            return RedirectToAction("LeaveTypeList", new { message = returnViewModel });

        }

        /// <summary>
        /// Edits the type of the leave.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <param name="message">The message.</param>
        /// <retu rns></returns>
        [HttpGet]
        public ActionResult EditLeaveType(int leaveTypeId, string message)
        {
            var viewModel = companySetupServices.GetLeaveTypeEditView(leaveTypeId, message);

            return this.PartialView("EditLeaveType", viewModel);
        }

        /// <summary>
        /// Edits the type of the leave.
        /// </summary>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeInfo</exception>
        [HttpPost]
        public ActionResult EditLeaveType(LeaveTypeModelView leaveTypeInfo)
        {
            if (leaveTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveTypeInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.companySetupServices.GetLeaveTypeUpdateView(leaveTypeInfo, "");

                return this.View("EditLeaveType", model);
            }

            var processingMessage = companySetupServices.ProcessEditLeaveType(leaveTypeInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.companySetupServices.GetLeaveTypeUpdateView(leaveTypeInfo, "");

                return this.View("EditLeaveType", model);
            }

            processingMessage = string.Format("{0} edited successfully", leaveTypeInfo.LeaveTypeName);

            return this.RedirectToAction("LeaveTypeList", new { message = processingMessage });
        }

        /// <summary>
        /// Deletes the type of the leave.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">leaveTypeId</exception>
        public ActionResult DeleteLeaveType(int leaveTypeId, string message)
        {
            if (leaveTypeId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(leaveTypeId));
            }

            var viewModel = companySetupServices.GetLeaveTypeEditView(leaveTypeId, message);

            return this.PartialView("DeleteLeaveType", viewModel);
        }

        /// <summary>
        /// Deletes the type of the leave.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeId</exception>
        [HttpPost]
        public ActionResult DeleteLeaveType(int leaveTypeId)
        {
            if (leaveTypeId <= 0)
            {
                throw new ArgumentNullException(nameof(leaveTypeId));
            }

            var message = companySetupServices.DeleteLeaveType(leaveTypeId);

            var returnMessage = string.Format("Selected Leave Type has been deleted");

            return RedirectToAction("LeaveTypeList", new { message = returnMessage });
        }

        #endregion

        #region //----------------------------------------Benefit Section------------------------------------//

        /// <summary>
        /// Benefits the list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedDepartmentId">The selected department identifier.</param>
        /// <param name="selectedDepartment">The selected department.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult BenefitList(string selectedCompanyName, string selectedBenefitName,
            string message)
        {
            var viewModel = companySetupServices.CreateBenefitList(selectedBenefitName, selectedCompanyName, message);

            return this.View("BenefitList", viewModel);
        }

        /// <summary>
        /// Creates the benefit.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateBenefit()
        {

            var viewModel = this.companySetupServices.GetBenefitCreateView();

            return this.PartialView("CreateBenefit", viewModel);
        }

        /// <summary>
        /// Creates the benefit.
        /// </summary>
        /// <param name="benefitModel">The benefit model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitModel</exception>
        [HttpPost]
        public ActionResult CreateBenefit(BenefitModelView benefitModel, HttpPostedFileBase benefitExcelFile)
        {

            var processingMessage = String.Empty;
            if (benefitExcelFile != null)
            {



                processingMessage = this.companySetupServices.ProcessUploadExcelBenefit(benefitExcelFile);


                if (!string.IsNullOrEmpty(processingMessage))
                {
                    var viewModel = this.companySetupServices.GetBenefitCreateView(benefitModel, processingMessage);

                    return this.View("CreateBenefit", viewModel);
                }

                processingMessage = string.Format("{0} successful added", benefitModel.BenefitName);

                return this.RedirectToAction("BenefitList", "CompanySetup", new { message = processingMessage });
            }

            if (benefitModel == null)
            {
                throw new ArgumentNullException(nameof(benefitModel));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetBenefitCreateView(benefitModel, string.Empty);

                return this.View("CreateBenefit", viewModel);
            }

            processingMessage = this.companySetupServices.ProcessBenefitInfo(benefitModel);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.companySetupServices.GetBenefitCreateView(benefitModel, processingMessage);

                return this.View("CreateBenefit", model);
            }

            processingMessage = string.Format("New Benefit named - {0}", benefitModel.BenefitName);

            return RedirectToAction("BenefitList", "CompanySetup",
                new
                {
                    companyId = benefitModel.CompanyId,
                    message = processingMessage
                });
        }

        /// <summary>
        /// Edits the benefit.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitId</exception>
        [HttpGet]
        public ActionResult EditBenefit(int benefitId)
        {
            if (benefitId <= 0)
            {
                throw new ArgumentNullException(nameof(benefitId));
            }
            
            var viewModel = this.companySetupServices.GetBenefitEditView(benefitId);

            return this.PartialView("EditBenefit", viewModel);
        }

        /// <summary>
        /// Edits the benefit.
        /// </summary>
        /// <param name="benefitInfo">The benefit information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitInfo</exception>
        [HttpPost]
        public ActionResult EditBenefit(BenefitModelView benefitInfo)
        {
            if (benefitInfo == null)
            {
                throw new ArgumentNullException(nameof(benefitInfo));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetBenefitCreateView(benefitInfo, string.Empty);

                return this.View("EditBenefit", viewModel);
            }

            var processingMessage = this.companySetupServices.ProcessEditBenefitInfo(benefitInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.companySetupServices.GetBenefitCreateView(benefitInfo, processingMessage);

                return this.View("EditBenefit", model);
            }
            var returnMessage = string.Format("{0} Edited Successfully", benefitInfo.BenefitName);

            return RedirectToAction("BenefitList", "CompanySetup",
                new
                {
                    message = returnMessage
                });
        }

        /// <summary>
        /// Deletes the specified benefit identifier.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteBenefit(int benefitId)
        {
            if (benefitId < 0)
            {
                throw new ArgumentNullException(nameof(benefitId));
            }
            
            var viewModel = this.companySetupServices.GetBenefitEditView(benefitId);

            return this.PartialView("DeleteBenefit", viewModel);
        }

        /// <summary>
        /// Deletes the confirm.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteBenefit(int benefitId, string btnSubmit)
        {
            if (benefitId < 0)
            {
                throw new ArgumentNullException(nameof(benefitId));
            }

            var viewModel = this.companySetupServices.ProcessDeleteBenefitInfo(benefitId);

            viewModel = string.Format("Benefit Deleted");

            return RedirectToAction("BenefitList", "CompanySetup", new { message = viewModel });
        }

        #endregion

        #region //------------------------------------------Reward Section--------------------------------//

        /// <summary>
        /// Rewards the list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedReward">The selected reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public ActionResult RewardList(string selectedReward, string message)
        {

            var levelView = companySetupServices.GetRewardList(selectedReward, message);

            return this.View("RewardList", levelView);
        }

        // GET: Reward/Create        
        /// <summary>
        /// Creates the reward.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public ActionResult CreateReward()
        {
            var viewModel = this.companySetupServices.GetCreateRewardView();

            return this.PartialView("CreateReward", viewModel);
        }

        // POST: Reward/Create        
        /// <summary>
        /// Creates the reward.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">reward</exception>
        [HttpPost]
        public ActionResult CreateReward(RewardView reward)
        {
            if (reward == null)
            {
                throw new ArgumentNullException(nameof(reward));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetRewardUpadteView(reward, string.Empty);

                return this.View("CreateReward", viewModel);
            }

            var returnMessage = this.companySetupServices.ProcessCreateRewardInfo(reward);

            if (!string.IsNullOrEmpty(returnMessage))
            {
                var viewModel = this.companySetupServices.GetRewardUpadteView(reward, returnMessage);

                return this.View("CreateReward", viewModel);
            }

            returnMessage = string.Format("New Reward Added - {0}", reward.RewardName);

            return this.RedirectToAction("RewardList", new { message = returnMessage });
        }

        // GET: Reward/Edit/5        
        /// <summary>
        /// Edits the reward.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardId</exception>
        [HttpGet]
        public ActionResult EditReward(int rewardId)
        {
            if (rewardId <= 0)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            var viewModel = this.companySetupServices.GetRewardEditView(rewardId);

            return this.PartialView("EditReward", viewModel);
        }

        // POST: Reward/Edit/5        
        /// <summary>
        /// Edits the reward.
        /// </summary>
        /// <param name="reward">The reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">reward</exception>
        [HttpPost]
        public ActionResult EditReward(RewardView reward)
        {
            if (reward == null)
            {
                throw new ArgumentNullException(nameof(reward));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetRewardUpadteView(reward, string.Empty);

                return this.View("EditReward", viewModel);
            }

            var returnMessage = this.companySetupServices.ProcessEditRewardInfo(reward);

            if (!string.IsNullOrEmpty(returnMessage))
            {
                var viewModel = this.companySetupServices.GetRewardUpadteView(reward, returnMessage);

                return this.View("EditReward", viewModel);
            }

            returnMessage = string.Format("{0} edited successfully", reward.RewardName);

            return this.RedirectToAction("RewardList", new { message = returnMessage, companyId = reward.CompanyId });

        }

        // GET: Reward/Delete/5        
        /// <summary>
        /// Deletes the reward.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardId</exception>
        [HttpGet]
        public ActionResult DeleteReward(int rewardId)
        {

            if (rewardId <= 0)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            var viewModel = this.companySetupServices.GetRewardEditView(rewardId);

            return this.PartialView("DeleteReward", viewModel);
        }

        // POST: Reward/Delete/5        
        /// <summary>
        /// Deletes the reward.
        /// </summary>
        /// <param name="rewardId">The reward identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardId</exception>
        [HttpPost]
        public ActionResult DeleteReward(int rewardId, string btnSubmit)
        {
            if (rewardId <= 0)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            var returnModel = this.companySetupServices.ProcessDeleteRewardInfo(rewardId);

            returnModel = "Reward Deleted";

            return this.RedirectToAction("RewardList", new { message = returnModel });

        }

        #endregion
        
        #region //----------------------------------------------Loan Section----------------------------------------------------//

        // GET: Loan/list        
        /// <summary>
        /// Lists the specified selected company.
        /// </summary>
        /// <param name="selectedCompany">The selected company.</param>
        /// <returns></returns>
        public ActionResult LoanList(int? selectedCompany, string message)
        {
            var viewModel = this.companySetupServices.GetLoansList(selectedCompany ?? -1, message);

            return this.View("LoanList", viewModel);
        }

        /// <summary>
        /// Employees the loan list.
        /// </summary>
        /// <param name="selectedEmployeeLoan">The selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult EmployeeLoanList(string selectedEmployeeLoan, string selectedCompanyName,
            string selectedEmployeeName, string message)
        {
            var viewModel = this.companySetupServices.GetEmployeeLoansList(selectedEmployeeLoan, selectedCompanyName,
            selectedEmployeeName, message);

            viewModel.URL = "/CompanySetup/EmployeeLoanList?message=";

            return this.View("EmployeeLoanList", viewModel);
        }

        /// <summary>
        /// Employees the loan employee list.
        /// </summary>
        /// <param name="selectedEmployeeLoan">The selected employee loan.</param>
        /// <param name="selectedCompanyName">Name of the selected company.</param>
        /// <param name="selectedEmployeeName">Name of the selected employee.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeeLoanEmployeeList(string selectedEmployeeLoan, string selectedCompanyName,
            string selectedEmployeeName, string message)
        {
            var viewModel = this.companySetupServices.GetEmployeeLoansListByEmployee(selectedEmployeeLoan, selectedCompanyName,
            selectedEmployeeName, string.Empty);

            viewModel.URL = "/CompanySetup/EmployeeLoanEmployeeList?message=";

            return this.View("EmployeeLoanList", viewModel);
        }


        /// <summary>
        /// Employees the loan.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmployeeLoan(int employeeId, string message)
        {

            var viewModel = this.companySetupServices.GetEmployeeLoansList(employeeId, message);

            viewModel.URL = "/CompanySetup/EmployeeLoan?employeeId=" + employeeId + "&message=";

            return this.View("EmployeeLoan", viewModel);
        }

        /// <summary>
        /// Views the employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewEmployeeLoan(int employeeLoanId)
        {
            var viewModel = this.companySetupServices.CreateEditEmployeeLoan(employeeLoanId, string.Empty);

            return this.PartialView("ViewEmployeeLoan", viewModel);
        }

        /// <summary>
        /// Edits the employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditEmployeeLoan (int employeeLoanId, string url)
        {

            var viewModel = this.companySetupServices.CreateEditEmployeeLoan(employeeLoanId, string.Empty);

            viewModel.URL = url;
            
            return this.PartialView("EditEmployeeLoan", viewModel);

        }

        /// <summary>
        /// Edits the employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeLoanView
        /// or
        /// logUserId
        /// </exception>
        [HttpPost]
        public ActionResult EditEmployeeLoan (EmployeeLoanView employeeLoanView)
        {

            //Check that loan info is not null
            if (employeeLoanView == null)
            {
                throw new ArgumentNullException(nameof(employeeLoanView));
            }


            //Validate Model
            if (!ModelState.IsValid)
            {
                var viewModel = companySetupServices.GetEmployeetLoanUpdateView(employeeLoanView, string.Empty);

                return View("EditEmployeeLoan", viewModel);
            }

            var returnModel = this.companySetupServices.ProcessEditEmployeeLoan(employeeLoanView);

            if (!string.IsNullOrEmpty(returnModel))
            {
                var viewModel = companySetupServices.GetEmployeetLoanUpdateView(employeeLoanView, returnModel);

                //return this.View("EditEmployeeLoan", viewModel);
            }

            returnModel = string.Format("{0} Modify of Loan Successfully", employeeLoanView.LoanName);

            employeeLoanView.URL += "&message=" + returnModel;

            return this.Redirect(employeeLoanView.URL);
           

        }

        /// <summary>
        /// Deletes the employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoanId</exception>
        [HttpGet]
        public ActionResult DeleteEmployeeLoan(int employeeLoanId, string url)
        {

            if (employeeLoanId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeLoanId));
            }

            var viewModel = this.companySetupServices.CreateDeleteEmployeeLoan(employeeLoanId, string.Empty);

            viewModel.URL = url;

            return this.PartialView("DeleteEmployeeLoan", viewModel);

        }

        /// <summary>
        /// Deletes the employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoanView</exception>
        [HttpPost]
        public ActionResult DeleteEmployeeLoan(EmployeeLoanView employeeLoanView)
        {

            //Check that loan info is not null
            if (employeeLoanView == null)
            {
                throw new ArgumentNullException(nameof(employeeLoanView));
            }
            
            //Validate Model
            if (!ModelState.IsValid)
            {
                var viewModel = companySetupServices.GetEmployeetLoanUpdateView(employeeLoanView, string.Empty);

                return View("ApplyLoan", viewModel);
            }
            var returnModel = this.companySetupServices.ProcessDeleteEmployeeLoan(employeeLoanView);

            if (!string.IsNullOrEmpty(returnModel))
            {
                var viewModel = companySetupServices.GetEmployeetLoanUpdateView(employeeLoanView, returnModel);

                return this.View("ApplyLoan", returnModel);
            }

            returnModel = string.Format("{0} Delete of Loan Successfully", employeeLoanView.LoanName);

            employeeLoanView.URL += "&message=" + returnModel;

            return this.Redirect(employeeLoanView.URL);

        }
        
        /// <summary>
        /// Applies the loan.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">logUserId</exception>
        [HttpGet]
        public ActionResult ApplyLoan(string url)
        {
            int employeeId = (int)this.session.GetSessionValue(SessionKey.UserId);

            var viewModel = companySetupServices.GetEmployeeLoanRegistrationView();

            viewModel.URL = url;

            return this.PartialView("EmployeeApplyLoan", viewModel);
        }

        /// <summary>
        /// It is a List of Employee's loan.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">logUserId</exception>
        [HttpGet]
        public ActionResult EmployeeApplyLoan(int employeeId, string url)
        {
            var viewModel = companySetupServices.GetEmployeeLoanRegistrationView(employeeId);

            viewModel.URL = url;

            return this.PartialView("EmployeeApplyLoan", viewModel);
        }

        /// <summary>
        /// Applies the loan.
        /// </summary>
        /// <param name="employeeLoanInfo">The employee loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoanInfo</exception>
        [HttpPost]
        public ActionResult ApplyLoan(EmployeeLoanView employeeLoanInfo)
        {
            //Check that loan info is not null
            if (employeeLoanInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeLoanInfo));
            }

            //Validate Model
            if (!ModelState.IsValid)
            {
                var viewModel = companySetupServices.GetEmployeetLoanUpdateView(employeeLoanInfo, string.Empty);

                return View("EmployeeApplyLoan", viewModel);
            }

            //Process The loan Information
            var returnModel = companySetupServices.ProcessEmployeeLoanInfo(employeeLoanInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(returnModel))
            {
                var viewModel = companySetupServices.GetEmployeetLoanUpdateView(employeeLoanInfo, returnModel);

                return this.View("EmployeeApplyLoan", viewModel);
            }

            returnModel = string.Format("Application of Loan Successful");

            employeeLoanInfo.URL += "&message=" + returnModel;

            return this.Redirect(employeeLoanInfo.URL);
        }

        // GET: Loan/Create                
        /// <summary>
        /// Creates the loan.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateLoan()
        {

            var viewModel = companySetupServices.GetLoanRegistrationView();

            return this.PartialView("CreateLoan", viewModel);
        }

        // POST: Loan/Create        
        /// <summary>
        /// Creates the specified loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLoan(LoanView loanInfo)
        {
            //Check that loan info is not null
            if (loanInfo == null)
            {
                throw new ArgumentNullException(nameof(loanInfo));
            }


            //Validate Model
            if (!ModelState.IsValid)
            {
                var viewModel = companySetupServices.GetLoanUpadteView(loanInfo, string.Empty);
                return View("CreateLoan", viewModel);
            }

            //Process The loan Information
            var returnModel = companySetupServices.ProcessLoanInfo(loanInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(returnModel))
            {
                var viewModel = companySetupServices.GetLoanUpadteView(loanInfo, returnModel);
                return this.View("CreateLoan", returnModel);
            }

            returnModel = string.Format("{0} Created Successfully", loanInfo.LoanType);

            return this.RedirectToAction("LoanList", "CompanySetup", new { message = returnModel });
        }

        // GET: Loan/Edit/5        
        /// <summary>
        /// Edits the loan.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditLoan(int loanId)
        {
            var viewModel = companySetupServices.GetLoanEditView(loanId);

            return this.PartialView("EditLoan", viewModel);
        }

        // POST: Loan/Edit/5        
        /// <summary>
        /// Edits the specified loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLoan(LoanView loanInfo)
        {
            if (loanInfo == null)
            {
                throw new ArgumentNullException(nameof(loanInfo));
            }

            if (!ModelState.IsValid)
            {

                var viewModel = companySetupServices.GetLoanUpadteView(loanInfo, string.Empty);

                return this.View("EditLoan", viewModel);
            }

            var returnModel = companySetupServices.ProcessEditLoanInfo(loanInfo);

            if (!string.IsNullOrEmpty(returnModel))
            {
                var viewModel = companySetupServices.GetLoanUpadteView(loanInfo, returnModel);

                return this.View("EditLoan", viewModel);
            }

            returnModel = string.Format("{0} Loan update successful", loanInfo.LoanType);

            return this.RedirectToAction("LoanList", new { message = returnModel });
        }

        // GET: Loan/Delete/5        
        /// <summary>
        /// Deletes the specified loan identifier.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        public ActionResult DeleteLoan(int loanId)
        {
            var viewModel = companySetupServices.GetLoanEditView(loanId);

            return this.PartialView("DeleteLoan", viewModel);
        }

        // POST: Loan/Delete/5        
        /// <summary>
        /// Deletes the loan.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">loanId</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLoan(int loanId, string btnSubmit)
        {
            if (loanId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(loanId));
            }

            var returnModel = companySetupServices.ProcessDeleteLoanInfo(loanId);

            if (string.IsNullOrEmpty(returnModel))
            {
                returnModel = string.Format("Deleted Successfull");
            }
            
            return RedirectToAction("LoanList", "CompanySetup");
        }

        #endregion

        #region //------------------------------------------------Level Section----------------------------------------------------//

        /// <summary>
        /// Levels the list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <returns></returns>
        public ActionResult LevelList(string selectedLevel, int? companyId, string message)
        {
            var levelView = companySetupServices.GetLevelList(selectedLevel, companyId ?? -1, message);

            return this.View("LevelList", levelView);
        }

        /// <summary>
        /// Creates the level.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        [HttpGet]
        public ActionResult CreateLevel()
        {
            var viewModel = this.companySetupServices.GetLevelRegistrationView();

            return this.PartialView("CreateLevel", viewModel);
        }

        // POST: Level/Create        
        /// <summary>
        /// Creates the level.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLevel(LevelView levelInfo, HttpPostedFileBase excelFile)
        {

            if (excelFile != null)
            {

                var processingMessage = this.companySetupServices.ProcessUploadExcelLevel(excelFile);


                if (!string.IsNullOrEmpty(processingMessage))
                {
                    var viewModel = this.companySetupServices.GetLevelUpdateView(levelInfo, processingMessage);

                    return this.View("CreateLevel", viewModel);
                }
                
                processingMessage = string.Format("{0} successful added", levelInfo.LevelName);

                return this.RedirectToAction("LevelList", "CompanySetup", new { message = processingMessage });
            }

            if (levelInfo == null)
            {
                throw new ArgumentNullException(nameof(levelInfo));
            }

            
            
            //Validate Model
            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetLevelUpdateView(levelInfo, string.Empty);

                return View("CreateLevel", viewModel);
            }

            var returnModel = companySetupServices.ProcessLevelInfo(levelInfo);


            //Check if the Processing Message is Not Empty
            //If it is not empty, Means there is no error
            if (!string.IsNullOrEmpty(returnModel))
            {
                var viewModel = this.companySetupServices.GetLevelUpdateView(levelInfo, returnModel);

                return this.View("CreateLevel", viewModel);
            }
            

            returnModel = string.Format("{0} successful added", levelInfo.LevelName);

            return this.RedirectToAction("LevelList", "CompanySetup", new { message = returnModel });
        }

        // GET: Level/Edit/5        
        /// <summary>
        /// Edits the specified level identifier.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditLevel(int levelId)
        {
            if (levelId == 0)
            {
                throw new ArgumentNullException(nameof(levelId));
            }

            var viewModel = companySetupServices.GetLevelEditView(levelId);

            return this.PartialView(viewModel);
        }

        // POST: Level/Edit/5        
        /// <summary>
        /// Edits the specified level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelInfo</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLevel(LevelView levelInfo)
        {
            if (levelInfo == null)
            {
                throw new ArgumentNullException(nameof(levelInfo));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetLevelUpdateView(levelInfo, string.Empty);

                return View("EditLevel", viewModel);
            }

            var returnModel = companySetupServices.ProcessEditLevelInfo(levelInfo);

            if (!string.IsNullOrEmpty(returnModel))
            {

                var viewModel = this.companySetupServices.GetLevelUpdateView(levelInfo, returnModel);

                return View("EditLevel", viewModel);
            }

            returnModel = string.Format("{0} update successful", levelInfo.LevelName);

            return RedirectToAction("LevelList", new { message = returnModel });
        }

        // GET: Level/Delete/5        
        /// <summary>
        /// Deletes the level.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteLevel(int levelId)
        {
            if(levelId == 0)
            {
                throw new ArgumentNullException(nameof(levelId));
            }

            var viewModel = companySetupServices.GetLevelEditView(levelId);

            return this.PartialView("DeleteLevel", viewModel);

        }

        // POST: Level/Delete/5        
        /// <summary>
        /// Deletes the level.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">levelId</exception>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLevel(int levelId, string btnSubmit)
        {
            if (levelId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(levelId));
            }

            var returnModel = companySetupServices.ProcessDeleteLevelInfo(levelId);

            returnModel = string.Format("You Deleted a Level");

            return RedirectToAction("LevelList", "CompanySetup", new { message = returnModel });
        }

        /// <summary>
        /// Fetches the levels.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public JsonResult FetchLevels(int companyId)
        {
            var levels = this.companySetupServices.GetLevelCollection(companyId);

            return Json(levels, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region //-----------------------------------------------------Deduction Section----------------------------------------------//

        /// <summary>
        /// Deductions the list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedDeduction">The selected deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public ActionResult DeductionList(string selectedDeduction, string message)
        {
            var levelView = companySetupServices.GetDeductionList(selectedDeduction, message);

            return this.View("DeductionList", levelView);
        }

        /// <summary>
        /// Creates the deduction.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public ActionResult CreateDeduction()
        {
            var viewModel = this.companySetupServices.GetCreateDeductionView();

            return this.PartialView("CreateDeduction", viewModel);
        }

        /// <summary>
        /// Creates the deduction.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deduction</exception>
        [HttpPost]
        public ActionResult CreateDeduction(DeductionViewModel deduction)
        {
            if (deduction == null)
            {
                throw new ArgumentNullException(nameof(deduction));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetDeductionUpadteView(deduction, string.Empty);

                return this.View("CreateDeduction", viewModel);
            }

            var returnMessage = this.companySetupServices.ProcessCreateDeductionInfo(deduction);

            if (!string.IsNullOrEmpty(returnMessage))
            {
                var viewModel = this.companySetupServices.GetDeductionUpadteView(deduction, returnMessage);

                return this.View("CreateDeduction", viewModel);
            }

            returnMessage = string.Format("New Deduction Added - {0}", deduction.DeductionName);

            return this.RedirectToAction("DeductionList", new { message = returnMessage, companyId = deduction.CompanyId });
        }

        /// <summary>
        /// Edits the deduction.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deductionId</exception>
        public ActionResult EditDeduction(int deductionId)
        {
            if (deductionId <= 0)
            {
                throw new ArgumentNullException(nameof(deductionId));
            }

            var viewModel = this.companySetupServices.GetDeductionEditView(deductionId);

            return this.PartialView("EditDeduction", viewModel);
        }

        /// <summary>
        /// Edits the deduction.
        /// </summary>
        /// <param name="deduction">The deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deduction</exception>
        [HttpPost]
        public ActionResult EditDeduction(DeductionViewModel deduction)
        {
            if (deduction == null)
            {
                throw new ArgumentNullException(nameof(deduction));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetDeductionUpadteView(deduction, string.Empty);

                return this.View("EditDeduction", viewModel);
            }

            var returnMessage = this.companySetupServices.ProcessEditDeductionInfo(deduction);

            if (!string.IsNullOrEmpty(returnMessage))
            {
                var viewModel = this.companySetupServices.GetDeductionUpadteView(deduction, returnMessage);

                return this.View("EditDeduction", viewModel);
            }

            returnMessage = string.Format("{0} Edited", deduction.DeductionName);

            return this.RedirectToAction("DeductionList", new { message = returnMessage });

        }

        /// <summary>
        /// Deletes the deduction.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">rewardId</exception>
        public ActionResult DeleteDeduction(int deductionId)
        {

            if (deductionId <= 0)
            {
                throw new ArgumentNullException(nameof(deductionId));
            }

            var viewModel = this.companySetupServices.GetDeductionEditView(deductionId);

            return this.PartialView("DeleteDeduction", viewModel);
        }

        /// <summary>
        /// Deletes the deduction.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deductionId</exception>
        [HttpPost]
        public ActionResult DeleteDeduction(int deductionId, string btnSubmit)
        {
            if (deductionId <= 0)
            {
                throw new ArgumentNullException(nameof(deductionId));
            }

            var returnModel = this.companySetupServices.ProcessDeleteDeductionInfo(deductionId);
            

            returnModel = "Deduction Deleted";

            return this.RedirectToAction("DeductionList", new { message = returnModel });

        }

        #endregion

        #region //-----------------------------------------------------Level Grade Section----------------------------------------------//  

        /// <summary>
        /// Levels the grade list.
        /// </summary>
        /// <param name="selectedLevel">The selected level.</param>
        /// <param name="selectedGrade">The selected grade.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult PayScaleList(string selectedLevel, string selectedGrade, string selectedCompany, string message)
        {
            var Model = this.companySetupServices.GetLevelGradeList(selectedLevel, selectedGrade, selectedCompany, message);

            return this.View("PayScaleList", Model);
        }

        /// <summary>
        /// Adds the level grade.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddLevelGrade()
        {

            var viewModel = this.companySetupServices.GetCreateLevelGradeView();

            return this.View("AddLevelGrade", viewModel);
        }

        /// <summary>
        /// Adds the level grade.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeInfo</exception>
        [HttpPost]
        public ActionResult AddLevelGrade(PayScaleModel levelGradeInfo, List<PayScaleBenefitModel> payScalebenefits,
            List<int> selectedBenefits)
        {
            if (levelGradeInfo == null)
            {
                throw new ArgumentNullException(nameof(levelGradeInfo));
            }
            

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetLevelGradeUpadteView(levelGradeInfo, payScalebenefits, selectedBenefits, string.Empty);

                return this.View("AddLevelGrade", viewModel);
            }

            var returnMessage = this.companySetupServices.ProcessLevelGradeInfo(levelGradeInfo, payScalebenefits, selectedBenefits);

            if (!string.IsNullOrEmpty(returnMessage))
            {
                var viewModel = this.companySetupServices.GetLevelGradeUpadteView(levelGradeInfo, payScalebenefits, selectedBenefits, returnMessage);

                return this.View("AddLevelGrade", viewModel);
            }

            returnMessage = string.Format("New Salary Scale Added for {0} Grade {1} Level", levelGradeInfo.GradeName, levelGradeInfo.LevelName);

            return this.RedirectToAction("PayScaleList", new { message = returnMessage });
        }

        /// <summary>
        /// Edits the level grade.
        /// </summary>
        /// <param name="levelGradeId">The level grade identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeId</exception>
        [HttpGet]
        public ActionResult EditLevelGrade(int levelGradeId)
        {
            if (levelGradeId <= 0)
            {
                throw new ArgumentNullException(nameof(levelGradeId));
            }
            
            var viewModel = this.companySetupServices.GetLevelGradeEditView(levelGradeId);

            return this.View("EditLevelGrade", viewModel);
        }
        /// <summary>
        /// Edits the level grade.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeInfo</exception>
        [HttpPost]
        public ActionResult EditLevelGrade(PayScaleModel levelGradeInfo, List<PayScaleBenefitModel> payScalebenefits,
            List<int> selectedBenefits)
        {
            if (levelGradeInfo == null)
            {
                throw new ArgumentNullException(nameof(levelGradeInfo));
            }
            

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetLevelGradeUpadteView(levelGradeInfo, payScalebenefits, selectedBenefits, string.Empty);

                return this.View("EditLevelGrade", viewModel);
            }

            var returnMessage = this.companySetupServices.ProcessLevelGradeEditInfo(levelGradeInfo, payScalebenefits, selectedBenefits);

            if (!string.IsNullOrEmpty(returnMessage))
            {
                var viewModel = this.companySetupServices.GetLevelGradeUpadteView(levelGradeInfo, payScalebenefits, selectedBenefits, returnMessage);

                return this.View("EditLevelGrade", viewModel);
            }

            returnMessage = string.Format("Level {0} Grade {1} Edited successfully", levelGradeInfo.GradeName, levelGradeInfo.LevelName);

            return this.RedirectToAction("PayScaleList", "CompanySetup", new { message = returnMessage });
        }
        /// <summary>
        /// Deletes the level grade.
        /// </summary>
        /// <param name="levelGradeId">The level grade identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeId</exception>
        [HttpGet]
        public ActionResult DeleteLevelGrade(int levelGradeId)
        {
            if (levelGradeId <= 0)
            {
                throw new ArgumentNullException(nameof(levelGradeId));
            }
            
            
            var viewModel = this.companySetupServices.GetLevelGradeEditView(levelGradeId);

            return this.View("DeleteLevelGrade", viewModel);
        }

        /// <summary>
        /// Deletes the level grade.
        /// </summary>
        /// <param name="levelGradeId">The level grade identifier.</param>
        /// <param name="submitBtn">The submit BTN.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeId</exception>
        [HttpPost]
        public ActionResult DeleteLevelGrade(int levelGradeId, string submitBtn)
        {
            if (levelGradeId <= 0)
            {
                throw new ArgumentNullException(nameof(levelGradeId));
            }

            var returnModel = this.companySetupServices.ProcessDeleteLevelGradeInfo(levelGradeId);
            
            returnModel = "Level Deleted";

            return this.RedirectToAction("PayScaleList", "CompanySetup", new { message = returnModel });
        }

        /// <summary>
        /// Payscalebenefitses the specified payscale identifier.
        /// </summary>
        /// <param name="payscaleId">The payscale identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payscaleId</exception>
        public ActionResult Payscalebenefits(int payscaleId, string message)
        {

            if (payscaleId <= 0) throw new ArgumentNullException(nameof(payscaleId));

            var viewModel = this.companySetupServices.GetPayscalebenefit(payscaleId, message);
            
            return View("Payscalebenefits", viewModel);
        }

        /// <summary>
        /// Fetches the grade level.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public JsonResult FetchGradeLevel(int companyId)
        {
            var gradeLevel = companySetupServices.GetGradeLevelCollection(companyId);

            return Json(gradeLevel, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region //-----------------------------------------------------Tax Section --------------------------------------------------------//

        /// <summary>
        /// Taxes the list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TaxList()
        {

            var Model = this.companySetupServices.GetTaxList();

            return this.View("TaxList", Model);
        }

        #endregion

        #region //----------------------------------------------------Employee Reward Begins Here----------------------------------------------------//

        /// <summary>
        /// Gets the employee reward list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public ActionResult GetEmployeeRewardList(int employeeId)
        {
            var viewModel = this.companySetupServices.GetEmployeeRewardList(employeeId, "");

            return this.View("GetEmployeeRewardList", viewModel);
        }

        /// <summary>
        /// Creates the employee reward view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateEmployeeRewardView(int employeeId)
        {
            var viewModel = this.companySetupServices.CreateEmployeeRewardByCompanyId(employeeId, string.Empty);
            return this.PartialView("CreateEmployeeRewardView", viewModel);
        }

        /// <summary>
        /// Creates the employee reward view.
        /// </summary>
        /// <param name="RewardModel">The reward model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">RewardModel</exception>
        [HttpPost]
        public ActionResult CreateEmployeeRewardView(EmployeeRewardViewModel RewardModel)
        {
            if (RewardModel == null)
            {
                throw new ArgumentNullException(nameof(RewardModel));
            }

            var userId = (int)this.session.GetSessionValue(SessionKey.UserId);

            if (!ModelState.IsValid)
            {
                var employeeCreateView = this.companySetupServices.CreateEmployeeRewardEditView(RewardModel, userId,"");
                return this.View("CreateEmployeeRewardView", employeeCreateView);
            }

            var viewModel = this.companySetupServices.ProcessEmployeeReward(RewardModel);

            if (!string.IsNullOrEmpty(viewModel))
            {
                var employeeCreateView = this.companySetupServices.CreateEmployeeRewardEditView(RewardModel, userId, "");
                return this.View("CreateEmployeeRewardView", employeeCreateView);
            }

            viewModel = "Employee Reward successfully added";

            return this.RedirectToAction("GetEmployeeRewardList", new { employeeId = RewardModel.EmployeeId });

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedEmployeeLoan"></param>
        /// <param name="selectedCompanyName"></param>
        /// <param name="selectedEmployeeName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ActionResult EmployeeDeductionList(string selectedEmployeeLoan, string selectedCompanyName,
           string selectedEmployeeName, string message)
        {

            var viewModel = this.companySetupServices.GetEmployeeDeductionsListByEmployee(selectedEmployeeLoan, selectedCompanyName,
            selectedEmployeeName, message);

            return this.View("EmployeeDeductionList", viewModel);
        }
        
        /// <summary>
        /// Creates the employee deduction.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateEmployeeDeduction(int employeeId)
        {
            var viewModel = this.companySetupServices.DeductionByCompanyId(employeeId,  string.Empty);

            return PartialView("CreateEmployeeDeduction", viewModel);
        }

        /// <summary>
        /// Creates the employee deduction.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeduction</exception>
        [HttpPost]
        public ActionResult CreateEmployeeDeduction(DeductionViewModel employeeDeduction)
        {
            if (employeeDeduction == null)
            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }

            if (!ModelState.IsValid)
            {
                var viewModel = this.companySetupServices.GetUpdateDeduction(employeeDeduction, string.Empty);

                return this.View("CreateEmployeeDeduction", viewModel);
            }

            var returnMessage = this.companySetupServices.ProcessDeductionInfo(employeeDeduction);

            if (!string.IsNullOrEmpty(returnMessage))
            {
                var viewModel = this.companySetupServices.GetUpdateDeduction(employeeDeduction, returnMessage);

                return this.View("CreateEmployeeDeduction", viewModel);
            }

            returnMessage = string.Format("New Employee Deduction Added - {0}", employeeDeduction.DeductionName);

            var URL = "/EmployeeDeduction/EmployeeDeduction?employeeId=" + employeeDeduction.EmployeeId;

            return Redirect(URL + "&message=" + returnMessage);
        }

        /// <summary>
        /// Deletes the employee deduction.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="URL">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeductionId</exception>
        [HttpGet]
        public ActionResult DeleteEmployeeDeduction(int employeeDeductionId, int employeeId, string URL)
        {
            if (employeeDeductionId == 0)
            {
                throw new ArgumentNullException(nameof(employeeDeductionId));
            }

            var userId = (int)this.session.GetSessionValue(SessionKey.UserId);

            var viewModel = this.companySetupServices.GetEditEmployeeDeduction(userId, employeeDeductionId, employeeId);

            viewModel.URL = URL;
            return this.PartialView("DeleteEmployeeDeduction", viewModel);
        }

        /// <summary>
        /// Deletes the employee deduction.
        /// </summary>
        /// <param name="deductionViewModel">The deduction view model.</param>
        /// <param name="URL">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deductionViewModel</exception>
        [HttpPost]
        public ActionResult DeleteEmployeeDeduction(DeductionViewModel deductionViewModel, string URL)
        {

            if(deductionViewModel == null)
            {
                throw new ArgumentNullException(nameof(deductionViewModel));
            }

            var returnModel = this.companySetupServices.SaveDeleteEmployeeDeduction(deductionViewModel);
            
            returnModel = string.Format("You have successfully Deactivate");
          
            return Redirect(URL);
        }

        #endregion
    }
}