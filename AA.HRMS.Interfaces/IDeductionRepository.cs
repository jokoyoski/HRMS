using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IDeductionRepository
    {

        /// <summary>
        /// Gets the deduction by identifier.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        IDeduction GetDeductionById(int deductionId);

        /// <summary>
        /// Gets the name of the deduction by.
        /// </summary>
        /// <param name="deductionName">Name of the deduction.</param>
        /// <returns></returns>
        IDeduction GetDeductionByName(string deductionName);

        /// <summary>
        /// Saves the deduction information.
        /// </summary>
        /// <param name="deductionInfo">The deduction information.</param>
        /// <returns></returns>
        string SaveDeductionInfo(IDeductionViewModel deductionInfo);

        /// <summary>
        /// Saves the edit deduction information.
        /// </summary>
        /// <param name="deductionInfo">The deduction information.</param>
        /// <returns></returns>
        string SaveEditDeductionInfo(IDeductionViewModel deductionInfo);

        /// <summary>
        /// Saves the delete deduction information.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        string SaveDeleteDeductionInfo(int deductionId);

        /// <summary>
        /// get All deduction List
        /// </summary>
        /// <returns></returns>
        IList<IDeduction> GetDeduction();

        /// <summary>
        /// Gets the deduction by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IDeduction> GetDeductionByEmployeeId(int employeeId);
    }
}
