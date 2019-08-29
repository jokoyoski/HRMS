using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeLoanRepository
    {

        /// <summary>
        /// Saves the employee loan information.
        /// </summary>
        /// <param name="employeeLoan">The employee loan.</param>
        /// <returns></returns>
        string SaveEmployeeLoanInfo(IEmployeeLoanView employeeLoan);

        /// <summary>
        /// Gets the employee loan.
        /// </summary>
        /// <param name="employeeLoanId">The employee loan identifier.</param>
        /// <returns></returns>
        IEmployeeLoan GetEmployeeLoanById(int employeeLoanId);

        /// <summary>
        /// Gets the employee loan by employee loan identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="loanId">The loan identifier.</param>
        /// <returns></returns>
        IEmployeeLoan GetEmployeeLoanByEmployeeLoanId(int employeeId, int loanId);

        /// <summary>
        /// Updates the employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        string UpdateEmployeeLoan(IEmployeeLoanView employeeLoanView);

        /// <summary>
        /// Deletes the employee loan.
        /// </summary>
        /// <param name="employeeLoanView">The employee loan view.</param>
        /// <returns></returns>
        string DeleteEmployeeLoan(IEmployeeLoanView employeeLoanView);

        /// <summary>
        /// Gets the employee loan list by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeLoan> GetEmployeeLoanListByEmployeeId(int employeeId);
    }
}
