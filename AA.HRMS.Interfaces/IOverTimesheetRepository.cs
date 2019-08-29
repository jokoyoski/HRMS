using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
   public interface IOverTimesheetRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SaveOverTimesheetInfo"></param>
        /// <returns></returns>
        string SaveOverTimesheetInfo(IOverTimesheetView SaveOverTimesheetInfo);
        /// <summary>
        /// sss
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<IOverTimesheet> GetOverTimesheetByCompanyId(int companyId);

        /// <summary>
        /// Gets the over timesheet by identifier.
        /// </summary>
        /// <param name="overTimeSheetId">The over time sheet identifier.</param>
        /// <returns></returns>
        IOverTimesheet GetOverTimesheetById(int overTimeSheetId);

        /// <summary>
        /// Saves the edit over timesheet information.
        /// </summary>
        /// <param name="overTimesheetInfo">The over timesheet information.</param>
        /// <returns></returns>
        string SaveEditOverTimesheetInfo(IOverTimesheetView overTimesheetInfo);

        /// <summary>
        /// Saves the delete over timesheet information.
        /// </summary>
        /// <param name="overTimesheetId">The over timesheet identifier.</param>
        /// <returns></returns>
        string SaveDeleteOverTimesheetInfo(int overTimesheetId);
    }
}
