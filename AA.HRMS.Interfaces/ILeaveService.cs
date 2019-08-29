using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveService
    {
        /// <summary>
        /// Gets the leave type model view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveTypeModelView GetLeaveTypeModelView(string message);
        /// <summary>
        /// Processes the leave type view information.
        /// </summary>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        ILeaveTypeModelView ProcessLeaveTypeViewInfo(ILeaveTypeModelView leaveTypeInfo);
        /// <summary>
        /// Gets the leave request model view.
        /// </summary>
        /// <param name="processingMesaage">The processing mesaage.</param>
        /// <returns></returns>
        ILeaveRequestViewModel GetLeaveRequestModelView(string processingMesaage);
        /// <summary>
        /// Processes the leave request view information.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        ILeaveRequestViewModel ProcessLeaveRequestViewInfo(ILeaveRequestViewModel leaveRequestInfo);
        /// <summary>
        /// Gets the leave request listl view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestListView GetLeaveRequestListlView(string message);
        /// <summary>
        /// Gets the leave request details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ILeaveRequestModel GetLeaveRequestDetails(int id);
        /// <summary>
        /// Gets the leave approval hr update view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="leaveId">The leave identifier.</param>
        /// <returns></returns>
        ILeaveHrUpdateView GetLeaveApprovalHrUpdateView(string processingMessage, int leaveId);
        /// <summary>
        /// Gets the leave approval supervisor update view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="leaveId">The leave identifier.</param>
        /// <returns></returns>
        ILeaveSupervisorUpdateView GetLeaveApprovalSupervisorUpdateView(string processingMessage, int leaveId);
        /// <summary>
        /// Processes the leave approval hr update.
        /// </summary>
        /// <param name="leaveHrUpdateView">The leave hr update view.</param>
        /// <param name="leaveId">The leave identifier.</param>
        /// <returns></returns>
        string ProcessLeaveApprovalHRUpdate(ILeaveHrUpdateView leaveHrUpdateView, int leaveId);
        /// <summary>
        /// Processes the leave approval supervisor update.
        /// </summary>
        /// <param name="leaveSupervisorUpdateView">The leave supervisor update view.</param>
        /// <param name="leaveId">The leave identifier.</param>
        /// <returns></returns>
        string ProcessLeaveApprovalSupervisorUpdate(ILeaveSupervisorUpdateView leaveSupervisorUpdateView, int leaveId);
    }
}
