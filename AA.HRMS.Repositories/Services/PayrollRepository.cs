using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayrollRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public PayrollRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the payroll by identifier.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Payroll by Id</exception>
        public IPayroll GetPayrollById(int payrollId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getPayrllById(dbContext, payrollId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Payroll by Id", e);
            }
        }

        /// <summary>
        /// Gets the payrll by company mont year.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="monthCode">The month code.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Payroll by Id</exception>
        public IPayrollHistory GetPayrllHistoryByCompanyMonthYear(int companyId, string monthCode, int yearId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getPayrllHistoryByCompanyMontYear(dbContext, companyId, monthCode, yearId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Payrll By Company Month Year", e);
            }
        }

        /// <summary>
        /// Gets the payroll list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">get all payroll list</exception>
        public IList<IPayroll> GetPayrollList(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getAllPayroll(dbContext, companyId).ToList();

                    return list;

                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("get all payroll list", e);
            }
        }

        /// <summary>
        /// Gets the payroll history list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">get all payroll list</exception>
        public IList<IPayrollHistory> GetPayrollHistoryList(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getPayrollHistoryList(dbContext, companyId).ToList();

                    return list;

                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("get all payroll list", e);
            }
        }
        
        /// <summary>
        /// Gets the payroll list by payroll history identifier.
        /// </summary>
        /// <param name="payrollHistoryId">The payroll history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">get all payroll list</exception>
        public IList<IPayroll> GetPayrollListByPayrollHistoryId(int payrollHistoryId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getPayrollByPayrollHistoryId(dbContext, payrollHistoryId).ToList();

                    return list;

                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("get all payroll list", e);
            }
        }


        /// <summary>

        /// Gets the employee payroll list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">get all payroll list</exception>
        public IList<IPayroll> GetEmployeePayrollList(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getAllEmployeePayroll(dbContext, employeeId).ToList();

                    return list;

                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("get all payroll list", e);
            }
        }

        /// <summary>
        /// Saves the payroll.
        /// </summary>
        /// <param name="payrollInfo">The payroll information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">payrollInfo</exception>
        public async Task<int> SavePayroll(IPayrollView payrollInfo)
        {
            if (payrollInfo == null)
            {
                throw new ArgumentNullException(nameof(payrollInfo));
            }

            string result = string.Empty;

            var newRecord = new Payroll
            {
                BasicSalary = payrollInfo.BasicSalary,
                EmployeeId = payrollInfo.EmployeeId,
                CompanyId = payrollInfo.CompanyId,
                NetSalary = payrollInfo.NetSalary,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                PayrollHistoryId = payrollInfo.PayrollHistoryId
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Payrolls.Add(newRecord);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save payroll info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            int payrollId = newRecord.PayrollId;

            return payrollId;

        }

        /// <summary>
        /// Saves the payroll history.
        /// </summary>
        /// <param name="payrollInfo">The payroll information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payrollInfo</exception>
        public string SavePayrollHistory(IPayrollHistory payrollInfo)
        {
            if (payrollInfo == null)
            {
                throw new ArgumentNullException(nameof(payrollInfo));
            }

            string result = string.Empty;

            var newRecord = new PayrollHistory
            {
                MonthCode = payrollInfo.MonthCode,
                Year = payrollInfo.Year,
                CompanyId = payrollInfo.CompanyId,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.PayrollHistories.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Payroll History info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;

        }

        /// <summary>
        /// Saves the payroll employee deduction.
        /// </summary>
        /// <param name="payrollEmployeeDeduction">The payroll employee deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payrollEmployeeDeduction</exception>
        public string SavePayrollEmployeeDeduction(IPayrollEmployeeDeduction payrollEmployeeDeduction)
        {
            if (payrollEmployeeDeduction == null)
            {
                throw new ArgumentNullException(nameof(payrollEmployeeDeduction));
            }

            string result = string.Empty;

            var newRecord = new PayrollEmployeeDeduction
            {
                PayrollId = payrollEmployeeDeduction.PayrollId,
                CompanyId = payrollEmployeeDeduction.CompanyId,
                EmployeeDeductionId = payrollEmployeeDeduction.EmployeeDeductionId,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.PayrollEmployeeDeductions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save payroll info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;

        }

        /// <summary>
        /// Gets the payroll employee deduction by payroll identifier.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Payroll Employee Deduction By PayrollId</exception>
        public IList<IPayrollEmployeeDeduction> GetPayrollEmployeeDeductionByPayrollId(int payrollId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getPayrollEmployeeDeductionByPayrollId(dbContext, payrollId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Payroll Employee Deduction By PayrollId", e);
            }
        }

        /// <summary>
        /// Gets the payroll employee loan by payroll identifier.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Payroll Employee Deduction By PayrollId</exception>
        public IList<IPayrollEmployeeLoan> GetPayrollEmployeeLoanByPayrollId(int payrollId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getPayrollEmployeeLoanByPayrollId(dbContext, payrollId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Payroll Employee Deduction By PayrollId", e);
            }
        }

        /// <summary>
        /// Gets the payroll employee reward by payroll identifier.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Payroll Employee Deduction By PayrollId</exception>
        public IList<IPayrollEmployeeReward> GetPayrollEmployeeRewardByPayrollId(int payrollId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getPayrollEmployeeRewardByPayrollId(dbContext, payrollId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Payroll Employee Deduction By PayrollId", e);
            }
        }


        /// <summary>
        /// Saves the payroll employee loan.
        /// </summary>
        /// <param name="payrollEmployeeLoan">The payroll employee loan.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payrollEmployeeLoan</exception>
        public string SavePayrollEmployeeLoan(IPayrollEmployeeLoan payrollEmployeeLoan)
        {
            if (payrollEmployeeLoan == null)
            {
                throw new ArgumentNullException(nameof(payrollEmployeeLoan));
            }

            string result = string.Empty;

            var newRecord = new PayrollEmployeeLoan
            {
                PayrollId = payrollEmployeeLoan.PayrollId,
                CompanyId = payrollEmployeeLoan.CompanyId,
                EmployeeLoanId = payrollEmployeeLoan.EmployeeLoanId,
                IsActive = true,
                DateCreate = DateTime.UtcNow,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.PayrollEmployeeLoans.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save payroll info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;

        }

        /// <summary>
        /// Saves the payroll employee reward.
        /// </summary>
        /// <param name="payrollEmployeeReward">The payroll employee reward.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payrollEmployeeReward</exception>
        public string SavePayrollEmployeeReward(IPayrollEmployeeReward payrollEmployeeReward)
        {
            if (payrollEmployeeReward == null)
            {
                throw new ArgumentNullException(nameof(payrollEmployeeReward));
            }

            string result = string.Empty;

            var newRecord = new PayrollEmployeeReward
            {
                PayrollId = payrollEmployeeReward.PayrollId,
                CompanyId = payrollEmployeeReward.CompanyId,
                EmployeeRewardId = payrollEmployeeReward.EmployeeRewardId,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.PayrollEmployeeRewards.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save payroll info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;

        }
        
        /// <summary>
        /// Gets the payrll history by company month year.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Payrll By Company Month Year</exception>
        public IList<IPayrollHistory> GetPayrllHistoryByCompanyMonthYear(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PayrollQueries.getPayrllHistoryByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Payroll By Company Month Year", e);
            }
        }

        /// <summary>
        /// Saves the payroll history information.
        /// </summary>
        /// <param name="payrollHistoryInfo">The payroll history information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">payrollHistoryInfo</exception>
        public async Task<int> SavePayrollHistoryInfo(IPayrollHistoryView payrollHistoryInfo)
        {
            if (payrollHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(payrollHistoryInfo));
            }

            var result = string.Empty;
            var newRecord = new PayrollHistory
            {

                MonthCode = payrollHistoryInfo.MonthCode,
                Year = payrollHistoryInfo.Year,
                CompanyId = payrollHistoryInfo.CompanyId,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.PayrollHistories.Add(newRecord);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SavePayrollHistoryInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            int payrollHistoryId = newRecord.PayrollHistoryId;

            return payrollHistoryId;
            
        }


    }
}
