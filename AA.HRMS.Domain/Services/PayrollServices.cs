using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
using AA.HRMS.Repositories.Services;
using AA.Infrastructure.Interfaces;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace AA.HRMS.Domain.Services
{
    public class PayrollServices : Registry, IPayrollServices
    {
        private readonly IPayrollRepository payrollRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly IPayrollViewModelFactory payrollViewModelFactory;
        private readonly ILevelGradeRepository levelGradeRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IEmployeeDeductionRepository employeeDeductionRepository;
        private readonly IRewardRepository rewardRepository;
        private readonly ILoanRepository loanRepository;
        private readonly IUsersRepository usersRepository;
        private readonly ILevelRepository levelRepository;
        private readonly IGradeRepository gradeRepository;
        private readonly IBenefitRepository benefitRepository;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly IDigitalFileRepository digitalFileRepository;
        private readonly ISessionStateService session;


        public PayrollServices(IPayrollRepository payrollRepository, ILookupRepository lookupRepository, IEmployeeRepository employeeRepository,
            IPayrollViewModelFactory payrollViewModelFactory, ILevelGradeRepository levelGradeRepository, ICompanyRepository companyRepository,
            IEmployeeDeductionRepository employeeDeductionRepository, IRewardRepository rewardRepository, ILoanRepository loanRepository,
            IEmployeeOnBoardRepository employeeOnBoardRepository, IUsersRepository usersRepository, ILevelRepository levelRepository,
            IGradeRepository gradeRepository, IBenefitRepository benefitRepository, IDigitalFileRepository digitalFileRepository, ISessionStateService session)
        {
            this.lookupRepository = lookupRepository;
            this.payrollRepository = payrollRepository;
            this.payrollViewModelFactory = payrollViewModelFactory;
            this.levelGradeRepository = levelGradeRepository;
            this.employeeRepository = employeeRepository;
            this.employeeDeductionRepository = employeeDeductionRepository;
            this.companyRepository = companyRepository;
            this.rewardRepository = rewardRepository;
            this.loanRepository = loanRepository;
            this.usersRepository = usersRepository;
            this.levelRepository = levelRepository;
            this.gradeRepository = gradeRepository;
            this.benefitRepository = benefitRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.digitalFileRepository = digitalFileRepository;
            this.session = session;
        }


        //public PayrollServices()
        //{
        //    //Get all the schedule task for a specific companyId
        //    var scheduleCollection = this.lookupRepository.GetSchedules();

        //    //Check f any schedule exist
        //    if (scheduleCollection != null && scheduleCollection.Count > 0)
        //    {
        //        foreach (var item in scheduleCollection)
        //        {
        //            //check if the schedule is a Payroll
        //            if (item.ScheduleName.Contains("Payroll"))
        //            {
        //                // Schedule a more complex action to run immediately and on an monthly interval
        //                if (item.WeekId == 1)
        //                {
        //                    if (item.DayId == 1)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 2)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Tuesday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 3)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Wednesday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 4)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Thursday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 5)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Friday).At(0, 0);
        //                    }
        //                }
        //                else if (item.WeekId == 2)
        //                {
        //                    if (item.DayId == 1)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Monday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 2)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Tuesday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 3)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Wednesday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 4)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Thursday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 5)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheSecond(DayOfWeek.Friday).At(0, 0);
        //                    }
        //                }
        //                else if (item.WeekId == 3)
        //                {
        //                    if (item.DayId == 1)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Monday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 2)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Tuesday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 3)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Wednesday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 4)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Thursday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 5)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheThird(DayOfWeek.Friday).At(0, 0);
        //                    }
        //                }
        //                else if (item.WeekId == 4)
        //                {
        //                    if (item.DayId == 1)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Monday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 2)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Tuesday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 3)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Wednesday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 4)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Thursday).At(0, 0);
        //                    }
        //                    else if (item.DayId == 5)
        //                    {
        //                        Schedule<SchedulerServices>().ToRunNow().AndEvery(1).Months().OnTheFourth(DayOfWeek.Friday).At(0, 0);
        //                    }
        //                }

        //            }
        //        }
        //    }
        //}


        /// <summary>
        /// Gets the payroll view.
        /// </summary>
        /// <returns></returns>
        public IPayrollListView GetPayrollView()
        {

            var loggedUserDetails = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var employeeCollection = lookupRepository.GetEmployeeByCompanyId(companyId);
            var payrollCollection = payrollRepository.GetPayrollList(companyId);

            var monthDropDown = this.lookupRepository.GetAllMonths();
            var yearDropDown = this.lookupRepository.GetAllYears();


            var viewModel = this.payrollViewModelFactory.CreatePayrollView(companyId, employeeCollection, payrollCollection, monthDropDown, yearDropDown);

            return viewModel;
        }

        /// <summary>
        /// Gets the pay slip view.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// payrollId
        /// or
        /// payslip
        /// or
        /// employee
        /// </exception>
        public IPaySlipViewModel GetPaySlipView(int payrollId)
        {
            if (payrollId <= 0)
            {
                throw new ArgumentNullException(nameof(payrollId));
            }

            //Get the payroll information
            var payslip = this.payrollRepository.GetPayrollById(payrollId);

            if (payslip == null)
            {
                throw new ArgumentNullException(nameof(payslip));
            }

            //Get the emlpoyee information for this payslip 
            var employee = this.employeeRepository.GetEmployeeById(payslip.EmployeeId);

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            //Get  the reward of an employee
            var rewardCollection = this.payrollRepository.GetPayrollEmployeeRewardByPayrollId(payslip.PayrollId);

            //Get the loans an employee applied for 
            var loanCollection = this.payrollRepository.GetPayrollEmployeeLoanByPayrollId(payslip.PayrollId);

            //Get the company an employee belong to 
            var companyInfo = this.companyRepository.GetCompanyById(employee.CompanyId);

            //Get the pay scale of the employee
            var payScale = this.levelGradeRepository.GetLevelGradeByLevelIdAndGradeId(employee.CompanyId, employee.LevelId, employee.GradeId);

            //Get the benefits  for a sppecific pay scale 
            var payScaleBenefits = this.levelGradeRepository.GetIPayScaleBenefitByPayScaleId(payScale.PayScaleId);


            //Get the level of the employee
            var level = this.levelRepository.GetLevelById(employee.LevelId);

            var isLevelRecordExist = (level == null) ? false : true;

            //Get the grade of the employee
            var grade = this.gradeRepository.GetGradeById(employee.GradeId);

            var isGradeRecordExist = (grade == null) ? false : true;

            //Get employee deduction 
            var employeeDeductionCollection = this.payrollRepository.GetPayrollEmployeeDeductionByPayrollId(payslip.PayrollId);

            //Get profilePictureDetail
            var companyLogo = this.digitalFileRepository.GetDigitalFileDetail(companyInfo.LogoDigitalFileId ?? -1);

            //Get Tax rates
            var taxCollection = this.lookupRepository.GetAllTax();

            decimal benefitTaxable = 0;
            decimal benefitNotTaxable = 0;
            decimal basicSalary = payScale.BasePay;


            if (payScaleBenefits != null)
            {
                foreach (var benefits in payScaleBenefits)
                {
                    if (benefits.IsTaxable)
                    {
                        if (benefits.PercentageofBase <= 0)
                        {
                            var benefitAmount = benefits.CashValue;

                            benefitTaxable += (decimal)benefitAmount;

                            if (benefits.Period.Contains("Quarterly"))
                            {
                                benefitTaxable = benefitTaxable / 4;
                            }
                            else if (benefits.Period.Equals("Annually"))
                            {
                                benefitTaxable = benefitTaxable / 12;
                            }
                            else if (benefits.Period.Equals("Semi Annually"))
                            {
                                benefitTaxable = benefitTaxable / 6;
                            }

                        }

                        if (benefits.CashValue <= 0)
                        {
                            var benefitPercent = benefits.PercentageofBase;

                            var benefitAmount = (decimal)(basicSalary * benefitPercent) / 100;

                            benefitTaxable += (decimal)benefitAmount;

                            if (benefits.Period.Contains("Quarterly"))
                            {
                                benefitTaxable = benefitTaxable / 4;
                            }
                            else if (benefits.Period.Equals("Annually"))
                            {
                                benefitTaxable = benefitTaxable / 12;
                            }
                            else if (benefits.Period.Equals("Semi Annually"))
                            {
                                benefitTaxable = benefitTaxable / 6;
                            }

                        }
                    }
                    else
                    {
                        if (benefits.PercentageofBase <= 0)
                        {
                            var benefitAmount = benefits.CashValue;

                            benefitNotTaxable += (decimal)benefitAmount;
                        }

                        if (benefits.CashValue <= 0)
                        {
                            var benefitPercent = benefits.PercentageofBase;

                            var benefitAmount = (decimal)(basicSalary * benefitPercent) / 100;

                            benefitNotTaxable += (decimal)benefitAmount;

                        }
                    }
                }
            }

            decimal taxValue = 0;

            //Get Number of Children
            var childrenCollection = this.lookupRepository.GetChildrenInformationListById(payslip.EmployeeId);
            var childrenConsolidation = 0;

            //Get Spouse(s)
            var spouseCollection = this.employeeRepository.GetSpouseInfoById(payslip.EmployeeId);
            var spouseConsolidation = 0;

            //Children Dependence Allowance in tax (with a maximum of four(4) children, with a constant value of NGN2500 per child
            if (childrenCollection.Count <= 4 && childrenCollection != null && childrenCollection.Count >= 1)
            {
                childrenConsolidation = childrenCollection.Count * 2500;
            }

            //Spouse(s) Dependence Allowance in tax (with a maximum of four(2) spouse, with a constant value of NGN2000 per spouse (dependant)
            if (spouseCollection.Count <= 2 && spouseCollection != null && spouseCollection.Count >= 1)
            {
                spouseConsolidation = spouseCollection.Count * 2000;
            }


            decimal totalPackage = basicSalary + benefitNotTaxable + benefitTaxable;

            //Tax Consolidation Relief Allowance. Check Annual income s
            decimal consolidationReliefAllowance = (totalPackage < 20000000) ? ((20 * totalPackage) / 100 + 200000) : (21 * totalPackage) / 100;


            //Collate Employee Pension Calculation
            var pensionContribution = totalPackage * (decimal)(7.5 / 100);


            //Get Taxable income
            var taxableIncome = totalPackage - spouseConsolidation - childrenConsolidation - consolidationReliefAllowance - pensionContribution;


            //Calculate tax base on the taxable income and Annual income
            foreach (var tax in taxCollection)
            {

                if (taxableIncome < tax.AnnualIncome)
                {
                    taxValue += taxableIncome * (tax.TaxRate / 100);
                    break;
                }
                else
                {
                    taxValue += tax.AnnualIncome * (tax.TaxRate / 100);
                }

                taxableIncome = taxableIncome - tax.AnnualIncome;
            }



            //Loop for number of loans and calculate the monthly install payment
            foreach (var loan in loanCollection)
            {

                double principal = (double)loan.Amount;

                double interestRate = (double)(loan.InterestRate / 100);

                //double deductionRate = (double)(loan.DeductionRate / 100);

                int NoOfInstallation = loan.Tenure;

                if (NoOfInstallation > 0)
                {
                    loan.MonthlyDeduction = (decimal)((principal * interestRate * (Math.Pow((1 + interestRate), NoOfInstallation))) / ((1 + interestRate)));
                }
            }


            var viewModel = this.payrollViewModelFactory.CreatePaySlipView(payslip, payScale, taxValue, payScaleBenefits, companyInfo, companyLogo, employee, level, grade,
                rewardCollection, employeeDeductionCollection, loanCollection, pensionContribution, spouseConsolidation, childrenConsolidation, consolidationReliefAllowance, taxableIncome);

            return viewModel;
        }

        /// <summary>
        /// Gets the payroll list.
        /// </summary>
        /// <param name="payrollHistoryId"></param>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IPayrollListView GetPayrollList(int payrollHistoryId, string selectedMonth, int? selectedYear, string message)
        {

            var monthDropDown = this.lookupRepository.GetAllMonths();
            var yearDropDown = this.lookupRepository.GetAllYears();

            var payrollCollection = this.payrollRepository.GetPayrollListByPayrollHistoryId(payrollHistoryId);

            var viewModel = this.payrollViewModelFactory.CreatePayrollList(selectedMonth, selectedYear, payrollCollection, monthDropDown, yearDropDown, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the payroll history list.
        /// </summary>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPayrollHistoryListView GetPayrollHistoryList(string selectedMonth, int? selectedYear, string message)
        {
            var loggedUserDetails = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            // company Collection
            var companyCollection = this.companyRepository.GetMyCompanies(loggedUserDetails.CompanyId);

            var companyInSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var monthDropDown = this.lookupRepository.GetAllMonths();

            var yearDropDown = this.lookupRepository.GetAllYears();

            var payrollHistoryCollection = payrollRepository.GetPayrollHistoryList(companyInSession);

            var viewModel = this.payrollViewModelFactory.CreatePayrollHistoryList(selectedMonth, selectedYear, payrollHistoryCollection, monthDropDown, yearDropDown, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the payroll employee list.
        /// </summary>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPayrollListView GetPayrollEmployeeList(string selectedMonth, int? selectedYear, string message)
        {
            var loggedUserDetails = usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(loggedUserDetails.Email);

            var monthDropDown = this.lookupRepository.GetAllMonths();
            var yearDropDown = this.lookupRepository.GetAllYears();

            var payrollCollection = payrollRepository.GetEmployeePayrollList(employeeInfo.EmployeeId);

            var viewModel = this.payrollViewModelFactory.CreatePayrollList(selectedMonth, selectedYear, payrollCollection, monthDropDown, yearDropDown, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the employee payroll list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPayrollListView GetEmployeePayrollList(int employeeId, string selectedMonth, int? selectedYear, string message)
        {
            var employeeInfo = employeeRepository.GetEmployeeById(employeeId);

            var monthDropDown = this.lookupRepository.GetAllMonths();
            var yearDropDown = this.lookupRepository.GetAllYears();

            var companyInfo = companyRepository.GetCompanyById(employeeInfo.CompanyId);

            var payrollCollection = payrollRepository.GetEmployeePayrollList(employeeInfo.EmployeeId);

            var viewModel = this.payrollViewModelFactory.CreateEmployeePayrollList(selectedMonth, selectedYear, payrollCollection, companyInfo, employeeInfo, monthDropDown, yearDropDown, message);

            return viewModel;
        }

        /// <summary>
        /// Generates the pay.
        /// </summary>
        /// <param name="monthCode"></param>
        /// <param name="yearId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyId
        /// or
        /// monthCode
        /// or
        /// yearId
        /// or
        /// userInfo
        /// or
        /// company
        /// </exception>
        public async Task<string> GeneratePay(string monthCode, int yearId)
        {

            //get login user information
            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyId = (int)session.GetSessionValue(SessionKey.UserId);

            //check if companyId is greater or equal to zero
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            //check if month code is equal to null
            if (monthCode == null)
            {
                throw new ArgumentNullException(nameof(monthCode));
            }

            //check if yearId id greater than or equal to zero 
            if (yearId <= 0)
            {
                throw new ArgumentNullException(nameof(yearId));
            }

            //get company information
            var company = this.companyRepository.GetCompanyById(companyId);

            string result = string.Empty;

            //check if user information is null
            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            //check if company information is null
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            //check if payroll history for a partiicular company exist
            var isDataOkay = (this.payrollRepository.GetPayrllHistoryByCompanyMonthYear(companyId, monthCode, yearId) == null) ? true : false;


            if (!isDataOkay)
            {
                return Messages.PayrollAlreadyExist;
            }

            if (isDataOkay)
            {

                //Get the list of employee for a particular company. Can not be null for payroll generation to occur
                var employeeBycompanyCollection = this.lookupRepository.GetEmployeeByCompanyId(company.CompanyId);

                var isEmployeeeRecordExist = (employeeBycompanyCollection == null || employeeBycompanyCollection.Count == 0) ? false : true;

                if (!isEmployeeeRecordExist)
                {
                    result = Messages.NoEmployeeRecord;

                    return result;
                }

                

                var payrollHistory = new PayrollHistoryView();

                //Passing the values for PayrollHistory 
                payrollHistory.CompanyId = company.CompanyId;
                payrollHistory.Year = yearId;
                payrollHistory.MonthCode = monthCode;

                //Save the Payroll history
                int payrollHistoryId = await this.payrollRepository.SavePayrollHistoryInfo(payrollHistory);

                if (string.IsNullOrEmpty(result))
                {

                    //loop through each employee in the company
                    foreach (var item in employeeBycompanyCollection)
                    {

                        PayrollView payroll = new PayrollView();

                        var payrollEmployeeDeductionCollection = new List<IPayrollEmployeeDeduction>();
                        var payrollEmployeeLoanCollection = new List<IPayrollEmployeeLoan>();
                        var payrollEmployeeRewardCollection = new List<IPayrollEmployeeReward>();

                        //Initiating value to calculate
                        decimal basicSalary = 0;
                        decimal totalBenefit = 0;
                        decimal benefitTaxable = 0;
                        decimal benefitNotTaxable = 0;
                        decimal totalBenefitTaxable = 0;
                        decimal totalBenefitNotTaxable = 0;
                        decimal rewardAmount = 0;
                        decimal deductionAmount = 0;
                        decimal monthlyPayment = 0;
                        decimal pensionContribution = 0;
                        decimal NetPay = 0;


                        //Get all reward for an employee
                        var rewardCollection = this.lookupRepository.GetEmployeeRewardByEmployeeId(item.EmployeeId);

                        //Get all loans for an employee
                        var loanCollection = this.lookupRepository.GetEmployeeLoanByEmployeeId(item.EmployeeId);

                        //Get deduction of an employee
                        var employeeDeduction = this.employeeDeductionRepository.GetEmployeeDeductionByEmployeeId(item.EmployeeId);

                        //Get PayScale information
                        var basePay = this.levelGradeRepository.GetLevelGradeByLevelIdAndGradeId(item.CompanyId, item.LevelId, item.GradeId);


                        if (basePay == null)
                        {
                            result = Messages.PayScaleNotSet;

                            return result;
                        }

                        //Collatiion of Base Pay and monetary benefits for an employee
                        basicSalary = basePay.BasePay;

                        //Get the benefit(s) of an employee
                        var benefitCollections = this.levelGradeRepository.GetIPayScaleBenefitByPayScaleId(basePay.PayScaleId);

                        //Check if basePay null
                        var isSalaryRecordExist = (basePay == null) ? false : true;

                        if (!isSalaryRecordExist)
                        {
                            result = Messages.levelRecordExist;

                            return result;
                        }

                        //Collation of Benefits for an employee 
                        foreach (var benefits in benefitCollections)
                        {

                            if (benefits != null)
                            {
                                decimal benefit = 0;

                                //Taxable benefits
                                if (benefits.IsTaxable)
                                {

                                    //Check if its Percentage of Base Pay
                                    if (benefits.PercentageofBase <= 0)
                                    {
                                        benefit = benefits.CashValue / 12;

                                        benefitTaxable = (decimal)benefits.CashValue;

                                    }

                                    //Check if its Cash Values
                                    if (benefits.CashValue <= 0)
                                    {
                                        var benefitPercent = benefits.PercentageofBase;

                                        benefit = ((decimal)(basicSalary * benefitPercent) / 100) / 12;

                                        benefitTaxable = (decimal)(basicSalary * benefitPercent) / 100;

                                    }

                                }
                                //Non Taxable benefits
                                else
                                {
                                    //Check if its Percentage of Base Pay
                                    if (benefits.PercentageofBase <= 0)
                                    {
                                        benefit = benefits.CashValue / 12;

                                        benefitNotTaxable = benefits.CashValue;

                                    }

                                    //Check if its Cash Values
                                    if (benefits.CashValue <= 0)
                                    {
                                        var benefitPercent = benefits.PercentageofBase;

                                        benefit = ((decimal)(basicSalary * benefitPercent) / 100) / 12;

                                        benefitNotTaxable = (decimal)(basicSalary * benefitPercent) / 100;

                                    }

                                }

                                totalBenefit += benefit;
                                totalBenefitTaxable += benefitTaxable;
                                totalBenefitNotTaxable += benefitNotTaxable;
                            }
                        }

                        //Collation of Rewards for an employee 
                        foreach (var reward in rewardCollection)
                        {

                            var payrollEmployeeReward = new PayrollEmployeeRewardModel();

                            if (reward.IsActive)
                            {
                                payroll.EmployeeRewardId = reward.RewardId;
                                rewardAmount += reward.Amount;

                                payrollEmployeeReward.EmployeeRewardId = reward.EmployeeRewardId;
                                payrollEmployeeReward.CompanyId = item.CompanyId;

                                payrollEmployeeRewardCollection.Add(payrollEmployeeReward);
                            }
                        }

                        //Collation of deductioon for an employee
                        foreach (var deduction in employeeDeduction)
                        {

                            var payrollEmployeeDeduction = new PayrollEmployeeDeductionModel();

                            if (deduction.IsActive)
                            {
                                payroll.EmployeeDeductionId = deduction.DeductionId;
                                deductionAmount += deduction.DeductionAmount;


                                payrollEmployeeDeduction.EmployeeDeductionId = deduction.DeductionId;
                                payrollEmployeeDeduction.CompanyId = item.CompanyId;

                                payrollEmployeeDeductionCollection.Add(payrollEmployeeDeduction);

                            }
                        }

                        //Collation and Calculation of Month Installmental payment for loans collected by an employee
                        foreach (var loan in loanCollection)
                        {

                            var payrollEmployeeLoan = new PayrollEmployeeLoanModel();

                            //Check if the loan is active
                            if (loan.IsActive)
                            {

                                double principal = (double)loan.Amount;

                                double interestRate = (double)(loan.InterestRate / 100);

                                int NoOfInstallation = loan.Tenure;

                                if (loan.PeriodRemain > 0)
                                {
                                    monthlyPayment += (decimal)((principal * interestRate * (Math.Pow((1 + interestRate), NoOfInstallation))) / ((1 + interestRate)));
                                    --loan.PeriodRemain;
                                    payroll.EmployeeLoanId = loan.EmployeeLoanId;

                                    payrollEmployeeLoan.EmployeeLoanId = loan.EmployeeLoanId;
                                    payrollEmployeeLoan.CompanyId = item.CompanyId;

                                    payrollEmployeeLoanCollection.Add(payrollEmployeeLoan);

                                    //Update employeeloan after a payroll payment period
                                    loanRepository.UpdateLoanInfo(loan);
                                }
                                else
                                {
                                    //Delete Loan when periodRemaining is zero
                                    loanRepository.DeleteLoanInfo(loan.EmployeeLoanId);
                                }


                            }


                        }


                        //Get Number of Children
                        var childrenCollection = this.lookupRepository.GetChildrenInformationListById(item.EmployeeId);
                        var childrenConsolidation = 0;

                        //Get Spouse(s)
                        var spouseCollection = this.employeeRepository.GetSpouseInfoById(item.EmployeeId);
                        var spouseConsolidation = 0;

                        //Children Dependence Allowance in tax (with a maximum of four(4) children, with a constant value of NGN2500 per child
                        if (childrenCollection != null && childrenCollection.Count <= 4 && childrenCollection.Count >= 1)
                        {
                            childrenConsolidation = childrenCollection.Count * 2500;
                        }

                        //Spouse(s) Dependence Allowance in tax (with a maximum of four(2) spouse, with a constant value of NGN2000 per spouse (dependant)
                        if (spouseCollection != null && spouseCollection.Count <= 2 && spouseCollection.Count >= 1)
                        {
                            spouseConsolidation = spouseCollection.Count * 2000;
                        }

                        decimal totalPackage = basicSalary + totalBenefitTaxable + totalBenefitNotTaxable;

                        //Tax Consolidation Relief Allowance. Check Annual income s
                        decimal consolidationReliefAllowance = (totalPackage < 20000000) ? ((20 * totalPackage) / 100 + 200000) : (21 * totalPackage) / 100;


                        //Collate Employee Pension Calculation
                        pensionContribution = totalPackage * (decimal)(7.5 / 100);

                        //Get tax list 
                        var taxCollection = this.lookupRepository.GetAllTax();

                        //Get Taxable income
                        var taxableIncome = totalPackage - spouseConsolidation - childrenConsolidation - consolidationReliefAllowance - pensionContribution;



                        decimal taxValue = 0;

                        //Calculate tax base on the taxable income and Annual income
                        foreach (var tax in taxCollection)
                        {

                            if (taxableIncome < tax.AnnualIncome)
                            {
                                taxValue += taxableIncome * (tax.TaxRate / 100);
                                break;
                            }
                            else
                            {
                                taxValue += tax.AnnualIncome * (tax.TaxRate / 100);
                            }

                            taxableIncome = taxableIncome - tax.AnnualIncome;
                        }


                        if (taxValue < 0) taxValue = 0;


                        //Calualte the net pay
                        NetPay = (basicSalary / 12) + totalBenefit - monthlyPayment - deductionAmount + rewardAmount - (taxValue / 12) - (pensionContribution / 12);

                        //Passing Value to the payroll 
                        payroll.BasicSalary = (basicSalary / 12);
                        payroll.CompanyId = company.CompanyId;
                        payroll.EmployeeId = item.EmployeeId;
                        payroll.NetSalary = NetPay;
                        payroll.YearId = yearId;
                        payroll.MonthCode = monthCode;
                        payroll.PayrollHistoryId = payrollHistoryId;

                        int payrollId = await this.payrollRepository.SavePayroll(payroll);

                        //Adding all the deduction of a payroll to payroll deduction table
                        foreach (var cells in payrollEmployeeDeductionCollection)
                        {
                            cells.PayrollId = payrollId;
                            payrollRepository.SavePayrollEmployeeDeduction(cells);
                        }

                        //Adding all the loan of a payroll to payroll loan table
                        foreach (var packets in payrollEmployeeLoanCollection)
                        {
                            packets.PayrollId = payrollId;
                            payrollRepository.SavePayrollEmployeeLoan(packets);
                        }

                        //Adding all the rewards of a payroll to payroll reward table
                        foreach (var boxes in payrollEmployeeRewardCollection)
                        {
                            boxes.PayrollId = payrollId;
                            payrollRepository.SavePayrollEmployeeReward(boxes);
                        }

                    }
                }

            }

            return result;
        }
     
        
    }
} 

