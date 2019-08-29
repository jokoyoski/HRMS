using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeDeductionRepository
    {
        /// <summary>
        /// Gets the employee deduction.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IDeduction> GetEmployeeDeductionByEmployeeId(int employeeId);

        /// <summary>
        /// Gets the employee deduction by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmployeeDeduction GetEmployeeDeductionByEmployeeId(int employeeId, int deductionId);

        /// <summary>
        /// Gets the employee deduction by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeDeduction> GetEmployeeDeductionByCompanyId(int companyId);

        /// <summary>
        /// Gets the employee deduction by deduction identifier.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        IEmployeeDeduction GetEmployeeDeductionByDeductionId(int deductionId);

        /// <summary>
        /// Saves the employee deduction information.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <returns></returns>
        string SaveEmployeeDeductionInfo(IEmployeeDeductionView employeeDeduction);

        string SaveDeductionInfo(IDeductionViewModel employeeDeduction);
        /// <summary>
        /// Saves the delete employee deduction.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        string SaveDeleteEmployeeDeduction(IDeductionViewModel deductionViewModel);

        /// <summary>
        /// Gets the employee deduction.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeDeduction> GetEmployeeDeduction(int employeeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        IList<IEmployeeDeduction> GetDeductionByCompanyId(int CompanyId);

        /// <summary>
        /// Gets the employee deduction by identifier.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        IList<IEmployeeDeduction> GetEmployeeDeductionById(int employeeDeductionId);

        /// <summary>
        /// Gets the employee deduction by employee deduction identifier.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        IEmployeeDeduction GetEmployeeDeductionByEmployeeDeductionId(int employeeDeductionId);

        /// <summary>
        /// Gets all employee deduction by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IDeduction GetAllEmployeeDeductionByEmployeeId(int employeeId);

        /// <summary>
        /// Gets the employee deduction list by employee deduction identifier.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        IList<IDeduction> GetEmployeeDeductionListByEmployeeDeductionId(int employeeDeductionId);
    }
}
