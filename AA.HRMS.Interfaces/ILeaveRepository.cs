using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveRepository
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
        /// Gets the pending leave request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ILeaveRequestModel> GetPendingLeaveRequestByCompanyId(int companyId);

        /// <summary>
        /// Gets the leave request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ILeaveRequestModel> GetLeaveRequestByCompanyId(int companyId);

        /// <summary>
        /// Saves the leave request information.
        /// </summary>
        /// <param name="leaveTypeModelInfo">The leave type model information.</param>
        /// <returns></returns>
        string SaveLeaveRequestInfo(ILeaveRequestViewModel leaveTypeModelInfo);

        string UpdateLeaveRequestInfo(ILeaveRequestViewModel leaveRequestInfo);

        ILeaveType GetLeaveTypeById(int leaveTypeId);

        ILeaveType GetLeaveTypeByName(string leaveTypeName, int companyId);

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
        /// Gets the leave requests made by a particular employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<ILeaveRequestModel> GetLeaveRequestByEmployeeId(int employeeId);

        IList<ILeaveRequestModel> GetLeaveRequestByEmployeeId(int companyId, int employeeId);

        ILeaveRequestModel GetLatestLeaveRequestByEmployeeId(int employeeId);

        /// <summary>
        /// Gets the list of leave requests made by employees in just the parent company of the HR admin
        /// </summary>
        /// <param name="hrId">The hr identifier.</param>
        /// <returns></returns>
        IList<ILeaveRequestModel> GetLeaveRequestByHrAdminId(int hrId, int companyId);

        IList<ILeaveRequestModel> GetLeaveRequestByEmployeeSupervisorId(int supervisorId);

        /// <summary>
        /// Gets the list of leave requests made by employees in both the parent company and child companies of an HR admin
        /// </summary>
        /// <param name="hrId">The hr identifier.</param>
        /// <returns></returns>
        IList<ILeaveRequestModel> GetLeaveRequestByHrAdminIdWithChildCompanies(int hrId);

        /// <summary>
        /// Gets the leave status list.
        /// </summary>
        /// <returns></returns>
        IList<ILeaveStatus> GetLeaveStatusList();

        ILeaveStatus GetLeaveStatusByName(string statusName);

        ILeaveStatus GetLeaveStatusById(int leaveStatusId);

    }
}
