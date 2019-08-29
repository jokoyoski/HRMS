using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveModelRepository
    {

        /// <summary>
        /// Saves the leave type model information.
        /// </summary>
        /// <param name="leaveTypeModelInfo">The leave type model information.</param>
        /// <returns></returns>
        string SaveLeaveTypeModelInfo(ILeaveTypeModelView leaveTypeModelInfo);

        IList<ILeaveType> GetLeaveTypeListForCompanyId(int companyId);

        /// <summary>
        /// Gets the leave type list.
        /// </summary>
        /// <returns></returns>
        IList<ILeaveType> GetLeaveTypeList();

        /// <summary>
        /// Saves the leave request information.
        /// </summary>
        /// <param name="leaveTypeModelInfo">The leave type model information.</param>
        /// <returns></returns>
        string SaveLeaveRequestInfo(ILeaveRequestModelView leaveTypeModelInfo);

        ILeaveType GetLeaveTypeById(int leaveTypeId);

        string UpdateLeaveTypeInfo(ILeaveTypeModelView leaveTypeInfo);

        string DeleteLeaveType(int leaveTypeId);

        //IList<ILeaveRequest> GetLeaveRequestList();

        /// <summary>
        /// Gets the leave request list.
        /// </summary>
        /// <returns></returns>
        IList<ILeaveRequestModel> GetLeaveRequestList();

        /// <summary>
        /// Gets the leave request details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ILeaveRequestModel GetLeaveRequestDetails(int id);

        /// <summary>
        /// Gets the leave status list.
        /// </summary>
        /// <returns></returns>
        IList<ILeaveStatus> GetLeaveStatusList();

        /// <summary>
        /// Updates the leave approval hr.
        /// </summary>
        /// <param name="leaveHrUpdateView">The leave hr update view.</param>
        /// <param name="leaveId">The leave identifier.</param>
        /// <returns></returns>
        string UpdateLeaveApprovalHR(ILeaveHrUpdateView leaveHrUpdateView, int leaveId);

        /// <summary>
        /// Updates the leave approval supervisor.
        /// </summary>
        /// <param name="leaveSupervisorUpdateView">The leave supervisor update view.</param>
        /// <param name="leaveId">The leave identifier.</param>
        /// <returns></returns>
        string UpdateLeaveApprovalSupervisor(ILeaveSupervisorUpdateView leaveSupervisorUpdateView, int leaveId);
    }
}
