using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class EmployeeLoanRepository : IEmployeeLoanRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        
        public EmployeeLoanRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Saves the employee loan information.
        /// </summary>
        /// <param name="employeeLoan">The employee loan.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeLoan</exception>
        public string SaveEmployeeLoanInfo(IEmployeeLoanView employeeLoan)
        {
            if (employeeLoan == null)
            {
                throw new ArgumentNullException(nameof(employeeLoan));
            }

            string result = string.Empty;

            var newReocord = new EmployeeLoan
            {
                EmployeeId = employeeLoan.EmployeeId,
                CompanyId = employeeLoan.CompanyId,
                Tenure = employeeLoan.Tenure,
                LoanTypeId = employeeLoan.LoanId,
                Reason = employeeLoan.Reason,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
                AgreedDate = null,
                Amount = employeeLoan.LoanAmount,
                IsApproved = null,
                HRComment = null,
                DateDisburst = employeeLoan.DisburstDate,
                ExpectedDate = employeeLoan.ExpectedDate,
                PeriodRemain = employeeLoan.Tenure,
                
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeLoans.Add(newReocord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Employee loan info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        //public string UpdateEmployeeLoanInterestRate(IEmployeeLoanView employeeLoanView)
        //{
        //    if (employeeLoanView == null) throw new ArgumentNullException(nameof(employeeLoanView));

        //    var result = string.Empty;


        //    try
        //    {
        //        using (
        //            var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
        //        {
        //            var employeeLoanData =
        //                dbContext.EmployeeLoans.SingleOrDefault(m => m.EmployeeLoanId.Equals(employeeLoanView.EmployeeLoanId));
        //            if (employeeLoanData == null) throw new ArgumentNullException(nameof(employeeLoanData));

        //            if (employeeLoanData != null)
        //            {
                      
        //                employeeLoanData.InterestRate = employeeLoanView.InterestRate;
        //                dbContext.SaveChanges();
        //            }

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        result = string.Format("Update Employee Loan Information - {0} , {1}", e.Message,
        //            e.InnerException != null ? e.InnerException.Message : "");
        //    }
        //    return result;
        //}


        /// <summary>
        /// Gets the employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">get EmployeeLoan Error</exception>
        public IEmployeeLoan GetEmployeeLoanById(int employeeLoanId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var record = EmployeeLoanQueries.getEmployeeLoanByEmployeeLoanId(dbContext, employeeLoanId);
                    return record;
                }

            }
            catch (Exception e)
            {
                throw new Exception("get EmployeeLoan Error", e);
            }
        }

        /// <summary>
        /// Gets the employee loan list by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">get EmployeeLoan Error</exception>
        public IList<IEmployeeLoan> GetEmployeeLoanListByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var record = EmployeeLoanQueries.getEmployeeLoanByEmployeeId(dbContext, employeeId).ToList();

                    return record;
                }

            }
            catch (Exception e)
            {
                throw new Exception("get EmployeeLoan Error", e);
            }
        }


        /// <summary>
        /// Gets the employee loan by employee loan identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Get Employee Loan By EmployeeId LoanId</exception>
        public IEmployeeLoan GetEmployeeLoanByEmployeeLoanId(int employeeId, int loanId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var record = EmployeeLoanQueries.getEmployeeLoanByEmployeeandCompanyId(dbContext, employeeId, loanId);
                    return record;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Get Employee Loan By EmployeeId LoanId", e);
            }
        }

        /// <summary>
        /// Updates the employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeLoanView
        /// or
        /// employeeLoanData
        /// </exception>
        public string UpdateEmployeeLoan(IEmployeeLoanView employeeLoanView)
        {
            if (employeeLoanView == null) throw new ArgumentNullException(nameof(employeeLoanView));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeLoanData =
                        dbContext.EmployeeLoans.SingleOrDefault(m => m.EmployeeLoanId.Equals(employeeLoanView.EmployeeLoanId));
                    if (employeeLoanData == null) throw new ArgumentNullException(nameof(employeeLoanData));

                    if (employeeLoanData != null)
                    {
                        employeeLoanData.IsApproved = employeeLoanView.IsApproved;
                        employeeLoanData.Tenure = employeeLoanView.Tenure;
                        employeeLoanData.Reason = employeeLoanView.Reason;
                        employeeLoanData.DateDisburst = employeeLoanView.DisburstDate;
                        employeeLoanData.HRComment = employeeLoanView.HRComment;
                        employeeLoanData.AgreedDate = employeeLoanView.AgreedDate;
                        employeeLoanData.ExpectedDate = employeeLoanView.ExpectedDate;
                        employeeLoanData.Amount = employeeLoanView.LoanAmount;
                        employeeLoanData.InterestRate = employeeLoanView.InterestRate;




                        dbContext.SaveChanges();
                    }

                }

            }
            catch (Exception e)
            {
                result = string.Format("Update Employee Loan Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

        /// <summary>
        /// Deletes the employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeLoanView
        /// or
        /// employeeLoanData
        /// </exception>
        public string DeleteEmployeeLoan(IEmployeeLoanView employeeLoanView)
        {
            if (employeeLoanView == null) throw new ArgumentNullException(nameof(employeeLoanView));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeLoanData =
                        dbContext.EmployeeLoans.SingleOrDefault(m => m.EmployeeLoanId.Equals(employeeLoanView.EmployeeLoanId));
                    if (employeeLoanData == null) throw new ArgumentNullException(nameof(employeeLoanData));

                    if (employeeLoanData != null)
                    {
                        employeeLoanData.IsActive = false;
                        employeeLoanData.IsApproved = false;
                   //Sets IsActive to false
                        dbContext.SaveChanges();
                    }

                }

            }
            catch (Exception e)
            {
                result = string.Format("Delete Employee Loan Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

    }
}
