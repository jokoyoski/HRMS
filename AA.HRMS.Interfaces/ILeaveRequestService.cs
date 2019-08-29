using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveRequestService
    {
        // List views
        ILeaveRequestListView GetLeaveRequestListViewForEmployee(string message);
        /// <summary>
        /// Gets the leave request ListView for employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestListView GetLeaveRequestListViewForEmployee(int employeeId, string message);
        /// <summary>
        /// Gets the leave request ListView for hr admin.
        /// </summary>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestListView GetLeaveRequestListViewForHRAdmin(int leaveStatusId, string message);
        /// <summary>
        /// Gets the leave request ListView for supervisor.
        /// </summary>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestListView GetLeaveRequestListViewForSupervisor(int leaveStatusId, string message);

        // List views overloads
        ILeaveRequestListView GetLeaveRequestListViewForEmployee(int employeeId, int leaveStatusId, string message);
        /// <summary>
        /// Gets the leave request ListView for hr admin.
        /// </summary>
        /// <param name="hrUserId">The hr user identifier.</param>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestListView GetLeaveRequestListViewForHRAdmin(int hrUserId, int leaveStatusId, string message);
        /// <summary>
        /// Gets the leave request ListView for supervisor.
        /// </summary>
        /// <param name="supervisorId">The supervisor identifier.</param>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestListView GetLeaveRequestListViewForSupervisor(int supervisorId, int leaveStatusId, string message);

        // Create, edit and update views
        ILeaveRequestViewModel GetLeaveRequestCreateView(string message);
        /// <summary>
        /// Gets the leave employee request create view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestViewModel GetLeaveRequestCreateViewForHR(int employeeId, string message);
        /// <summary>
        /// Gets the selected leave request view.
        /// </summary>
        /// <param name="leaveRequestId">The leave request identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestViewModel GetSelectedLeaveRequestView(int leaveRequestId, string message);
        /// <summary>
        /// Gets the leave request update view.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ILeaveRequestViewModel GetLeaveRequestUpdateView(ILeaveRequestViewModel leaveRequestInfo, string message);

        // processing...
        string ProcessLeaveRequestCreate(ILeaveRequestViewModel leaveRequestInfo);
        /// <summary>
        /// Processes the leave request approval status change.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <param name="hrUserId">The hr user identifier.</param>
        /// <param name="supervisorId">The supervisor identifier.</param>
        /// <returns></returns>
        string ProcessLeaveRequestApprovalStatusChange(ILeaveRequestViewModel leaveRequestInfo, int hrUserId = -1, int supervisorId = -1);
        /// <summary>
        /// Processes the leave request approval status change hr.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        string ProcessLeaveRequestApprovalStatusChangeHr(ILeaveRequestViewModel leaveRequestInfo);
        /// <summary>
        /// Processes the leave request approval status change supervisor.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        string ProcessLeaveRequestApprovalStatusChangeSupervisor(ILeaveRequestViewModel leaveRequestInfo);

        int GetDurationByLeaveType(int leaveTypeId); 
    }
}
