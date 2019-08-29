using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IExitManagementRepository
    {
        /// <summary>
        /// Gets the employee exit by employee identifier.
        /// </summary>
        /// <param name="employeeeId">The employeee identifier.</param>
        /// <returns></returns>
        IEmployeeExit GetEmployeeExitByEmployeeId(int employeeeId);

        /// <summary>
        /// Saves the employee exit information.
        /// </summary>
        /// <param name="employeeExitInfo">The employee exit information.</param>
        /// <returns></returns>
        string SaveEmployeeExitInfo(IEmployeeExitView employeeExitInfo);

        IList<IEmployeeExit> GetAllMyEmployeeExit(int companyId);




    }
}
