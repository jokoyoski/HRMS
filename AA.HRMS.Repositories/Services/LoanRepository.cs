using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ILoanRepository" />
    public class LoanRepository : ILoanRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public LoanRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory; 
        }


        /// <summary>
        /// Gets the pending loan request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get EmployeeLoan by CompanyId {0}</exception>
        public IList<IEmployeeLoan> GetPendingLoanRequestByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LoanQueries.getPendingLoanRequestByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeLoan by CompanyId {0}", e);
            }
        }

        /// <summary>
        /// Gets the employee loan by identifier.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get EmployeeLoan by CompanyId {0}</exception>
        public IList<IEmployeeLoan> GetEmployeeLoanById(int employeeLoanId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LoanQueries.getEmployeeLoanById(dbContext, employeeLoanId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeLoan by CompanyId {0}", e);
            }
        }
        

        /// <summary>
        /// Gets the employee loan by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get EmployeeLoan by CompanyId {0}</exception>
        public IList<IEmployeeLoan> GetEmployeeLoanByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LoanQueries.getEmployeeLoanByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeLoan by CompanyId {0}", e);
            }
        }


        /// <summary>
        /// Gets the employee loan by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get EmployeeLoan by CompanyId {0}</exception>
        public IList<IEmployeeLoan> GetEmployeeLoanByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LoanQueries.getEmployeeLoanByEmployeeId(dbContext, employeeId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeLoan by CompanyId {0}", e);
            }
        }

        /// <summary>
        /// Saves the loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">loanInfo</exception>
        public string SaveLoanInfo(ILoanView loanInfo)
        {
            if (loanInfo == null) throw new ArgumentNullException(nameof(loanInfo));

            var result = string.Empty;

            var newRecord = new LoanType
            {
                LoanType1 = loanInfo.LoanType,
                //LoanAmount = loanInfo.LoanAmount,
                //InterestRate = loanInfo.InterestRate,
                //DeductionRate = loanInfo.DeductionRate,
                //Duration = loanInfo.Duration,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
               // CompanyId = loanInfo.CompanyId
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.LoanTypes.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Loan Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Updates the loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loanInfo
        /// or
        /// loanData
        /// </exception>
        public string UpdateLoanInfo(ILoanView loanInfo)
        {
            if (loanInfo == null) throw new ArgumentNullException(nameof(loanInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var loanData =
                        dbContext.LoanTypes.SingleOrDefault(m => m.LoanTypeId.Equals(loanInfo.LoanType));
                    if (loanData == null) throw new ArgumentNullException(nameof(loanData));

                    loanData.LoanType1 = loanInfo.LoanType;
                 

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Loan Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Gets the loan by identifier.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLoanById</exception>
        public ILoan GetLoanById(int loanId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newRecord =
                        LoanQueries.GetLoanById(dbContext, loanId);

                    return newRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLoanById", e);
            }
        }

        /// <summary>
        /// Deletes the loan information.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">loanId</exception>
        /// <exception cref="ArgumentNullException">levellId</exception>
        public string DeleteLoanInfo(int EmployeeloanId)
        {
            if (EmployeeloanId < 1)

            {
                throw new ArgumentOutOfRangeException("EmployeeloanId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var loanData =
                        dbContext.EmployeeLoans.SingleOrDefault(m => m.EmployeeLoanId.Equals(EmployeeloanId));
                    if (loanData == null) throw new ArgumentNullException("levellId");

                    loanData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Loan Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Updates the loan information.
        /// </summary>
        /// <param name="employeeloan">The employeeloan.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Employeeloan</exception>
        /// <exception cref="ArgumentNullException">levellId</exception>
        public string UpdateLoanInfo(IEmployeeLoan employeeloan)
        {
            if (employeeloan == null)

            {
                throw new ArgumentOutOfRangeException("Employeeloan");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var loanData =
                        dbContext.EmployeeLoans.SingleOrDefault(m => m.EmployeeLoanId.Equals(employeeloan.EmployeeLoanId));
                    if (loanData == null) throw new ArgumentNullException("levellId");

                    loanData.PeriodRemain = employeeloan.PeriodRemain;



                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Loan Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Gets the list of loans by identifier.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLoanById</exception>
        public IList<ILoan> GetListOfLoansById(int loanId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newRecord =
                        LoanQueries.GetListOfLoanById(dbContext, loanId).ToList();

                    return newRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLoanById", e);
            }
        }
    }
}
