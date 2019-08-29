using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILoanRepository
    {

        /// <summary>
        /// Saves the loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        string SaveLoanInfo(ILoanView loanInfo);

        /// <summary>
        /// Gets the pending loan request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeLoan> GetPendingLoanRequestByCompanyId(int companyId);

        /// <summary>
        /// Updates the loan information.
        /// </summary>
        /// <param name="loanInfo">The loan information.</param>
        /// <returns></returns>
        string UpdateLoanInfo(ILoanView loanInfo);

        /// <summary>
        /// Gets the loan by identifier.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        ILoan GetLoanById(int loanId);

        /// <summary>
        /// Deletes the loan information.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        string DeleteLoanInfo(int loanId);
        
        /// <summary>
        /// Gets the employee loan by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeLoan> GetEmployeeLoanByCompanyId(int companyId);

        /// <summary>
        /// Gets the list of loans by identifier.
        /// </summary>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        IList<ILoan> GetListOfLoansById(int loanId);

        /// <summary>
        /// Updates the loan information.
        /// </summary>
        /// <param name="employeeloan">The employeeloan.</param>
        /// <returns></returns>
        string UpdateLoanInfo(IEmployeeLoan employeeloan);

        /// <summary>
        /// Gets the employee loan by identifier.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <returns></returns>
        IList<IEmployeeLoan> GetEmployeeLoanById(int employeeLoanId);

        /// <summary>
        /// Gets the employee loan by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeLoan> GetEmployeeLoanByEmployeeId(int employeeId);
    }
}
